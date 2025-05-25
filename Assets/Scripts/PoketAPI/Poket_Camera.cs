using UnityEngine;

namespace PoketAPI.Camera {
    public static class CameraData
    {
        public static float GetWidth()
        {
            return UnityEngine.Camera.main.aspect * (UnityEngine.Camera.main.orthographicSize * 2);
        }
        public static float GetHight()
        {
            return UnityEngine.Camera.main.orthographicSize * 2;
        }
        public static void test()
        {
            Debug.Log("d");
        }
    }
}
