using UnityEditor;
using UnityEngine;

namespace TNRD.Constraints
{
    public static class Constrain
    {
        public static ConstrainedRect To(EditorWindow editorWindow)
        {
            return To(new Rect(Vector2.zero, editorWindow.position.size));
        }

        public static ConstrainedRect To(Rect rect)
        {
            return new ConstrainedRect(rect);
        }
    }
}