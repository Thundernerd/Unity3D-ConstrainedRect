using UnityEngine;

namespace TNRD.Constraints
{
    public class ConstrainedRect
    {
        private Rect parent;

        public Constraint Top { get; }
        public Constraint Bottom { get; }
        public Constraint Left { get; }
        public Constraint Right { get; }
        public Constraint Width { get; }
        public Constraint Height { get; }

        private bool centerHorizontally;
        private bool centerVertically;

        private bool isValid;

        internal ConstrainedRect(Rect parent)
        {
            Top = new Constraint(this, false);
            Bottom = new Constraint(this, true);
            Left = new Constraint(this, false);
            Right = new Constraint(this, true);
            Width = new Constraint(this, false);
            Height = new Constraint(this, false);

            Reset(parent);
        }

        internal void Reset(Rect parent)
        {
            this.parent = parent;

            centerHorizontally = false;
            centerVertically = false;

            Top.Reset();
            Bottom.Reset();
            Left.Reset();
            Right.Reset();
            Width.Reset();
            Height.Reset();

            isValid = true;
        }

        public Rect Relative(float value)
        {
            ThrowIfInvalid();
            return Relative(value, value, value, value);
        }

        public Rect Relative(float left, float top, float right, float bottom)
        {
            ThrowIfInvalid();
            return Left.Relative(left)
                .Top.Relative(top)
                .Right.Relative(right)
                .Bottom.Relative(bottom)
                .ToRect();
        }

        public ConstrainedRect CenterHorizontally()
        {
            ThrowIfInvalid();
            centerHorizontally = true;
            return this;
        }

        public ConstrainedRect CenterVertically()
        {
            ThrowIfInvalid();
            centerVertically = true;
            return this;
        }

        public Rect ToRect()
        {
            ThrowIfInvalid();
            float left, top, right, bottom;

            CalculateHorizontal(out left, out right);
            CalculateVertical(out top, out bottom);

            ConstrainedRectPool.Return(this);
            isValid = false;

            return new Rect(left, top, right, bottom);
        }

        private void CalculateHorizontal(out float left, out float right)
        {
            if (centerHorizontally && Width.IsSet)
            {
                float width = Mathf.Abs(Width.RawValue);
                left = parent.center.x - width * 0.5f;
                right = width;

                return;
            }

            if (!Width.IsSet || (Left.IsSet && Right.IsSet))
            {
                left = Left.Apply(parent.xMin);
                right = Right.Apply(parent.xMax) - left;
                return;
            }

            if (Left.IsSet && !Right.IsSet)
            {
                left = Left.Apply(parent.xMin);
                right = Width.Apply(parent.width);
            }
            else if (!Left.IsSet && Right.IsSet)
            {
                right = Width.Apply(parent.width);
                left = Right.Apply(parent.xMax) - right;
            }
            else
            {
                left = Left.Apply(parent.xMin);
                right = Width.Apply(parent.width);
            }
        }

        private void CalculateVertical(out float top, out float bottom)
        {
            if (centerVertically && Height.IsSet)
            {
                float height = Mathf.Abs(Height.RawValue);
                top = parent.center.y - height * 0.5f;
                bottom = height;

                return;
            }

            if (!Height.IsSet || (Top.IsSet && Bottom.IsSet))
            {
                top = Top.Apply(parent.yMin);
                bottom = Bottom.Apply(parent.yMax) - top;
                return;
            }

            if (Top.IsSet && !Bottom.IsSet)
            {
                top = Top.Apply(parent.yMin);
                bottom = Height.Apply(parent.height);
            }
            else if (!Top.IsSet && Bottom.IsSet)
            {
                bottom = Height.Apply(parent.height);
                top = Bottom.Apply(parent.yMax) - bottom;
            }
            else
            {
                top = Top.Apply(parent.yMin);
                bottom = Height.Apply(parent.height);
            }
        }

        internal void ThrowIfInvalid()
        {
            if (isValid)
                return;

            throw new InvalidStateException();
        }
    }
}
