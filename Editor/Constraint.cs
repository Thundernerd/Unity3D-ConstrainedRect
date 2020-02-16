using System;

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
        private ConstrainMode mode;
        private bool negateValue;
        private float value;

        private float Value => negateValue ? -value : value;

        public bool IsSet => mode != ConstrainMode.NotSet;

        public Constraint(ConstrainedRect parent, bool negateValue)
        {
            this.parent = parent;
            this.negateValue = negateValue;
        }

        public ConstrainedRect Relative(float value)
        {
            mode = ConstrainMode.Relative;
            this.value = value;
            return parent;
        }

        public ConstrainedRect Absolute(float value)
        {
            mode = ConstrainMode.Absolute;
            this.value = value;
            return parent;
        }

        public ConstrainedRect Percentage(float value)
        {
            mode = ConstrainMode.Percentage;
            this.value = value;
            return parent;
        }

        internal float Apply(float value)
        {
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