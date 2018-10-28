using System.IO;
using UnityEditor;
using UnityEngine;
using z3nth10n.EditorUtils;

namespace UnityGif.Editor
{
    [CustomPropertyDrawer(typeof(UniGif.GifFile))]
    public class UniGifFileEditor : PropertyDrawer
    {
        private GifFileEditor gif;

        private Texture texture;

        //private float totalHeight;

        private xEditorGUI xUI;

        private bool isFoldout;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (Application.isPlaying)
            {
                EditorGUI.HelpBox(position, "Inspector isn't showed while playing!", MessageType.Warning);

                position.y += 25;

                base.OnGUI(position, property, label);
            }

            if (xUI == null)
                xUI = new xEditorGUI();

            xUI.ResetPosition(position);

            EditorUtility.SetDirty(property.serializedObject.targetObject);

            string path = property.FindPropertyRelative("path").stringValue;

            EditorGUI.BeginProperty(position, label, property);

            if (!string.IsNullOrEmpty(path))
            {
                isFoldout = xUI.Foldout(isFoldout, "Display GIF");

                if (isFoldout)
                {
                    xUI.VerticalSpace(10);

                    if (gif == null)
                        gif = new GifFileEditor(File.ReadAllBytes(path));

                    gif.DrawFromEditor(xUI.GetRect(), xUI);

                    // xUI.VerticalSpace(10);

                    string _label = string.Format("Current Loaded Gif Path: {0}", path.Replace(Application.dataPath + "/", ""));
                    GUI.Label(xUI.DefaultLabelStyle(_label), _label);

                    // xUI.VerticalSpace(10);
                }
            }

            string _label1 = "Set Gif File Path";
            if (GUI.Button(xUI.DefaultButtonStyle(_label1), _label1))
                property.FindPropertyRelative("path").stringValue = EditorUtility.OpenFilePanel("Search for gif", Application.dataPath, "gif");

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (!Application.isPlaying)
                return xUI != null ? xUI.GetEditorHeight() : 0;
            else
                return base.GetPropertyHeight(property, label);
        }
    }
}