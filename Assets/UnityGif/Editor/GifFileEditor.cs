using System.IO;
using UnityEditor;
using UnityEngine;

namespace UnityGif.Editor
{
    [CustomPropertyDrawer(typeof(UniGif.GifFile))]
    public class GifFileEditor : PropertyDrawer
    {
        private UniGif.GifFile gif;

        private Texture texture;

        private float totalHeight;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (Application.isPlaying)
            {
                EditorGUI.HelpBox(position, "Inspector isn't showed while playing!", MessageType.Warning);

                position.y += 25;

                base.OnGUI(position, property, label);
            }

            EditorUtility.SetDirty(property.serializedObject.targetObject);

            string path = property.FindPropertyRelative("path").stringValue;

            EditorGUI.BeginProperty(position, label, property);

            totalHeight = 0;

            position.yMin += 10;
            totalHeight += 10;

            if (!string.IsNullOrEmpty(path))
            {
                if (gif == null)
                    gif = new UniGif.GifFile(File.ReadAllBytes(path));

                float maxWidth = 200f;
                Vector2 v = RedimGif(gif.data, maxWidth);
                Rect gifPos = new Rect(position.position, v);

                gifPos.x += (Screen.width - maxWidth) / 2;

                gif.DrawFromEditor(gifPos);

                position.yMin += v.y + 10;
                totalHeight += v.y + 10;

                GUI.Label(position, string.Format("Current Loaded Gif Path: {0}", path.Replace(Application.dataPath + "/", "")));

                position.yMin += 25;
                totalHeight += 25;
            }

            if (GUI.Button(position, "Set Gif File Path"))
                property.FindPropertyRelative("path").stringValue = EditorUtility.OpenFilePanel("Search for gif", Application.dataPath, "gif");

            EditorGUI.EndProperty();

            totalHeight += 25;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (!Application.isPlaying)
                return totalHeight;
            else
                return base.GetPropertyHeight(property, label);
        }

        private static Vector2 RedimGif(UniGif.WrapperData data, float maxWidth)
        {
            return new Vector2(maxWidth, data.height * (maxWidth / data.width));
        }
    }
}