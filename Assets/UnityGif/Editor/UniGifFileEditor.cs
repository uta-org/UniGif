using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Extensions;
using UnityEngine.Global.IMGUI;
using UnityEngine.UI.Effects;
using Object = UnityEngine.Object;
using RectHelper = UnityEngine.Extensions.RectHelper.RectWrapper;

namespace UnityGif.Editor
{
    /// <summary>
    ///  A custom drawer for Gif File
    /// </summary>
    /// <seealso cref="PropertyDrawer" />
    [CustomPropertyDrawer(typeof(UniGif.GifFile))]
    public class UniGifFileEditor : PropertyDrawer
    {
        /// <summary>
        /// The texture to draw
        /// </summary>
        private Texture texture;

        /// <summary>
        /// The rect helper
        /// </summary>
        private RectHelper r;

        /// <summary>
        /// Is fould out?
        /// </summary>
        private bool isFoldout;

        /// <summary>
        /// Is a valid path?
        /// </summary>
        private bool validPath;

        /// <summary>
        /// Is UI loaded?
        /// </summary>
        private bool isUILoaded;

        /// <summary>
        /// Has execution an exception
        /// </summary>
        private bool hasException => exception != null;

        /// <summary>
        /// The exception
        /// </summary>
        private Exception exception;

        /// <summary>
        /// Height when there isn't any content
        /// </summary>
        private float? noContentHeight;

        /// <summary>
        /// The first frame
        /// </summary>
        private Texture2D m_firstFrame;

        /// <summary>
        /// The final height
        /// </summary>
        private float? m_finalHeight;

        /// <summary>
        /// The box background
        /// </summary>
        private Texture2D m_boxBackground;

        /// <summary>
        /// The draw once
        /// </summary>
        private bool m_drawOnce;

        /// <summary>
        /// Called when [GUI].
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="property">The property.</param>
        /// <param name="label">The label.</param>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            const float helpBoxSize = 25f,
                        lateralInspectorPadding = 15f;

            float finalWidth = EditorGUIUtility.currentViewWidth - lateralInspectorPadding;

            var declaringType = fieldInfo.DeclaringType;

            if (!declaringType.BaseType.FullName.Contains("MonoSingleton"))
            {
                EditorGUI.HelpBox(position, "Declaring type of this field is not a MonoSingleton.", MessageType.Error);
                noContentHeight = helpBoxSize;
                return;
            }

            if (!declaringType.IsExecutingInEditMode())
                EditorGUI.HelpBox(position,
                    "Declared MonoBehaviour needs to have [ExecuteInEditMode] attribute declared in order to view the Gif.",
                    MessageType.Warning);

            if (hasException)
            {
                var content = new GUIContent(exception.ToString());

                float helpBoxHeight = EditorStyles.helpBox.CalcHeight(content, finalWidth);

                EditorGUI.HelpBox(position, content.text, MessageType.Error);
                position.y += helpBoxHeight;

                noContentHeight = helpBoxHeight;

                // TODO: Add button to reload assemblies

                // Exit UI
                return;
            }

