using UnityEngine;
using UnityEditor;
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
        public static EditorWindow CreateWindow<T>(string title = "new Window",float width = 400, float height = 400) where T : EditorWindow
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
        public static void CenterWindow<T>(T window,float width = 400, float height = 400) where T : EditorWindow
        {
             window.position = new(
                (Screen.currentResolution.width / 2) - width / 2,
                (Screen.currentResolution.height / 2) - height / 2,
                width,
                height
            );
        }
    }
}
