namespace TNRD.Constraints
{
    public class Constraint
    {
        private enum ConstrainMode
        {
            NotSet,
            Relative,
            Absolute,
            Percentage
        }

        private readonly ConstrainedRect parent;
        private readonly bool negateValue;
        private ConstrainMode mode;
        private float value;

        private float Value => negateValue ? -value : value;

        internal float RawValue => value;

        public bool IsSet => mode != ConstrainMode.NotSet;

        internal Constraint(ConstrainedRect parent, bool negateValue)
        {
            this.parent = parent;
            this.negateValue = negateValue;
            Reset();
        }

        internal void Reset()
        {
            mode = ConstrainMode.NotSet;
            value = 0;
        }

        public ConstrainedRect Relative(float value)
        {
            parent.ThrowIfInvalid();
            mode = ConstrainMode.Relative;
            this.value = value;
            return parent;
        }

        public ConstrainedRect Absolute(float value)
        {
            parent.ThrowIfInvalid();
            mode = ConstrainMode.Absolute;
            this.value = value;
            return parent;
        }

        public ConstrainedRect Percentage(float value)
        {
            parent.ThrowIfInvalid();
            mode = ConstrainMode.Percentage;
            this.value = value;
            return parent;
        }

        internal float Apply(float value)
        {
            parent.ThrowIfInvalid();
            switch (mode)
            {
                case ConstrainMode.Relative:
                    return value + Value;
                case ConstrainMode.Absolute:
                    return this.value; // We don't want to negate the value here
                case ConstrainMode.Percentage:
                    return value * Value;
            }

            return value;
        }
    }
}
