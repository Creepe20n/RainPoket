using UnityEngine;
using PoketAPI.Convert;
namespace PoketAPI.Touch {
    public static class GetTouch {
        //The Start touch position
        public static Vector2 touchStart = Vector2.zero;

        public static bool IsTouching() {
            if(Input.touchCount <= 0) {
                touchStart = Vector2.zero;
                return false;
            }
            else
                return true;
        }

        public static Vector2 Position(bool raw = false) {
            if(Input.touchCount == 0) {
                touchStart = Vector2.zero;

                return Vector2.zero;
            }
            UnityEngine.Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began) {
                touchStart = raw ? touch.position : ConvertPosition.ToWorldPoint(touch.position);
            }

            if(raw) 
                return touch.position;
            
            return ConvertPosition.ToWorldPoint(touch.position);
        }
    }
    
    public static class GetTab
    {
        /// <summary>
        /// checks if the tab count is greater than 
        /// </summary>
        /// <param name="customTouchCount"></param>
        /// <returns></returns>
        public static bool DoubleTab(int customTouchCount = 1)
        {
            if (Input.touchCount <= 0)
                return false;

            UnityEngine.Touch t = Input.GetTouch(0);

            if (t.tapCount <= customTouchCount)
                return false;

            return true;
        }
    }
}
