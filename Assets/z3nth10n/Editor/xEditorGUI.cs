using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Internal;
using UnityEngine.Rendering;
using UnityEditor;
using Object = UnityEngine.Object;

namespace z3nth10n.EditorUtils
{

    public static class FEditor
    {
        public static void AddOrSet<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
            else
                dictionary[key] = value;
        }
    }


    public class StyleWrapper
    {
        public Dictionary<GUIStyle, GUIContents> listWrapper = new Dictionary<GUIStyle, GUIContents>();

        public StyleWrapper(GUIStyle style, GUIContent label)
        {
            listWrapper.AddOrSet(style, GUIContents.AddOrSet(GUIContents.GetContents(style.name), label));
        }

        public StyleWrapper(GUIStyle style, string label)
        {
            listWrapper.AddOrSet(style, GUIContents.AddOrSet(GUIContents.GetContents(style.name), new GUIContent(label)));
        }
    }

    public class GUIContents
    {
        private static Dictionary<string, GUIContents> dictionary = new Dictionary<string, GUIContents>();

        public List<GUIContent> list = new List<GUIContent>();

        public static GUIContents GetContents(string name)
        {
            if (!dictionary.ContainsKey(name))
                dictionary.Add(name, new GUIContents());

            return dictionary[name];
        }

        public static GUIContents AddOrSet(GUIContents contents, GUIContent content)
        {
            int index = contents.list.IndexOf(content);

            if (index == -1)
                contents.list.Add(content);
            else
                contents.list[index] = content;

            return contents;
        }
    }

    public class xEditorGUI
    {
        private Dictionary<string, StyleWrapper> stylesDict = new Dictionary<string, StyleWrapper>();

        public void FocusTextInControl(string name)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.FocusTextInControl(name);
			*/
        }

        public void BeginDisabledGroup(bool disabled)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.BeginDisabledGroup(disabled);
			*/
        }

        public void DropShadowLabel(Rect position, string text)
        {
            EditorGUI.DropShadowLabel(position, text);
        }

        public void DropShadowLabel(Rect position, GUIContent content)
        {
            EditorGUI.DropShadowLabel(position, content);
        }

        public void DropShadowLabel(Rect position, string text, GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DropShadowLabel"))
                stylesDict.Add("DropShadowLabel", new StyleWrapper(style, text));

            EditorGUI.DropShadowLabel(position, text, style);
        }

        public void DropShadowLabel(Rect position, GUIContent content, GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DropShadowLabel"))
                stylesDict.Add("DropShadowLabel", new StyleWrapper(style, content));

            EditorGUI.DropShadowLabel(position, content, style);
        }

        public bool Toggle(Rect position, bool value)
        {
            if (!stylesDict.ContainsKey("Toggle"))
                stylesDict.Add("Toggle", new StyleWrapper(EditorStyles.toggle, GUIContent.none));

            return EditorGUI.Toggle(position, value);
        }

        public bool Toggle(Rect position, string label, bool value)
        {
            if (!stylesDict.ContainsKey("Toggle"))
                stylesDict.Add("Toggle", new StyleWrapper(EditorStyles.toggle, label));

            return EditorGUI.Toggle(position, label, value);
        }

        public bool Toggle(Rect position, bool value, GUIStyle style)
        {
            if (!stylesDict.ContainsKey("Toggle"))
                stylesDict.Add("Toggle", new StyleWrapper(style, GUIContent.none));

            return EditorGUI.Toggle(position, value, style);
        }

        public bool Toggle(Rect position, string label, bool value, GUIStyle style)
        {
            if (!stylesDict.ContainsKey("Toggle"))
                stylesDict.Add("Toggle", new StyleWrapper(style, label));

            return EditorGUI.Toggle(position, label, value, style);
        }

        public bool Toggle(Rect position, GUIContent label, bool value)
        {
            if (!stylesDict.ContainsKey("Toggle"))
                stylesDict.Add("Toggle", new StyleWrapper(EditorStyles.toggle, label));

            return EditorGUI.Toggle(position, label, value);
        }

        public bool Toggle(Rect position, GUIContent label, bool value, GUIStyle style)
        {
            if (!stylesDict.ContainsKey("Toggle"))
                stylesDict.Add("Toggle", new StyleWrapper(style, label));

            return EditorGUI.Toggle(position, label, value, style);
        }

        public string DoPasswordField(int id, Rect position, string password, GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DoPasswordField"))
                stylesDict.Add("DoPasswordField", new StyleWrapper(style, GUIContent.none));

            return EditorGUI.DoPasswordField(id, position, password, style);
        }

        public string DoPasswordField(int id, Rect position, GUIContent label, string password, GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DoPasswordField"))
                stylesDict.Add("DoPasswordField", new StyleWrapper(style, label));

            return EditorGUI.DoPasswordField(id, position, label, password, style);
        }

        public float Slider(Rect position, float value, float leftValue, float rightValue)
        {
            return EditorGUI.Slider(position, value, leftValue, rightValue);
        }

        public float Slider(Rect position, string label, float value, float leftValue, float rightValue)
        {
            return EditorGUI.Slider(position, label, value, leftValue, rightValue);
        }

        public float Slider(Rect position, GUIContent label, float value, float leftValue, float rightValue)
        {
            return EditorGUI.Slider(position, label, value, leftValue, rightValue);
        }

        public void Slider(Rect position, SerializedProperty property, float leftValue, float rightValue)
        {
            EditorGUI.Slider(position, property, leftValue, rightValue);
        }

        public void Slider(Rect position, SerializedProperty property, float leftValue, float rightValue, string label)
        {
            EditorGUI.Slider(position, property, leftValue, rightValue, label);
        }

        public void Slider(Rect position, SerializedProperty property, float leftValue, float rightValue, GUIContent label)
        {
            EditorGUI.Slider(position, property, leftValue, rightValue, label);
        }

        public int IntSlider(Rect position, int value, int leftValue, int rightValue)
        {
            return EditorGUI.IntSlider(position, value, leftValue, rightValue);
        }

        public int IntSlider(Rect position, string label, int value, int leftValue, int rightValue)
        {
            return EditorGUI.IntSlider(position, label, value, leftValue, rightValue);
        }

        public int IntSlider(Rect position, GUIContent label, int value, int leftValue, int rightValue)
        {
            return EditorGUI.IntSlider(position, label, value, leftValue, rightValue);
        }

        public void IntSlider(Rect position, SerializedProperty property, int leftValue, int rightValue)
        {
            EditorGUI.IntSlider(position, property, leftValue, rightValue);
        }

        public void IntSlider(Rect position, SerializedProperty property, int leftValue, int rightValue, string label)
        {
            EditorGUI.IntSlider(position, property, leftValue, rightValue, label);
        }

        public void IntSlider(Rect position, SerializedProperty property, int leftValue, int rightValue, GUIContent label)
        {
            EditorGUI.IntSlider(position, property, leftValue, rightValue, label);
        }

        public void MinMaxSlider(GUIContent label, Rect position, ref float minValue, ref float maxValue, float minLimit, float maxLimit)
        {
            EditorGUI.MinMaxSlider(label, position, ref minValue, ref maxValue, minLimit, maxLimit);
        }

        public void MinMaxSlider(Rect position, string label, ref float minValue, ref float maxValue, float minLimit, float maxLimit)
        {
            EditorGUI.MinMaxSlider(position, label, ref minValue, ref maxValue, minLimit, maxLimit);
        }

        public void MinMaxSlider(Rect position, GUIContent label, ref float minValue, ref float maxValue, float minLimit, float maxLimit)
        {
            EditorGUI.MinMaxSlider(position, label, ref minValue, ref maxValue, minLimit, maxLimit);
        }

        public void MinMaxSlider(Rect position, ref float minValue, ref float maxValue, float minLimit, float maxLimit)
        {
            EditorGUI.MinMaxSlider(position, ref minValue, ref maxValue, minLimit, maxLimit);
        }

        public int GetSelectedValueForControl(int controlID, int selected)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.GetSelectedValueForControl(controlID, selected);
			*/
        }

        public Enum EnumFlagsField(Rect position, Enum enumValue)
        {
            return EditorGUI.EnumFlagsField(position, enumValue);
        }

        public Enum EnumFlagsField(Rect position, Enum enumValue, GUIStyle style)
        {
            if (!stylesDict.ContainsKey("EnumFlagsField"))
                stylesDict.Add("EnumFlagsField", new StyleWrapper(style, GUIContent.none));

            return EditorGUI.EnumFlagsField(position, enumValue, style);
        }

        public Enum EnumFlagsField(Rect position, string label, Enum enumValue)
        {
            return EditorGUI.EnumFlagsField(position, label, enumValue);
        }

        public Enum EnumFlagsField(Rect position, string label, Enum enumValue, GUIStyle style)
        {
            if (!stylesDict.ContainsKey("EnumFlagsField"))
                stylesDict.Add("EnumFlagsField", new StyleWrapper(style, label));

            return EditorGUI.EnumFlagsField(position, label, enumValue, style);
        }

        public Enum EnumFlagsField(Rect position, GUIContent label, Enum enumValue)
        {
            return EditorGUI.EnumFlagsField(position, label, enumValue);
        }

        public Enum EnumFlagsField(Rect position, GUIContent label, Enum enumValue, GUIStyle style)
        {
            if (!stylesDict.ContainsKey("EnumFlagsField"))
                stylesDict.Add("EnumFlagsField", new StyleWrapper(style, label));

            return EditorGUI.EnumFlagsField(position, label, enumValue, style);
        }

        public Enum EnumFlagsField(Rect position, GUIContent label, Enum enumValue, [DefaultValue("false")] bool includeObsolete, [DefaultValue("null")] GUIStyle style = null)
        {
            throw new Exception("Methods with optional attributed params aren't implemented yet!");
            /*
			if(!stylesDict.ContainsKey("EnumFlagsField"))
				stylesDict.Add("EnumFlagsField", new StyleWrapper(style, label));

			return EditorGUI.EnumFlagsField(position, label, enumValue, includeObsolete, style);
			*/
        }

        public void ObjectField(Rect position, SerializedProperty property)
        {
            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, GUIContent.none));

            EditorGUI.ObjectField(position, property);
        }

        public void ObjectField(Rect position, SerializedProperty property, GUIContent label)
        {
            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

            EditorGUI.ObjectField(position, property, label);
        }

        public void ObjectField(Rect position, SerializedProperty property, Type objType)
        {
            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, GUIContent.none));

            EditorGUI.ObjectField(position, property, objType);
        }

        public void ObjectField(Rect position, SerializedProperty property, Type objType, GUIContent label)
        {
            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

            EditorGUI.ObjectField(position, property, objType, label);
        }

        public Object ObjectField(Rect position, Object obj, Type objType, bool allowSceneObjects)
        {
            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, GUIContent.none));

            return EditorGUI.ObjectField(position, obj, objType, allowSceneObjects);
        }

        public Object ObjectField(Rect position, Object obj, Type objType)
        {
            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, GUIContent.none));

            return EditorGUI.ObjectField(position, obj, objType);
        }

        public Object ObjectField(Rect position, string label, Object obj, Type objType, bool allowSceneObjects)
        {
            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

            return EditorGUI.ObjectField(position, label, obj, objType, allowSceneObjects);
        }

        public Object ObjectField(Rect position, string label, Object obj, Type objType)
        {
            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

            return EditorGUI.ObjectField(position, label, obj, objType);
        }

        public Object ObjectField(Rect position, GUIContent label, Object obj, Type objType, bool allowSceneObjects)
        {
            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

            return EditorGUI.ObjectField(position, label, obj, objType, allowSceneObjects);
        }

        public Object ObjectField(Rect position, GUIContent label, Object obj, Type objType)
        {
            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

            return EditorGUI.ObjectField(position, label, obj, objType);
        }

        public Rect IndentedRect(Rect source)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.IndentedRect(source);
			*/
        }

        public Vector2 Vector2Field(Rect position, string label, Vector2 value)
        {
            return EditorGUI.Vector2Field(position, label, value);
        }

        public Vector2 Vector2Field(Rect position, GUIContent label, Vector2 value)
        {
            return EditorGUI.Vector2Field(position, label, value);
        }

        public Vector3 Vector3Field(Rect position, string label, Vector3 value)
        {
            return EditorGUI.Vector3Field(position, label, value);
        }

        public Vector3 Vector3Field(Rect position, GUIContent label, Vector3 value)
        {
            return EditorGUI.Vector3Field(position, label, value);
        }

        public Vector4 Vector4Field(Rect position, string label, Vector4 value)
        {
            return EditorGUI.Vector4Field(position, label, value);
        }

        public Vector4 Vector4Field(Rect position, GUIContent label, Vector4 value)
        {
            return EditorGUI.Vector4Field(position, label, value);
        }

        public Vector2Int Vector2IntField(Rect position, string label, Vector2Int value)
        {
            return EditorGUI.Vector2IntField(position, label, value);
        }

        public Vector2Int Vector2IntField(Rect position, GUIContent label, Vector2Int value)
        {
            return EditorGUI.Vector2IntField(position, label, value);
        }

        public Vector3Int Vector3IntField(Rect position, string label, Vector3Int value)
        {
            return EditorGUI.Vector3IntField(position, label, value);
        }

        public Vector3Int Vector3IntField(Rect position, GUIContent label, Vector3Int value)
        {
            return EditorGUI.Vector3IntField(position, label, value);
        }

        public Rect RectField(Rect position, Rect value)
        {
            return EditorGUI.RectField(position, value);
        }

        public Rect RectField(Rect position, string label, Rect value)
        {
            return EditorGUI.RectField(position, label, value);
        }

        public Rect RectField(Rect position, GUIContent label, Rect value)
        {
            return EditorGUI.RectField(position, label, value);
        }

        public RectInt RectIntField(Rect position, RectInt value)
        {
            return EditorGUI.RectIntField(position, value);
        }

        public RectInt RectIntField(Rect position, string label, RectInt value)
        {
            return EditorGUI.RectIntField(position, label, value);
        }

        public RectInt RectIntField(Rect position, GUIContent label, RectInt value)
        {
            return EditorGUI.RectIntField(position, label, value);
        }

        public Bounds BoundsField(Rect position, Bounds value)
        {
            return EditorGUI.BoundsField(position, value);
        }

        public Bounds BoundsField(Rect position, string label, Bounds value)
        {
            return EditorGUI.BoundsField(position, label, value);
        }

        public Bounds BoundsField(Rect position, GUIContent label, Bounds value)
        {
            return EditorGUI.BoundsField(position, label, value);
        }

        public BoundsInt BoundsIntField(Rect position, BoundsInt value)
        {
            return EditorGUI.BoundsIntField(position, value);
        }

        public BoundsInt BoundsIntField(Rect position, string label, BoundsInt value)
        {
            return EditorGUI.BoundsIntField(position, label, value);
        }

        public BoundsInt BoundsIntField(Rect position, GUIContent label, BoundsInt value)
        {
            return EditorGUI.BoundsIntField(position, label, value);
        }

        public void MultiFloatField(Rect position, GUIContent label, GUIContent[] subLabels, float[] values)
        {
            EditorGUI.MultiFloatField(position, label, subLabels, values);
        }

        public void MultiFloatField(Rect position, GUIContent[] subLabels, float[] values)
        {
            EditorGUI.MultiFloatField(position, subLabels, values);
        }

        public void MultiIntField(Rect position, GUIContent[] subLabels, int[] values)
        {
            EditorGUI.MultiIntField(position, subLabels, values);
        }

        public void MultiPropertyField(Rect position, GUIContent[] subLabels, SerializedProperty valuesIterator, GUIContent label)
        {
            EditorGUI.MultiPropertyField(position, subLabels, valuesIterator, label);
        }

        public void MultiPropertyField(Rect position, GUIContent[] subLabels, SerializedProperty valuesIterator)
        {
            EditorGUI.MultiPropertyField(position, subLabels, valuesIterator);
        }

        public Color ColorField(Rect position, Color value)
        {
            if (!stylesDict.ContainsKey("ColorField"))
                stylesDict.Add("ColorField", new StyleWrapper(EditorStyles.colorField, GUIContent.none));

            return EditorGUI.ColorField(position, value);
        }

        public Color ColorField(Rect position, string label, Color value)
        {
            if (!stylesDict.ContainsKey("ColorField"))
                stylesDict.Add("ColorField", new StyleWrapper(EditorStyles.colorField, label));

            return EditorGUI.ColorField(position, label, value);
        }

        public Color ColorField(Rect position, GUIContent label, Color value)
        {
            if (!stylesDict.ContainsKey("ColorField"))
                stylesDict.Add("ColorField", new StyleWrapper(EditorStyles.colorField, label));

            return EditorGUI.ColorField(position, label, value);
        }

        public Color ColorField(Rect position, GUIContent label, Color value, bool showEyedropper, bool showAlpha, bool hdr, ColorPickerHDRConfig hdrConfig)
        {
            if (!stylesDict.ContainsKey("ColorField"))
                stylesDict.Add("ColorField", new StyleWrapper(EditorStyles.colorField, label));

            return EditorGUI.ColorField(position, label, value, showEyedropper, showAlpha, hdr, hdrConfig);
        }

        public Color ColorField(Rect position, GUIContent label, Color value, bool showEyedropper, bool showAlpha, bool hdr)
        {
            if (!stylesDict.ContainsKey("ColorField"))
                stylesDict.Add("ColorField", new StyleWrapper(EditorStyles.colorField, label));

            return EditorGUI.ColorField(position, label, value, showEyedropper, showAlpha, hdr);
        }

        public AnimationCurve CurveField(Rect position, AnimationCurve value)
        {
            return EditorGUI.CurveField(position, value);
        }

        public AnimationCurve CurveField(Rect position, string label, AnimationCurve value)
        {
            return EditorGUI.CurveField(position, label, value);
        }

        public AnimationCurve CurveField(Rect position, GUIContent label, AnimationCurve value)
        {
            return EditorGUI.CurveField(position, label, value);
        }

        public AnimationCurve CurveField(Rect position, AnimationCurve value, Color color, Rect ranges)
        {
            return EditorGUI.CurveField(position, value, color, ranges);
        }

        public AnimationCurve CurveField(Rect position, string label, AnimationCurve value, Color color, Rect ranges)
        {
            return EditorGUI.CurveField(position, label, value, color, ranges);
        }

        public AnimationCurve CurveField(Rect position, GUIContent label, AnimationCurve value, Color color, Rect ranges)
        {
            return EditorGUI.CurveField(position, label, value, color, ranges);
        }

        public void CurveField(Rect position, SerializedProperty property, Color color, Rect ranges)
        {
            EditorGUI.CurveField(position, property, color, ranges);
        }

        public void CurveField(Rect position, SerializedProperty property, Color color, Rect ranges, GUIContent label)
        {
            EditorGUI.CurveField(position, property, color, ranges, label);
        }

        public void InspectorTitlebar(Rect position, Object[] targetObjs)
        {
            EditorGUI.InspectorTitlebar(position, targetObjs);
        }

        public bool InspectorTitlebar(Rect position, bool foldout, Object targetObj, bool expandable)
        {
            return EditorGUI.InspectorTitlebar(position, foldout, targetObj, expandable);
        }

        public bool InspectorTitlebar(Rect position, bool foldout, Object[] targetObjs, bool expandable)
        {
            return EditorGUI.InspectorTitlebar(position, foldout, targetObjs, expandable);
        }

        public bool InspectorTitlebar(Rect position, bool foldout, Editor editor)
        {
            throw new Exception("Methods with Editor type in it's parameters aren't implemented yet!");
            /*
			return EditorGUI.InspectorTitlebar(position, foldout, editor);
			*/
        }

        public void ProgressBar(Rect position, float value, string text)
        {
            EditorGUI.ProgressBar(position, value, text);
        }

        public void HelpBox(Rect position, string message, MessageType type)
        {
            if (!stylesDict.ContainsKey("HelpBox"))
                stylesDict.Add("HelpBox", new StyleWrapper(EditorStyles.helpBox, message));

            EditorGUI.HelpBox(position, message, type);
        }

        public Rect PrefixLabel(Rect totalPosition, GUIContent label)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.PrefixLabel(totalPosition, label);
			*/
        }

        public Rect PrefixLabel(Rect totalPosition, GUIContent label, GUIStyle style)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("PrefixLabel"))
				stylesDict.Add("PrefixLabel", new StyleWrapper(style, label));

			return EditorGUI.PrefixLabel(totalPosition, label, style);
			*/
        }

        public Rect PrefixLabel(Rect totalPosition, int id, GUIContent label)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.PrefixLabel(totalPosition, id, label);
			*/
        }

        public Rect PrefixLabel(Rect totalPosition, int id, GUIContent label, GUIStyle style)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("PrefixLabel"))
				stylesDict.Add("PrefixLabel", new StyleWrapper(style, label));

			return EditorGUI.PrefixLabel(totalPosition, id, label, style);
			*/
        }

        public GUIContent BeginProperty(Rect totalPosition, GUIContent label, SerializedProperty property)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.BeginProperty(totalPosition, label, property);
			*/
        }

        public float GetPropertyHeight(SerializedPropertyType type, GUIContent label)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.GetPropertyHeight(type, label);
			*/
        }

        public bool CanCacheInspectorGUI(SerializedProperty property)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.CanCacheInspectorGUI(property);
			*/
        }

        public bool DropdownButton(Rect position, GUIContent content, FocusType focusType)
        {
            return EditorGUI.DropdownButton(position, content, focusType);
        }

        public bool DropdownButton(Rect position, GUIContent content, FocusType focusType, GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DropdownButton"))
                stylesDict.Add("DropdownButton", new StyleWrapper(style, content));

            return EditorGUI.DropdownButton(position, content, focusType, style);
        }

        public void DrawTextureAlpha(Rect position, Texture image, [DefaultValue("ScaleMode.StretchToFill")] ScaleMode scaleMode, [DefaultValue("0")] float imageAspect, [DefaultValue("-1")] float mipLevel)
        {
            EditorGUI.DrawTextureAlpha(position, image, scaleMode, imageAspect, mipLevel);
        }

        public void DrawTextureAlpha(Rect position, Texture image)
        {
            EditorGUI.DrawTextureAlpha(position, image);
        }

        public void DrawTextureAlpha(Rect position, Texture image, ScaleMode scaleMode)
        {
            EditorGUI.DrawTextureAlpha(position, image, scaleMode);
        }

        public void DrawTextureAlpha(Rect position, Texture image, ScaleMode scaleMode, float imageAspect)
        {
            EditorGUI.DrawTextureAlpha(position, image, scaleMode, imageAspect);
        }

        public void DrawTextureTransparent(Rect position, Texture image, [DefaultValue("ScaleMode.StretchToFill")] ScaleMode scaleMode, [DefaultValue("0")] float imageAspect, [DefaultValue("-1")] float mipLevel, [DefaultValue("ColorWriteMask.All")] ColorWriteMask colorWriteMask)
        {
            throw new Exception("This method isn't supported!");
            /*
			EditorGUI.DrawTextureTransparent(position, image, scaleMode, imageAspect, mipLevel, colorWriteMask);
			*/
        }

        public void DrawTextureTransparent(Rect position, Texture image, ScaleMode scaleMode)
        {
            EditorGUI.DrawTextureTransparent(position, image, scaleMode);
        }

        public void DrawTextureTransparent(Rect position, Texture image)
        {
            EditorGUI.DrawTextureTransparent(position, image);
        }

        public void DrawTextureTransparent(Rect position, Texture image, ScaleMode scaleMode, float imageAspect)
        {
            EditorGUI.DrawTextureTransparent(position, image, scaleMode, imageAspect);
        }

        public void DrawTextureTransparent(Rect position, Texture image, ScaleMode scaleMode, float imageAspect, float mipLevel)
        {
            EditorGUI.DrawTextureTransparent(position, image, scaleMode, imageAspect, mipLevel);
        }

        public void DrawPreviewTexture(Rect position, Texture image, Material mat, ScaleMode scaleMode, float imageAspect, float mipLevel)
        {
            EditorGUI.DrawPreviewTexture(position, image, mat, scaleMode, imageAspect, mipLevel);
        }

        public void DrawPreviewTexture(Rect position, Texture image, Material mat, ScaleMode scaleMode, float imageAspect)
        {
            EditorGUI.DrawPreviewTexture(position, image, mat, scaleMode, imageAspect);
        }

        public void DrawPreviewTexture(Rect position, Texture image, Material mat, ScaleMode scaleMode)
        {
            EditorGUI.DrawPreviewTexture(position, image, mat, scaleMode);
        }

        public void DrawPreviewTexture(Rect position, Texture image, Material mat)
        {
            EditorGUI.DrawPreviewTexture(position, image, mat);
        }

        public void DrawPreviewTexture(Rect position, Texture image)
        {
            EditorGUI.DrawPreviewTexture(position, image);
        }

        public void LabelField(Rect position, string label)
        {
            EditorGUI.LabelField(position, label);
        }

        public void LabelField(Rect position, string label, [DefaultValue("EditorStyles.label")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("LabelField"))
                stylesDict.Add("LabelField", new StyleWrapper(style, label));

            EditorGUI.LabelField(position, label, style);
        }

        public void LabelField(Rect position, GUIContent label)
        {
            EditorGUI.LabelField(position, label);
        }

        public void LabelField(Rect position, GUIContent label, [DefaultValue("EditorStyles.label")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("LabelField"))
                stylesDict.Add("LabelField", new StyleWrapper(style, label));

            EditorGUI.LabelField(position, label, style);
        }

        public void LabelField(Rect position, string label, string label2)
        {
            EditorGUI.LabelField(position, label, label2);
        }

        public void LabelField(Rect position, string label, string label2, [DefaultValue("EditorStyles.label")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("LabelField"))
                stylesDict.Add("LabelField", new StyleWrapper(style, label));

            EditorGUI.LabelField(position, label, label2, style);
        }

        public void LabelField(Rect position, GUIContent label, GUIContent label2)
        {
            EditorGUI.LabelField(position, label, label2);
        }

        public void LabelField(Rect position, GUIContent label, GUIContent label2, [DefaultValue("EditorStyles.label")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("LabelField"))
                stylesDict.Add("LabelField", new StyleWrapper(style, label));

            EditorGUI.LabelField(position, label, label2, style);
        }

        public bool ToggleLeft(Rect position, string label, bool value)
        {
            return EditorGUI.ToggleLeft(position, label, value);
        }

        public bool ToggleLeft(Rect position, string label, bool value, [DefaultValue("EditorStyles.label")] GUIStyle labelStyle)
        {
            return EditorGUI.ToggleLeft(position, label, value, labelStyle);
        }

        public bool ToggleLeft(Rect position, GUIContent label, bool value)
        {
            return EditorGUI.ToggleLeft(position, label, value);
        }

        public bool ToggleLeft(Rect position, GUIContent label, bool value, [DefaultValue("EditorStyles.label")] GUIStyle labelStyle)
        {
            return EditorGUI.ToggleLeft(position, label, value, labelStyle);
        }

        public string TextField(Rect position, string text)
        {
            if (!stylesDict.ContainsKey("TextField"))
                stylesDict.Add("TextField", new StyleWrapper(EditorStyles.textField, text));

            return EditorGUI.TextField(position, text);
        }

        public string TextField(Rect position, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("TextField"))
                stylesDict.Add("TextField", new StyleWrapper(style, text));

            return EditorGUI.TextField(position, text, style);
        }

        public string TextField(Rect position, string label, string text)
        {
            if (!stylesDict.ContainsKey("TextField"))
                stylesDict.Add("TextField", new StyleWrapper(EditorStyles.textField, label));

            return EditorGUI.TextField(position, label, text);
        }

        public string TextField(Rect position, string label, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("TextField"))
                stylesDict.Add("TextField", new StyleWrapper(style, label));

            return EditorGUI.TextField(position, label, text, style);
        }

        public string TextField(Rect position, GUIContent label, string text)
        {
            if (!stylesDict.ContainsKey("TextField"))
                stylesDict.Add("TextField", new StyleWrapper(EditorStyles.textField, label));

            return EditorGUI.TextField(position, label, text);
        }

        public string TextField(Rect position, GUIContent label, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("TextField"))
                stylesDict.Add("TextField", new StyleWrapper(style, label));

            return EditorGUI.TextField(position, label, text, style);
        }

        public string DelayedTextField(Rect position, string text)
        {
            return EditorGUI.DelayedTextField(position, text);
        }

        public string DelayedTextField(Rect position, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedTextField"))
                stylesDict.Add("DelayedTextField", new StyleWrapper(style, text));

            return EditorGUI.DelayedTextField(position, text, style);
        }

        public string DelayedTextField(Rect position, string label, string text)
        {
            return EditorGUI.DelayedTextField(position, label, text);
        }

        public string DelayedTextField(Rect position, string label, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedTextField"))
                stylesDict.Add("DelayedTextField", new StyleWrapper(style, label));

            return EditorGUI.DelayedTextField(position, label, text, style);
        }

        public string DelayedTextField(Rect position, GUIContent label, string text)
        {
            return EditorGUI.DelayedTextField(position, label, text);
        }

        public string DelayedTextField(Rect position, GUIContent label, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedTextField"))
                stylesDict.Add("DelayedTextField", new StyleWrapper(style, label));

            return EditorGUI.DelayedTextField(position, label, text, style);
        }

        public void DelayedTextField(Rect position, SerializedProperty property)
        {
            EditorGUI.DelayedTextField(position, property);
        }

        public void DelayedTextField(Rect position, SerializedProperty property, [DefaultValue("null")] GUIContent label)
        {
            EditorGUI.DelayedTextField(position, property, label);
        }

        public string DelayedTextField(Rect position, GUIContent label, int controlId, string text)
        {
            return EditorGUI.DelayedTextField(position, label, controlId, text);
        }

        public string DelayedTextField(Rect position, GUIContent label, int controlId, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedTextField"))
                stylesDict.Add("DelayedTextField", new StyleWrapper(style, label));

            return EditorGUI.DelayedTextField(position, label, controlId, text, style);
        }

        public string TextArea(Rect position, string text)
        {
            if (!stylesDict.ContainsKey("TextArea"))
                stylesDict.Add("TextArea", new StyleWrapper(EditorStyles.textArea, text));

            return EditorGUI.TextArea(position, text);
        }

        public string TextArea(Rect position, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("TextArea"))
                stylesDict.Add("TextArea", new StyleWrapper(style, text));

            return EditorGUI.TextArea(position, text, style);
        }

        public void SelectableLabel(Rect position, string text)
        {
            EditorGUI.SelectableLabel(position, text);
        }

        public void SelectableLabel(Rect position, string text, [DefaultValue("EditorStyles.label")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("SelectableLabel"))
                stylesDict.Add("SelectableLabel", new StyleWrapper(style, text));

            EditorGUI.SelectableLabel(position, text, style);
        }

        public string PasswordField(Rect position, string password)
        {
            return EditorGUI.PasswordField(position, password);
        }

        public string PasswordField(Rect position, string password, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("PasswordField"))
                stylesDict.Add("PasswordField", new StyleWrapper(style, GUIContent.none));

            return EditorGUI.PasswordField(position, password, style);
        }

        public string PasswordField(Rect position, string label, string password)
        {
            return EditorGUI.PasswordField(position, label, password);
        }

        public string PasswordField(Rect position, string label, string password, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("PasswordField"))
                stylesDict.Add("PasswordField", new StyleWrapper(style, label));

            return EditorGUI.PasswordField(position, label, password, style);
        }

        public string PasswordField(Rect position, GUIContent label, string password)
        {
            return EditorGUI.PasswordField(position, label, password);
        }

        public string PasswordField(Rect position, GUIContent label, string password, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("PasswordField"))
                stylesDict.Add("PasswordField", new StyleWrapper(style, label));

            return EditorGUI.PasswordField(position, label, password, style);
        }

        public float FloatField(Rect position, float value)
        {
            return EditorGUI.FloatField(position, value);
        }

        public float FloatField(Rect position, float value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("FloatField"))
                stylesDict.Add("FloatField", new StyleWrapper(style, GUIContent.none));

            return EditorGUI.FloatField(position, value, style);
        }

        public float FloatField(Rect position, string label, float value)
        {
            return EditorGUI.FloatField(position, label, value);
        }

        public float FloatField(Rect position, string label, float value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("FloatField"))
                stylesDict.Add("FloatField", new StyleWrapper(style, label));

            return EditorGUI.FloatField(position, label, value, style);
        }

        public float FloatField(Rect position, GUIContent label, float value)
        {
            return EditorGUI.FloatField(position, label, value);
        }

        public float FloatField(Rect position, GUIContent label, float value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("FloatField"))
                stylesDict.Add("FloatField", new StyleWrapper(style, label));

            return EditorGUI.FloatField(position, label, value, style);
        }

        public float DelayedFloatField(Rect position, float value)
        {
            return EditorGUI.DelayedFloatField(position, value);
        }

        public float DelayedFloatField(Rect position, float value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedFloatField"))
                stylesDict.Add("DelayedFloatField", new StyleWrapper(style, GUIContent.none));

            return EditorGUI.DelayedFloatField(position, value, style);
        }

        public float DelayedFloatField(Rect position, string label, float value)
        {
            return EditorGUI.DelayedFloatField(position, label, value);
        }

        public float DelayedFloatField(Rect position, string label, float value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedFloatField"))
                stylesDict.Add("DelayedFloatField", new StyleWrapper(style, label));

            return EditorGUI.DelayedFloatField(position, label, value, style);
        }

        public float DelayedFloatField(Rect position, GUIContent label, float value)
        {
            return EditorGUI.DelayedFloatField(position, label, value);
        }

        public float DelayedFloatField(Rect position, GUIContent label, float value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedFloatField"))
                stylesDict.Add("DelayedFloatField", new StyleWrapper(style, label));

            return EditorGUI.DelayedFloatField(position, label, value, style);
        }

        public void DelayedFloatField(Rect position, SerializedProperty property)
        {
            EditorGUI.DelayedFloatField(position, property);
        }

        public void DelayedFloatField(Rect position, SerializedProperty property, [DefaultValue("null")] GUIContent label)
        {
            EditorGUI.DelayedFloatField(position, property, label);
        }

        public double DoubleField(Rect position, double value)
        {
            return EditorGUI.DoubleField(position, value);
        }

        public double DoubleField(Rect position, double value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DoubleField"))
                stylesDict.Add("DoubleField", new StyleWrapper(style, GUIContent.none));

            return EditorGUI.DoubleField(position, value, style);
        }

        public double DoubleField(Rect position, string label, double value)
        {
            return EditorGUI.DoubleField(position, label, value);
        }

        public double DoubleField(Rect position, string label, double value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DoubleField"))
                stylesDict.Add("DoubleField", new StyleWrapper(style, label));

            return EditorGUI.DoubleField(position, label, value, style);
        }

        public double DoubleField(Rect position, GUIContent label, double value)
        {
            return EditorGUI.DoubleField(position, label, value);
        }

        public double DoubleField(Rect position, GUIContent label, double value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DoubleField"))
                stylesDict.Add("DoubleField", new StyleWrapper(style, label));

            return EditorGUI.DoubleField(position, label, value, style);
        }

        public double DelayedDoubleField(Rect position, double value)
        {
            return EditorGUI.DelayedDoubleField(position, value);
        }

        public double DelayedDoubleField(Rect position, double value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedDoubleField"))
                stylesDict.Add("DelayedDoubleField", new StyleWrapper(style, GUIContent.none));

            return EditorGUI.DelayedDoubleField(position, value, style);
        }

        public double DelayedDoubleField(Rect position, string label, double value)
        {
            return EditorGUI.DelayedDoubleField(position, label, value);
        }

        public double DelayedDoubleField(Rect position, string label, double value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedDoubleField"))
                stylesDict.Add("DelayedDoubleField", new StyleWrapper(style, label));

            return EditorGUI.DelayedDoubleField(position, label, value, style);
        }

        public double DelayedDoubleField(Rect position, GUIContent label, double value)
        {
            return EditorGUI.DelayedDoubleField(position, label, value);
        }

        public double DelayedDoubleField(Rect position, GUIContent label, double value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedDoubleField"))
                stylesDict.Add("DelayedDoubleField", new StyleWrapper(style, label));

            return EditorGUI.DelayedDoubleField(position, label, value, style);
        }

        public int IntField(Rect position, int value)
        {
            return EditorGUI.IntField(position, value);
        }

        public int IntField(Rect position, int value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("IntField"))
                stylesDict.Add("IntField", new StyleWrapper(style, GUIContent.none));

            return EditorGUI.IntField(position, value, style);
        }

        public int IntField(Rect position, string label, int value)
        {
            return EditorGUI.IntField(position, label, value);
        }

        public int IntField(Rect position, string label, int value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("IntField"))
                stylesDict.Add("IntField", new StyleWrapper(style, label));

            return EditorGUI.IntField(position, label, value, style);
        }

        public int IntField(Rect position, GUIContent label, int value)
        {
            return EditorGUI.IntField(position, label, value);
        }

        public int IntField(Rect position, GUIContent label, int value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("IntField"))
                stylesDict.Add("IntField", new StyleWrapper(style, label));

            return EditorGUI.IntField(position, label, value, style);
        }

        public int DelayedIntField(Rect position, int value)
        {
            return EditorGUI.DelayedIntField(position, value);
        }

        public int DelayedIntField(Rect position, int value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedIntField"))
                stylesDict.Add("DelayedIntField", new StyleWrapper(style, GUIContent.none));

            return EditorGUI.DelayedIntField(position, value, style);
        }

        public int DelayedIntField(Rect position, string label, int value)
        {
            return EditorGUI.DelayedIntField(position, label, value);
        }

        public int DelayedIntField(Rect position, string label, int value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedIntField"))
                stylesDict.Add("DelayedIntField", new StyleWrapper(style, label));

            return EditorGUI.DelayedIntField(position, label, value, style);
        }

        public int DelayedIntField(Rect position, GUIContent label, int value)
        {
            return EditorGUI.DelayedIntField(position, label, value);
        }

        public int DelayedIntField(Rect position, GUIContent label, int value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedIntField"))
                stylesDict.Add("DelayedIntField", new StyleWrapper(style, label));

            return EditorGUI.DelayedIntField(position, label, value, style);
        }

        public void DelayedIntField(Rect position, SerializedProperty property)
        {
            EditorGUI.DelayedIntField(position, property);
        }

        public void DelayedIntField(Rect position, SerializedProperty property, [DefaultValue("null")] GUIContent label)
        {
            EditorGUI.DelayedIntField(position, property, label);
        }

        public long LongField(Rect position, long value)
        {
            return EditorGUI.LongField(position, value);
        }

        public long LongField(Rect position, long value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("LongField"))
                stylesDict.Add("LongField", new StyleWrapper(style, GUIContent.none));

            return EditorGUI.LongField(position, value, style);
        }

        public long LongField(Rect position, string label, long value)
        {
            return EditorGUI.LongField(position, label, value);
        }

        public long LongField(Rect position, string label, long value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("LongField"))
                stylesDict.Add("LongField", new StyleWrapper(style, label));

            return EditorGUI.LongField(position, label, value, style);
        }

        public long LongField(Rect position, GUIContent label, long value)
        {
            return EditorGUI.LongField(position, label, value);
        }

        public long LongField(Rect position, GUIContent label, long value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("LongField"))
                stylesDict.Add("LongField", new StyleWrapper(style, label));

            return EditorGUI.LongField(position, label, value, style);
        }

        public int Popup(Rect position, int selectedIndex, string[] displayedOptions)
        {
            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(EditorStyles.popup, GUIContent.none));

            return EditorGUI.Popup(position, selectedIndex, displayedOptions);
        }

        public int Popup(Rect position, int selectedIndex, string[] displayedOptions, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(style, GUIContent.none));

            return EditorGUI.Popup(position, selectedIndex, displayedOptions, style);
        }

        public int Popup(Rect position, int selectedIndex, GUIContent[] displayedOptions)
        {
            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(EditorStyles.popup, GUIContent.none));

            return EditorGUI.Popup(position, selectedIndex, displayedOptions);
        }

        public int Popup(Rect position, int selectedIndex, GUIContent[] displayedOptions, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(style, GUIContent.none));

            return EditorGUI.Popup(position, selectedIndex, displayedOptions, style);
        }

        public int Popup(Rect position, string label, int selectedIndex, string[] displayedOptions)
        {
            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(EditorStyles.popup, label));

            return EditorGUI.Popup(position, label, selectedIndex, displayedOptions);
        }

        public int Popup(Rect position, string label, int selectedIndex, string[] displayedOptions, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(style, label));

            return EditorGUI.Popup(position, label, selectedIndex, displayedOptions, style);
        }

        public int Popup(Rect position, GUIContent label, int selectedIndex, GUIContent[] displayedOptions)
        {
            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(EditorStyles.popup, label));

            return EditorGUI.Popup(position, label, selectedIndex, displayedOptions);
        }

        public int Popup(Rect position, GUIContent label, int selectedIndex, GUIContent[] displayedOptions, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(style, label));

            return EditorGUI.Popup(position, label, selectedIndex, displayedOptions, style);
        }

        public Enum EnumPopup(Rect position, Enum selected)
        {
            return EditorGUI.EnumPopup(position, selected);
        }

        public Enum EnumPopup(Rect position, Enum selected, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("EnumPopup"))
                stylesDict.Add("EnumPopup", new StyleWrapper(style, GUIContent.none));

            return EditorGUI.EnumPopup(position, selected, style);
        }

        public Enum EnumPopup(Rect position, string label, Enum selected)
        {
            return EditorGUI.EnumPopup(position, label, selected);
        }

        public Enum EnumPopup(Rect position, string label, Enum selected, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("EnumPopup"))
                stylesDict.Add("EnumPopup", new StyleWrapper(style, label));

            return EditorGUI.EnumPopup(position, label, selected, style);
        }

        public Enum EnumPopup(Rect position, GUIContent label, Enum selected)
        {
            return EditorGUI.EnumPopup(position, label, selected);
        }

        public Enum EnumPopup(Rect position, GUIContent label, Enum selected, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("EnumPopup"))
                stylesDict.Add("EnumPopup", new StyleWrapper(style, label));

            return EditorGUI.EnumPopup(position, label, selected, style);
        }

        public Enum EnumPopup(Rect position, GUIContent label, Enum selected, [DefaultValue("null")] Func<Enum, bool> checkEnabled, [DefaultValue("false")] bool includeObsolete = false, [DefaultValue("null")] GUIStyle style = null)
        {
            throw new Exception("Methods with optional attributed params aren't implemented yet!");
            /*
			if(!stylesDict.ContainsKey("EnumPopup"))
				stylesDict.Add("EnumPopup", new StyleWrapper(style, label));

			return EditorGUI.EnumPopup(position, label, selected, checkEnabled, includeObsolete, style);
			*/
        }

        public int IntPopup(Rect position, int selectedValue, string[] displayedOptions, int[] optionValues)
        {
            return EditorGUI.IntPopup(position, selectedValue, displayedOptions, optionValues);
        }

        public int IntPopup(Rect position, int selectedValue, string[] displayedOptions, int[] optionValues, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(style, GUIContent.none));

            return EditorGUI.IntPopup(position, selectedValue, displayedOptions, optionValues, style);
        }

        public int IntPopup(Rect position, int selectedValue, GUIContent[] displayedOptions, int[] optionValues)
        {
            return EditorGUI.IntPopup(position, selectedValue, displayedOptions, optionValues);
        }

        public int IntPopup(Rect position, int selectedValue, GUIContent[] displayedOptions, int[] optionValues, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(style, GUIContent.none));

            return EditorGUI.IntPopup(position, selectedValue, displayedOptions, optionValues, style);
        }

        public int IntPopup(Rect position, GUIContent label, int selectedValue, GUIContent[] displayedOptions, int[] optionValues)
        {
            return EditorGUI.IntPopup(position, label, selectedValue, displayedOptions, optionValues);
        }

        public int IntPopup(Rect position, GUIContent label, int selectedValue, GUIContent[] displayedOptions, int[] optionValues, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(style, label));

            return EditorGUI.IntPopup(position, label, selectedValue, displayedOptions, optionValues, style);
        }

        public void IntPopup(Rect position, SerializedProperty property, GUIContent[] displayedOptions, int[] optionValues)
        {
            EditorGUI.IntPopup(position, property, displayedOptions, optionValues);
        }

        public void IntPopup(Rect position, SerializedProperty property, GUIContent[] displayedOptions, int[] optionValues, [DefaultValue("null")] GUIContent label)
        {
            EditorGUI.IntPopup(position, property, displayedOptions, optionValues, label);
        }

        public int IntPopup(Rect position, string label, int selectedValue, string[] displayedOptions, int[] optionValues)
        {
            return EditorGUI.IntPopup(position, label, selectedValue, displayedOptions, optionValues);
        }

        public int IntPopup(Rect position, string label, int selectedValue, string[] displayedOptions, int[] optionValues, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(style, label));

            return EditorGUI.IntPopup(position, label, selectedValue, displayedOptions, optionValues, style);
        }

        public string TagField(Rect position, string tag)
        {
            return EditorGUI.TagField(position, tag);
        }

        public string TagField(Rect position, string tag, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("TagField"))
                stylesDict.Add("TagField", new StyleWrapper(style, GUIContent.none));

            return EditorGUI.TagField(position, tag, style);
        }

        public string TagField(Rect position, string label, string tag)
        {
            return EditorGUI.TagField(position, label, tag);
        }

        public string TagField(Rect position, string label, string tag, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("TagField"))
                stylesDict.Add("TagField", new StyleWrapper(style, label));

            return EditorGUI.TagField(position, label, tag, style);
        }

        public string TagField(Rect position, GUIContent label, string tag)
        {
            return EditorGUI.TagField(position, label, tag);
        }

        public string TagField(Rect position, GUIContent label, string tag, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("TagField"))
                stylesDict.Add("TagField", new StyleWrapper(style, label));

            return EditorGUI.TagField(position, label, tag, style);
        }

        public int LayerField(Rect position, int layer)
        {
            return EditorGUI.LayerField(position, layer);
        }

        public int LayerField(Rect position, int layer, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("LayerField"))
                stylesDict.Add("LayerField", new StyleWrapper(style, GUIContent.none));

            return EditorGUI.LayerField(position, layer, style);
        }

        public int LayerField(Rect position, string label, int layer)
        {
            return EditorGUI.LayerField(position, label, layer);
        }

        public int LayerField(Rect position, string label, int layer, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("LayerField"))
                stylesDict.Add("LayerField", new StyleWrapper(style, label));

            return EditorGUI.LayerField(position, label, layer, style);
        }

        public int LayerField(Rect position, GUIContent label, int layer)
        {
            return EditorGUI.LayerField(position, label, layer);
        }

        public int LayerField(Rect position, GUIContent label, int layer, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("LayerField"))
                stylesDict.Add("LayerField", new StyleWrapper(style, label));

            return EditorGUI.LayerField(position, label, layer, style);
        }

        public int MaskField(Rect position, GUIContent label, int mask, string[] displayedOptions)
        {
            return EditorGUI.MaskField(position, label, mask, displayedOptions);
        }

        public int MaskField(Rect position, GUIContent label, int mask, string[] displayedOptions, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("MaskField"))
                stylesDict.Add("MaskField", new StyleWrapper(style, label));

            return EditorGUI.MaskField(position, label, mask, displayedOptions, style);
        }

        public int MaskField(Rect position, string label, int mask, string[] displayedOptions)
        {
            return EditorGUI.MaskField(position, label, mask, displayedOptions);
        }

        public int MaskField(Rect position, string label, int mask, string[] displayedOptions, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("MaskField"))
                stylesDict.Add("MaskField", new StyleWrapper(style, label));

            return EditorGUI.MaskField(position, label, mask, displayedOptions, style);
        }

        public int MaskField(Rect position, int mask, string[] displayedOptions)
        {
            return EditorGUI.MaskField(position, mask, displayedOptions);
        }

        public int MaskField(Rect position, int mask, string[] displayedOptions, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("MaskField"))
                stylesDict.Add("MaskField", new StyleWrapper(style, GUIContent.none));

            return EditorGUI.MaskField(position, mask, displayedOptions, style);
        }

        public bool Foldout(Rect position, bool foldout, string content)
        {
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(EditorStyles.foldout, content));

            return EditorGUI.Foldout(position, foldout, content);
        }

        public bool Foldout(Rect position, bool foldout, string content, [DefaultValue("EditorStyles.foldout")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(style, content));

            return EditorGUI.Foldout(position, foldout, content, style);
        }

        public bool Foldout(Rect position, bool foldout, string content, bool toggleOnLabelClick)
        {
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(EditorStyles.foldout, content));

            return EditorGUI.Foldout(position, foldout, content, toggleOnLabelClick);
        }

        public bool Foldout(Rect position, bool foldout, string content, bool toggleOnLabelClick, [DefaultValue("EditorStyles.foldout")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(style, content));

            return EditorGUI.Foldout(position, foldout, content, toggleOnLabelClick, style);
        }

        public bool Foldout(Rect position, bool foldout, GUIContent content)
        {
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(EditorStyles.foldout, content));

            return EditorGUI.Foldout(position, foldout, content);
        }

        public bool Foldout(Rect position, bool foldout, GUIContent content, [DefaultValue("EditorStyles.foldout")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(style, content));

            return EditorGUI.Foldout(position, foldout, content, style);
        }

        public bool Foldout(Rect position, bool foldout, GUIContent content, bool toggleOnLabelClick)
        {
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(EditorStyles.foldout, content));

            return EditorGUI.Foldout(position, foldout, content, toggleOnLabelClick);
        }

        public bool Foldout(Rect position, bool foldout, GUIContent content, bool toggleOnLabelClick, [DefaultValue("EditorStyles.foldout")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(style, content));

            return EditorGUI.Foldout(position, foldout, content, toggleOnLabelClick, style);
        }

        public void HandlePrefixLabel(Rect totalPosition, Rect labelPosition, GUIContent label, int id)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.HandlePrefixLabel(totalPosition, labelPosition, label, id);
			*/
        }

        public void HandlePrefixLabel(Rect totalPosition, Rect labelPosition, GUIContent label)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.HandlePrefixLabel(totalPosition, labelPosition, label);
			*/
        }

        public void HandlePrefixLabel(Rect totalPosition, Rect labelPosition, GUIContent label, [DefaultValue("0")] int id, [DefaultValue("EditorStyles.label")] GUIStyle style)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("HandlePrefixLabel"))
				stylesDict.Add("HandlePrefixLabel", new StyleWrapper(style, label));

			EditorGUI.HandlePrefixLabel(totalPosition, labelPosition, label, id, style);
			*/
        }

        public float GetPropertyHeight(SerializedProperty property, bool includeChildren)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.GetPropertyHeight(property, includeChildren);
			*/
        }

        public float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.GetPropertyHeight(property, label);
			*/
        }

        public float GetPropertyHeight(SerializedProperty property)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.GetPropertyHeight(property);
			*/
        }

        public float GetPropertyHeight(SerializedProperty property, [DefaultValue("null")] GUIContent label, [DefaultValue("true")] bool includeChildren)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.GetPropertyHeight(property, label, includeChildren);
			*/
        }

        public bool PropertyField(Rect position, SerializedProperty property)
        {
            return EditorGUI.PropertyField(position, property);
        }

        public bool PropertyField(Rect position, SerializedProperty property, [DefaultValue("false")] bool includeChildren)
        {
            return EditorGUI.PropertyField(position, property, includeChildren);
        }

        public bool PropertyField(Rect position, SerializedProperty property, GUIContent label)
        {
            return EditorGUI.PropertyField(position, property, label);
        }

        public bool PropertyField(Rect position, SerializedProperty property, GUIContent label, [DefaultValue("false")] bool includeChildren)
        {
            return EditorGUI.PropertyField(position, property, label, includeChildren);
        }

        public bool Foldout(bool foldout, string content)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("Foldout"))
				stylesDict.Add("Foldout", new StyleWrapper(EditorStyles.foldout, content));

			return EditorGUI.Foldout(foldout, content);
			*/
        }

        public bool Foldout(bool foldout, string content, [DefaultValue("EditorStyles.foldout")] GUIStyle style)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("Foldout"))
				stylesDict.Add("Foldout", new StyleWrapper(style, content));

			return EditorGUI.Foldout(foldout, content, style);
			*/
        }

        public bool Foldout(bool foldout, GUIContent content)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("Foldout"))
				stylesDict.Add("Foldout", new StyleWrapper(EditorStyles.foldout, content));

			return EditorGUI.Foldout(foldout, content);
			*/
        }

        public bool Foldout(bool foldout, GUIContent content, [DefaultValue("EditorStyles.foldout")] GUIStyle style)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("Foldout"))
				stylesDict.Add("Foldout", new StyleWrapper(style, content));

			return EditorGUI.Foldout(foldout, content, style);
			*/
        }

        public bool Foldout(bool foldout, string content, bool toggleOnLabelClick)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("Foldout"))
				stylesDict.Add("Foldout", new StyleWrapper(EditorStyles.foldout, content));

			return EditorGUI.Foldout(foldout, content, toggleOnLabelClick);
			*/
        }

        public bool Foldout(bool foldout, string content, bool toggleOnLabelClick, [DefaultValue("EditorStyles.foldout")] GUIStyle style)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("Foldout"))
				stylesDict.Add("Foldout", new StyleWrapper(style, content));

			return EditorGUI.Foldout(foldout, content, toggleOnLabelClick, style);
			*/
        }

        public bool Foldout(bool foldout, GUIContent content, bool toggleOnLabelClick)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("Foldout"))
				stylesDict.Add("Foldout", new StyleWrapper(EditorStyles.foldout, content));

			return EditorGUI.Foldout(foldout, content, toggleOnLabelClick);
			*/
        }

        public bool Foldout(bool foldout, GUIContent content, bool toggleOnLabelClick, [DefaultValue("EditorStyles.foldout")] GUIStyle style)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("Foldout"))
				stylesDict.Add("Foldout", new StyleWrapper(style, content));

			return EditorGUI.Foldout(foldout, content, toggleOnLabelClick, style);
			*/
        }

        public void PrefixLabel(string label)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.PrefixLabel(label);
			*/
        }

        public void PrefixLabel(string label, [DefaultValue("\"Button\"")] GUIStyle followingStyle)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.PrefixLabel(label, followingStyle);
			*/
        }

        public void PrefixLabel(string label, GUIStyle followingStyle, GUIStyle labelStyle)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.PrefixLabel(label, followingStyle, labelStyle);
			*/
        }

        public void PrefixLabel(GUIContent label)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.PrefixLabel(label);
			*/
        }

        public void PrefixLabel(GUIContent label, [DefaultValue("\"Button\"")] GUIStyle followingStyle)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.PrefixLabel(label, followingStyle);
			*/
        }

        public void PrefixLabel(GUIContent label, GUIStyle followingStyle, GUIStyle labelStyle)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.PrefixLabel(label, followingStyle, labelStyle);
			*/
        }

        public void LabelField(string label, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.LabelField(label, options);
			*/
        }

        public void LabelField(string label, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("LabelField"))
				stylesDict.Add("LabelField", new StyleWrapper(style, label));

			EditorGUI.LabelField(label, style, options);
			*/
        }

        public void LabelField(GUIContent label, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.LabelField(label, options);
			*/
        }

        public void LabelField(GUIContent label, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("LabelField"))
				stylesDict.Add("LabelField", new StyleWrapper(style, label));

			EditorGUI.LabelField(label, style, options);
			*/
        }

        public void LabelField(string label, string label2, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.LabelField(label, label2, options);
			*/
        }

        public void LabelField(string label, string label2, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("LabelField"))
				stylesDict.Add("LabelField", new StyleWrapper(style, label));

			EditorGUI.LabelField(label, label2, style, options);
			*/
        }

        public void LabelField(GUIContent label, GUIContent label2, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.LabelField(label, label2, options);
			*/
        }

        public void LabelField(GUIContent label, GUIContent label2, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("LabelField"))
				stylesDict.Add("LabelField", new StyleWrapper(style, label));

			EditorGUI.LabelField(label, label2, style, options);
			*/
        }

        public bool Toggle(bool value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("Toggle"))
				stylesDict.Add("Toggle", new StyleWrapper(EditorStyles.toggle, GUIContent.none));

			return EditorGUI.Toggle(value, options);
			*/
        }

        public bool Toggle(string label, bool value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("Toggle"))
				stylesDict.Add("Toggle", new StyleWrapper(EditorStyles.toggle, label));

			return EditorGUI.Toggle(label, value, options);
			*/
        }

        public bool Toggle(GUIContent label, bool value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("Toggle"))
				stylesDict.Add("Toggle", new StyleWrapper(EditorStyles.toggle, label));

			return EditorGUI.Toggle(label, value, options);
			*/
        }

        public bool Toggle(bool value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("Toggle"))
				stylesDict.Add("Toggle", new StyleWrapper(style, GUIContent.none));

			return EditorGUI.Toggle(value, style, options);
			*/
        }

        public bool Toggle(string label, bool value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("Toggle"))
				stylesDict.Add("Toggle", new StyleWrapper(style, label));

			return EditorGUI.Toggle(label, value, style, options);
			*/
        }

        public bool Toggle(GUIContent label, bool value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("Toggle"))
				stylesDict.Add("Toggle", new StyleWrapper(style, label));

			return EditorGUI.Toggle(label, value, style, options);
			*/
        }

        public bool ToggleLeft(string label, bool value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.ToggleLeft(label, value, options);
			*/
        }

        public bool ToggleLeft(GUIContent label, bool value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.ToggleLeft(label, value, options);
			*/
        }

        public bool ToggleLeft(string label, bool value, GUIStyle labelStyle, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.ToggleLeft(label, value, labelStyle, options);
			*/
        }

        public bool ToggleLeft(GUIContent label, bool value, GUIStyle labelStyle, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.ToggleLeft(label, value, labelStyle, options);
			*/
        }

        public string TextField(string text, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("TextField"))
				stylesDict.Add("TextField", new StyleWrapper(EditorStyles.textField, text));

			return EditorGUI.TextField(text, options);
			*/
        }

        public string TextField(string text, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("TextField"))
				stylesDict.Add("TextField", new StyleWrapper(style, text));

			return EditorGUI.TextField(text, style, options);
			*/
        }

        public string TextField(string label, string text, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("TextField"))
				stylesDict.Add("TextField", new StyleWrapper(EditorStyles.textField, label));

			return EditorGUI.TextField(label, text, options);
			*/
        }

        public string TextField(string label, string text, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("TextField"))
				stylesDict.Add("TextField", new StyleWrapper(style, label));

			return EditorGUI.TextField(label, text, style, options);
			*/
        }

        public string TextField(GUIContent label, string text, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("TextField"))
				stylesDict.Add("TextField", new StyleWrapper(EditorStyles.textField, label));

			return EditorGUI.TextField(label, text, options);
			*/
        }

        public string TextField(GUIContent label, string text, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("TextField"))
				stylesDict.Add("TextField", new StyleWrapper(style, label));

			return EditorGUI.TextField(label, text, style, options);
			*/
        }

        public string DelayedTextField(string text, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.DelayedTextField(text, options);
			*/
        }

        public string DelayedTextField(string text, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("DelayedTextField"))
				stylesDict.Add("DelayedTextField", new StyleWrapper(style, text));

			return EditorGUI.DelayedTextField(text, style, options);
			*/
        }

        public string DelayedTextField(string label, string text, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.DelayedTextField(label, text, options);
			*/
        }

        public string DelayedTextField(string label, string text, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("DelayedTextField"))
				stylesDict.Add("DelayedTextField", new StyleWrapper(style, label));

			return EditorGUI.DelayedTextField(label, text, style, options);
			*/
        }

        public string DelayedTextField(GUIContent label, string text, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.DelayedTextField(label, text, options);
			*/
        }

        public string DelayedTextField(GUIContent label, string text, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("DelayedTextField"))
				stylesDict.Add("DelayedTextField", new StyleWrapper(style, label));

			return EditorGUI.DelayedTextField(label, text, style, options);
			*/
        }

        public void DelayedTextField(SerializedProperty property, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.DelayedTextField(property, options);
			*/
        }

        public void DelayedTextField(SerializedProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.DelayedTextField(property, label, options);
			*/
        }

        public string TextArea(string text, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("TextArea"))
				stylesDict.Add("TextArea", new StyleWrapper(EditorStyles.textArea, text));

			return EditorGUI.TextArea(text, options);
			*/
        }

        public string TextArea(string text, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("TextArea"))
				stylesDict.Add("TextArea", new StyleWrapper(style, text));

			return EditorGUI.TextArea(text, style, options);
			*/
        }

        public void SelectableLabel(string text, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.SelectableLabel(text, options);
			*/
        }

        public void SelectableLabel(string text, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("SelectableLabel"))
				stylesDict.Add("SelectableLabel", new StyleWrapper(style, text));

			EditorGUI.SelectableLabel(text, style, options);
			*/
        }

        public string PasswordField(string password, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.PasswordField(password, options);
			*/
        }

        public string PasswordField(string password, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("PasswordField"))
				stylesDict.Add("PasswordField", new StyleWrapper(style, GUIContent.none));

			return EditorGUI.PasswordField(password, style, options);
			*/
        }

        public string PasswordField(string label, string password, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.PasswordField(label, password, options);
			*/
        }

        public string PasswordField(string label, string password, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("PasswordField"))
				stylesDict.Add("PasswordField", new StyleWrapper(style, label));

			return EditorGUI.PasswordField(label, password, style, options);
			*/
        }

        public string PasswordField(GUIContent label, string password, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.PasswordField(label, password, options);
			*/
        }

        public string PasswordField(GUIContent label, string password, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("PasswordField"))
				stylesDict.Add("PasswordField", new StyleWrapper(style, label));

			return EditorGUI.PasswordField(label, password, style, options);
			*/
        }

        public float FloatField(float value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.FloatField(value, options);
			*/
        }

        public float FloatField(float value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("FloatField"))
				stylesDict.Add("FloatField", new StyleWrapper(style, GUIContent.none));

			return EditorGUI.FloatField(value, style, options);
			*/
        }

        public float FloatField(string label, float value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.FloatField(label, value, options);
			*/
        }

        public float FloatField(string label, float value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("FloatField"))
				stylesDict.Add("FloatField", new StyleWrapper(style, label));

			return EditorGUI.FloatField(label, value, style, options);
			*/
        }

        public float FloatField(GUIContent label, float value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.FloatField(label, value, options);
			*/
        }

        public float FloatField(GUIContent label, float value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("FloatField"))
				stylesDict.Add("FloatField", new StyleWrapper(style, label));

			return EditorGUI.FloatField(label, value, style, options);
			*/
        }

        public float DelayedFloatField(float value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.DelayedFloatField(value, options);
			*/
        }

        public float DelayedFloatField(float value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("DelayedFloatField"))
				stylesDict.Add("DelayedFloatField", new StyleWrapper(style, GUIContent.none));

			return EditorGUI.DelayedFloatField(value, style, options);
			*/
        }

        public float DelayedFloatField(string label, float value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.DelayedFloatField(label, value, options);
			*/
        }

        public float DelayedFloatField(string label, float value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("DelayedFloatField"))
				stylesDict.Add("DelayedFloatField", new StyleWrapper(style, label));

			return EditorGUI.DelayedFloatField(label, value, style, options);
			*/
        }

        public float DelayedFloatField(GUIContent label, float value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.DelayedFloatField(label, value, options);
			*/
        }

        public float DelayedFloatField(GUIContent label, float value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("DelayedFloatField"))
				stylesDict.Add("DelayedFloatField", new StyleWrapper(style, label));

			return EditorGUI.DelayedFloatField(label, value, style, options);
			*/
        }

        public void DelayedFloatField(SerializedProperty property, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.DelayedFloatField(property, options);
			*/
        }

        public void DelayedFloatField(SerializedProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.DelayedFloatField(property, label, options);
			*/
        }

        public double DoubleField(double value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.DoubleField(value, options);
			*/
        }

        public double DoubleField(double value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("DoubleField"))
				stylesDict.Add("DoubleField", new StyleWrapper(style, GUIContent.none));

			return EditorGUI.DoubleField(value, style, options);
			*/
        }

        public double DoubleField(string label, double value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.DoubleField(label, value, options);
			*/
        }

        public double DoubleField(string label, double value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("DoubleField"))
				stylesDict.Add("DoubleField", new StyleWrapper(style, label));

			return EditorGUI.DoubleField(label, value, style, options);
			*/
        }

        public double DoubleField(GUIContent label, double value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.DoubleField(label, value, options);
			*/
        }

        public double DoubleField(GUIContent label, double value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("DoubleField"))
				stylesDict.Add("DoubleField", new StyleWrapper(style, label));

			return EditorGUI.DoubleField(label, value, style, options);
			*/
        }

        public double DelayedDoubleField(double value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.DelayedDoubleField(value, options);
			*/
        }

        public double DelayedDoubleField(double value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("DelayedDoubleField"))
				stylesDict.Add("DelayedDoubleField", new StyleWrapper(style, GUIContent.none));

			return EditorGUI.DelayedDoubleField(value, style, options);
			*/
        }

        public double DelayedDoubleField(string label, double value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.DelayedDoubleField(label, value, options);
			*/
        }

        public double DelayedDoubleField(string label, double value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("DelayedDoubleField"))
				stylesDict.Add("DelayedDoubleField", new StyleWrapper(style, label));

			return EditorGUI.DelayedDoubleField(label, value, style, options);
			*/
        }

        public double DelayedDoubleField(GUIContent label, double value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.DelayedDoubleField(label, value, options);
			*/
        }

        public double DelayedDoubleField(GUIContent label, double value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("DelayedDoubleField"))
				stylesDict.Add("DelayedDoubleField", new StyleWrapper(style, label));

			return EditorGUI.DelayedDoubleField(label, value, style, options);
			*/
        }

        public int IntField(int value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.IntField(value, options);
			*/
        }

        public int IntField(int value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("IntField"))
				stylesDict.Add("IntField", new StyleWrapper(style, GUIContent.none));

			return EditorGUI.IntField(value, style, options);
			*/
        }

        public int IntField(string label, int value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.IntField(label, value, options);
			*/
        }

        public int IntField(string label, int value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("IntField"))
				stylesDict.Add("IntField", new StyleWrapper(style, label));

			return EditorGUI.IntField(label, value, style, options);
			*/
        }

        public int IntField(GUIContent label, int value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.IntField(label, value, options);
			*/
        }

        public int IntField(GUIContent label, int value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("IntField"))
				stylesDict.Add("IntField", new StyleWrapper(style, label));

			return EditorGUI.IntField(label, value, style, options);
			*/
        }

        public int DelayedIntField(int value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.DelayedIntField(value, options);
			*/
        }

        public int DelayedIntField(int value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("DelayedIntField"))
				stylesDict.Add("DelayedIntField", new StyleWrapper(style, GUIContent.none));

			return EditorGUI.DelayedIntField(value, style, options);
			*/
        }

        public int DelayedIntField(string label, int value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.DelayedIntField(label, value, options);
			*/
        }

        public int DelayedIntField(string label, int value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("DelayedIntField"))
				stylesDict.Add("DelayedIntField", new StyleWrapper(style, label));

			return EditorGUI.DelayedIntField(label, value, style, options);
			*/
        }

        public int DelayedIntField(GUIContent label, int value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.DelayedIntField(label, value, options);
			*/
        }

        public int DelayedIntField(GUIContent label, int value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("DelayedIntField"))
				stylesDict.Add("DelayedIntField", new StyleWrapper(style, label));

			return EditorGUI.DelayedIntField(label, value, style, options);
			*/
        }

        public void DelayedIntField(SerializedProperty property, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.DelayedIntField(property, options);
			*/
        }

        public void DelayedIntField(SerializedProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.DelayedIntField(property, label, options);
			*/
        }

        public long LongField(long value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.LongField(value, options);
			*/
        }

        public long LongField(long value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("LongField"))
				stylesDict.Add("LongField", new StyleWrapper(style, GUIContent.none));

			return EditorGUI.LongField(value, style, options);
			*/
        }

        public long LongField(string label, long value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.LongField(label, value, options);
			*/
        }

        public long LongField(string label, long value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("LongField"))
				stylesDict.Add("LongField", new StyleWrapper(style, label));

			return EditorGUI.LongField(label, value, style, options);
			*/
        }

        public long LongField(GUIContent label, long value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.LongField(label, value, options);
			*/
        }

        public long LongField(GUIContent label, long value, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("LongField"))
				stylesDict.Add("LongField", new StyleWrapper(style, label));

			return EditorGUI.LongField(label, value, style, options);
			*/
        }

        public float Slider(float value, float leftValue, float rightValue, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.Slider(value, leftValue, rightValue, options);
			*/
        }

        public float Slider(string label, float value, float leftValue, float rightValue, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.Slider(label, value, leftValue, rightValue, options);
			*/
        }

        public float Slider(GUIContent label, float value, float leftValue, float rightValue, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.Slider(label, value, leftValue, rightValue, options);
			*/
        }

        public void Slider(SerializedProperty property, float leftValue, float rightValue, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.Slider(property, leftValue, rightValue, options);
			*/
        }

        public void Slider(SerializedProperty property, float leftValue, float rightValue, string label, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.Slider(property, leftValue, rightValue, label, options);
			*/
        }

        public void Slider(SerializedProperty property, float leftValue, float rightValue, GUIContent label, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.Slider(property, leftValue, rightValue, label, options);
			*/
        }

        public int IntSlider(int value, int leftValue, int rightValue, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.IntSlider(value, leftValue, rightValue, options);
			*/
        }

        public int IntSlider(string label, int value, int leftValue, int rightValue, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.IntSlider(label, value, leftValue, rightValue, options);
			*/
        }

        public int IntSlider(GUIContent label, int value, int leftValue, int rightValue, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.IntSlider(label, value, leftValue, rightValue, options);
			*/
        }

        public void IntSlider(SerializedProperty property, int leftValue, int rightValue, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.IntSlider(property, leftValue, rightValue, options);
			*/
        }

        public void IntSlider(SerializedProperty property, int leftValue, int rightValue, string label, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.IntSlider(property, leftValue, rightValue, label, options);
			*/
        }

        public void IntSlider(SerializedProperty property, int leftValue, int rightValue, GUIContent label, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.IntSlider(property, leftValue, rightValue, label, options);
			*/
        }

        public void MinMaxSlider(ref float minValue, ref float maxValue, float minLimit, float maxLimit, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.MinMaxSlider(ref minValue, ref maxValue, minLimit, maxLimit, options);
			*/
        }

        public void MinMaxSlider(string label, ref float minValue, ref float maxValue, float minLimit, float maxLimit, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.MinMaxSlider(label, ref minValue, ref maxValue, minLimit, maxLimit, options);
			*/
        }

        public void MinMaxSlider(GUIContent label, ref float minValue, ref float maxValue, float minLimit, float maxLimit, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.MinMaxSlider(label, ref minValue, ref maxValue, minLimit, maxLimit, options);
			*/
        }

        public int Popup(int selectedIndex, string[] displayedOptions, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("Popup"))
				stylesDict.Add("Popup", new StyleWrapper(EditorStyles.popup, GUIContent.none));

			return EditorGUI.Popup(selectedIndex, displayedOptions, options);
			*/
        }

        public int Popup(int selectedIndex, string[] displayedOptions, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("Popup"))
				stylesDict.Add("Popup", new StyleWrapper(style, GUIContent.none));

			return EditorGUI.Popup(selectedIndex, displayedOptions, style, options);
			*/
        }

        public int Popup(int selectedIndex, GUIContent[] displayedOptions, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("Popup"))
				stylesDict.Add("Popup", new StyleWrapper(EditorStyles.popup, GUIContent.none));

			return EditorGUI.Popup(selectedIndex, displayedOptions, options);
			*/
        }

        public int Popup(int selectedIndex, GUIContent[] displayedOptions, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("Popup"))
				stylesDict.Add("Popup", new StyleWrapper(style, GUIContent.none));

			return EditorGUI.Popup(selectedIndex, displayedOptions, style, options);
			*/
        }

        public int Popup(string label, int selectedIndex, string[] displayedOptions, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("Popup"))
				stylesDict.Add("Popup", new StyleWrapper(EditorStyles.popup, label));

			return EditorGUI.Popup(label, selectedIndex, displayedOptions, options);
			*/
        }

        public int Popup(GUIContent label, int selectedIndex, string[] displayedOptions, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("Popup"))
				stylesDict.Add("Popup", new StyleWrapper(EditorStyles.popup, label));

			return EditorGUI.Popup(label, selectedIndex, displayedOptions, options);
			*/
        }

        public int Popup(string label, int selectedIndex, string[] displayedOptions, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("Popup"))
				stylesDict.Add("Popup", new StyleWrapper(style, label));

			return EditorGUI.Popup(label, selectedIndex, displayedOptions, style, options);
			*/
        }

        public int Popup(GUIContent label, int selectedIndex, GUIContent[] displayedOptions, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("Popup"))
				stylesDict.Add("Popup", new StyleWrapper(EditorStyles.popup, label));

			return EditorGUI.Popup(label, selectedIndex, displayedOptions, options);
			*/
        }

        public int Popup(GUIContent label, int selectedIndex, GUIContent[] displayedOptions, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("Popup"))
				stylesDict.Add("Popup", new StyleWrapper(style, label));

			return EditorGUI.Popup(label, selectedIndex, displayedOptions, style, options);
			*/
        }

        public Enum EnumPopup(Enum selected, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.EnumPopup(selected, options);
			*/
        }

        public Enum EnumPopup(Enum selected, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("EnumPopup"))
				stylesDict.Add("EnumPopup", new StyleWrapper(style, GUIContent.none));

			return EditorGUI.EnumPopup(selected, style, options);
			*/
        }

        public Enum EnumPopup(string label, Enum selected, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.EnumPopup(label, selected, options);
			*/
        }

        public Enum EnumPopup(string label, Enum selected, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("EnumPopup"))
				stylesDict.Add("EnumPopup", new StyleWrapper(style, label));

			return EditorGUI.EnumPopup(label, selected, style, options);
			*/
        }

        public Enum EnumPopup(GUIContent label, Enum selected, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.EnumPopup(label, selected, options);
			*/
        }

        public Enum EnumPopup(GUIContent label, Enum selected, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("EnumPopup"))
				stylesDict.Add("EnumPopup", new StyleWrapper(style, label));

			return EditorGUI.EnumPopup(label, selected, style, options);
			*/
        }

        public Enum EnumPopup(GUIContent label, Enum selected, Func<Enum, bool> checkEnabled, bool includeObsolete, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.EnumPopup(label, selected, checkEnabled, includeObsolete, options);
			*/
        }

        public Enum EnumPopup(GUIContent label, Enum selected, Func<Enum, bool> checkEnabled, bool includeObsolete, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("EnumPopup"))
				stylesDict.Add("EnumPopup", new StyleWrapper(style, label));

			return EditorGUI.EnumPopup(label, selected, checkEnabled, includeObsolete, style, options);
			*/
        }

        public int IntPopup(int selectedValue, string[] displayedOptions, int[] optionValues, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.IntPopup(selectedValue, displayedOptions, optionValues, options);
			*/
        }

        public int IntPopup(int selectedValue, string[] displayedOptions, int[] optionValues, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("IntPopup"))
				stylesDict.Add("IntPopup", new StyleWrapper(style, GUIContent.none));

			return EditorGUI.IntPopup(selectedValue, displayedOptions, optionValues, style, options);
			*/
        }

        public int IntPopup(int selectedValue, GUIContent[] displayedOptions, int[] optionValues, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.IntPopup(selectedValue, displayedOptions, optionValues, options);
			*/
        }

        public int IntPopup(int selectedValue, GUIContent[] displayedOptions, int[] optionValues, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("IntPopup"))
				stylesDict.Add("IntPopup", new StyleWrapper(style, GUIContent.none));

			return EditorGUI.IntPopup(selectedValue, displayedOptions, optionValues, style, options);
			*/
        }

        public int IntPopup(string label, int selectedValue, string[] displayedOptions, int[] optionValues, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.IntPopup(label, selectedValue, displayedOptions, optionValues, options);
			*/
        }

        public int IntPopup(string label, int selectedValue, string[] displayedOptions, int[] optionValues, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("IntPopup"))
				stylesDict.Add("IntPopup", new StyleWrapper(style, label));

			return EditorGUI.IntPopup(label, selectedValue, displayedOptions, optionValues, style, options);
			*/
        }

        public int IntPopup(GUIContent label, int selectedValue, GUIContent[] displayedOptions, int[] optionValues, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.IntPopup(label, selectedValue, displayedOptions, optionValues, options);
			*/
        }

        public int IntPopup(GUIContent label, int selectedValue, GUIContent[] displayedOptions, int[] optionValues, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("IntPopup"))
				stylesDict.Add("IntPopup", new StyleWrapper(style, label));

			return EditorGUI.IntPopup(label, selectedValue, displayedOptions, optionValues, style, options);
			*/
        }

        public void IntPopup(SerializedProperty property, GUIContent[] displayedOptions, int[] optionValues, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.IntPopup(property, displayedOptions, optionValues, options);
			*/
        }

        public void IntPopup(SerializedProperty property, GUIContent[] displayedOptions, int[] optionValues, GUIContent label, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.IntPopup(property, displayedOptions, optionValues, label, options);
			*/
        }

        public void IntPopup(SerializedProperty property, GUIContent[] displayedOptions, int[] optionValues, GUIContent label, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("IntPopup"))
				stylesDict.Add("IntPopup", new StyleWrapper(style, label));

			EditorGUI.IntPopup(property, displayedOptions, optionValues, label, style, options);
			*/
        }

        public string TagField(string tag, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.TagField(tag, options);
			*/
        }

        public string TagField(string tag, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("TagField"))
				stylesDict.Add("TagField", new StyleWrapper(style, GUIContent.none));

			return EditorGUI.TagField(tag, style, options);
			*/
        }

        public string TagField(string label, string tag, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.TagField(label, tag, options);
			*/
        }

        public string TagField(string label, string tag, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("TagField"))
				stylesDict.Add("TagField", new StyleWrapper(style, label));

			return EditorGUI.TagField(label, tag, style, options);
			*/
        }

        public string TagField(GUIContent label, string tag, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.TagField(label, tag, options);
			*/
        }

        public string TagField(GUIContent label, string tag, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("TagField"))
				stylesDict.Add("TagField", new StyleWrapper(style, label));

			return EditorGUI.TagField(label, tag, style, options);
			*/
        }

        public int LayerField(int layer, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.LayerField(layer, options);
			*/
        }

        public int LayerField(int layer, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("LayerField"))
				stylesDict.Add("LayerField", new StyleWrapper(style, GUIContent.none));

			return EditorGUI.LayerField(layer, style, options);
			*/
        }

        public int LayerField(string label, int layer, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.LayerField(label, layer, options);
			*/
        }

        public int LayerField(string label, int layer, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("LayerField"))
				stylesDict.Add("LayerField", new StyleWrapper(style, label));

			return EditorGUI.LayerField(label, layer, style, options);
			*/
        }

        public int LayerField(GUIContent label, int layer, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.LayerField(label, layer, options);
			*/
        }

        public int LayerField(GUIContent label, int layer, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("LayerField"))
				stylesDict.Add("LayerField", new StyleWrapper(style, label));

			return EditorGUI.LayerField(label, layer, style, options);
			*/
        }

        public int MaskField(GUIContent label, int mask, string[] displayedOptions, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("MaskField"))
				stylesDict.Add("MaskField", new StyleWrapper(style, label));

			return EditorGUI.MaskField(label, mask, displayedOptions, style, options);
			*/
        }

        public int MaskField(string label, int mask, string[] displayedOptions, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("MaskField"))
				stylesDict.Add("MaskField", new StyleWrapper(style, label));

			return EditorGUI.MaskField(label, mask, displayedOptions, style, options);
			*/
        }

        public int MaskField(GUIContent label, int mask, string[] displayedOptions, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.MaskField(label, mask, displayedOptions, options);
			*/
        }

        public int MaskField(string label, int mask, string[] displayedOptions, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.MaskField(label, mask, displayedOptions, options);
			*/
        }

        public int MaskField(int mask, string[] displayedOptions, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("MaskField"))
				stylesDict.Add("MaskField", new StyleWrapper(style, GUIContent.none));

			return EditorGUI.MaskField(mask, displayedOptions, style, options);
			*/
        }

        public int MaskField(int mask, string[] displayedOptions, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.MaskField(mask, displayedOptions, options);
			*/
        }

        public Enum EnumFlagsField(Enum enumValue, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.EnumFlagsField(enumValue, options);
			*/
        }

        public Enum EnumFlagsField(Enum enumValue, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("EnumFlagsField"))
				stylesDict.Add("EnumFlagsField", new StyleWrapper(style, GUIContent.none));

			return EditorGUI.EnumFlagsField(enumValue, style, options);
			*/
        }

        public Enum EnumFlagsField(string label, Enum enumValue, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.EnumFlagsField(label, enumValue, options);
			*/
        }

        public Enum EnumFlagsField(string label, Enum enumValue, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("EnumFlagsField"))
				stylesDict.Add("EnumFlagsField", new StyleWrapper(style, label));

			return EditorGUI.EnumFlagsField(label, enumValue, style, options);
			*/
        }

        public Enum EnumFlagsField(GUIContent label, Enum enumValue, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.EnumFlagsField(label, enumValue, options);
			*/
        }

        public Enum EnumFlagsField(GUIContent label, Enum enumValue, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("EnumFlagsField"))
				stylesDict.Add("EnumFlagsField", new StyleWrapper(style, label));

			return EditorGUI.EnumFlagsField(label, enumValue, style, options);
			*/
        }

        public Enum EnumFlagsField(GUIContent label, Enum enumValue, bool includeObsolete, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.EnumFlagsField(label, enumValue, includeObsolete, options);
			*/
        }

        public Enum EnumFlagsField(GUIContent label, Enum enumValue, bool includeObsolete, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("EnumFlagsField"))
				stylesDict.Add("EnumFlagsField", new StyleWrapper(style, label));

			return EditorGUI.EnumFlagsField(label, enumValue, includeObsolete, style, options);
			*/
        }

        public Object ObjectField(Object obj, Type objType, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("ObjectField"))
				stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, GUIContent.none));

			return EditorGUI.ObjectField(obj, objType, options);
			*/
        }

        public Object ObjectField(Object obj, Type objType, bool allowSceneObjects, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("ObjectField"))
				stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, GUIContent.none));

			return EditorGUI.ObjectField(obj, objType, allowSceneObjects, options);
			*/
        }

        public Object ObjectField(string label, Object obj, Type objType, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("ObjectField"))
				stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

			return EditorGUI.ObjectField(label, obj, objType, options);
			*/
        }

        public Object ObjectField(string label, Object obj, Type objType, bool allowSceneObjects, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("ObjectField"))
				stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

			return EditorGUI.ObjectField(label, obj, objType, allowSceneObjects, options);
			*/
        }

        public Object ObjectField(GUIContent label, Object obj, Type objType, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("ObjectField"))
				stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

			return EditorGUI.ObjectField(label, obj, objType, options);
			*/
        }

        public Object ObjectField(GUIContent label, Object obj, Type objType, bool allowSceneObjects, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("ObjectField"))
				stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

			return EditorGUI.ObjectField(label, obj, objType, allowSceneObjects, options);
			*/
        }

        public void ObjectField(SerializedProperty property, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("ObjectField"))
				stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, GUIContent.none));

			EditorGUI.ObjectField(property, options);
			*/
        }

        public void ObjectField(SerializedProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("ObjectField"))
				stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

			EditorGUI.ObjectField(property, label, options);
			*/
        }

        public void ObjectField(SerializedProperty property, Type objType, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("ObjectField"))
				stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, GUIContent.none));

			EditorGUI.ObjectField(property, objType, options);
			*/
        }

        public void ObjectField(SerializedProperty property, Type objType, GUIContent label, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("ObjectField"))
				stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

			EditorGUI.ObjectField(property, objType, label, options);
			*/
        }

        public Vector2 Vector2Field(string label, Vector2 value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.Vector2Field(label, value, options);
			*/
        }

        public Vector2 Vector2Field(GUIContent label, Vector2 value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.Vector2Field(label, value, options);
			*/
        }

        public Vector3 Vector3Field(string label, Vector3 value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.Vector3Field(label, value, options);
			*/
        }

        public Vector3 Vector3Field(GUIContent label, Vector3 value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.Vector3Field(label, value, options);
			*/
        }

        public Vector4 Vector4Field(string label, Vector4 value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.Vector4Field(label, value, options);
			*/
        }

        public Vector4 Vector4Field(GUIContent label, Vector4 value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.Vector4Field(label, value, options);
			*/
        }

        public Vector2Int Vector2IntField(string label, Vector2Int value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.Vector2IntField(label, value, options);
			*/
        }

        public Vector2Int Vector2IntField(GUIContent label, Vector2Int value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.Vector2IntField(label, value, options);
			*/
        }

        public Vector3Int Vector3IntField(string label, Vector3Int value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.Vector3IntField(label, value, options);
			*/
        }

        public Vector3Int Vector3IntField(GUIContent label, Vector3Int value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.Vector3IntField(label, value, options);
			*/
        }

        public Rect RectField(Rect value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.RectField(value, options);
			*/
        }

        public Rect RectField(string label, Rect value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.RectField(label, value, options);
			*/
        }

        public Rect RectField(GUIContent label, Rect value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.RectField(label, value, options);
			*/
        }

        public RectInt RectIntField(RectInt value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.RectIntField(value, options);
			*/
        }

        public RectInt RectIntField(string label, RectInt value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.RectIntField(label, value, options);
			*/
        }

        public RectInt RectIntField(GUIContent label, RectInt value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.RectIntField(label, value, options);
			*/
        }

        public Bounds BoundsField(Bounds value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.BoundsField(value, options);
			*/
        }

        public Bounds BoundsField(string label, Bounds value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.BoundsField(label, value, options);
			*/
        }

        public Bounds BoundsField(GUIContent label, Bounds value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.BoundsField(label, value, options);
			*/
        }

        public BoundsInt BoundsIntField(BoundsInt value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.BoundsIntField(value, options);
			*/
        }

        public BoundsInt BoundsIntField(string label, BoundsInt value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.BoundsIntField(label, value, options);
			*/
        }

        public BoundsInt BoundsIntField(GUIContent label, BoundsInt value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.BoundsIntField(label, value, options);
			*/
        }

        public Color ColorField(Color value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("ColorField"))
				stylesDict.Add("ColorField", new StyleWrapper(EditorStyles.colorField, GUIContent.none));

			return EditorGUI.ColorField(value, options);
			*/
        }

        public Color ColorField(string label, Color value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("ColorField"))
				stylesDict.Add("ColorField", new StyleWrapper(EditorStyles.colorField, label));

			return EditorGUI.ColorField(label, value, options);
			*/
        }

        public Color ColorField(GUIContent label, Color value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("ColorField"))
				stylesDict.Add("ColorField", new StyleWrapper(EditorStyles.colorField, label));

			return EditorGUI.ColorField(label, value, options);
			*/
        }

        public Color ColorField(GUIContent label, Color value, bool showEyedropper, bool showAlpha, bool hdr, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("ColorField"))
				stylesDict.Add("ColorField", new StyleWrapper(EditorStyles.colorField, label));

			return EditorGUI.ColorField(label, value, showEyedropper, showAlpha, hdr, options);
			*/
        }

        public AnimationCurve CurveField(AnimationCurve value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.CurveField(value, options);
			*/
        }

        public AnimationCurve CurveField(string label, AnimationCurve value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.CurveField(label, value, options);
			*/
        }

        public AnimationCurve CurveField(GUIContent label, AnimationCurve value, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.CurveField(label, value, options);
			*/
        }

        public AnimationCurve CurveField(AnimationCurve value, Color color, Rect ranges, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.CurveField(value, color, ranges, options);
			*/
        }

        public AnimationCurve CurveField(string label, AnimationCurve value, Color color, Rect ranges, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.CurveField(label, value, color, ranges, options);
			*/
        }

        public AnimationCurve CurveField(GUIContent label, AnimationCurve value, Color color, Rect ranges, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.CurveField(label, value, color, ranges, options);
			*/
        }

        public void CurveField(SerializedProperty property, Color color, Rect ranges, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.CurveField(property, color, ranges, options);
			*/
        }

        public void CurveField(SerializedProperty property, Color color, Rect ranges, GUIContent label, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.CurveField(property, color, ranges, label, options);
			*/
        }

        public bool InspectorTitlebar(bool foldout, Object targetObj)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.InspectorTitlebar(foldout, targetObj);
			*/
        }

        public bool InspectorTitlebar(bool foldout, Object targetObj, bool expandable)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.InspectorTitlebar(foldout, targetObj, expandable);
			*/
        }

        public bool InspectorTitlebar(bool foldout, Object[] targetObjs)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.InspectorTitlebar(foldout, targetObjs);
			*/
        }

        public bool InspectorTitlebar(bool foldout, Object[] targetObjs, bool expandable)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.InspectorTitlebar(foldout, targetObjs, expandable);
			*/
        }

        public bool InspectorTitlebar(bool foldout, Editor editor)
        {
            throw new Exception("Methods with Editor type in it's parameters aren't implemented yet!");
            /*
			return EditorGUI.InspectorTitlebar(foldout, editor);
			*/
        }

        public void InspectorTitlebar(Object[] targetObjs)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			EditorGUI.InspectorTitlebar(targetObjs);
			*/
        }

        public void HelpBox(string message, MessageType type)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("HelpBox"))
				stylesDict.Add("HelpBox", new StyleWrapper(EditorStyles.helpBox, message));

			EditorGUI.HelpBox(message, type);
			*/
        }

        public void HelpBox(string message, MessageType type, bool wide)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("HelpBox"))
				stylesDict.Add("HelpBox", new StyleWrapper(EditorStyles.helpBox, message));

			EditorGUI.HelpBox(message, type, wide);
			*/
        }

        public void HelpBox(GUIContent content, bool wide = true)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("HelpBox"))
				stylesDict.Add("HelpBox", new StyleWrapper(EditorStyles.helpBox, content));

			EditorGUI.HelpBox(content, wide);
			*/
        }

        public bool BeginToggleGroup(string label, bool toggle)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.BeginToggleGroup(label, toggle);
			*/
        }

        public bool BeginToggleGroup(GUIContent label, bool toggle)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.BeginToggleGroup(label, toggle);
			*/
        }

        public Rect BeginHorizontal(params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.BeginHorizontal(options);
			*/
        }

        public Rect BeginHorizontal(GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("BeginHorizontal"))
				stylesDict.Add("BeginHorizontal", new StyleWrapper(style, GUIContent.none));

			return EditorGUI.BeginHorizontal(style, options);
			*/
        }

        public Rect BeginVertical(params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.BeginVertical(options);
			*/
        }

        public Rect BeginVertical(GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("BeginVertical"))
				stylesDict.Add("BeginVertical", new StyleWrapper(style, GUIContent.none));

			return EditorGUI.BeginVertical(style, options);
			*/
        }

        public Vector2 BeginScrollView(Vector2 scrollPosition, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.BeginScrollView(scrollPosition, options);
			*/
        }

        public Vector2 BeginScrollView(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.BeginScrollView(scrollPosition, alwaysShowHorizontal, alwaysShowVertical, options);
			*/
        }

        public Vector2 BeginScrollView(Vector2 scrollPosition, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.BeginScrollView(scrollPosition, horizontalScrollbar, verticalScrollbar, options);
			*/
        }

        public Vector2 BeginScrollView(Vector2 scrollPosition, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("BeginScrollView"))
				stylesDict.Add("BeginScrollView", new StyleWrapper(style, GUIContent.none));

			return EditorGUI.BeginScrollView(scrollPosition, style, options);
			*/
        }

        public Vector2 BeginScrollView(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.BeginScrollView(scrollPosition, alwaysShowHorizontal, alwaysShowVertical, horizontalScrollbar, verticalScrollbar, background, options);
			*/
        }

        public bool PropertyField(SerializedProperty property, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.PropertyField(property, options);
			*/
        }

        public bool PropertyField(SerializedProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.PropertyField(property, label, options);
			*/
        }

        public bool PropertyField(SerializedProperty property, bool includeChildren, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.PropertyField(property, includeChildren, options);
			*/
        }

        public bool PropertyField(SerializedProperty property, GUIContent label, bool includeChildren, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.PropertyField(property, label, includeChildren, options);
			*/
        }

        public Rect GetControlRect(params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.GetControlRect(options);
			*/
        }

        public Rect GetControlRect(bool hasLabel, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.GetControlRect(hasLabel, options);
			*/
        }

        public Rect GetControlRect(bool hasLabel, float height, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.GetControlRect(hasLabel, height, options);
			*/
        }

        public Rect GetControlRect(bool hasLabel, float height, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("GetControlRect"))
				stylesDict.Add("GetControlRect", new StyleWrapper(style, GUIContent.none));

			return EditorGUI.GetControlRect(hasLabel, height, style, options);
			*/
        }

        public bool BeginFadeGroup(float value)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.BeginFadeGroup(value);
			*/
        }

        public bool DropdownButton(GUIContent content, FocusType focusType, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			return EditorGUI.DropdownButton(content, focusType, options);
			*/
        }

        public bool DropdownButton(GUIContent content, FocusType focusType, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("No implementation Layout yet!");
            /*
			if(!stylesDict.ContainsKey("DropdownButton"))
				stylesDict.Add("DropdownButton", new StyleWrapper(style, content));

			return EditorGUI.DropdownButton(content, focusType, style, options);
			*/
        }


        public float GetHeight()
        {
            float size = 0;

            foreach (StyleWrapper wrapper in stylesDict.Values)
                size += wrapper.listWrapper.Sum(x => x.Value.list.Sum(y => x.Key.CalcSize(y).y));

            return size;
        }
    }
}