            try
            {
                if (!m_drawOnce)
                {
                    m_boxBackground = new Color32(33, 33, 33, 128).ToTexture();
                    m_drawOnce = true;
                }

                if (m_finalHeight.HasValue)
                {
                    GUI.Box(
                        new Rect(position.position, new Vector2(finalWidth - 10, m_finalHeight.Value)),
                        string.Empty,
                        new GUIStyle("box") { normal = new GUIStyleState() { background = m_boxBackground } });
                }

                EditorGUI.BeginProperty(position, label, property);
                {
                    if (Application.isPlaying)
                    {
                        EditorGUI.HelpBox(position, "Inspector isn't showed while playing!", MessageType.Warning);
                        position.y += helpBoxSize;

                        noContentHeight = helpBoxSize;

                        // Exit UI
                        return;
                    }

                    var gif = fieldInfo.GetValue(property.serializedObject.targetObject) as UniGif.GifFile;

                    EditorUtility.SetDirty(property.serializedObject.targetObject);

                    const float defHeight = 16f;

                    r = new RectHelper(position);

                    var monoProp = property.FindPropertyRelative("mono");

                    if (monoProp.objectReferenceValue == null)
                    {
                        monoProp.objectReferenceValue = (Object)declaringType.GetInstanceFromSingleton();
                    }

                    var pathProp = property.FindPropertyRelative("path");
                    string path = pathProp.stringValue;

                    // Sloppy patch
                    r.VerticalSpace(-15f);

                    const float texSize = 64f;

                    var buttonRect = r.NextHeight(texSize);
                    var _labelRect = buttonRect.RestLeft(20);
                    var _boxRect = _labelRect.RestLeft(20);

                    var labelContent = new GUIContent($"<b>GIF:</b> {fieldInfo.Name}");
                    float labelWidth = GUI.skin.label.CalcSize(labelContent).x;

                    GUI.Label(_labelRect.ForceWidth(labelWidth).RestTop(defHeight + 5), labelContent, GlobalGUIStyle.WithCenteredRichText());
                    GUI.Box(_boxRect.ForceWidth(texSize).SumLeft(labelWidth + 5).RestTop(texSize - (defHeight + 5)), m_firstFrame);

                    if (GUI.Button(_boxRect.ForceBoth(defHeight * 2, defHeight).SumLeft(labelWidth + texSize + 10).SumTop(5), "..."))
                    {
                        string gifPath;
                        do
                        {
                            gifPath = EditorUtility.OpenFilePanel("Search for gif", string.IsNullOrEmpty(path) ? Application.dataPath : path, "gif");
                            pathProp.stringValue = gifPath;

                            validPath = CheckValidGif(path);

                            if (string.IsNullOrEmpty(path))
                            {
                                break;
                            }
                        }
                        while (!validPath);

                        if (validPath && path != gifPath)
                        {
                            // Do something when the property changes
                            gif.UpdateFromPath(gifPath, this);

                            SetFirstFrame(gif);
                        }
                    }

                    r.VerticalSpace(5);

                    var foldoutRect = r.GetNextHeight(defHeight).SumLeft(15f);
                    if (Event.current.type == EventType.MouseUp && foldoutRect.Contains(Event.current.mousePosition))
                    {
                        isFoldout = !isFoldout;
                        GUI.changed = true;
                        Event.current.Use();
                    }

                    if (validPath)
                    {
                        isFoldout = EditorGUI.Foldout(foldoutRect, isFoldout, "Display GIF");
                        property.isExpanded = isFoldout;

                        if (property.isExpanded)
                        {
                            const float vertSpace = 40f,
                                        vertFix = -15f;

                            r.VerticalSpace(vertSpace);
                            gif.Draw(r);

                            var withCenteredRichText = GlobalGUIStyle.WithCenteredRichText();

                            // Fixed: Uneccesary height appears after the gif
                            Rect labelRect = r.NextHeight(defHeight),
                                 marqueeRect = r.NextHeight(defHeight);

                            // Sloppy patch
                            labelRect.y += vertFix;
                            marqueeRect.y += vertFix;

                            GUI.Label(labelRect, "<b>Current Loaded Gif Path</b>", withCenteredRichText);
                            MarqueeEffect.MarqueeLabelOnHover(marqueeRect, $"{path.Replace(Application.dataPath + "/", "")}");

                            r.VerticalSpace(vertFix);
                        }
                        else
                        {
                            r.VerticalSpace(15);
                        }

                        SetFirstFrame(gif);
                    }

                    OnceUILoaded(property, path, gif);
                }
                EditorGUI.EndProperty();

                m_finalHeight = r.CurrentHeight;
            }
            catch (Exception ex)
            {
                exception = ex;
                Debug.LogException(ex);
            }
        }

        private void SetFirstFrame(UniGif.GifFile gif)
        {
            if (m_firstFrame == null)
            {
                m_firstFrame = gif.GetFirstFrame();
            }
        }

        /// <summary>
        /// Checks the valid GIF.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        private static bool CheckValidGif(string path)
        {
            return !string.IsNullOrEmpty(path)
                && !path.IsDirectory()
                && File.Exists(path)
                && Path.GetExtension(path).ToLowerInvariant() == ".gif";
        }

        /// <summary>
        /// Gets the height of the property.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <param name="label">The label.</param>
        /// <returns></returns>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (r != null)
            {
                return r.CurrentHeight;
            }

            if (noContentHeight.HasValue)
            {
                return noContentHeight.Value;
            }

            return 18;
        }

        /// <summary>
        /// Called when [UI loaded].
        /// </summary>
        /// <param name="objs">The objs.</param>
        private void OnceUILoaded(params object[] objs)
        {
            if (objs.Length == 0)
            {
                return;
            }

            if (!isUILoaded)
            {
                // FIX: This is called any time when the object is selected... So Gif will be loaded all the times that this object is reselected
                // Debug.Log("Loading gif UI (property drawer)!");

                // Fixed: If any exception occurs this will not continue executing
                isUILoaded = true;

                SerializedProperty property = objs[0] as SerializedProperty;
                string path = (string)objs[1];
                UniGif.GifFile gif = objs[2] as UniGif.GifFile;

                isFoldout = property.isExpanded;
                validPath = CheckValidGif(path);

                if (validPath)
                {
                    gif.UpdateFromPath(path, this);
                }
            }
        }
    }
}