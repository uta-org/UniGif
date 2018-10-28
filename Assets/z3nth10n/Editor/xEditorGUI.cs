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

    public sealed class StyleWrapper
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

    public sealed class GUIContents
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

    // I suggest you not to implement anything here due to generation. Use partial approach.
    public sealed partial class xEditorGUI
    {
        private Dictionary<string, StyleWrapper> stylesDict = new Dictionary<string, StyleWrapper>();

        private Rect _position;

        public void FocusTextInControl(string name)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("FocusTextInControl"))
                stylesDict.Add("FocusTextInControl", new StyleWrapper(new GUIStyle("focusTextInControl"), GUIContent.none));

            EditorGUI.FocusTextInControl(name);
        }

        public void BeginDisabledGroup(bool disabled)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("BeginDisabledGroup"))
                stylesDict.Add("BeginDisabledGroup", new StyleWrapper(new GUIStyle("beginDisabledGroup"), GUIContent.none));

            EditorGUI.BeginDisabledGroup(disabled);
        }

        public void DropShadowLabel(Rect position, string text)
        {
            if (!stylesDict.ContainsKey("DropShadowLabel"))
                stylesDict.Add("DropShadowLabel", new StyleWrapper(new GUIStyle("dropShadowLabel"), text));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("dropShadowLabel"), text);

            EditorGUI.DropShadowLabel(position, text);
        }

        public void DropShadowLabel(Rect position, GUIContent content)
        {
            if (!stylesDict.ContainsKey("DropShadowLabel"))
                stylesDict.Add("DropShadowLabel", new StyleWrapper(new GUIStyle("dropShadowLabel"), content));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("dropShadowLabel"), content);

            EditorGUI.DropShadowLabel(position, content);
        }

        public void DropShadowLabel(Rect position, string text, GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DropShadowLabel"))
                stylesDict.Add("DropShadowLabel", new StyleWrapper(style, text));

            Rect lastPosition = _position;
            UpdatePosition(style, text);

            EditorGUI.DropShadowLabel(position, text, style);
        }

        public void DropShadowLabel(Rect position, GUIContent content, GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DropShadowLabel"))
                stylesDict.Add("DropShadowLabel", new StyleWrapper(style, content));

            Rect lastPosition = _position;
            UpdatePosition(style, content);

            EditorGUI.DropShadowLabel(position, content, style);
        }

        public bool Toggle(Rect position, bool value)
        {
            if (!stylesDict.ContainsKey("Toggle"))
                stylesDict.Add("Toggle", new StyleWrapper(EditorStyles.toggle, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.toggle, GUIContent.none);

            return EditorGUI.Toggle(position, value);
        }

        public bool Toggle(Rect position, string label, bool value)
        {
            if (!stylesDict.ContainsKey("Toggle"))
                stylesDict.Add("Toggle", new StyleWrapper(EditorStyles.toggle, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.toggle, label);

            return EditorGUI.Toggle(position, label, value);
        }

        public bool Toggle(Rect position, bool value, GUIStyle style)
        {
            if (!stylesDict.ContainsKey("Toggle"))
                stylesDict.Add("Toggle", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.Toggle(position, value, style);
        }

        public bool Toggle(Rect position, string label, bool value, GUIStyle style)
        {
            if (!stylesDict.ContainsKey("Toggle"))
                stylesDict.Add("Toggle", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.Toggle(position, label, value, style);
        }

        public bool Toggle(Rect position, GUIContent label, bool value)
        {
            if (!stylesDict.ContainsKey("Toggle"))
                stylesDict.Add("Toggle", new StyleWrapper(EditorStyles.toggle, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.toggle, label);

            return EditorGUI.Toggle(position, label, value);
        }

        public bool Toggle(Rect position, GUIContent label, bool value, GUIStyle style)
        {
            if (!stylesDict.ContainsKey("Toggle"))
                stylesDict.Add("Toggle", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.Toggle(position, label, value, style);
        }

        public string DoPasswordField(int id, Rect position, string password, GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DoPasswordField"))
                stylesDict.Add("DoPasswordField", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.DoPasswordField(id, position, password, style);
        }

        public string DoPasswordField(int id, Rect position, GUIContent label, string password, GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DoPasswordField"))
                stylesDict.Add("DoPasswordField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.DoPasswordField(id, position, label, password, style);
        }

        public float Slider(Rect position, float value, float leftValue, float rightValue)
        {
            if (!stylesDict.ContainsKey("Slider"))
                stylesDict.Add("Slider", new StyleWrapper(new GUIStyle("slider"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("slider"), GUIContent.none);

            return EditorGUI.Slider(position, value, leftValue, rightValue);
        }

        public float Slider(Rect position, string label, float value, float leftValue, float rightValue)
        {
            if (!stylesDict.ContainsKey("Slider"))
                stylesDict.Add("Slider", new StyleWrapper(new GUIStyle("slider"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("slider"), label);

            return EditorGUI.Slider(position, label, value, leftValue, rightValue);
        }

        public float Slider(Rect position, GUIContent label, float value, float leftValue, float rightValue)
        {
            if (!stylesDict.ContainsKey("Slider"))
                stylesDict.Add("Slider", new StyleWrapper(new GUIStyle("slider"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("slider"), label);

            return EditorGUI.Slider(position, label, value, leftValue, rightValue);
        }

        public void Slider(Rect position, SerializedProperty property, float leftValue, float rightValue)
        {
            if (!stylesDict.ContainsKey("Slider"))
                stylesDict.Add("Slider", new StyleWrapper(new GUIStyle("slider"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("slider"), GUIContent.none);

            EditorGUI.Slider(position, property, leftValue, rightValue);
        }

        public void Slider(Rect position, SerializedProperty property, float leftValue, float rightValue, string label)
        {
            if (!stylesDict.ContainsKey("Slider"))
                stylesDict.Add("Slider", new StyleWrapper(new GUIStyle("slider"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("slider"), label);

            EditorGUI.Slider(position, property, leftValue, rightValue, label);
        }

        public void Slider(Rect position, SerializedProperty property, float leftValue, float rightValue, GUIContent label)
        {
            if (!stylesDict.ContainsKey("Slider"))
                stylesDict.Add("Slider", new StyleWrapper(new GUIStyle("slider"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("slider"), label);

            EditorGUI.Slider(position, property, leftValue, rightValue, label);
        }

        public int IntSlider(Rect position, int value, int leftValue, int rightValue)
        {
            if (!stylesDict.ContainsKey("IntSlider"))
                stylesDict.Add("IntSlider", new StyleWrapper(new GUIStyle("intSlider"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intSlider"), GUIContent.none);

            return EditorGUI.IntSlider(position, value, leftValue, rightValue);
        }

        public int IntSlider(Rect position, string label, int value, int leftValue, int rightValue)
        {
            if (!stylesDict.ContainsKey("IntSlider"))
                stylesDict.Add("IntSlider", new StyleWrapper(new GUIStyle("intSlider"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intSlider"), label);

            return EditorGUI.IntSlider(position, label, value, leftValue, rightValue);
        }

        public int IntSlider(Rect position, GUIContent label, int value, int leftValue, int rightValue)
        {
            if (!stylesDict.ContainsKey("IntSlider"))
                stylesDict.Add("IntSlider", new StyleWrapper(new GUIStyle("intSlider"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intSlider"), label);

            return EditorGUI.IntSlider(position, label, value, leftValue, rightValue);
        }

        public void IntSlider(Rect position, SerializedProperty property, int leftValue, int rightValue)
        {
            if (!stylesDict.ContainsKey("IntSlider"))
                stylesDict.Add("IntSlider", new StyleWrapper(new GUIStyle("intSlider"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intSlider"), GUIContent.none);

            EditorGUI.IntSlider(position, property, leftValue, rightValue);
        }

        public void IntSlider(Rect position, SerializedProperty property, int leftValue, int rightValue, string label)
        {
            if (!stylesDict.ContainsKey("IntSlider"))
                stylesDict.Add("IntSlider", new StyleWrapper(new GUIStyle("intSlider"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intSlider"), label);

            EditorGUI.IntSlider(position, property, leftValue, rightValue, label);
        }

        public void IntSlider(Rect position, SerializedProperty property, int leftValue, int rightValue, GUIContent label)
        {
            if (!stylesDict.ContainsKey("IntSlider"))
                stylesDict.Add("IntSlider", new StyleWrapper(new GUIStyle("intSlider"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intSlider"), label);

            EditorGUI.IntSlider(position, property, leftValue, rightValue, label);
        }

        public void MinMaxSlider(GUIContent label, Rect position, ref float minValue, ref float maxValue, float minLimit, float maxLimit)
        {
            if (!stylesDict.ContainsKey("MinMaxSlider"))
                stylesDict.Add("MinMaxSlider", new StyleWrapper(new GUIStyle("minMaxSlider"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("minMaxSlider"), label);

            EditorGUI.MinMaxSlider(label, position, ref minValue, ref maxValue, minLimit, maxLimit);
        }

        public void MinMaxSlider(Rect position, string label, ref float minValue, ref float maxValue, float minLimit, float maxLimit)
        {
            if (!stylesDict.ContainsKey("MinMaxSlider"))
                stylesDict.Add("MinMaxSlider", new StyleWrapper(new GUIStyle("minMaxSlider"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("minMaxSlider"), label);

            EditorGUI.MinMaxSlider(position, label, ref minValue, ref maxValue, minLimit, maxLimit);
        }

        public void MinMaxSlider(Rect position, GUIContent label, ref float minValue, ref float maxValue, float minLimit, float maxLimit)
        {
            if (!stylesDict.ContainsKey("MinMaxSlider"))
                stylesDict.Add("MinMaxSlider", new StyleWrapper(new GUIStyle("minMaxSlider"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("minMaxSlider"), label);

            EditorGUI.MinMaxSlider(position, label, ref minValue, ref maxValue, minLimit, maxLimit);
        }

        public void MinMaxSlider(Rect position, ref float minValue, ref float maxValue, float minLimit, float maxLimit)
        {
            if (!stylesDict.ContainsKey("MinMaxSlider"))
                stylesDict.Add("MinMaxSlider", new StyleWrapper(new GUIStyle("minMaxSlider"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("minMaxSlider"), GUIContent.none);

            EditorGUI.MinMaxSlider(position, ref minValue, ref maxValue, minLimit, maxLimit);
        }

        public int GetSelectedValueForControl(int controlID, int selected)
        {
            throw new Exception("This method isn't supported!");
        }

        public Enum EnumFlagsField(Rect position, Enum enumValue)
        {
            throw new Exception("This method isn't supported!");
        }

        public Enum EnumFlagsField(Rect position, Enum enumValue, GUIStyle style)
        {
            throw new Exception("This method isn't supported!");
        }

        public Enum EnumFlagsField(Rect position, string label, Enum enumValue)
        {
            throw new Exception("This method isn't supported!");
        }

        public Enum EnumFlagsField(Rect position, string label, Enum enumValue, GUIStyle style)
        {
            throw new Exception("This method isn't supported!");
        }

        public Enum EnumFlagsField(Rect position, GUIContent label, Enum enumValue)
        {
            throw new Exception("This method isn't supported!");
        }

        public Enum EnumFlagsField(Rect position, GUIContent label, Enum enumValue, GUIStyle style)
        {
            throw new Exception("This method isn't supported!");
        }

        public Enum EnumFlagsField(Rect position, GUIContent label, Enum enumValue, [DefaultValue("false")] bool includeObsolete, [DefaultValue("null")] GUIStyle style = null)
        {
            throw new Exception("Methods with optional attributed params aren't implemented yet!");
            /*
			if(!stylesDict.ContainsKey("EnumFlagsField"))
				stylesDict.Add("EnumFlagsField", new StyleWrapper(style, label));

			Rect lastPosition = _position;
			UpdatePosition(style, label);

			// This call has the following (1) unsupported params (an implementation is required): includeObsolete
			return EditorGUI.EnumFlagsField(position, label, enumValue, style);
			*/
        }

        public void ObjectField(Rect position, SerializedProperty property)
        {
            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.objectField, GUIContent.none);

            EditorGUI.ObjectField(position, property);
        }

        public void ObjectField(Rect position, SerializedProperty property, GUIContent label)
        {
            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.objectField, label);

            EditorGUI.ObjectField(position, property, label);
        }

        public void ObjectField(Rect position, SerializedProperty property, Type objType)
        {
            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.objectField, GUIContent.none);

            EditorGUI.ObjectField(position, property, objType);
        }

        public void ObjectField(Rect position, SerializedProperty property, Type objType, GUIContent label)
        {
            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.objectField, label);

            EditorGUI.ObjectField(position, property, objType, label);
        }

        public Object ObjectField(Rect position, Object obj, Type objType, bool allowSceneObjects)
        {
            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.objectField, GUIContent.none);

            return EditorGUI.ObjectField(position, obj, objType, allowSceneObjects);
        }

        public Object ObjectField(Rect position, Object obj, Type objType)
        {
            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.objectField, GUIContent.none);

            return EditorGUI.ObjectField(position, obj, objType);
        }

        public Object ObjectField(Rect position, string label, Object obj, Type objType, bool allowSceneObjects)
        {
            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.objectField, label);

            return EditorGUI.ObjectField(position, label, obj, objType, allowSceneObjects);
        }

        public Object ObjectField(Rect position, string label, Object obj, Type objType)
        {
            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.objectField, label);

            return EditorGUI.ObjectField(position, label, obj, objType);
        }

        public Object ObjectField(Rect position, GUIContent label, Object obj, Type objType, bool allowSceneObjects)
        {
            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.objectField, label);

            return EditorGUI.ObjectField(position, label, obj, objType, allowSceneObjects);
        }

        public Object ObjectField(Rect position, GUIContent label, Object obj, Type objType)
        {
            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.objectField, label);

            return EditorGUI.ObjectField(position, label, obj, objType);
        }

        public Rect IndentedRect(Rect source)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("IndentedRect"))
                stylesDict.Add("IndentedRect", new StyleWrapper(new GUIStyle("indentedRect"), GUIContent.none));

            return EditorGUI.IndentedRect(source);
        }

        public Vector2 Vector2Field(Rect position, string label, Vector2 value)
        {
            if (!stylesDict.ContainsKey("Vector2Field"))
                stylesDict.Add("Vector2Field", new StyleWrapper(new GUIStyle("vector2Field"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("vector2Field"), label);

            return EditorGUI.Vector2Field(position, label, value);
        }

        public Vector2 Vector2Field(Rect position, GUIContent label, Vector2 value)
        {
            if (!stylesDict.ContainsKey("Vector2Field"))
                stylesDict.Add("Vector2Field", new StyleWrapper(new GUIStyle("vector2Field"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("vector2Field"), label);

            return EditorGUI.Vector2Field(position, label, value);
        }

        public Vector3 Vector3Field(Rect position, string label, Vector3 value)
        {
            if (!stylesDict.ContainsKey("Vector3Field"))
                stylesDict.Add("Vector3Field", new StyleWrapper(new GUIStyle("vector3Field"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("vector3Field"), label);

            return EditorGUI.Vector3Field(position, label, value);
        }

        public Vector3 Vector3Field(Rect position, GUIContent label, Vector3 value)
        {
            if (!stylesDict.ContainsKey("Vector3Field"))
                stylesDict.Add("Vector3Field", new StyleWrapper(new GUIStyle("vector3Field"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("vector3Field"), label);

            return EditorGUI.Vector3Field(position, label, value);
        }

        public Vector4 Vector4Field(Rect position, string label, Vector4 value)
        {
            if (!stylesDict.ContainsKey("Vector4Field"))
                stylesDict.Add("Vector4Field", new StyleWrapper(new GUIStyle("vector4Field"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("vector4Field"), label);

            return EditorGUI.Vector4Field(position, label, value);
        }

        public Vector4 Vector4Field(Rect position, GUIContent label, Vector4 value)
        {
            if (!stylesDict.ContainsKey("Vector4Field"))
                stylesDict.Add("Vector4Field", new StyleWrapper(new GUIStyle("vector4Field"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("vector4Field"), label);

            return EditorGUI.Vector4Field(position, label, value);
        }

        public Vector2Int Vector2IntField(Rect position, string label, Vector2Int value)
        {
            if (!stylesDict.ContainsKey("Vector2IntField"))
                stylesDict.Add("Vector2IntField", new StyleWrapper(new GUIStyle("vector2IntField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("vector2IntField"), label);

            return EditorGUI.Vector2IntField(position, label, value);
        }

        public Vector2Int Vector2IntField(Rect position, GUIContent label, Vector2Int value)
        {
            if (!stylesDict.ContainsKey("Vector2IntField"))
                stylesDict.Add("Vector2IntField", new StyleWrapper(new GUIStyle("vector2IntField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("vector2IntField"), label);

            return EditorGUI.Vector2IntField(position, label, value);
        }

        public Vector3Int Vector3IntField(Rect position, string label, Vector3Int value)
        {
            if (!stylesDict.ContainsKey("Vector3IntField"))
                stylesDict.Add("Vector3IntField", new StyleWrapper(new GUIStyle("vector3IntField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("vector3IntField"), label);

            return EditorGUI.Vector3IntField(position, label, value);
        }

        public Vector3Int Vector3IntField(Rect position, GUIContent label, Vector3Int value)
        {
            if (!stylesDict.ContainsKey("Vector3IntField"))
                stylesDict.Add("Vector3IntField", new StyleWrapper(new GUIStyle("vector3IntField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("vector3IntField"), label);

            return EditorGUI.Vector3IntField(position, label, value);
        }

        public Rect RectField(Rect position, Rect value)
        {
            if (!stylesDict.ContainsKey("RectField"))
                stylesDict.Add("RectField", new StyleWrapper(new GUIStyle("rectField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("rectField"), GUIContent.none);

            return EditorGUI.RectField(position, value);
        }

        public Rect RectField(Rect position, string label, Rect value)
        {
            if (!stylesDict.ContainsKey("RectField"))
                stylesDict.Add("RectField", new StyleWrapper(new GUIStyle("rectField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("rectField"), label);

            return EditorGUI.RectField(position, label, value);
        }

        public Rect RectField(Rect position, GUIContent label, Rect value)
        {
            if (!stylesDict.ContainsKey("RectField"))
                stylesDict.Add("RectField", new StyleWrapper(new GUIStyle("rectField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("rectField"), label);

            return EditorGUI.RectField(position, label, value);
        }

        public RectInt RectIntField(Rect position, RectInt value)
        {
            if (!stylesDict.ContainsKey("RectIntField"))
                stylesDict.Add("RectIntField", new StyleWrapper(new GUIStyle("rectIntField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("rectIntField"), GUIContent.none);

            return EditorGUI.RectIntField(position, value);
        }

        public RectInt RectIntField(Rect position, string label, RectInt value)
        {
            if (!stylesDict.ContainsKey("RectIntField"))
                stylesDict.Add("RectIntField", new StyleWrapper(new GUIStyle("rectIntField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("rectIntField"), label);

            return EditorGUI.RectIntField(position, label, value);
        }

        public RectInt RectIntField(Rect position, GUIContent label, RectInt value)
        {
            if (!stylesDict.ContainsKey("RectIntField"))
                stylesDict.Add("RectIntField", new StyleWrapper(new GUIStyle("rectIntField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("rectIntField"), label);

            return EditorGUI.RectIntField(position, label, value);
        }

        public Bounds BoundsField(Rect position, Bounds value)
        {
            if (!stylesDict.ContainsKey("BoundsField"))
                stylesDict.Add("BoundsField", new StyleWrapper(new GUIStyle("boundsField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("boundsField"), GUIContent.none);

            return EditorGUI.BoundsField(position, value);
        }

        public Bounds BoundsField(Rect position, string label, Bounds value)
        {
            if (!stylesDict.ContainsKey("BoundsField"))
                stylesDict.Add("BoundsField", new StyleWrapper(new GUIStyle("boundsField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("boundsField"), label);

            return EditorGUI.BoundsField(position, label, value);
        }

        public Bounds BoundsField(Rect position, GUIContent label, Bounds value)
        {
            if (!stylesDict.ContainsKey("BoundsField"))
                stylesDict.Add("BoundsField", new StyleWrapper(new GUIStyle("boundsField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("boundsField"), label);

            return EditorGUI.BoundsField(position, label, value);
        }

        public BoundsInt BoundsIntField(Rect position, BoundsInt value)
        {
            if (!stylesDict.ContainsKey("BoundsIntField"))
                stylesDict.Add("BoundsIntField", new StyleWrapper(new GUIStyle("boundsIntField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("boundsIntField"), GUIContent.none);

            return EditorGUI.BoundsIntField(position, value);
        }

        public BoundsInt BoundsIntField(Rect position, string label, BoundsInt value)
        {
            if (!stylesDict.ContainsKey("BoundsIntField"))
                stylesDict.Add("BoundsIntField", new StyleWrapper(new GUIStyle("boundsIntField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("boundsIntField"), label);

            return EditorGUI.BoundsIntField(position, label, value);
        }

        public BoundsInt BoundsIntField(Rect position, GUIContent label, BoundsInt value)
        {
            if (!stylesDict.ContainsKey("BoundsIntField"))
                stylesDict.Add("BoundsIntField", new StyleWrapper(new GUIStyle("boundsIntField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("boundsIntField"), label);

            return EditorGUI.BoundsIntField(position, label, value);
        }

        public void MultiFloatField(Rect position, GUIContent label, GUIContent[] subLabels, float[] values)
        {
            if (!stylesDict.ContainsKey("MultiFloatField"))
                stylesDict.Add("MultiFloatField", new StyleWrapper(new GUIStyle("multiFloatField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("multiFloatField"), label);

            EditorGUI.MultiFloatField(position, label, subLabels, values);
        }

        public void MultiFloatField(Rect position, GUIContent[] subLabels, float[] values)
        {
            if (!stylesDict.ContainsKey("MultiFloatField"))
                stylesDict.Add("MultiFloatField", new StyleWrapper(new GUIStyle("multiFloatField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("multiFloatField"), GUIContent.none);

            EditorGUI.MultiFloatField(position, subLabels, values);
        }

        public void MultiIntField(Rect position, GUIContent[] subLabels, int[] values)
        {
            if (!stylesDict.ContainsKey("MultiIntField"))
                stylesDict.Add("MultiIntField", new StyleWrapper(new GUIStyle("multiIntField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("multiIntField"), GUIContent.none);

            EditorGUI.MultiIntField(position, subLabels, values);
        }

        public void MultiPropertyField(Rect position, GUIContent[] subLabels, SerializedProperty valuesIterator, GUIContent label)
        {
            if (!stylesDict.ContainsKey("MultiPropertyField"))
                stylesDict.Add("MultiPropertyField", new StyleWrapper(new GUIStyle("multiPropertyField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("multiPropertyField"), label);

            EditorGUI.MultiPropertyField(position, subLabels, valuesIterator, label);
        }

        public void MultiPropertyField(Rect position, GUIContent[] subLabels, SerializedProperty valuesIterator)
        {
            if (!stylesDict.ContainsKey("MultiPropertyField"))
                stylesDict.Add("MultiPropertyField", new StyleWrapper(new GUIStyle("multiPropertyField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("multiPropertyField"), GUIContent.none);

            EditorGUI.MultiPropertyField(position, subLabels, valuesIterator);
        }

        public Color ColorField(Rect position, Color value)
        {
            if (!stylesDict.ContainsKey("ColorField"))
                stylesDict.Add("ColorField", new StyleWrapper(EditorStyles.colorField, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.colorField, GUIContent.none);

            return EditorGUI.ColorField(position, value);
        }

        public Color ColorField(Rect position, string label, Color value)
        {
            if (!stylesDict.ContainsKey("ColorField"))
                stylesDict.Add("ColorField", new StyleWrapper(EditorStyles.colorField, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.colorField, label);

            return EditorGUI.ColorField(position, label, value);
        }

        public Color ColorField(Rect position, GUIContent label, Color value)
        {
            if (!stylesDict.ContainsKey("ColorField"))
                stylesDict.Add("ColorField", new StyleWrapper(EditorStyles.colorField, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.colorField, label);

            return EditorGUI.ColorField(position, label, value);
        }

        public Color ColorField(Rect position, GUIContent label, Color value, bool showEyedropper, bool showAlpha, bool hdr, ColorPickerHDRConfig hdrConfig)
        {
            if (!stylesDict.ContainsKey("ColorField"))
                stylesDict.Add("ColorField", new StyleWrapper(EditorStyles.colorField, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.colorField, label);

            return EditorGUI.ColorField(position, label, value, showEyedropper, showAlpha, hdr, hdrConfig);
        }

        public Color ColorField(Rect position, GUIContent label, Color value, bool showEyedropper, bool showAlpha, bool hdr)
        {
            if (!stylesDict.ContainsKey("ColorField"))
                stylesDict.Add("ColorField", new StyleWrapper(EditorStyles.colorField, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.colorField, label);

            return EditorGUI.ColorField(position, label, value, showEyedropper, showAlpha, hdr);
        }

        public AnimationCurve CurveField(Rect position, AnimationCurve value)
        {
            if (!stylesDict.ContainsKey("CurveField"))
                stylesDict.Add("CurveField", new StyleWrapper(new GUIStyle("curveField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("curveField"), GUIContent.none);

            return EditorGUI.CurveField(position, value);
        }

        public AnimationCurve CurveField(Rect position, string label, AnimationCurve value)
        {
            if (!stylesDict.ContainsKey("CurveField"))
                stylesDict.Add("CurveField", new StyleWrapper(new GUIStyle("curveField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("curveField"), label);

            return EditorGUI.CurveField(position, label, value);
        }

        public AnimationCurve CurveField(Rect position, GUIContent label, AnimationCurve value)
        {
            if (!stylesDict.ContainsKey("CurveField"))
                stylesDict.Add("CurveField", new StyleWrapper(new GUIStyle("curveField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("curveField"), label);

            return EditorGUI.CurveField(position, label, value);
        }

        public AnimationCurve CurveField(Rect position, AnimationCurve value, Color color, Rect ranges)
        {
            if (!stylesDict.ContainsKey("CurveField"))
                stylesDict.Add("CurveField", new StyleWrapper(new GUIStyle("curveField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("curveField"), GUIContent.none);

            return EditorGUI.CurveField(position, value, color, ranges);
        }

        public AnimationCurve CurveField(Rect position, string label, AnimationCurve value, Color color, Rect ranges)
        {
            if (!stylesDict.ContainsKey("CurveField"))
                stylesDict.Add("CurveField", new StyleWrapper(new GUIStyle("curveField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("curveField"), label);

            return EditorGUI.CurveField(position, label, value, color, ranges);
        }

        public AnimationCurve CurveField(Rect position, GUIContent label, AnimationCurve value, Color color, Rect ranges)
        {
            if (!stylesDict.ContainsKey("CurveField"))
                stylesDict.Add("CurveField", new StyleWrapper(new GUIStyle("curveField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("curveField"), label);

            return EditorGUI.CurveField(position, label, value, color, ranges);
        }

        public void CurveField(Rect position, SerializedProperty property, Color color, Rect ranges)
        {
            if (!stylesDict.ContainsKey("CurveField"))
                stylesDict.Add("CurveField", new StyleWrapper(new GUIStyle("curveField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("curveField"), GUIContent.none);

            EditorGUI.CurveField(position, property, color, ranges);
        }

        public void CurveField(Rect position, SerializedProperty property, Color color, Rect ranges, GUIContent label)
        {
            if (!stylesDict.ContainsKey("CurveField"))
                stylesDict.Add("CurveField", new StyleWrapper(new GUIStyle("curveField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("curveField"), label);

            EditorGUI.CurveField(position, property, color, ranges, label);
        }

        public void InspectorTitlebar(Rect position, Object[] targetObjs)
        {
            throw new Exception("This method isn't supported!");
        }

        public bool InspectorTitlebar(Rect position, bool foldout, Object targetObj, bool expandable)
        {
            throw new Exception("This method isn't supported!");
        }

        public bool InspectorTitlebar(Rect position, bool foldout, Object[] targetObjs, bool expandable)
        {
            throw new Exception("This method isn't supported!");
        }

        public bool InspectorTitlebar(Rect position, bool foldout, Editor editor)
        {
            throw new Exception("This method isn't supported!");
        }

        public void ProgressBar(Rect position, float value, string text)
        {
            if (!stylesDict.ContainsKey("ProgressBar"))
                stylesDict.Add("ProgressBar", new StyleWrapper(new GUIStyle("progressBar"), text));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("progressBar"), text);

            EditorGUI.ProgressBar(position, value, text);
        }

        public void HelpBox(Rect position, string message, MessageType type)
        {
            if (!stylesDict.ContainsKey("HelpBox"))
                stylesDict.Add("HelpBox", new StyleWrapper(EditorStyles.helpBox, message));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.helpBox, message);

            EditorGUI.HelpBox(position, message, type);
        }

        public Rect PrefixLabel(Rect totalPosition, GUIContent label)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("PrefixLabel"))
                stylesDict.Add("PrefixLabel", new StyleWrapper(new GUIStyle("prefixLabel"), label));

            return EditorGUI.PrefixLabel(totalPosition, label);
        }

        public Rect PrefixLabel(Rect totalPosition, GUIContent label, GUIStyle style)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("PrefixLabel"))
                stylesDict.Add("PrefixLabel", new StyleWrapper(style, label));

            return EditorGUI.PrefixLabel(totalPosition, label, style);
        }

        public Rect PrefixLabel(Rect totalPosition, int id, GUIContent label)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("PrefixLabel"))
                stylesDict.Add("PrefixLabel", new StyleWrapper(new GUIStyle("prefixLabel"), label));

            return EditorGUI.PrefixLabel(totalPosition, id, label);
        }

        public Rect PrefixLabel(Rect totalPosition, int id, GUIContent label, GUIStyle style)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("PrefixLabel"))
                stylesDict.Add("PrefixLabel", new StyleWrapper(style, label));

            return EditorGUI.PrefixLabel(totalPosition, id, label, style);
        }

        public GUIContent BeginProperty(Rect totalPosition, GUIContent label, SerializedProperty property)
        {
            throw new Exception("This method isn't supported!");
        }

        public float GetPropertyHeight(SerializedPropertyType type, GUIContent label)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("GetPropertyHeight"))
                stylesDict.Add("GetPropertyHeight", new StyleWrapper(new GUIStyle("getPropertyHeight"), label));

            return EditorGUI.GetPropertyHeight(type, label);
        }

        public bool CanCacheInspectorGUI(SerializedProperty property)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("CanCacheInspectorGUI"))
                stylesDict.Add("CanCacheInspectorGUI", new StyleWrapper(new GUIStyle("canCacheInspectorGUI"), GUIContent.none));

            return EditorGUI.CanCacheInspectorGUI(property);
        }

        public bool DropdownButton(Rect position, GUIContent content, FocusType focusType)
        {
            if (!stylesDict.ContainsKey("DropdownButton"))
                stylesDict.Add("DropdownButton", new StyleWrapper(new GUIStyle("dropdownButton"), content));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("dropdownButton"), content);

            return EditorGUI.DropdownButton(position, content, focusType);
        }

        public bool DropdownButton(Rect position, GUIContent content, FocusType focusType, GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DropdownButton"))
                stylesDict.Add("DropdownButton", new StyleWrapper(style, content));

            Rect lastPosition = _position;
            UpdatePosition(style, content);

            return EditorGUI.DropdownButton(position, content, focusType, style);
        }

        public void DrawTextureAlpha(Rect position, Texture image, [DefaultValue("ScaleMode.StretchToFill")] ScaleMode scaleMode, [DefaultValue("0")] float imageAspect, [DefaultValue("-1")] float mipLevel)
        {
            if (!stylesDict.ContainsKey("DrawTextureAlpha"))
                stylesDict.Add("DrawTextureAlpha", new StyleWrapper(new GUIStyle("drawTextureAlpha"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("drawTextureAlpha"), GUIContent.none);

            EditorGUI.DrawTextureAlpha(position, image, scaleMode, imageAspect, mipLevel);
        }

        public void DrawTextureAlpha(Rect position, Texture image)
        {
            if (!stylesDict.ContainsKey("DrawTextureAlpha"))
                stylesDict.Add("DrawTextureAlpha", new StyleWrapper(new GUIStyle("drawTextureAlpha"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("drawTextureAlpha"), GUIContent.none);

            EditorGUI.DrawTextureAlpha(position, image);
        }

        public void DrawTextureAlpha(Rect position, Texture image, ScaleMode scaleMode)
        {
            if (!stylesDict.ContainsKey("DrawTextureAlpha"))
                stylesDict.Add("DrawTextureAlpha", new StyleWrapper(new GUIStyle("drawTextureAlpha"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("drawTextureAlpha"), GUIContent.none);

            EditorGUI.DrawTextureAlpha(position, image, scaleMode);
        }

        public void DrawTextureAlpha(Rect position, Texture image, ScaleMode scaleMode, float imageAspect)
        {
            if (!stylesDict.ContainsKey("DrawTextureAlpha"))
                stylesDict.Add("DrawTextureAlpha", new StyleWrapper(new GUIStyle("drawTextureAlpha"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("drawTextureAlpha"), GUIContent.none);

            EditorGUI.DrawTextureAlpha(position, image, scaleMode, imageAspect);
        }

        public void DrawTextureTransparent(Rect position, Texture image, [DefaultValue("ScaleMode.StretchToFill")] ScaleMode scaleMode, [DefaultValue("0")] float imageAspect, [DefaultValue("-1")] float mipLevel, [DefaultValue("ColorWriteMask.All")] ColorWriteMask colorWriteMask)
        {
            if (!stylesDict.ContainsKey("DrawTextureTransparent"))
                stylesDict.Add("DrawTextureTransparent", new StyleWrapper(new GUIStyle("drawTextureTransparent"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("drawTextureTransparent"), GUIContent.none);

            // This call has the following (1) unsupported params (an implementation is required): colorWriteMask
            EditorGUI.DrawTextureTransparent(position, image, scaleMode, imageAspect, mipLevel);
        }

        public void DrawTextureTransparent(Rect position, Texture image, ScaleMode scaleMode)
        {
            throw new Exception("This method isn't supported!");
        }

        public void DrawTextureTransparent(Rect position, Texture image)
        {
            throw new Exception("This method isn't supported!");
        }

        public void DrawTextureTransparent(Rect position, Texture image, ScaleMode scaleMode, float imageAspect)
        {
            throw new Exception("This method isn't supported!");
        }

        public void DrawTextureTransparent(Rect position, Texture image, ScaleMode scaleMode, float imageAspect, float mipLevel)
        {
            throw new Exception("This method isn't supported!");
        }

        public void DrawPreviewTexture(Rect position, Texture image, Material mat, ScaleMode scaleMode, float imageAspect, float mipLevel)
        {
            if (!stylesDict.ContainsKey("DrawPreviewTexture"))
                stylesDict.Add("DrawPreviewTexture", new StyleWrapper(new GUIStyle("drawPreviewTexture"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("drawPreviewTexture"), GUIContent.none);

            EditorGUI.DrawPreviewTexture(position, image, mat, scaleMode, imageAspect, mipLevel);
        }

        public void DrawPreviewTexture(Rect position, Texture image, Material mat, ScaleMode scaleMode, float imageAspect)
        {
            if (!stylesDict.ContainsKey("DrawPreviewTexture"))
                stylesDict.Add("DrawPreviewTexture", new StyleWrapper(new GUIStyle("drawPreviewTexture"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("drawPreviewTexture"), GUIContent.none);

            EditorGUI.DrawPreviewTexture(position, image, mat, scaleMode, imageAspect);
        }

        public void DrawPreviewTexture(Rect position, Texture image, Material mat, ScaleMode scaleMode)
        {
            if (!stylesDict.ContainsKey("DrawPreviewTexture"))
                stylesDict.Add("DrawPreviewTexture", new StyleWrapper(new GUIStyle("drawPreviewTexture"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("drawPreviewTexture"), GUIContent.none);

            EditorGUI.DrawPreviewTexture(position, image, mat, scaleMode);
        }

        public void DrawPreviewTexture(Rect position, Texture image, Material mat)
        {
            if (!stylesDict.ContainsKey("DrawPreviewTexture"))
                stylesDict.Add("DrawPreviewTexture", new StyleWrapper(new GUIStyle("drawPreviewTexture"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("drawPreviewTexture"), GUIContent.none);

            EditorGUI.DrawPreviewTexture(position, image, mat);
        }

        public void DrawPreviewTexture(Rect position, Texture image)
        {
            if (!stylesDict.ContainsKey("DrawPreviewTexture"))
                stylesDict.Add("DrawPreviewTexture", new StyleWrapper(new GUIStyle("drawPreviewTexture"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("drawPreviewTexture"), GUIContent.none);

            EditorGUI.DrawPreviewTexture(position, image);
        }

        public void LabelField(Rect position, string label)
        {
            if (!stylesDict.ContainsKey("LabelField"))
                stylesDict.Add("LabelField", new StyleWrapper(new GUIStyle("labelField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("labelField"), label);

            EditorGUI.LabelField(position, label);
        }

        public void LabelField(Rect position, string label, [DefaultValue("EditorStyles.label")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("LabelField"))
                stylesDict.Add("LabelField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            EditorGUI.LabelField(position, label, style);
        }

        public void LabelField(Rect position, GUIContent label)
        {
            if (!stylesDict.ContainsKey("LabelField"))
                stylesDict.Add("LabelField", new StyleWrapper(new GUIStyle("labelField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("labelField"), label);

            EditorGUI.LabelField(position, label);
        }

        public void LabelField(Rect position, GUIContent label, [DefaultValue("EditorStyles.label")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("LabelField"))
                stylesDict.Add("LabelField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            EditorGUI.LabelField(position, label, style);
        }

        public void LabelField(Rect position, string label, string label2)
        {
            if (!stylesDict.ContainsKey("LabelField"))
                stylesDict.Add("LabelField", new StyleWrapper(new GUIStyle("labelField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("labelField"), label);

            EditorGUI.LabelField(position, label, label2);
        }

        public void LabelField(Rect position, string label, string label2, [DefaultValue("EditorStyles.label")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("LabelField"))
                stylesDict.Add("LabelField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            EditorGUI.LabelField(position, label, label2, style);
        }

        public void LabelField(Rect position, GUIContent label, GUIContent label2)
        {
            if (!stylesDict.ContainsKey("LabelField"))
                stylesDict.Add("LabelField", new StyleWrapper(new GUIStyle("labelField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("labelField"), label);

            EditorGUI.LabelField(position, label, label2);
        }

        public void LabelField(Rect position, GUIContent label, GUIContent label2, [DefaultValue("EditorStyles.label")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("LabelField"))
                stylesDict.Add("LabelField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            EditorGUI.LabelField(position, label, label2, style);
        }

        public bool ToggleLeft(Rect position, string label, bool value)
        {
            if (!stylesDict.ContainsKey("ToggleLeft"))
                stylesDict.Add("ToggleLeft", new StyleWrapper(new GUIStyle("toggleLeft"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("toggleLeft"), label);

            return EditorGUI.ToggleLeft(position, label, value);
        }

        public bool ToggleLeft(Rect position, string label, bool value, [DefaultValue("EditorStyles.label")] GUIStyle labelStyle)
        {
            if (!stylesDict.ContainsKey("ToggleLeft"))
                stylesDict.Add("ToggleLeft", new StyleWrapper(new GUIStyle("toggleLeft"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("toggleLeft"), label);

            return EditorGUI.ToggleLeft(position, label, value, labelStyle);
        }

        public bool ToggleLeft(Rect position, GUIContent label, bool value)
        {
            if (!stylesDict.ContainsKey("ToggleLeft"))
                stylesDict.Add("ToggleLeft", new StyleWrapper(new GUIStyle("toggleLeft"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("toggleLeft"), label);

            return EditorGUI.ToggleLeft(position, label, value);
        }

        public bool ToggleLeft(Rect position, GUIContent label, bool value, [DefaultValue("EditorStyles.label")] GUIStyle labelStyle)
        {
            if (!stylesDict.ContainsKey("ToggleLeft"))
                stylesDict.Add("ToggleLeft", new StyleWrapper(new GUIStyle("toggleLeft"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("toggleLeft"), label);

            return EditorGUI.ToggleLeft(position, label, value, labelStyle);
        }

        public string TextField(Rect position, string text)
        {
            if (!stylesDict.ContainsKey("TextField"))
                stylesDict.Add("TextField", new StyleWrapper(EditorStyles.textField, text));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.textField, text);

            return EditorGUI.TextField(position, text);
        }

        public string TextField(Rect position, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("TextField"))
                stylesDict.Add("TextField", new StyleWrapper(style, text));

            Rect lastPosition = _position;
            UpdatePosition(style, text);

            return EditorGUI.TextField(position, text, style);
        }

        public string TextField(Rect position, string label, string text)
        {
            if (!stylesDict.ContainsKey("TextField"))
                stylesDict.Add("TextField", new StyleWrapper(EditorStyles.textField, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.textField, label);

            return EditorGUI.TextField(position, label, text);
        }

        public string TextField(Rect position, string label, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("TextField"))
                stylesDict.Add("TextField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.TextField(position, label, text, style);
        }

        public string TextField(Rect position, GUIContent label, string text)
        {
            if (!stylesDict.ContainsKey("TextField"))
                stylesDict.Add("TextField", new StyleWrapper(EditorStyles.textField, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.textField, label);

            return EditorGUI.TextField(position, label, text);
        }

        public string TextField(Rect position, GUIContent label, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("TextField"))
                stylesDict.Add("TextField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.TextField(position, label, text, style);
        }

        public string DelayedTextField(Rect position, string text)
        {
            if (!stylesDict.ContainsKey("DelayedTextField"))
                stylesDict.Add("DelayedTextField", new StyleWrapper(new GUIStyle("delayedTextField"), text));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedTextField"), text);

            return EditorGUI.DelayedTextField(position, text);
        }

        public string DelayedTextField(Rect position, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedTextField"))
                stylesDict.Add("DelayedTextField", new StyleWrapper(style, text));

            Rect lastPosition = _position;
            UpdatePosition(style, text);

            return EditorGUI.DelayedTextField(position, text, style);
        }

        public string DelayedTextField(Rect position, string label, string text)
        {
            if (!stylesDict.ContainsKey("DelayedTextField"))
                stylesDict.Add("DelayedTextField", new StyleWrapper(new GUIStyle("delayedTextField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedTextField"), label);

            return EditorGUI.DelayedTextField(position, label, text);
        }

        public string DelayedTextField(Rect position, string label, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedTextField"))
                stylesDict.Add("DelayedTextField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.DelayedTextField(position, label, text, style);
        }

        public string DelayedTextField(Rect position, GUIContent label, string text)
        {
            if (!stylesDict.ContainsKey("DelayedTextField"))
                stylesDict.Add("DelayedTextField", new StyleWrapper(new GUIStyle("delayedTextField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedTextField"), label);

            return EditorGUI.DelayedTextField(position, label, text);
        }

        public string DelayedTextField(Rect position, GUIContent label, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedTextField"))
                stylesDict.Add("DelayedTextField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.DelayedTextField(position, label, text, style);
        }

        public void DelayedTextField(Rect position, SerializedProperty property)
        {
            if (!stylesDict.ContainsKey("DelayedTextField"))
                stylesDict.Add("DelayedTextField", new StyleWrapper(new GUIStyle("delayedTextField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedTextField"), GUIContent.none);

            EditorGUI.DelayedTextField(position, property);
        }

        public void DelayedTextField(Rect position, SerializedProperty property, [DefaultValue("null")] GUIContent label)
        {
            if (!stylesDict.ContainsKey("DelayedTextField"))
                stylesDict.Add("DelayedTextField", new StyleWrapper(new GUIStyle("delayedTextField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedTextField"), label);

            EditorGUI.DelayedTextField(position, property, label);
        }

        public string DelayedTextField(Rect position, GUIContent label, int controlId, string text)
        {
            if (!stylesDict.ContainsKey("DelayedTextField"))
                stylesDict.Add("DelayedTextField", new StyleWrapper(new GUIStyle("delayedTextField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedTextField"), label);

            return EditorGUI.DelayedTextField(position, label, controlId, text);
        }

        public string DelayedTextField(Rect position, GUIContent label, int controlId, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedTextField"))
                stylesDict.Add("DelayedTextField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.DelayedTextField(position, label, controlId, text, style);
        }

        public string TextArea(Rect position, string text)
        {
            if (!stylesDict.ContainsKey("TextArea"))
                stylesDict.Add("TextArea", new StyleWrapper(EditorStyles.textArea, text));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.textArea, text);

            return EditorGUI.TextArea(position, text);
        }

        public string TextArea(Rect position, string text, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("TextArea"))
                stylesDict.Add("TextArea", new StyleWrapper(style, text));

            Rect lastPosition = _position;
            UpdatePosition(style, text);

            return EditorGUI.TextArea(position, text, style);
        }

        public void SelectableLabel(Rect position, string text)
        {
            if (!stylesDict.ContainsKey("SelectableLabel"))
                stylesDict.Add("SelectableLabel", new StyleWrapper(new GUIStyle("selectableLabel"), text));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("selectableLabel"), text);

            EditorGUI.SelectableLabel(position, text);
        }

        public void SelectableLabel(Rect position, string text, [DefaultValue("EditorStyles.label")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("SelectableLabel"))
                stylesDict.Add("SelectableLabel", new StyleWrapper(style, text));

            Rect lastPosition = _position;
            UpdatePosition(style, text);

            EditorGUI.SelectableLabel(position, text, style);
        }

        public string PasswordField(Rect position, string password)
        {
            if (!stylesDict.ContainsKey("PasswordField"))
                stylesDict.Add("PasswordField", new StyleWrapper(new GUIStyle("passwordField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("passwordField"), GUIContent.none);

            return EditorGUI.PasswordField(position, password);
        }

        public string PasswordField(Rect position, string password, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("PasswordField"))
                stylesDict.Add("PasswordField", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.PasswordField(position, password, style);
        }

        public string PasswordField(Rect position, string label, string password)
        {
            if (!stylesDict.ContainsKey("PasswordField"))
                stylesDict.Add("PasswordField", new StyleWrapper(new GUIStyle("passwordField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("passwordField"), label);

            return EditorGUI.PasswordField(position, label, password);
        }

        public string PasswordField(Rect position, string label, string password, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("PasswordField"))
                stylesDict.Add("PasswordField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.PasswordField(position, label, password, style);
        }

        public string PasswordField(Rect position, GUIContent label, string password)
        {
            if (!stylesDict.ContainsKey("PasswordField"))
                stylesDict.Add("PasswordField", new StyleWrapper(new GUIStyle("passwordField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("passwordField"), label);

            return EditorGUI.PasswordField(position, label, password);
        }

        public string PasswordField(Rect position, GUIContent label, string password, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("PasswordField"))
                stylesDict.Add("PasswordField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.PasswordField(position, label, password, style);
        }

        public float FloatField(Rect position, float value)
        {
            if (!stylesDict.ContainsKey("FloatField"))
                stylesDict.Add("FloatField", new StyleWrapper(new GUIStyle("floatField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("floatField"), GUIContent.none);

            return EditorGUI.FloatField(position, value);
        }

        public float FloatField(Rect position, float value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("FloatField"))
                stylesDict.Add("FloatField", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.FloatField(position, value, style);
        }

        public float FloatField(Rect position, string label, float value)
        {
            if (!stylesDict.ContainsKey("FloatField"))
                stylesDict.Add("FloatField", new StyleWrapper(new GUIStyle("floatField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("floatField"), label);

            return EditorGUI.FloatField(position, label, value);
        }

        public float FloatField(Rect position, string label, float value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("FloatField"))
                stylesDict.Add("FloatField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.FloatField(position, label, value, style);
        }

        public float FloatField(Rect position, GUIContent label, float value)
        {
            if (!stylesDict.ContainsKey("FloatField"))
                stylesDict.Add("FloatField", new StyleWrapper(new GUIStyle("floatField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("floatField"), label);

            return EditorGUI.FloatField(position, label, value);
        }

        public float FloatField(Rect position, GUIContent label, float value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("FloatField"))
                stylesDict.Add("FloatField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.FloatField(position, label, value, style);
        }

        public float DelayedFloatField(Rect position, float value)
        {
            if (!stylesDict.ContainsKey("DelayedFloatField"))
                stylesDict.Add("DelayedFloatField", new StyleWrapper(new GUIStyle("delayedFloatField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedFloatField"), GUIContent.none);

            return EditorGUI.DelayedFloatField(position, value);
        }

        public float DelayedFloatField(Rect position, float value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedFloatField"))
                stylesDict.Add("DelayedFloatField", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.DelayedFloatField(position, value, style);
        }

        public float DelayedFloatField(Rect position, string label, float value)
        {
            if (!stylesDict.ContainsKey("DelayedFloatField"))
                stylesDict.Add("DelayedFloatField", new StyleWrapper(new GUIStyle("delayedFloatField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedFloatField"), label);

            return EditorGUI.DelayedFloatField(position, label, value);
        }

        public float DelayedFloatField(Rect position, string label, float value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedFloatField"))
                stylesDict.Add("DelayedFloatField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.DelayedFloatField(position, label, value, style);
        }

        public float DelayedFloatField(Rect position, GUIContent label, float value)
        {
            if (!stylesDict.ContainsKey("DelayedFloatField"))
                stylesDict.Add("DelayedFloatField", new StyleWrapper(new GUIStyle("delayedFloatField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedFloatField"), label);

            return EditorGUI.DelayedFloatField(position, label, value);
        }

        public float DelayedFloatField(Rect position, GUIContent label, float value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedFloatField"))
                stylesDict.Add("DelayedFloatField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.DelayedFloatField(position, label, value, style);
        }

        public void DelayedFloatField(Rect position, SerializedProperty property)
        {
            if (!stylesDict.ContainsKey("DelayedFloatField"))
                stylesDict.Add("DelayedFloatField", new StyleWrapper(new GUIStyle("delayedFloatField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedFloatField"), GUIContent.none);

            EditorGUI.DelayedFloatField(position, property);
        }

        public void DelayedFloatField(Rect position, SerializedProperty property, [DefaultValue("null")] GUIContent label)
        {
            if (!stylesDict.ContainsKey("DelayedFloatField"))
                stylesDict.Add("DelayedFloatField", new StyleWrapper(new GUIStyle("delayedFloatField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedFloatField"), label);

            EditorGUI.DelayedFloatField(position, property, label);
        }

        public double DoubleField(Rect position, double value)
        {
            if (!stylesDict.ContainsKey("DoubleField"))
                stylesDict.Add("DoubleField", new StyleWrapper(new GUIStyle("doubleField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("doubleField"), GUIContent.none);

            return EditorGUI.DoubleField(position, value);
        }

        public double DoubleField(Rect position, double value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DoubleField"))
                stylesDict.Add("DoubleField", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.DoubleField(position, value, style);
        }

        public double DoubleField(Rect position, string label, double value)
        {
            if (!stylesDict.ContainsKey("DoubleField"))
                stylesDict.Add("DoubleField", new StyleWrapper(new GUIStyle("doubleField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("doubleField"), label);

            return EditorGUI.DoubleField(position, label, value);
        }

        public double DoubleField(Rect position, string label, double value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DoubleField"))
                stylesDict.Add("DoubleField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.DoubleField(position, label, value, style);
        }

        public double DoubleField(Rect position, GUIContent label, double value)
        {
            if (!stylesDict.ContainsKey("DoubleField"))
                stylesDict.Add("DoubleField", new StyleWrapper(new GUIStyle("doubleField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("doubleField"), label);

            return EditorGUI.DoubleField(position, label, value);
        }

        public double DoubleField(Rect position, GUIContent label, double value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DoubleField"))
                stylesDict.Add("DoubleField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.DoubleField(position, label, value, style);
        }

        public double DelayedDoubleField(Rect position, double value)
        {
            if (!stylesDict.ContainsKey("DelayedDoubleField"))
                stylesDict.Add("DelayedDoubleField", new StyleWrapper(new GUIStyle("delayedDoubleField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedDoubleField"), GUIContent.none);

            return EditorGUI.DelayedDoubleField(position, value);
        }

        public double DelayedDoubleField(Rect position, double value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedDoubleField"))
                stylesDict.Add("DelayedDoubleField", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.DelayedDoubleField(position, value, style);
        }

        public double DelayedDoubleField(Rect position, string label, double value)
        {
            if (!stylesDict.ContainsKey("DelayedDoubleField"))
                stylesDict.Add("DelayedDoubleField", new StyleWrapper(new GUIStyle("delayedDoubleField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedDoubleField"), label);

            return EditorGUI.DelayedDoubleField(position, label, value);
        }

        public double DelayedDoubleField(Rect position, string label, double value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedDoubleField"))
                stylesDict.Add("DelayedDoubleField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.DelayedDoubleField(position, label, value, style);
        }

        public double DelayedDoubleField(Rect position, GUIContent label, double value)
        {
            if (!stylesDict.ContainsKey("DelayedDoubleField"))
                stylesDict.Add("DelayedDoubleField", new StyleWrapper(new GUIStyle("delayedDoubleField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedDoubleField"), label);

            return EditorGUI.DelayedDoubleField(position, label, value);
        }

        public double DelayedDoubleField(Rect position, GUIContent label, double value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedDoubleField"))
                stylesDict.Add("DelayedDoubleField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.DelayedDoubleField(position, label, value, style);
        }

        public int IntField(Rect position, int value)
        {
            if (!stylesDict.ContainsKey("IntField"))
                stylesDict.Add("IntField", new StyleWrapper(new GUIStyle("intField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intField"), GUIContent.none);

            return EditorGUI.IntField(position, value);
        }

        public int IntField(Rect position, int value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("IntField"))
                stylesDict.Add("IntField", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.IntField(position, value, style);
        }

        public int IntField(Rect position, string label, int value)
        {
            if (!stylesDict.ContainsKey("IntField"))
                stylesDict.Add("IntField", new StyleWrapper(new GUIStyle("intField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intField"), label);

            return EditorGUI.IntField(position, label, value);
        }

        public int IntField(Rect position, string label, int value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("IntField"))
                stylesDict.Add("IntField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.IntField(position, label, value, style);
        }

        public int IntField(Rect position, GUIContent label, int value)
        {
            if (!stylesDict.ContainsKey("IntField"))
                stylesDict.Add("IntField", new StyleWrapper(new GUIStyle("intField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intField"), label);

            return EditorGUI.IntField(position, label, value);
        }

        public int IntField(Rect position, GUIContent label, int value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("IntField"))
                stylesDict.Add("IntField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.IntField(position, label, value, style);
        }

        public int DelayedIntField(Rect position, int value)
        {
            if (!stylesDict.ContainsKey("DelayedIntField"))
                stylesDict.Add("DelayedIntField", new StyleWrapper(new GUIStyle("delayedIntField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedIntField"), GUIContent.none);

            return EditorGUI.DelayedIntField(position, value);
        }

        public int DelayedIntField(Rect position, int value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedIntField"))
                stylesDict.Add("DelayedIntField", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.DelayedIntField(position, value, style);
        }

        public int DelayedIntField(Rect position, string label, int value)
        {
            if (!stylesDict.ContainsKey("DelayedIntField"))
                stylesDict.Add("DelayedIntField", new StyleWrapper(new GUIStyle("delayedIntField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedIntField"), label);

            return EditorGUI.DelayedIntField(position, label, value);
        }

        public int DelayedIntField(Rect position, string label, int value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedIntField"))
                stylesDict.Add("DelayedIntField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.DelayedIntField(position, label, value, style);
        }

        public int DelayedIntField(Rect position, GUIContent label, int value)
        {
            if (!stylesDict.ContainsKey("DelayedIntField"))
                stylesDict.Add("DelayedIntField", new StyleWrapper(new GUIStyle("delayedIntField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedIntField"), label);

            return EditorGUI.DelayedIntField(position, label, value);
        }

        public int DelayedIntField(Rect position, GUIContent label, int value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("DelayedIntField"))
                stylesDict.Add("DelayedIntField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.DelayedIntField(position, label, value, style);
        }

        public void DelayedIntField(Rect position, SerializedProperty property)
        {
            if (!stylesDict.ContainsKey("DelayedIntField"))
                stylesDict.Add("DelayedIntField", new StyleWrapper(new GUIStyle("delayedIntField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedIntField"), GUIContent.none);

            EditorGUI.DelayedIntField(position, property);
        }

        public void DelayedIntField(Rect position, SerializedProperty property, [DefaultValue("null")] GUIContent label)
        {
            if (!stylesDict.ContainsKey("DelayedIntField"))
                stylesDict.Add("DelayedIntField", new StyleWrapper(new GUIStyle("delayedIntField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedIntField"), label);

            EditorGUI.DelayedIntField(position, property, label);
        }

        public long LongField(Rect position, long value)
        {
            if (!stylesDict.ContainsKey("LongField"))
                stylesDict.Add("LongField", new StyleWrapper(new GUIStyle("longField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("longField"), GUIContent.none);

            return EditorGUI.LongField(position, value);
        }

        public long LongField(Rect position, long value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("LongField"))
                stylesDict.Add("LongField", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.LongField(position, value, style);
        }

        public long LongField(Rect position, string label, long value)
        {
            if (!stylesDict.ContainsKey("LongField"))
                stylesDict.Add("LongField", new StyleWrapper(new GUIStyle("longField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("longField"), label);

            return EditorGUI.LongField(position, label, value);
        }

        public long LongField(Rect position, string label, long value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("LongField"))
                stylesDict.Add("LongField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.LongField(position, label, value, style);
        }

        public long LongField(Rect position, GUIContent label, long value)
        {
            if (!stylesDict.ContainsKey("LongField"))
                stylesDict.Add("LongField", new StyleWrapper(new GUIStyle("longField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("longField"), label);

            return EditorGUI.LongField(position, label, value);
        }

        public long LongField(Rect position, GUIContent label, long value, [DefaultValue("EditorStyles.numberField")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("LongField"))
                stylesDict.Add("LongField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.LongField(position, label, value, style);
        }

        public int Popup(Rect position, int selectedIndex, string[] displayedOptions)
        {
            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(EditorStyles.popup, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.popup, GUIContent.none);

            return EditorGUI.Popup(position, selectedIndex, displayedOptions);
        }

        public int Popup(Rect position, int selectedIndex, string[] displayedOptions, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.Popup(position, selectedIndex, displayedOptions, style);
        }

        public int Popup(Rect position, int selectedIndex, GUIContent[] displayedOptions)
        {
            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(EditorStyles.popup, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.popup, GUIContent.none);

            // Couldn't add this line! (Exception: System.InvalidOperationException -- At line: 247)
            throw new Exception();
        }

        public int Popup(Rect position, int selectedIndex, GUIContent[] displayedOptions, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            // Couldn't add this line! (Exception: System.InvalidOperationException -- At line: 247)
            throw new Exception();
        }

        public int Popup(Rect position, string label, int selectedIndex, string[] displayedOptions)
        {
            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(EditorStyles.popup, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.popup, label);

            return EditorGUI.Popup(position, label, selectedIndex, displayedOptions);
        }

        public int Popup(Rect position, string label, int selectedIndex, string[] displayedOptions, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.Popup(position, label, selectedIndex, displayedOptions, style);
        }

        public int Popup(Rect position, GUIContent label, int selectedIndex, GUIContent[] displayedOptions)
        {
            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(EditorStyles.popup, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.popup, label);

            // Couldn't add this line! (Exception: System.InvalidOperationException -- At line: 247)
            throw new Exception();
        }

        public int Popup(Rect position, GUIContent label, int selectedIndex, GUIContent[] displayedOptions, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            // Couldn't add this line! (Exception: System.InvalidOperationException -- At line: 247)
            throw new Exception();
        }

        public Enum EnumPopup(Rect position, Enum selected)
        {
            if (!stylesDict.ContainsKey("EnumPopup"))
                stylesDict.Add("EnumPopup", new StyleWrapper(new GUIStyle("enumPopup"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("enumPopup"), GUIContent.none);

            return EditorGUI.EnumPopup(position, selected);
        }

        public Enum EnumPopup(Rect position, Enum selected, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("EnumPopup"))
                stylesDict.Add("EnumPopup", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.EnumPopup(position, selected, style);
        }

        public Enum EnumPopup(Rect position, string label, Enum selected)
        {
            if (!stylesDict.ContainsKey("EnumPopup"))
                stylesDict.Add("EnumPopup", new StyleWrapper(new GUIStyle("enumPopup"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("enumPopup"), label);

            return EditorGUI.EnumPopup(position, label, selected);
        }

        public Enum EnumPopup(Rect position, string label, Enum selected, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("EnumPopup"))
                stylesDict.Add("EnumPopup", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.EnumPopup(position, label, selected, style);
        }

        public Enum EnumPopup(Rect position, GUIContent label, Enum selected)
        {
            if (!stylesDict.ContainsKey("EnumPopup"))
                stylesDict.Add("EnumPopup", new StyleWrapper(new GUIStyle("enumPopup"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("enumPopup"), label);

            return EditorGUI.EnumPopup(position, label, selected);
        }

        public Enum EnumPopup(Rect position, GUIContent label, Enum selected, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("EnumPopup"))
                stylesDict.Add("EnumPopup", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.EnumPopup(position, label, selected, style);
        }

        public Enum EnumPopup(Rect position, GUIContent label, Enum selected, [DefaultValue("null")] Func<Enum, bool> checkEnabled, [DefaultValue("false")] bool includeObsolete = false, [DefaultValue("null")] GUIStyle style = null)
        {
            throw new Exception("Methods with optional attributed params aren't implemented yet!");
            /*
			if(!stylesDict.ContainsKey("EnumPopup"))
				stylesDict.Add("EnumPopup", new StyleWrapper(style, label));

			Rect lastPosition = _position;
			UpdatePosition(style, label);

			// This call has the following (2) unsupported params (an implementation is required): includeObsolete, checkEnabled
			return EditorGUI.EnumPopup(position, label, selected, style);
			*/
        }

        public int IntPopup(Rect position, int selectedValue, string[] displayedOptions, int[] optionValues)
        {
            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(new GUIStyle("intPopup"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intPopup"), GUIContent.none);

            return EditorGUI.IntPopup(position, selectedValue, displayedOptions, optionValues);
        }

        public int IntPopup(Rect position, int selectedValue, string[] displayedOptions, int[] optionValues, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.IntPopup(position, selectedValue, displayedOptions, optionValues, style);
        }

        public int IntPopup(Rect position, int selectedValue, GUIContent[] displayedOptions, int[] optionValues)
        {
            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(new GUIStyle("intPopup"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intPopup"), GUIContent.none);

            // Couldn't add this line! (Exception: System.InvalidOperationException -- At line: 247)
            throw new Exception();
        }

        public int IntPopup(Rect position, int selectedValue, GUIContent[] displayedOptions, int[] optionValues, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            // Couldn't add this line! (Exception: System.InvalidOperationException -- At line: 247)
            throw new Exception();
        }

        public int IntPopup(Rect position, GUIContent label, int selectedValue, GUIContent[] displayedOptions, int[] optionValues)
        {
            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(new GUIStyle("intPopup"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intPopup"), label);

            // Couldn't add this line! (Exception: System.InvalidOperationException -- At line: 247)
            throw new Exception();
        }

        public int IntPopup(Rect position, GUIContent label, int selectedValue, GUIContent[] displayedOptions, int[] optionValues, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            // Couldn't add this line! (Exception: System.InvalidOperationException -- At line: 247)
            throw new Exception();
        }

        public void IntPopup(Rect position, SerializedProperty property, GUIContent[] displayedOptions, int[] optionValues)
        {
            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(new GUIStyle("intPopup"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intPopup"), GUIContent.none);

            // Couldn't add this line! (Exception: System.InvalidOperationException -- At line: 247)
        }

        public void IntPopup(Rect position, SerializedProperty property, GUIContent[] displayedOptions, int[] optionValues, [DefaultValue("null")] GUIContent label)
        {
            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(new GUIStyle("intPopup"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intPopup"), label);

            // Couldn't add this line! (Exception: System.InvalidOperationException -- At line: 247)
        }

        public int IntPopup(Rect position, string label, int selectedValue, string[] displayedOptions, int[] optionValues)
        {
            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(new GUIStyle("intPopup"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intPopup"), label);

            return EditorGUI.IntPopup(position, label, selectedValue, displayedOptions, optionValues);
        }

        public int IntPopup(Rect position, string label, int selectedValue, string[] displayedOptions, int[] optionValues, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.IntPopup(position, label, selectedValue, displayedOptions, optionValues, style);
        }

        public string TagField(Rect position, string tag)
        {
            if (!stylesDict.ContainsKey("TagField"))
                stylesDict.Add("TagField", new StyleWrapper(new GUIStyle("tagField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("tagField"), GUIContent.none);

            return EditorGUI.TagField(position, tag);
        }

        public string TagField(Rect position, string tag, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("TagField"))
                stylesDict.Add("TagField", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.TagField(position, tag, style);
        }

        public string TagField(Rect position, string label, string tag)
        {
            if (!stylesDict.ContainsKey("TagField"))
                stylesDict.Add("TagField", new StyleWrapper(new GUIStyle("tagField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("tagField"), label);

            return EditorGUI.TagField(position, label, tag);
        }

        public string TagField(Rect position, string label, string tag, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("TagField"))
                stylesDict.Add("TagField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.TagField(position, label, tag, style);
        }

        public string TagField(Rect position, GUIContent label, string tag)
        {
            if (!stylesDict.ContainsKey("TagField"))
                stylesDict.Add("TagField", new StyleWrapper(new GUIStyle("tagField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("tagField"), label);

            return EditorGUI.TagField(position, label, tag);
        }

        public string TagField(Rect position, GUIContent label, string tag, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("TagField"))
                stylesDict.Add("TagField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.TagField(position, label, tag, style);
        }

        public int LayerField(Rect position, int layer)
        {
            if (!stylesDict.ContainsKey("LayerField"))
                stylesDict.Add("LayerField", new StyleWrapper(new GUIStyle("layerField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("layerField"), GUIContent.none);

            return EditorGUI.LayerField(position, layer);
        }

        public int LayerField(Rect position, int layer, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("LayerField"))
                stylesDict.Add("LayerField", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.LayerField(position, layer, style);
        }

        public int LayerField(Rect position, string label, int layer)
        {
            if (!stylesDict.ContainsKey("LayerField"))
                stylesDict.Add("LayerField", new StyleWrapper(new GUIStyle("layerField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("layerField"), label);

            return EditorGUI.LayerField(position, label, layer);
        }

        public int LayerField(Rect position, string label, int layer, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("LayerField"))
                stylesDict.Add("LayerField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.LayerField(position, label, layer, style);
        }

        public int LayerField(Rect position, GUIContent label, int layer)
        {
            if (!stylesDict.ContainsKey("LayerField"))
                stylesDict.Add("LayerField", new StyleWrapper(new GUIStyle("layerField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("layerField"), label);

            return EditorGUI.LayerField(position, label, layer);
        }

        public int LayerField(Rect position, GUIContent label, int layer, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("LayerField"))
                stylesDict.Add("LayerField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.LayerField(position, label, layer, style);
        }

        public int MaskField(Rect position, GUIContent label, int mask, string[] displayedOptions)
        {
            if (!stylesDict.ContainsKey("MaskField"))
                stylesDict.Add("MaskField", new StyleWrapper(new GUIStyle("maskField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("maskField"), label);

            return EditorGUI.MaskField(position, label, mask, displayedOptions);
        }

        public int MaskField(Rect position, GUIContent label, int mask, string[] displayedOptions, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("MaskField"))
                stylesDict.Add("MaskField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.MaskField(position, label, mask, displayedOptions, style);
        }

        public int MaskField(Rect position, string label, int mask, string[] displayedOptions)
        {
            if (!stylesDict.ContainsKey("MaskField"))
                stylesDict.Add("MaskField", new StyleWrapper(new GUIStyle("maskField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("maskField"), label);

            return EditorGUI.MaskField(position, label, mask, displayedOptions);
        }

        public int MaskField(Rect position, string label, int mask, string[] displayedOptions, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("MaskField"))
                stylesDict.Add("MaskField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.MaskField(position, label, mask, displayedOptions, style);
        }

        public int MaskField(Rect position, int mask, string[] displayedOptions)
        {
            if (!stylesDict.ContainsKey("MaskField"))
                stylesDict.Add("MaskField", new StyleWrapper(new GUIStyle("maskField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("maskField"), GUIContent.none);

            return EditorGUI.MaskField(position, mask, displayedOptions);
        }

        public int MaskField(Rect position, int mask, string[] displayedOptions, [DefaultValue("EditorStyles.popup")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("MaskField"))
                stylesDict.Add("MaskField", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.MaskField(position, mask, displayedOptions, style);
        }

        public bool Foldout(Rect position, bool foldout, string content)
        {
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(EditorStyles.foldout, content));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.foldout, content);

            return EditorGUI.Foldout(position, foldout, content);
        }

        public bool Foldout(Rect position, bool foldout, string content, [DefaultValue("EditorStyles.foldout")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(style, content));

            Rect lastPosition = _position;
            UpdatePosition(style, content);

            return EditorGUI.Foldout(position, foldout, content, style);
        }

        public bool Foldout(Rect position, bool foldout, string content, bool toggleOnLabelClick)
        {
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(EditorStyles.foldout, content));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.foldout, content);

            return EditorGUI.Foldout(position, foldout, content, toggleOnLabelClick);
        }

        public bool Foldout(Rect position, bool foldout, string content, bool toggleOnLabelClick, [DefaultValue("EditorStyles.foldout")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(style, content));

            Rect lastPosition = _position;
            UpdatePosition(style, content);

            return EditorGUI.Foldout(position, foldout, content, toggleOnLabelClick, style);
        }

        public bool Foldout(Rect position, bool foldout, GUIContent content)
        {
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(EditorStyles.foldout, content));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.foldout, content);

            return EditorGUI.Foldout(position, foldout, content);
        }

        public bool Foldout(Rect position, bool foldout, GUIContent content, [DefaultValue("EditorStyles.foldout")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(style, content));

            Rect lastPosition = _position;
            UpdatePosition(style, content);

            return EditorGUI.Foldout(position, foldout, content, style);
        }

        public bool Foldout(Rect position, bool foldout, GUIContent content, bool toggleOnLabelClick)
        {
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(EditorStyles.foldout, content));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.foldout, content);

            return EditorGUI.Foldout(position, foldout, content, toggleOnLabelClick);
        }

        public bool Foldout(Rect position, bool foldout, GUIContent content, bool toggleOnLabelClick, [DefaultValue("EditorStyles.foldout")] GUIStyle style)
        {
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(style, content));

            Rect lastPosition = _position;
            UpdatePosition(style, content);

            return EditorGUI.Foldout(position, foldout, content, toggleOnLabelClick, style);
        }

        public void HandlePrefixLabel(Rect totalPosition, Rect labelPosition, GUIContent label, int id)
        {
            throw new Exception("This method isn't supported!");
        }

        public void HandlePrefixLabel(Rect totalPosition, Rect labelPosition, GUIContent label)
        {
            throw new Exception("This method isn't supported!");
        }

        public void HandlePrefixLabel(Rect totalPosition, Rect labelPosition, GUIContent label, [DefaultValue("0")] int id, [DefaultValue("EditorStyles.label")] GUIStyle style)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("HandlePrefixLabel"))
                stylesDict.Add("HandlePrefixLabel", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            // This call has the following (1) unsupported params (an implementation is required): labelPosition
            EditorGUI.HandlePrefixLabel(lastPosition, totalPosition, label, id, style);
        }

        public float GetPropertyHeight(SerializedProperty property, bool includeChildren)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("GetPropertyHeight"))
                stylesDict.Add("GetPropertyHeight", new StyleWrapper(new GUIStyle("getPropertyHeight"), GUIContent.none));

            return EditorGUI.GetPropertyHeight(property, includeChildren);
        }

        public float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("GetPropertyHeight"))
                stylesDict.Add("GetPropertyHeight", new StyleWrapper(new GUIStyle("getPropertyHeight"), label));

            return EditorGUI.GetPropertyHeight(property, label);
        }

        public float GetPropertyHeight(SerializedProperty property)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("GetPropertyHeight"))
                stylesDict.Add("GetPropertyHeight", new StyleWrapper(new GUIStyle("getPropertyHeight"), GUIContent.none));

            return EditorGUI.GetPropertyHeight(property);
        }

        public float GetPropertyHeight(SerializedProperty property, [DefaultValue("null")] GUIContent label, [DefaultValue("true")] bool includeChildren)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("GetPropertyHeight"))
                stylesDict.Add("GetPropertyHeight", new StyleWrapper(new GUIStyle("getPropertyHeight"), label));

            return EditorGUI.GetPropertyHeight(property, label, includeChildren);
        }

        public bool PropertyField(Rect position, SerializedProperty property)
        {
            if (!stylesDict.ContainsKey("PropertyField"))
                stylesDict.Add("PropertyField", new StyleWrapper(new GUIStyle("propertyField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("propertyField"), GUIContent.none);

            return EditorGUI.PropertyField(position, property);
        }

        public bool PropertyField(Rect position, SerializedProperty property, [DefaultValue("false")] bool includeChildren)
        {
            if (!stylesDict.ContainsKey("PropertyField"))
                stylesDict.Add("PropertyField", new StyleWrapper(new GUIStyle("propertyField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("propertyField"), GUIContent.none);

            return EditorGUI.PropertyField(position, property, includeChildren);
        }

        public bool PropertyField(Rect position, SerializedProperty property, GUIContent label)
        {
            if (!stylesDict.ContainsKey("PropertyField"))
                stylesDict.Add("PropertyField", new StyleWrapper(new GUIStyle("propertyField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("propertyField"), label);

            return EditorGUI.PropertyField(position, property, label);
        }

        public bool PropertyField(Rect position, SerializedProperty property, GUIContent label, [DefaultValue("false")] bool includeChildren)
        {
            if (!stylesDict.ContainsKey("PropertyField"))
                stylesDict.Add("PropertyField", new StyleWrapper(new GUIStyle("propertyField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("propertyField"), label);

            return EditorGUI.PropertyField(position, property, label, includeChildren);
        }

        public bool Foldout(bool foldout, string content)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(EditorStyles.foldout, content));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.foldout, content);

            return EditorGUI.Foldout(lastPosition, foldout, content);
        }

        public bool Foldout(bool foldout, string content, [DefaultValue("EditorStyles.foldout")] GUIStyle style)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(style, content));

            Rect lastPosition = _position;
            UpdatePosition(style, content);

            return EditorGUI.Foldout(lastPosition, foldout, content, style);
        }

        public bool Foldout(bool foldout, GUIContent content)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(EditorStyles.foldout, content));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.foldout, content);

            return EditorGUI.Foldout(lastPosition, foldout, content);
        }

        public bool Foldout(bool foldout, GUIContent content, [DefaultValue("EditorStyles.foldout")] GUIStyle style)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(style, content));

            Rect lastPosition = _position;
            UpdatePosition(style, content);

            return EditorGUI.Foldout(lastPosition, foldout, content, style);
        }

        public bool Foldout(bool foldout, string content, bool toggleOnLabelClick)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(EditorStyles.foldout, content));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.foldout, content);

            return EditorGUI.Foldout(lastPosition, foldout, content, toggleOnLabelClick);
        }

        public bool Foldout(bool foldout, string content, bool toggleOnLabelClick, [DefaultValue("EditorStyles.foldout")] GUIStyle style)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(style, content));

            Rect lastPosition = _position;
            UpdatePosition(style, content);

            return EditorGUI.Foldout(lastPosition, foldout, content, toggleOnLabelClick, style);
        }

        public bool Foldout(bool foldout, GUIContent content, bool toggleOnLabelClick)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(EditorStyles.foldout, content));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.foldout, content);

            return EditorGUI.Foldout(lastPosition, foldout, content, toggleOnLabelClick);
        }

        public bool Foldout(bool foldout, GUIContent content, bool toggleOnLabelClick, [DefaultValue("EditorStyles.foldout")] GUIStyle style)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("Foldout"))
                stylesDict.Add("Foldout", new StyleWrapper(style, content));

            Rect lastPosition = _position;
            UpdatePosition(style, content);

            return EditorGUI.Foldout(lastPosition, foldout, content, toggleOnLabelClick, style);
        }

        public void PrefixLabel(string label)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("PrefixLabel"))
                stylesDict.Add("PrefixLabel", new StyleWrapper(new GUIStyle("prefixLabel"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("prefixLabel"), label);

            EditorGUI.PrefixLabel(lastPosition, (Converters)label);
        }

        public void PrefixLabel(string label, [DefaultValue("\"Button\"")] GUIStyle followingStyle)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("PrefixLabel"))
                stylesDict.Add("PrefixLabel", new StyleWrapper(new GUIStyle("prefixLabel"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("prefixLabel"), label);

            // This call has the following (1) unsupported params (an implementation is required): followingStyle
            EditorGUI.PrefixLabel(lastPosition, (Converters)label);
        }

        public void PrefixLabel(string label, GUIStyle followingStyle, GUIStyle labelStyle)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("PrefixLabel"))
                stylesDict.Add("PrefixLabel", new StyleWrapper(new GUIStyle("prefixLabel"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("prefixLabel"), label);

            // This call has the following (1) unsupported params (an implementation is required): followingStyle
            EditorGUI.PrefixLabel(lastPosition, (Converters)label, labelStyle);
        }

        public void PrefixLabel(GUIContent label)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("PrefixLabel"))
                stylesDict.Add("PrefixLabel", new StyleWrapper(new GUIStyle("prefixLabel"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("prefixLabel"), label);

            EditorGUI.PrefixLabel(lastPosition, label);
        }

        public void PrefixLabel(GUIContent label, [DefaultValue("\"Button\"")] GUIStyle followingStyle)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("PrefixLabel"))
                stylesDict.Add("PrefixLabel", new StyleWrapper(new GUIStyle("prefixLabel"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("prefixLabel"), label);

            // This call has the following (1) unsupported params (an implementation is required): followingStyle
            EditorGUI.PrefixLabel(lastPosition, label);
        }

        public void PrefixLabel(GUIContent label, GUIStyle followingStyle, GUIStyle labelStyle)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("PrefixLabel"))
                stylesDict.Add("PrefixLabel", new StyleWrapper(new GUIStyle("prefixLabel"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("prefixLabel"), label);

            // This call has the following (1) unsupported params (an implementation is required): followingStyle
            EditorGUI.PrefixLabel(lastPosition, label, labelStyle);
        }

        public void LabelField(string label, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("LabelField"))
                stylesDict.Add("LabelField", new StyleWrapper(new GUIStyle("labelField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("labelField"), label);

            EditorGUI.LabelField(lastPosition, label);
        }

        public void LabelField(string label, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("LabelField"))
                stylesDict.Add("LabelField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            EditorGUI.LabelField(lastPosition, label, style);
        }

        public void LabelField(GUIContent label, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("LabelField"))
                stylesDict.Add("LabelField", new StyleWrapper(new GUIStyle("labelField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("labelField"), label);

            EditorGUI.LabelField(lastPosition, label);
        }

        public void LabelField(GUIContent label, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("LabelField"))
                stylesDict.Add("LabelField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            EditorGUI.LabelField(lastPosition, label, style);
        }

        public void LabelField(string label, string label2, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("LabelField"))
                stylesDict.Add("LabelField", new StyleWrapper(new GUIStyle("labelField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("labelField"), label);

            EditorGUI.LabelField(lastPosition, label, label2);
        }

        public void LabelField(string label, string label2, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("LabelField"))
                stylesDict.Add("LabelField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            EditorGUI.LabelField(lastPosition, label, label2, style);
        }

        public void LabelField(GUIContent label, GUIContent label2, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("LabelField"))
                stylesDict.Add("LabelField", new StyleWrapper(new GUIStyle("labelField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("labelField"), label);

            EditorGUI.LabelField(lastPosition, label, label2);
        }

        public void LabelField(GUIContent label, GUIContent label2, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("LabelField"))
                stylesDict.Add("LabelField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            EditorGUI.LabelField(lastPosition, label, label2, style);
        }

        public bool Toggle(bool value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Toggle"))
                stylesDict.Add("Toggle", new StyleWrapper(EditorStyles.toggle, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.toggle, GUIContent.none);

            return EditorGUI.Toggle(lastPosition, value);
        }

        public bool Toggle(string label, bool value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Toggle"))
                stylesDict.Add("Toggle", new StyleWrapper(EditorStyles.toggle, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.toggle, label);

            return EditorGUI.Toggle(lastPosition, label, value);
        }

        public bool Toggle(GUIContent label, bool value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Toggle"))
                stylesDict.Add("Toggle", new StyleWrapper(EditorStyles.toggle, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.toggle, label);

            return EditorGUI.Toggle(lastPosition, label, value);
        }

        public bool Toggle(bool value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Toggle"))
                stylesDict.Add("Toggle", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.Toggle(lastPosition, value, style);
        }

        public bool Toggle(string label, bool value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Toggle"))
                stylesDict.Add("Toggle", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.Toggle(lastPosition, label, value, style);
        }

        public bool Toggle(GUIContent label, bool value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Toggle"))
                stylesDict.Add("Toggle", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.Toggle(lastPosition, label, value, style);
        }

        public bool ToggleLeft(string label, bool value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("ToggleLeft"))
                stylesDict.Add("ToggleLeft", new StyleWrapper(new GUIStyle("toggleLeft"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("toggleLeft"), label);

            return EditorGUI.ToggleLeft(lastPosition, label, value);
        }

        public bool ToggleLeft(GUIContent label, bool value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("ToggleLeft"))
                stylesDict.Add("ToggleLeft", new StyleWrapper(new GUIStyle("toggleLeft"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("toggleLeft"), label);

            return EditorGUI.ToggleLeft(lastPosition, label, value);
        }

        public bool ToggleLeft(string label, bool value, GUIStyle labelStyle, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("ToggleLeft"))
                stylesDict.Add("ToggleLeft", new StyleWrapper(new GUIStyle("toggleLeft"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("toggleLeft"), label);

            return EditorGUI.ToggleLeft(lastPosition, label, value, labelStyle);
        }

        public bool ToggleLeft(GUIContent label, bool value, GUIStyle labelStyle, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("ToggleLeft"))
                stylesDict.Add("ToggleLeft", new StyleWrapper(new GUIStyle("toggleLeft"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("toggleLeft"), label);

            return EditorGUI.ToggleLeft(lastPosition, label, value, labelStyle);
        }

        public string TextField(string text, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("TextField"))
                stylesDict.Add("TextField", new StyleWrapper(EditorStyles.textField, text));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.textField, text);

            return EditorGUI.TextField(lastPosition, text);
        }

        public string TextField(string text, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("TextField"))
                stylesDict.Add("TextField", new StyleWrapper(style, text));

            Rect lastPosition = _position;
            UpdatePosition(style, text);

            return EditorGUI.TextField(lastPosition, text, style);
        }

        public string TextField(string label, string text, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("TextField"))
                stylesDict.Add("TextField", new StyleWrapper(EditorStyles.textField, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.textField, label);

            return EditorGUI.TextField(lastPosition, label, text);
        }

        public string TextField(string label, string text, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("TextField"))
                stylesDict.Add("TextField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.TextField(lastPosition, label, text, style);
        }

        public string TextField(GUIContent label, string text, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("TextField"))
                stylesDict.Add("TextField", new StyleWrapper(EditorStyles.textField, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.textField, label);

            return EditorGUI.TextField(lastPosition, label, text);
        }

        public string TextField(GUIContent label, string text, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("TextField"))
                stylesDict.Add("TextField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.TextField(lastPosition, label, text, style);
        }

        public string DelayedTextField(string text, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedTextField"))
                stylesDict.Add("DelayedTextField", new StyleWrapper(new GUIStyle("delayedTextField"), text));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedTextField"), text);

            return EditorGUI.DelayedTextField(lastPosition, text);
        }

        public string DelayedTextField(string text, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedTextField"))
                stylesDict.Add("DelayedTextField", new StyleWrapper(style, text));

            Rect lastPosition = _position;
            UpdatePosition(style, text);

            return EditorGUI.DelayedTextField(lastPosition, text, style);
        }

        public string DelayedTextField(string label, string text, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedTextField"))
                stylesDict.Add("DelayedTextField", new StyleWrapper(new GUIStyle("delayedTextField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedTextField"), label);

            return EditorGUI.DelayedTextField(lastPosition, label, text);
        }

        public string DelayedTextField(string label, string text, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedTextField"))
                stylesDict.Add("DelayedTextField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.DelayedTextField(lastPosition, label, text, style);
        }

        public string DelayedTextField(GUIContent label, string text, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedTextField"))
                stylesDict.Add("DelayedTextField", new StyleWrapper(new GUIStyle("delayedTextField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedTextField"), label);

            return EditorGUI.DelayedTextField(lastPosition, label, text);
        }

        public string DelayedTextField(GUIContent label, string text, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedTextField"))
                stylesDict.Add("DelayedTextField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.DelayedTextField(lastPosition, label, text, style);
        }

        public void DelayedTextField(SerializedProperty property, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedTextField"))
                stylesDict.Add("DelayedTextField", new StyleWrapper(new GUIStyle("delayedTextField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedTextField"), GUIContent.none);

            EditorGUI.DelayedTextField(lastPosition, property);
        }

        public void DelayedTextField(SerializedProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedTextField"))
                stylesDict.Add("DelayedTextField", new StyleWrapper(new GUIStyle("delayedTextField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedTextField"), label);

            EditorGUI.DelayedTextField(lastPosition, property, label);
        }

        public string TextArea(string text, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("TextArea"))
                stylesDict.Add("TextArea", new StyleWrapper(EditorStyles.textArea, text));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.textArea, text);

            return EditorGUI.TextArea(lastPosition, text);
        }

        public string TextArea(string text, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("TextArea"))
                stylesDict.Add("TextArea", new StyleWrapper(style, text));

            Rect lastPosition = _position;
            UpdatePosition(style, text);

            return EditorGUI.TextArea(lastPosition, text, style);
        }

        public void SelectableLabel(string text, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("SelectableLabel"))
                stylesDict.Add("SelectableLabel", new StyleWrapper(new GUIStyle("selectableLabel"), text));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("selectableLabel"), text);

            EditorGUI.SelectableLabel(lastPosition, text);
        }

        public void SelectableLabel(string text, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("SelectableLabel"))
                stylesDict.Add("SelectableLabel", new StyleWrapper(style, text));

            Rect lastPosition = _position;
            UpdatePosition(style, text);

            EditorGUI.SelectableLabel(lastPosition, text, style);
        }

        public string PasswordField(string password, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("PasswordField"))
                stylesDict.Add("PasswordField", new StyleWrapper(new GUIStyle("passwordField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("passwordField"), GUIContent.none);

            return EditorGUI.PasswordField(lastPosition, password);
        }

        public string PasswordField(string password, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("PasswordField"))
                stylesDict.Add("PasswordField", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.PasswordField(lastPosition, password, style);
        }

        public string PasswordField(string label, string password, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("PasswordField"))
                stylesDict.Add("PasswordField", new StyleWrapper(new GUIStyle("passwordField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("passwordField"), label);

            return EditorGUI.PasswordField(lastPosition, label, password);
        }

        public string PasswordField(string label, string password, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("PasswordField"))
                stylesDict.Add("PasswordField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.PasswordField(lastPosition, label, password, style);
        }

        public string PasswordField(GUIContent label, string password, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("PasswordField"))
                stylesDict.Add("PasswordField", new StyleWrapper(new GUIStyle("passwordField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("passwordField"), label);

            return EditorGUI.PasswordField(lastPosition, label, password);
        }

        public string PasswordField(GUIContent label, string password, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("PasswordField"))
                stylesDict.Add("PasswordField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.PasswordField(lastPosition, label, password, style);
        }

        public float FloatField(float value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("FloatField"))
                stylesDict.Add("FloatField", new StyleWrapper(new GUIStyle("floatField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("floatField"), GUIContent.none);

            return EditorGUI.FloatField(lastPosition, value);
        }

        public float FloatField(float value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("FloatField"))
                stylesDict.Add("FloatField", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.FloatField(lastPosition, value, style);
        }

        public float FloatField(string label, float value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("FloatField"))
                stylesDict.Add("FloatField", new StyleWrapper(new GUIStyle("floatField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("floatField"), label);

            return EditorGUI.FloatField(lastPosition, label, value);
        }

        public float FloatField(string label, float value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("FloatField"))
                stylesDict.Add("FloatField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.FloatField(lastPosition, label, value, style);
        }

        public float FloatField(GUIContent label, float value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("FloatField"))
                stylesDict.Add("FloatField", new StyleWrapper(new GUIStyle("floatField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("floatField"), label);

            return EditorGUI.FloatField(lastPosition, label, value);
        }

        public float FloatField(GUIContent label, float value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("FloatField"))
                stylesDict.Add("FloatField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.FloatField(lastPosition, label, value, style);
        }

        public float DelayedFloatField(float value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedFloatField"))
                stylesDict.Add("DelayedFloatField", new StyleWrapper(new GUIStyle("delayedFloatField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedFloatField"), GUIContent.none);

            return EditorGUI.DelayedFloatField(lastPosition, value);
        }

        public float DelayedFloatField(float value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedFloatField"))
                stylesDict.Add("DelayedFloatField", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.DelayedFloatField(lastPosition, value, style);
        }

        public float DelayedFloatField(string label, float value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedFloatField"))
                stylesDict.Add("DelayedFloatField", new StyleWrapper(new GUIStyle("delayedFloatField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedFloatField"), label);

            return EditorGUI.DelayedFloatField(lastPosition, label, value);
        }

        public float DelayedFloatField(string label, float value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedFloatField"))
                stylesDict.Add("DelayedFloatField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.DelayedFloatField(lastPosition, label, value, style);
        }

        public float DelayedFloatField(GUIContent label, float value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedFloatField"))
                stylesDict.Add("DelayedFloatField", new StyleWrapper(new GUIStyle("delayedFloatField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedFloatField"), label);

            return EditorGUI.DelayedFloatField(lastPosition, label, value);
        }

        public float DelayedFloatField(GUIContent label, float value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedFloatField"))
                stylesDict.Add("DelayedFloatField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.DelayedFloatField(lastPosition, label, value, style);
        }

        public void DelayedFloatField(SerializedProperty property, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedFloatField"))
                stylesDict.Add("DelayedFloatField", new StyleWrapper(new GUIStyle("delayedFloatField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedFloatField"), GUIContent.none);

            EditorGUI.DelayedFloatField(lastPosition, property);
        }

        public void DelayedFloatField(SerializedProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedFloatField"))
                stylesDict.Add("DelayedFloatField", new StyleWrapper(new GUIStyle("delayedFloatField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedFloatField"), label);

            EditorGUI.DelayedFloatField(lastPosition, property, label);
        }

        public double DoubleField(double value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DoubleField"))
                stylesDict.Add("DoubleField", new StyleWrapper(new GUIStyle("doubleField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("doubleField"), GUIContent.none);

            return EditorGUI.DoubleField(lastPosition, value);
        }

        public double DoubleField(double value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DoubleField"))
                stylesDict.Add("DoubleField", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.DoubleField(lastPosition, value, style);
        }

        public double DoubleField(string label, double value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DoubleField"))
                stylesDict.Add("DoubleField", new StyleWrapper(new GUIStyle("doubleField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("doubleField"), label);

            return EditorGUI.DoubleField(lastPosition, label, value);
        }

        public double DoubleField(string label, double value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DoubleField"))
                stylesDict.Add("DoubleField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.DoubleField(lastPosition, label, value, style);
        }

        public double DoubleField(GUIContent label, double value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DoubleField"))
                stylesDict.Add("DoubleField", new StyleWrapper(new GUIStyle("doubleField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("doubleField"), label);

            return EditorGUI.DoubleField(lastPosition, label, value);
        }

        public double DoubleField(GUIContent label, double value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DoubleField"))
                stylesDict.Add("DoubleField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.DoubleField(lastPosition, label, value, style);
        }

        public double DelayedDoubleField(double value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedDoubleField"))
                stylesDict.Add("DelayedDoubleField", new StyleWrapper(new GUIStyle("delayedDoubleField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedDoubleField"), GUIContent.none);

            return EditorGUI.DelayedDoubleField(lastPosition, value);
        }

        public double DelayedDoubleField(double value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedDoubleField"))
                stylesDict.Add("DelayedDoubleField", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.DelayedDoubleField(lastPosition, value, style);
        }

        public double DelayedDoubleField(string label, double value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedDoubleField"))
                stylesDict.Add("DelayedDoubleField", new StyleWrapper(new GUIStyle("delayedDoubleField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedDoubleField"), label);

            return EditorGUI.DelayedDoubleField(lastPosition, label, value);
        }

        public double DelayedDoubleField(string label, double value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedDoubleField"))
                stylesDict.Add("DelayedDoubleField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.DelayedDoubleField(lastPosition, label, value, style);
        }

        public double DelayedDoubleField(GUIContent label, double value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedDoubleField"))
                stylesDict.Add("DelayedDoubleField", new StyleWrapper(new GUIStyle("delayedDoubleField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedDoubleField"), label);

            return EditorGUI.DelayedDoubleField(lastPosition, label, value);
        }

        public double DelayedDoubleField(GUIContent label, double value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedDoubleField"))
                stylesDict.Add("DelayedDoubleField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.DelayedDoubleField(lastPosition, label, value, style);
        }

        public int IntField(int value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("IntField"))
                stylesDict.Add("IntField", new StyleWrapper(new GUIStyle("intField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intField"), GUIContent.none);

            return EditorGUI.IntField(lastPosition, value);
        }

        public int IntField(int value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("IntField"))
                stylesDict.Add("IntField", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.IntField(lastPosition, value, style);
        }

        public int IntField(string label, int value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("IntField"))
                stylesDict.Add("IntField", new StyleWrapper(new GUIStyle("intField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intField"), label);

            return EditorGUI.IntField(lastPosition, label, value);
        }

        public int IntField(string label, int value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("IntField"))
                stylesDict.Add("IntField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.IntField(lastPosition, label, value, style);
        }

        public int IntField(GUIContent label, int value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("IntField"))
                stylesDict.Add("IntField", new StyleWrapper(new GUIStyle("intField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intField"), label);

            return EditorGUI.IntField(lastPosition, label, value);
        }

        public int IntField(GUIContent label, int value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("IntField"))
                stylesDict.Add("IntField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.IntField(lastPosition, label, value, style);
        }

        public int DelayedIntField(int value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedIntField"))
                stylesDict.Add("DelayedIntField", new StyleWrapper(new GUIStyle("delayedIntField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedIntField"), GUIContent.none);

            return EditorGUI.DelayedIntField(lastPosition, value);
        }

        public int DelayedIntField(int value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedIntField"))
                stylesDict.Add("DelayedIntField", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.DelayedIntField(lastPosition, value, style);
        }

        public int DelayedIntField(string label, int value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedIntField"))
                stylesDict.Add("DelayedIntField", new StyleWrapper(new GUIStyle("delayedIntField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedIntField"), label);

            return EditorGUI.DelayedIntField(lastPosition, label, value);
        }

        public int DelayedIntField(string label, int value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedIntField"))
                stylesDict.Add("DelayedIntField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.DelayedIntField(lastPosition, label, value, style);
        }

        public int DelayedIntField(GUIContent label, int value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedIntField"))
                stylesDict.Add("DelayedIntField", new StyleWrapper(new GUIStyle("delayedIntField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedIntField"), label);

            return EditorGUI.DelayedIntField(lastPosition, label, value);
        }

        public int DelayedIntField(GUIContent label, int value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedIntField"))
                stylesDict.Add("DelayedIntField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.DelayedIntField(lastPosition, label, value, style);
        }

        public void DelayedIntField(SerializedProperty property, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedIntField"))
                stylesDict.Add("DelayedIntField", new StyleWrapper(new GUIStyle("delayedIntField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedIntField"), GUIContent.none);

            EditorGUI.DelayedIntField(lastPosition, property);
        }

        public void DelayedIntField(SerializedProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DelayedIntField"))
                stylesDict.Add("DelayedIntField", new StyleWrapper(new GUIStyle("delayedIntField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("delayedIntField"), label);

            EditorGUI.DelayedIntField(lastPosition, property, label);
        }

        public long LongField(long value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("LongField"))
                stylesDict.Add("LongField", new StyleWrapper(new GUIStyle("longField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("longField"), GUIContent.none);

            return EditorGUI.LongField(lastPosition, value);
        }

        public long LongField(long value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("LongField"))
                stylesDict.Add("LongField", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.LongField(lastPosition, value, style);
        }

        public long LongField(string label, long value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("LongField"))
                stylesDict.Add("LongField", new StyleWrapper(new GUIStyle("longField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("longField"), label);

            return EditorGUI.LongField(lastPosition, label, value);
        }

        public long LongField(string label, long value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("LongField"))
                stylesDict.Add("LongField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.LongField(lastPosition, label, value, style);
        }

        public long LongField(GUIContent label, long value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("LongField"))
                stylesDict.Add("LongField", new StyleWrapper(new GUIStyle("longField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("longField"), label);

            return EditorGUI.LongField(lastPosition, label, value);
        }

        public long LongField(GUIContent label, long value, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("LongField"))
                stylesDict.Add("LongField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.LongField(lastPosition, label, value, style);
        }

        public float Slider(float value, float leftValue, float rightValue, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Slider"))
                stylesDict.Add("Slider", new StyleWrapper(new GUIStyle("slider"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("slider"), GUIContent.none);

            return EditorGUI.Slider(lastPosition, value, leftValue, rightValue);
        }

        public float Slider(string label, float value, float leftValue, float rightValue, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Slider"))
                stylesDict.Add("Slider", new StyleWrapper(new GUIStyle("slider"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("slider"), label);

            return EditorGUI.Slider(lastPosition, label, value, leftValue, rightValue);
        }

        public float Slider(GUIContent label, float value, float leftValue, float rightValue, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Slider"))
                stylesDict.Add("Slider", new StyleWrapper(new GUIStyle("slider"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("slider"), label);

            return EditorGUI.Slider(lastPosition, label, value, leftValue, rightValue);
        }

        public void Slider(SerializedProperty property, float leftValue, float rightValue, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Slider"))
                stylesDict.Add("Slider", new StyleWrapper(new GUIStyle("slider"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("slider"), GUIContent.none);

            EditorGUI.Slider(lastPosition, property, leftValue, rightValue);
        }

        public void Slider(SerializedProperty property, float leftValue, float rightValue, string label, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Slider"))
                stylesDict.Add("Slider", new StyleWrapper(new GUIStyle("slider"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("slider"), label);

            EditorGUI.Slider(lastPosition, property, leftValue, rightValue, label);
        }

        public void Slider(SerializedProperty property, float leftValue, float rightValue, GUIContent label, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Slider"))
                stylesDict.Add("Slider", new StyleWrapper(new GUIStyle("slider"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("slider"), label);

            EditorGUI.Slider(lastPosition, property, leftValue, rightValue, label);
        }

        public int IntSlider(int value, int leftValue, int rightValue, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("IntSlider"))
                stylesDict.Add("IntSlider", new StyleWrapper(new GUIStyle("intSlider"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intSlider"), GUIContent.none);

            return EditorGUI.IntSlider(lastPosition, value, leftValue, rightValue);
        }

        public int IntSlider(string label, int value, int leftValue, int rightValue, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("IntSlider"))
                stylesDict.Add("IntSlider", new StyleWrapper(new GUIStyle("intSlider"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intSlider"), label);

            return EditorGUI.IntSlider(lastPosition, label, value, leftValue, rightValue);
        }

        public int IntSlider(GUIContent label, int value, int leftValue, int rightValue, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("IntSlider"))
                stylesDict.Add("IntSlider", new StyleWrapper(new GUIStyle("intSlider"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intSlider"), label);

            return EditorGUI.IntSlider(lastPosition, label, value, leftValue, rightValue);
        }

        public void IntSlider(SerializedProperty property, int leftValue, int rightValue, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("IntSlider"))
                stylesDict.Add("IntSlider", new StyleWrapper(new GUIStyle("intSlider"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intSlider"), GUIContent.none);

            EditorGUI.IntSlider(lastPosition, property, leftValue, rightValue);
        }

        public void IntSlider(SerializedProperty property, int leftValue, int rightValue, string label, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("IntSlider"))
                stylesDict.Add("IntSlider", new StyleWrapper(new GUIStyle("intSlider"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intSlider"), label);

            EditorGUI.IntSlider(lastPosition, property, leftValue, rightValue, label);
        }

        public void IntSlider(SerializedProperty property, int leftValue, int rightValue, GUIContent label, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("IntSlider"))
                stylesDict.Add("IntSlider", new StyleWrapper(new GUIStyle("intSlider"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intSlider"), label);

            EditorGUI.IntSlider(lastPosition, property, leftValue, rightValue, label);
        }

        public void MinMaxSlider(ref float minValue, ref float maxValue, float minLimit, float maxLimit, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("MinMaxSlider"))
                stylesDict.Add("MinMaxSlider", new StyleWrapper(new GUIStyle("minMaxSlider"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("minMaxSlider"), GUIContent.none);

            EditorGUI.MinMaxSlider(lastPosition, ref minValue, ref maxValue, minLimit, maxLimit);
        }

        public void MinMaxSlider(string label, ref float minValue, ref float maxValue, float minLimit, float maxLimit, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("MinMaxSlider"))
                stylesDict.Add("MinMaxSlider", new StyleWrapper(new GUIStyle("minMaxSlider"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("minMaxSlider"), label);

            EditorGUI.MinMaxSlider(lastPosition, label, ref minValue, ref maxValue, minLimit, maxLimit);
        }

        public void MinMaxSlider(GUIContent label, ref float minValue, ref float maxValue, float minLimit, float maxLimit, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("MinMaxSlider"))
                stylesDict.Add("MinMaxSlider", new StyleWrapper(new GUIStyle("minMaxSlider"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("minMaxSlider"), label);

            EditorGUI.MinMaxSlider(lastPosition, label, ref minValue, ref maxValue, minLimit, maxLimit);
        }

        public int Popup(int selectedIndex, string[] displayedOptions, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(EditorStyles.popup, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.popup, GUIContent.none);

            return EditorGUI.Popup(lastPosition, selectedIndex, displayedOptions);
        }

        public int Popup(int selectedIndex, string[] displayedOptions, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.Popup(lastPosition, selectedIndex, displayedOptions, style);
        }

        public int Popup(int selectedIndex, GUIContent[] displayedOptions, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(EditorStyles.popup, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.popup, GUIContent.none);

            // Couldn't add this line! (Exception: System.InvalidOperationException -- At line: 247)
            throw new Exception();
        }

        public int Popup(int selectedIndex, GUIContent[] displayedOptions, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            // Couldn't add this line! (Exception: System.InvalidOperationException -- At line: 247)
            throw new Exception();
        }

        public int Popup(string label, int selectedIndex, string[] displayedOptions, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(EditorStyles.popup, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.popup, label);

            return EditorGUI.Popup(lastPosition, label, selectedIndex, displayedOptions);
        }

        public int Popup(GUIContent label, int selectedIndex, string[] displayedOptions, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(EditorStyles.popup, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.popup, label);

            return EditorGUI.Popup(lastPosition, label, selectedIndex, displayedOptions.Select(x => new GUIContent(x)).ToArray());
        }

        public int Popup(string label, int selectedIndex, string[] displayedOptions, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.Popup(lastPosition, label, selectedIndex, displayedOptions, style);
        }

        public int Popup(GUIContent label, int selectedIndex, GUIContent[] displayedOptions, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(EditorStyles.popup, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.popup, label);

            // Couldn't add this line! (Exception: System.InvalidOperationException -- At line: 247)
            throw new Exception();
        }

        public int Popup(GUIContent label, int selectedIndex, GUIContent[] displayedOptions, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Popup"))
                stylesDict.Add("Popup", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            // Couldn't add this line! (Exception: System.InvalidOperationException -- At line: 247)
            throw new Exception();
        }

        public Enum EnumPopup(Enum selected, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("EnumPopup"))
                stylesDict.Add("EnumPopup", new StyleWrapper(new GUIStyle("enumPopup"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("enumPopup"), GUIContent.none);

            return EditorGUI.EnumPopup(lastPosition, selected);
        }

        public Enum EnumPopup(Enum selected, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("EnumPopup"))
                stylesDict.Add("EnumPopup", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.EnumPopup(lastPosition, selected, style);
        }

        public Enum EnumPopup(string label, Enum selected, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("EnumPopup"))
                stylesDict.Add("EnumPopup", new StyleWrapper(new GUIStyle("enumPopup"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("enumPopup"), label);

            return EditorGUI.EnumPopup(lastPosition, label, selected);
        }

        public Enum EnumPopup(string label, Enum selected, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("EnumPopup"))
                stylesDict.Add("EnumPopup", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.EnumPopup(lastPosition, label, selected, style);
        }

        public Enum EnumPopup(GUIContent label, Enum selected, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("EnumPopup"))
                stylesDict.Add("EnumPopup", new StyleWrapper(new GUIStyle("enumPopup"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("enumPopup"), label);

            return EditorGUI.EnumPopup(lastPosition, label, selected);
        }

        public Enum EnumPopup(GUIContent label, Enum selected, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("EnumPopup"))
                stylesDict.Add("EnumPopup", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.EnumPopup(lastPosition, label, selected, style);
        }

        public Enum EnumPopup(GUIContent label, Enum selected, Func<Enum, bool> checkEnabled, bool includeObsolete, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("EnumPopup"))
                stylesDict.Add("EnumPopup", new StyleWrapper(new GUIStyle("enumPopup"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("enumPopup"), label);

            // This call has the following (2) unsupported params (an implementation is required): includeObsolete, checkEnabled
            return EditorGUI.EnumPopup(lastPosition, label, selected);
        }

        public Enum EnumPopup(GUIContent label, Enum selected, Func<Enum, bool> checkEnabled, bool includeObsolete, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("EnumPopup"))
                stylesDict.Add("EnumPopup", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            // This call has the following (2) unsupported params (an implementation is required): includeObsolete, checkEnabled
            return EditorGUI.EnumPopup(lastPosition, label, selected, style);
        }

        public int IntPopup(int selectedValue, string[] displayedOptions, int[] optionValues, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(new GUIStyle("intPopup"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intPopup"), GUIContent.none);

            return EditorGUI.IntPopup(lastPosition, selectedValue, displayedOptions, optionValues);
        }

        public int IntPopup(int selectedValue, string[] displayedOptions, int[] optionValues, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.IntPopup(lastPosition, selectedValue, displayedOptions, optionValues, style);
        }

        public int IntPopup(int selectedValue, GUIContent[] displayedOptions, int[] optionValues, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(new GUIStyle("intPopup"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intPopup"), GUIContent.none);

            // Couldn't add this line! (Exception: System.InvalidOperationException -- At line: 247)
            throw new Exception();
        }

        public int IntPopup(int selectedValue, GUIContent[] displayedOptions, int[] optionValues, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            // Couldn't add this line! (Exception: System.InvalidOperationException -- At line: 247)
            throw new Exception();
        }

        public int IntPopup(string label, int selectedValue, string[] displayedOptions, int[] optionValues, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(new GUIStyle("intPopup"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intPopup"), label);

            return EditorGUI.IntPopup(lastPosition, label, selectedValue, displayedOptions, optionValues);
        }

        public int IntPopup(string label, int selectedValue, string[] displayedOptions, int[] optionValues, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.IntPopup(lastPosition, label, selectedValue, displayedOptions, optionValues, style);
        }

        public int IntPopup(GUIContent label, int selectedValue, GUIContent[] displayedOptions, int[] optionValues, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(new GUIStyle("intPopup"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intPopup"), label);

            // Couldn't add this line! (Exception: System.InvalidOperationException -- At line: 247)
            throw new Exception();
        }

        public int IntPopup(GUIContent label, int selectedValue, GUIContent[] displayedOptions, int[] optionValues, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            // Couldn't add this line! (Exception: System.InvalidOperationException -- At line: 247)
            throw new Exception();
        }

        public void IntPopup(SerializedProperty property, GUIContent[] displayedOptions, int[] optionValues, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(new GUIStyle("intPopup"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intPopup"), GUIContent.none);

            // Couldn't add this line! (Exception: System.InvalidOperationException -- At line: 247)
        }

        public void IntPopup(SerializedProperty property, GUIContent[] displayedOptions, int[] optionValues, GUIContent label, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(new GUIStyle("intPopup"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("intPopup"), label);

            // Couldn't add this line! (Exception: System.InvalidOperationException -- At line: 247)
        }

        public void IntPopup(SerializedProperty property, GUIContent[] displayedOptions, int[] optionValues, GUIContent label, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("IntPopup"))
                stylesDict.Add("IntPopup", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            // Couldn't add this line! (Exception: System.InvalidOperationException -- At line: 247)
        }

        public string TagField(string tag, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("TagField"))
                stylesDict.Add("TagField", new StyleWrapper(new GUIStyle("tagField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("tagField"), GUIContent.none);

            return EditorGUI.TagField(lastPosition, tag);
        }

        public string TagField(string tag, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("TagField"))
                stylesDict.Add("TagField", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.TagField(lastPosition, tag, style);
        }

        public string TagField(string label, string tag, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("TagField"))
                stylesDict.Add("TagField", new StyleWrapper(new GUIStyle("tagField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("tagField"), label);

            return EditorGUI.TagField(lastPosition, label, tag);
        }

        public string TagField(string label, string tag, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("TagField"))
                stylesDict.Add("TagField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.TagField(lastPosition, label, tag, style);
        }

        public string TagField(GUIContent label, string tag, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("TagField"))
                stylesDict.Add("TagField", new StyleWrapper(new GUIStyle("tagField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("tagField"), label);

            return EditorGUI.TagField(lastPosition, label, tag);
        }

        public string TagField(GUIContent label, string tag, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("TagField"))
                stylesDict.Add("TagField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.TagField(lastPosition, label, tag, style);
        }

        public int LayerField(int layer, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("LayerField"))
                stylesDict.Add("LayerField", new StyleWrapper(new GUIStyle("layerField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("layerField"), GUIContent.none);

            return EditorGUI.LayerField(lastPosition, layer);
        }

        public int LayerField(int layer, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("LayerField"))
                stylesDict.Add("LayerField", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.LayerField(lastPosition, layer, style);
        }

        public int LayerField(string label, int layer, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("LayerField"))
                stylesDict.Add("LayerField", new StyleWrapper(new GUIStyle("layerField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("layerField"), label);

            return EditorGUI.LayerField(lastPosition, label, layer);
        }

        public int LayerField(string label, int layer, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("LayerField"))
                stylesDict.Add("LayerField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.LayerField(lastPosition, label, layer, style);
        }

        public int LayerField(GUIContent label, int layer, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("LayerField"))
                stylesDict.Add("LayerField", new StyleWrapper(new GUIStyle("layerField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("layerField"), label);

            return EditorGUI.LayerField(lastPosition, label, layer);
        }

        public int LayerField(GUIContent label, int layer, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("LayerField"))
                stylesDict.Add("LayerField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.LayerField(lastPosition, label, layer, style);
        }

        public int MaskField(GUIContent label, int mask, string[] displayedOptions, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("MaskField"))
                stylesDict.Add("MaskField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.MaskField(lastPosition, label, mask, displayedOptions, style);
        }

        public int MaskField(string label, int mask, string[] displayedOptions, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("MaskField"))
                stylesDict.Add("MaskField", new StyleWrapper(style, label));

            Rect lastPosition = _position;
            UpdatePosition(style, label);

            return EditorGUI.MaskField(lastPosition, label, mask, displayedOptions, style);
        }

        public int MaskField(GUIContent label, int mask, string[] displayedOptions, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("MaskField"))
                stylesDict.Add("MaskField", new StyleWrapper(new GUIStyle("maskField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("maskField"), label);

            return EditorGUI.MaskField(lastPosition, label, mask, displayedOptions);
        }

        public int MaskField(string label, int mask, string[] displayedOptions, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("MaskField"))
                stylesDict.Add("MaskField", new StyleWrapper(new GUIStyle("maskField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("maskField"), label);

            return EditorGUI.MaskField(lastPosition, label, mask, displayedOptions);
        }

        public int MaskField(int mask, string[] displayedOptions, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("MaskField"))
                stylesDict.Add("MaskField", new StyleWrapper(style, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(style, GUIContent.none);

            return EditorGUI.MaskField(lastPosition, mask, displayedOptions, style);
        }

        public int MaskField(int mask, string[] displayedOptions, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("MaskField"))
                stylesDict.Add("MaskField", new StyleWrapper(new GUIStyle("maskField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("maskField"), GUIContent.none);

            return EditorGUI.MaskField(lastPosition, mask, displayedOptions);
        }

        public Enum EnumFlagsField(Enum enumValue, params GUILayoutOption[] options)
        {
            throw new Exception("This method isn't supported!");
        }

        public Enum EnumFlagsField(Enum enumValue, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("This method isn't supported!");
        }

        public Enum EnumFlagsField(string label, Enum enumValue, params GUILayoutOption[] options)
        {
            throw new Exception("This method isn't supported!");
        }

        public Enum EnumFlagsField(string label, Enum enumValue, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("This method isn't supported!");
        }

        public Enum EnumFlagsField(GUIContent label, Enum enumValue, params GUILayoutOption[] options)
        {
            throw new Exception("This method isn't supported!");
        }

        public Enum EnumFlagsField(GUIContent label, Enum enumValue, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("This method isn't supported!");
        }

        public Enum EnumFlagsField(GUIContent label, Enum enumValue, bool includeObsolete, params GUILayoutOption[] options)
        {
            throw new Exception("This method isn't supported!");
        }

        public Enum EnumFlagsField(GUIContent label, Enum enumValue, bool includeObsolete, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("This method isn't supported!");
        }

        public Object ObjectField(Object obj, Type objType, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.objectField, GUIContent.none);

            return EditorGUI.ObjectField(lastPosition, obj, objType);
        }

        public Object ObjectField(Object obj, Type objType, bool allowSceneObjects, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.objectField, GUIContent.none);

            return EditorGUI.ObjectField(lastPosition, obj, objType, allowSceneObjects);
        }

        public Object ObjectField(string label, Object obj, Type objType, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.objectField, label);

            return EditorGUI.ObjectField(lastPosition, label, obj, objType);
        }

        public Object ObjectField(string label, Object obj, Type objType, bool allowSceneObjects, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.objectField, label);

            return EditorGUI.ObjectField(lastPosition, label, obj, objType, allowSceneObjects);
        }

        public Object ObjectField(GUIContent label, Object obj, Type objType, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.objectField, label);

            return EditorGUI.ObjectField(lastPosition, label, obj, objType);
        }

        public Object ObjectField(GUIContent label, Object obj, Type objType, bool allowSceneObjects, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.objectField, label);

            return EditorGUI.ObjectField(lastPosition, label, obj, objType, allowSceneObjects);
        }

        public void ObjectField(SerializedProperty property, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.objectField, GUIContent.none);

            EditorGUI.ObjectField(lastPosition, property);
        }

        public void ObjectField(SerializedProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.objectField, label);

            EditorGUI.ObjectField(lastPosition, property, label);
        }

        public void ObjectField(SerializedProperty property, Type objType, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.objectField, GUIContent.none);

            EditorGUI.ObjectField(lastPosition, property, objType);
        }

        public void ObjectField(SerializedProperty property, Type objType, GUIContent label, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("ObjectField"))
                stylesDict.Add("ObjectField", new StyleWrapper(EditorStyles.objectField, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.objectField, label);

            EditorGUI.ObjectField(lastPosition, property, objType, label);
        }

        public Vector2 Vector2Field(string label, Vector2 value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Vector2Field"))
                stylesDict.Add("Vector2Field", new StyleWrapper(new GUIStyle("vector2Field"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("vector2Field"), label);

            return EditorGUI.Vector2Field(lastPosition, label, value);
        }

        public Vector2 Vector2Field(GUIContent label, Vector2 value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Vector2Field"))
                stylesDict.Add("Vector2Field", new StyleWrapper(new GUIStyle("vector2Field"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("vector2Field"), label);

            return EditorGUI.Vector2Field(lastPosition, label, value);
        }

        public Vector3 Vector3Field(string label, Vector3 value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Vector3Field"))
                stylesDict.Add("Vector3Field", new StyleWrapper(new GUIStyle("vector3Field"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("vector3Field"), label);

            return EditorGUI.Vector3Field(lastPosition, label, value);
        }

        public Vector3 Vector3Field(GUIContent label, Vector3 value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Vector3Field"))
                stylesDict.Add("Vector3Field", new StyleWrapper(new GUIStyle("vector3Field"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("vector3Field"), label);

            return EditorGUI.Vector3Field(lastPosition, label, value);
        }

        public Vector4 Vector4Field(string label, Vector4 value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Vector4Field"))
                stylesDict.Add("Vector4Field", new StyleWrapper(new GUIStyle("vector4Field"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("vector4Field"), label);

            return EditorGUI.Vector4Field(lastPosition, label, value);
        }

        public Vector4 Vector4Field(GUIContent label, Vector4 value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Vector4Field"))
                stylesDict.Add("Vector4Field", new StyleWrapper(new GUIStyle("vector4Field"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("vector4Field"), label);

            return EditorGUI.Vector4Field(lastPosition, label, value);
        }

        public Vector2Int Vector2IntField(string label, Vector2Int value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Vector2IntField"))
                stylesDict.Add("Vector2IntField", new StyleWrapper(new GUIStyle("vector2IntField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("vector2IntField"), label);

            return EditorGUI.Vector2IntField(lastPosition, label, value);
        }

        public Vector2Int Vector2IntField(GUIContent label, Vector2Int value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Vector2IntField"))
                stylesDict.Add("Vector2IntField", new StyleWrapper(new GUIStyle("vector2IntField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("vector2IntField"), label);

            return EditorGUI.Vector2IntField(lastPosition, label, value);
        }

        public Vector3Int Vector3IntField(string label, Vector3Int value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Vector3IntField"))
                stylesDict.Add("Vector3IntField", new StyleWrapper(new GUIStyle("vector3IntField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("vector3IntField"), label);

            return EditorGUI.Vector3IntField(lastPosition, label, value);
        }

        public Vector3Int Vector3IntField(GUIContent label, Vector3Int value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("Vector3IntField"))
                stylesDict.Add("Vector3IntField", new StyleWrapper(new GUIStyle("vector3IntField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("vector3IntField"), label);

            return EditorGUI.Vector3IntField(lastPosition, label, value);
        }

        public Rect RectField(Rect value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("RectField"))
                stylesDict.Add("RectField", new StyleWrapper(new GUIStyle("rectField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("rectField"), GUIContent.none);

            return EditorGUI.RectField(lastPosition, value);
        }

        public Rect RectField(string label, Rect value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("RectField"))
                stylesDict.Add("RectField", new StyleWrapper(new GUIStyle("rectField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("rectField"), label);

            return EditorGUI.RectField(lastPosition, label, value);
        }

        public Rect RectField(GUIContent label, Rect value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("RectField"))
                stylesDict.Add("RectField", new StyleWrapper(new GUIStyle("rectField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("rectField"), label);

            return EditorGUI.RectField(lastPosition, label, value);
        }

        public RectInt RectIntField(RectInt value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("RectIntField"))
                stylesDict.Add("RectIntField", new StyleWrapper(new GUIStyle("rectIntField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("rectIntField"), GUIContent.none);

            return EditorGUI.RectIntField(lastPosition, value);
        }

        public RectInt RectIntField(string label, RectInt value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("RectIntField"))
                stylesDict.Add("RectIntField", new StyleWrapper(new GUIStyle("rectIntField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("rectIntField"), label);

            return EditorGUI.RectIntField(lastPosition, label, value);
        }

        public RectInt RectIntField(GUIContent label, RectInt value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("RectIntField"))
                stylesDict.Add("RectIntField", new StyleWrapper(new GUIStyle("rectIntField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("rectIntField"), label);

            return EditorGUI.RectIntField(lastPosition, label, value);
        }

        public Bounds BoundsField(Bounds value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("BoundsField"))
                stylesDict.Add("BoundsField", new StyleWrapper(new GUIStyle("boundsField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("boundsField"), GUIContent.none);

            return EditorGUI.BoundsField(lastPosition, value);
        }

        public Bounds BoundsField(string label, Bounds value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("BoundsField"))
                stylesDict.Add("BoundsField", new StyleWrapper(new GUIStyle("boundsField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("boundsField"), label);

            return EditorGUI.BoundsField(lastPosition, label, value);
        }

        public Bounds BoundsField(GUIContent label, Bounds value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("BoundsField"))
                stylesDict.Add("BoundsField", new StyleWrapper(new GUIStyle("boundsField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("boundsField"), label);

            return EditorGUI.BoundsField(lastPosition, label, value);
        }

        public BoundsInt BoundsIntField(BoundsInt value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("BoundsIntField"))
                stylesDict.Add("BoundsIntField", new StyleWrapper(new GUIStyle("boundsIntField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("boundsIntField"), GUIContent.none);

            return EditorGUI.BoundsIntField(lastPosition, value);
        }

        public BoundsInt BoundsIntField(string label, BoundsInt value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("BoundsIntField"))
                stylesDict.Add("BoundsIntField", new StyleWrapper(new GUIStyle("boundsIntField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("boundsIntField"), label);

            return EditorGUI.BoundsIntField(lastPosition, label, value);
        }

        public BoundsInt BoundsIntField(GUIContent label, BoundsInt value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("BoundsIntField"))
                stylesDict.Add("BoundsIntField", new StyleWrapper(new GUIStyle("boundsIntField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("boundsIntField"), label);

            return EditorGUI.BoundsIntField(lastPosition, label, value);
        }

        public Color ColorField(Color value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("ColorField"))
                stylesDict.Add("ColorField", new StyleWrapper(EditorStyles.colorField, GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.colorField, GUIContent.none);

            return EditorGUI.ColorField(lastPosition, value);
        }

        public Color ColorField(string label, Color value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("ColorField"))
                stylesDict.Add("ColorField", new StyleWrapper(EditorStyles.colorField, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.colorField, label);

            return EditorGUI.ColorField(lastPosition, label, value);
        }

        public Color ColorField(GUIContent label, Color value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("ColorField"))
                stylesDict.Add("ColorField", new StyleWrapper(EditorStyles.colorField, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.colorField, label);

            return EditorGUI.ColorField(lastPosition, label, value);
        }

        public Color ColorField(GUIContent label, Color value, bool showEyedropper, bool showAlpha, bool hdr, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("ColorField"))
                stylesDict.Add("ColorField", new StyleWrapper(EditorStyles.colorField, label));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.colorField, label);

            return EditorGUI.ColorField(lastPosition, label, value, showEyedropper, showAlpha, hdr);
        }

        public AnimationCurve CurveField(AnimationCurve value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("CurveField"))
                stylesDict.Add("CurveField", new StyleWrapper(new GUIStyle("curveField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("curveField"), GUIContent.none);

            return EditorGUI.CurveField(lastPosition, value);
        }

        public AnimationCurve CurveField(string label, AnimationCurve value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("CurveField"))
                stylesDict.Add("CurveField", new StyleWrapper(new GUIStyle("curveField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("curveField"), label);

            return EditorGUI.CurveField(lastPosition, label, value);
        }

        public AnimationCurve CurveField(GUIContent label, AnimationCurve value, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("CurveField"))
                stylesDict.Add("CurveField", new StyleWrapper(new GUIStyle("curveField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("curveField"), label);

            return EditorGUI.CurveField(lastPosition, label, value);
        }

        public AnimationCurve CurveField(AnimationCurve value, Color color, Rect ranges, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("CurveField"))
                stylesDict.Add("CurveField", new StyleWrapper(new GUIStyle("curveField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("curveField"), GUIContent.none);

            return EditorGUI.CurveField(lastPosition, value, color, ranges);
        }

        public AnimationCurve CurveField(string label, AnimationCurve value, Color color, Rect ranges, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("CurveField"))
                stylesDict.Add("CurveField", new StyleWrapper(new GUIStyle("curveField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("curveField"), label);

            return EditorGUI.CurveField(lastPosition, label, value, color, ranges);
        }

        public AnimationCurve CurveField(GUIContent label, AnimationCurve value, Color color, Rect ranges, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("CurveField"))
                stylesDict.Add("CurveField", new StyleWrapper(new GUIStyle("curveField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("curveField"), label);

            return EditorGUI.CurveField(lastPosition, label, value, color, ranges);
        }

        public void CurveField(SerializedProperty property, Color color, Rect ranges, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("CurveField"))
                stylesDict.Add("CurveField", new StyleWrapper(new GUIStyle("curveField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("curveField"), GUIContent.none);

            EditorGUI.CurveField(lastPosition, property, color, ranges);
        }

        public void CurveField(SerializedProperty property, Color color, Rect ranges, GUIContent label, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("CurveField"))
                stylesDict.Add("CurveField", new StyleWrapper(new GUIStyle("curveField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("curveField"), label);

            EditorGUI.CurveField(lastPosition, property, color, ranges, label);
        }

        public bool InspectorTitlebar(bool foldout, Object targetObj)
        {
            throw new Exception("This method isn't supported!");
        }

        public bool InspectorTitlebar(bool foldout, Object targetObj, bool expandable)
        {
            throw new Exception("This method isn't supported!");
        }

        public bool InspectorTitlebar(bool foldout, Object[] targetObjs)
        {
            throw new Exception("This method isn't supported!");
        }

        public bool InspectorTitlebar(bool foldout, Object[] targetObjs, bool expandable)
        {
            throw new Exception("This method isn't supported!");
        }

        public bool InspectorTitlebar(bool foldout, Editor editor)
        {
            throw new Exception("This method isn't supported!");
        }

        public void InspectorTitlebar(Object[] targetObjs)
        {
            throw new Exception("This method isn't supported!");
        }

        public void HelpBox(string message, MessageType type)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("HelpBox"))
                stylesDict.Add("HelpBox", new StyleWrapper(EditorStyles.helpBox, message));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.helpBox, message);

            EditorGUI.HelpBox(lastPosition, message, type);
        }

        public void HelpBox(string message, MessageType type, bool wide)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("HelpBox"))
                stylesDict.Add("HelpBox", new StyleWrapper(EditorStyles.helpBox, message));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.helpBox, message);

            // This call has the following (1) unsupported params (an implementation is required): wide
            EditorGUI.HelpBox(lastPosition, message, type);
        }

        public void HelpBox(GUIContent content, bool wide = true)
        {
            // throw new Exception("No implementation Layout yet!");
            if (!stylesDict.ContainsKey("HelpBox"))
                stylesDict.Add("HelpBox", new StyleWrapper(EditorStyles.helpBox, content));

            Rect lastPosition = _position;
            UpdatePosition(EditorStyles.helpBox, content);

            // This call has the following (1) unsupported params (an implementation is required): wide
            EditorGUI.HelpBox(lastPosition, content.text, default(MessageType));
        }

        public bool BeginToggleGroup(string label, bool toggle)
        {
            throw new Exception("This method isn't supported!");
        }

        public bool BeginToggleGroup(GUIContent label, bool toggle)
        {
            throw new Exception("This method isn't supported!");
        }

        public Rect BeginHorizontal(params GUILayoutOption[] options)
        {
            throw new Exception("This method isn't supported!");
        }

        public Rect BeginHorizontal(GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("This method isn't supported!");
        }

        public Rect BeginVertical(params GUILayoutOption[] options)
        {
            throw new Exception("This method isn't supported!");
        }

        public Rect BeginVertical(GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("This method isn't supported!");
        }

        public Vector2 BeginScrollView(Vector2 scrollPosition, params GUILayoutOption[] options)
        {
            throw new Exception("This method isn't supported!");
        }

        public Vector2 BeginScrollView(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, params GUILayoutOption[] options)
        {
            throw new Exception("This method isn't supported!");
        }

        public Vector2 BeginScrollView(Vector2 scrollPosition, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, params GUILayoutOption[] options)
        {
            throw new Exception("This method isn't supported!");
        }

        public Vector2 BeginScrollView(Vector2 scrollPosition, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("This method isn't supported!");
        }

        public Vector2 BeginScrollView(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background, params GUILayoutOption[] options)
        {
            throw new Exception("This method isn't supported!");
        }

        public bool PropertyField(SerializedProperty property, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("PropertyField"))
                stylesDict.Add("PropertyField", new StyleWrapper(new GUIStyle("propertyField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("propertyField"), GUIContent.none);

            return EditorGUI.PropertyField(lastPosition, property);
        }

        public bool PropertyField(SerializedProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("PropertyField"))
                stylesDict.Add("PropertyField", new StyleWrapper(new GUIStyle("propertyField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("propertyField"), label);

            return EditorGUI.PropertyField(lastPosition, property, label);
        }

        public bool PropertyField(SerializedProperty property, bool includeChildren, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("PropertyField"))
                stylesDict.Add("PropertyField", new StyleWrapper(new GUIStyle("propertyField"), GUIContent.none));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("propertyField"), GUIContent.none);

            return EditorGUI.PropertyField(lastPosition, property, includeChildren);
        }

        public bool PropertyField(SerializedProperty property, GUIContent label, bool includeChildren, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("PropertyField"))
                stylesDict.Add("PropertyField", new StyleWrapper(new GUIStyle("propertyField"), label));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("propertyField"), label);

            return EditorGUI.PropertyField(lastPosition, property, label, includeChildren);
        }

        public Rect GetControlRect(params GUILayoutOption[] options)
        {
            throw new Exception("This method isn't supported!");
        }

        public Rect GetControlRect(bool hasLabel, params GUILayoutOption[] options)
        {
            throw new Exception("This method isn't supported!");
        }

        public Rect GetControlRect(bool hasLabel, float height, params GUILayoutOption[] options)
        {
            throw new Exception("This method isn't supported!");
        }

        public Rect GetControlRect(bool hasLabel, float height, GUIStyle style, params GUILayoutOption[] options)
        {
            throw new Exception("This method isn't supported!");
        }

        public bool BeginFadeGroup(float value)
        {
            throw new Exception("This method isn't supported!");
        }

        public bool DropdownButton(GUIContent content, FocusType focusType, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DropdownButton"))
                stylesDict.Add("DropdownButton", new StyleWrapper(new GUIStyle("dropdownButton"), content));

            Rect lastPosition = _position;
            UpdatePosition(new GUIStyle("dropdownButton"), content);

            return EditorGUI.DropdownButton(lastPosition, content, focusType);
        }

        public bool DropdownButton(GUIContent content, FocusType focusType, GUIStyle style, params GUILayoutOption[] options)
        {
            // throw new Exception("No implementation Layout yet!");

            if (options != null)
                throw new ArgumentException("Options use isn't supported yet!", "options");

            if (!stylesDict.ContainsKey("DropdownButton"))
                stylesDict.Add("DropdownButton", new StyleWrapper(style, content));

            Rect lastPosition = _position;
            UpdatePosition(style, content);

            return EditorGUI.DropdownButton(lastPosition, content, focusType, style);
        }

        public float GetHeight()
        {
            float size = 0;

            foreach (StyleWrapper wrapper in stylesDict.Values)
                size += wrapper.listWrapper.Sum(x => x.Value.list.Sum(y => x.Key.CalcSize(y).y));

            return size;
        }

        private void UpdatePosition(GUIStyle style, string label)
        {
            UpdatePosition(style, new GUIContent(label));
        }

        /*private void UpdatePosition(GUIStyle style, GUIContent content)
        {
            Vector2 vector = style.CalcSize(content);

            float width = 0, height = 0;

            style.CalcMinMaxWidth(content, out width, out height);

            _position.yMin += vector.y;
            _position.xMin = vector.y;
            _position.width = width;
            _position.height = height;
        }*/
    }

    public class Converters : GUIContent
    {
        public static implicit operator Converters(string str)
        {
            return (Converters)new GUIContent(str);
        }
    }
}