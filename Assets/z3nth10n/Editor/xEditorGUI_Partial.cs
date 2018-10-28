using UnityEngine;

namespace z3nth10n.EditorUtils
{
    public sealed partial class xEditorGUI
    {
        // private Rect _position;

        //private Rect _position
        //{
        //    get
        //    {
        //        return rect;
        //    }
        //    set
        //    {
        //        rect = value;

        //        if (m_maxHeight < rect.y)
        //            m_maxHeight = rect.y;
        //    }
        //}

        private float m_maxWidth, m_maxHeight;

        //private GUIStyle defaultLabelStyle;

        //public GUIStyle DefaultLabelStyle
        //{
        //    get
        //    {
        //        if (defaultLabelStyle == null)
        //            defaultLabelStyle = GUI.skin.label;

        //        // UpdateHeight(defaultLabelStyle.lineHeight);

        //        return defaultLabelStyle;
        //    }
        //}

        // WIP: Wrapper for all GUI elements

        public Rect DefaultLabelStyle(string label)
        {
            return DefaultLabelStyle(new GUIContent(label));
        }

        public Rect DefaultLabelStyle(GUIContent content)
        {
            Vector2 vector = GUI.skin.label.CalcSize(content);

            _position.y += vector.y;
            _position.width = vector.x;

            return _position;
        }

        public Rect DefaultButtonStyle(string label)
        {
            return DefaultButtonStyle(new GUIContent(label));
        }

        public Rect DefaultButtonStyle(GUIContent content)
        {
            Vector2 vector = GUI.skin.button.CalcSize(content);

            _position.y += vector.y;
            _position.width = vector.x;

            return _position;
        }

        private void UpdateMaxWidth(float width)
        {
            if (m_maxWidth < width)
                m_maxWidth = width;
        }

        private void UpdateMaxHeight(float height)
        {
            if (m_maxHeight < height)
                m_maxHeight = height;
        }

        private void UpdatePosition(GUIStyle style, GUIContent content)
        {
            Vector2 vector = style.CalcSize(content);

            float width = 0, height = 0;

            style.CalcMinMaxWidth(content, out width, out height);

            width = Mathf.Max(width, Screen.width);
            height = style.CalcHeight(content, width);

            IncrementHeight(height);

            _position.width = width;
            _position.height = height;
        }

        public Rect GetRect()
        {
            return _position;
        }

        public void ResetPosition(Rect r)
        {
            _position = r;
        }

        private void IncrementHeight(float height)
        {
            // _position = new Rect(_position.x, _position.y + height, _position.width, _position.height);
            _position.y += height;

            UpdateMaxHeight(_position.y + height);
        }

        public void UpdateHeight(float height)
        {
            IncrementHeight(height);
        }

        public void VerticalSpace(float height)
        {
            IncrementHeight(height);
        }

        public float GetEditorHeight()
        {
            return _position.yMax;
        }
    }
}