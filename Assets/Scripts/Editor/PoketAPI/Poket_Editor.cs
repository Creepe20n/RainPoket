using UnityEngine;
using UnityEditor;
using Unity.Burst.Intrinsics;
namespace PoketAPI.Editor
{
    public static class BaseEditor
    {
        /// <summary>
        /// Creates a basic window in the middle of the screen
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static EditorWindow CreateWindow<T>(string title = "new Window", float width = 400, float height = 400) where T : EditorWindow
        {
            T window = EditorWindow.CreateWindow<T>(title);

            CenterWindow(window, width, height);
            return window;
        }
        /// <summary>
        /// Center Window based on the width an height
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="window"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void CenterWindow<T>(T window, float width = 400, float height = 400) where T : EditorWindow
        {
            window.position = new(
               (Screen.currentResolution.width / 2) - width / 2,
               (Screen.currentResolution.height / 2) - height / 2,
               width,
               height
           );
        }
    }

    public static class PoketEditorComponents
    {
        /// <summary>
        /// A standart Text field with Label
        /// </summary>
        /// <param name="input"></param>
        /// <param name="fieldName"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="style"></param>
        /// <returns>Text in field</returns>
        public static string TextField(string input, string fieldName = "Textfield", float x = 0, float y = 0, PoketEditorStyle style = null)
        {
            style ??= new(100, 20);

            float labelWidth = LabelField(fieldName, x, y);
            float fieldX = style.FixedStartPixel < 0 ? (x + labelWidth + 10) : style.FixedStartPixel;

            return Field(input, fieldX, y, style);
        }
        /// <summary>
        /// A field to enter Hohle numbers with label
        /// </summary>
        /// <param name="input"></param>
        /// <param name="fieldName"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="style"></param>
        /// <returns>Value in field</returns>
        public static int IntField(int input, string fieldName = "Intfield", float x = 0, float y = 0, PoketEditorStyle style = null)
        {
            style ??= new(100, 20);

            float labelWidth = LabelField(fieldName, x, y);
            float fieldX = style.FixedStartPixel < 0 ? (x + labelWidth + 10) : style.FixedStartPixel;

            try
            {
                return int.Parse(Field(input.ToString(), fieldX, y, style));
            }
            catch
            {
                return input;
            }
        }

        /// <summary>
        /// A Field to selct a sprite
        /// IT DOSE NOT USE FIXED POSITIONING
        /// </summary>
        /// <param name="input"></param>
        /// <param name="fieldName"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="style"></param>
        /// <returns>Sprite</returns>
        public static Sprite SpriteField(Sprite input, string fieldName = "Spritefield", float x = 0, float y = 0, PoketEditorStyle style = null)
        {
            LabelField(fieldName, x, y);

            EditorGUILayout.Space(style.DynamicYOffset);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space(style.FixedStartPixel);

            Sprite sprite = (Sprite)EditorGUILayout.ObjectField(input, typeof(Sprite), false, GUILayout.MaxWidth(style.Width));

            EditorGUILayout.Space(style.FixedEndPixel);
            EditorGUILayout.EndHorizontal();

            return sprite;
        }
        /// <summary>
        /// A field to get a game obj. 
        /// IT DOSE NOT USE FIXED POSITIONING
        /// </summary>
        /// <param name="input"></param>
        /// <param name="fieldName"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="style"></param>
        /// <returns>GameObject</returns>
        public static GameObject GameObjectField(GameObject input, string fieldName = "Spritefield", float x = 0, float y = 0, PoketEditorStyle style = null)
        {
            LabelField(fieldName, x, y);

            EditorGUILayout.Space(style.DynamicYOffset);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space(style.FixedStartPixel);

            GameObject tempGameObject = (GameObject)EditorGUILayout.ObjectField(input, typeof(GameObject), false, GUILayout.MaxWidth(style.Width));

            EditorGUILayout.Space(style.FixedEndPixel);
            EditorGUILayout.EndHorizontal();

            return tempGameObject;
        }

        /// <summary>
        /// A simple field to enter text without label
        /// </summary>
        /// <param name="input"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="style"></param>
        /// <returns>text in Field</returns>
        public static string Field(string input, float x, float y, PoketEditorStyle style)
        {
            style ??= new(500, 20);

            style = SetFixedEndPixelWidth(style, x);

            if (style.FixedStartPixel > 0)
                x = style.FixedStartPixel;

            return GUI.TextField(new(x, y, style.Width, style.Height), input);
        }

        /// <summary>
        /// A Label that returns its Width
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public static float LabelField(string fieldName, float x = 0, float y = 0, PoketEditorStyle style = null)
        {
            style ??= new(GetLabelWidth(fieldName), 20);

            GUI.Label(new Rect(x, y, style.Width, style.Height), fieldName);

            return style.Width;
        }
        /// <summary>
        /// Multiplies the number of chars by 8
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static float GetLabelWidth(string text)
        {
            return GUI.skin.label.CalcSize(new GUIContent(text)).x;
        }

        private static PoketEditorStyle SetFixedEndPixelWidth(PoketEditorStyle style, float x = 0, float labelWidth = 0, float offset = 0)
        {
            if (style.FixedEndPixel < 1)
                return style;

            float tempWidth = style.FixedEndPixel - (x + labelWidth + offset);

            style.MaxWidth = tempWidth;
            style.Width = tempWidth;

            return style;
        }
    }
    /// <summary>
    /// A Styling class for Poket Editor elements
    /// </summary>
    public class PoketEditorStyle
    {
        //Width
        private float _width = 20;
        public float Width
        {
            set
            {
                _width = Mathf.Clamp(value, 0, MaxWidth);
            }
            get => _width;
        }
        private float _maxWidth = 0;
        public float MaxWidth { set { _maxWidth = value; } get => _maxWidth; }

        //End and start width behavior
        private float _fixedEndPixel = -1;
        public float FixedEndPixel { set { _fixedEndPixel = value; } get => _fixedEndPixel; }
        private float _fixedStartPixel = -1;
        public float FixedStartPixel { set { _fixedStartPixel = value; } get => _fixedStartPixel; }

        //height
        private float _height = 20;
        public float Height { set { _height = value; } get => _height; }
        //Dynmic offset
        private float _dynamicYOffset = 0;
        public float DynamicYOffset { set { _dynamicYOffset = value; } get => _dynamicYOffset; }


        public PoketEditorStyle(float width, float height, float maxWidth = -1, float fixedEndPixel = -1, float fixedStartPixel = -1, float dynamicYOffset = 0)
        {
            if (maxWidth < 0)
                MaxWidth = width;
            else
                MaxWidth = maxWidth;

            FixedEndPixel = fixedEndPixel;
            FixedStartPixel = fixedStartPixel;

            DynamicYOffset = dynamicYOffset;

            Width = width;
            Height = height;
        }


    }
}
