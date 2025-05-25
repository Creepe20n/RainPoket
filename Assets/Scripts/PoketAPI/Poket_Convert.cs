using UnityEngine;

namespace PoketAPI.Convert {
    public class ConvertPosition
    {
        public static Vector2 ToWorldPoint(Vector2 ConvertPos)
        {
            return UnityEngine.Camera.main.ScreenToWorldPoint(ConvertPos);
        }
        public static float X_Distance(Vector2 Dist1, Vector2 Dist2)
        {
            Dist1 = new Vector2(Dist1.x, 0); Dist2 = new Vector2(Dist2.x, 0);
            return Vector2.Distance(Dist1, Dist2);
        }
        public static float X_Distance(float Dist1,float Dist2)
        {
              Vector2 dist1 = new Vector2(0,Dist1);
            Vector2 dist2 = new Vector2(0,Dist2);
            
            return Vector2.Distance(dist1, dist2);
        }
        public static float Y_Distance(Vector2 Dist1, Vector2 Dist2)
        {
            Dist1 = new Vector2(0, Dist1.y);
            Dist2 = new Vector2(0, Dist2.y);

            return Vector2.Distance(Dist1, Dist2);
        }
        public static float Y_Distance(float Dist1,float Dist2) {
            Vector2 dist1 = new Vector2(0,Dist1);
            Vector2 dist2 = new Vector2(0,Dist2);
            
            return Vector2.Distance(dist1, dist2);
        }
    }
}
