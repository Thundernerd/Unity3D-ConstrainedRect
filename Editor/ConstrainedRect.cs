using UnityEngine;

namespace TNRD.Constraints
{
    public class ConstrainedRect
    {
        private readonly Rect parent;

        public Constraint Top { get; }
        public Constraint Bottom { get; }
        public Constraint Left { get; }
        public Constraint Right { get; }
        public Constraint Width { get; }
        public Constraint Height { get; }

        public ConstrainedRect(Rect parent)
        {
            this.parent = parent;

            Top = new Constraint(this, false);
            Bottom = new Constraint(this, true);
            Left = new Constraint(this, false);
            Right = new Constraint(this, true);
            Width = new Constraint(this, false);
            Height = new Constraint(this, false);
        }

        public Rect Relative(float value)
        {
            return Relative(value, value, value, value);
        }

        public Rect Relative(float left, float top, float right, float bottom)
        {
            return Left.Relative(left)
                .Top.Relative(top)
                .Right.Relative(right)
                .Bottom.Relative(bottom)
                .ToRect();
        }

        public Rect ToRect()
        {
            var left = Left.Apply(parent.xMin);
            var top = Top.Apply(parent.yMin);
            var width = Width.IsSet ? Width.Apply(parent.width) : CalculateWidth();
            var height = Height.IsSet ? Height.Apply(parent.height) : CalculateHeight();

            return new Rect(left, top, width, height);
        }

        private float CalculateWidth()
        {
            var right = Right.Apply(parent.xMax);
            var left = Left.Apply(parent.xMin);
            return right - left;
        }

        private float CalculateHeight()
        {
            var bottom = Bottom.Apply(parent.yMax);
            var top = Top.Apply(parent.yMin);
            return bottom - top;
        }
    }
}