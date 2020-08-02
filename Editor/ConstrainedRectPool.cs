using System.Collections.Generic;
using UnityEngine;

namespace TNRD.Constraints
{
    internal static class ConstrainedRectPool
    {
        private static List<ConstrainedRect> available = new List<ConstrainedRect>();

        public static ConstrainedRect Create(Rect to)
        {
            if (available.Count == 0)
            {
                return CreateNew(to);
            }

            var constrainedRect = available[0];
            available.Remove(constrainedRect);
            constrainedRect.Reset(to);
            return constrainedRect;
        }

        private static ConstrainedRect CreateNew(Rect to)
        {
            var constrainedRect = new ConstrainedRect(to);
            return constrainedRect;
        }

        public static void Return(ConstrainedRect constrainedRect)
        {
            available.Add(constrainedRect);
        }
    }
}
