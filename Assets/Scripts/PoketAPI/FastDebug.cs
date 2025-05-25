using UnityEngine;
using UnityEngine.UI;
namespace FastDebug
{
   
    public class D_text {
        GameObject D_textField;
        /// <summary>
        /// Create a Text field.
        /// row and column start at 1
        /// </summary>
        public D_text(int row,int column,Canvas canvas = null,RectTransform rectTransform = null,int fontSize = 100,string name = "New D_text",
            int allowedColumns = 3,int allowedRows=10)
        {
            //Look up deffults
            canvas = canvas == null ? GameObject.FindAnyObjectByType<Canvas>() : canvas;
            Font font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            //Create Text
            D_textField = new GameObject();
            D_textField.name = name;
            D_textField.AddComponent<Text>();
            //Set deffult values
            D_textField.transform.SetParent(canvas.transform);
                //Text
            D_textField.GetComponent<Text>().fontSize = fontSize;
            D_textField.GetComponent<Text>().font = font;
            D_textField.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
            D_textField.GetComponent<Text>().horizontalOverflow = HorizontalWrapMode.Overflow;
                //Transform
            D_textField.GetComponent<RectTransform>().sizeDelta = new Vector2(160,160);
            D_textField.GetComponent<RectTransform>().anchoredPosition = rectTransform != null ? rectTransform.position :
                CalculateRecPos(canvas,row,column,allowedColumns,allowedRows).position;
        }
        public void SetText(string input,Color textColor = new Color()) {
            //Color Text
            textColor = textColor == new Color() ? Color.white : textColor;
            D_textField.GetComponent<Text>().color = textColor;
            //Set text
            D_textField.GetComponent<Text>().text = input;
        }
        public RectTransform CalculateRecPos(Canvas canvas,int row,int column,int allowedColums,int allowedRows) {
            RectTransform C_rect = canvas.GetComponent<RectTransform>();
            float C_width = C_rect.rect.width;
            float C_height = C_rect.rect.height;
            //Calculate Position deffults
                //x
            float columnLength = C_width / allowedColums;
            float firstColumn = -C_width / 2 + D_textField.GetComponent<RectTransform>().sizeDelta.x / 1.8f;//Dont know why 1.8f but it works
                //y
            float rowLength = C_height / allowedRows;
            float firstRow = C_height / 2 - D_textField.GetComponent<RectTransform>().sizeDelta.y / 1.8f;
            //Calculate Final Position
            C_rect.localPosition = new Vector2(firstColumn + ((column - 1) * columnLength),firstRow + ((row - 1) * -rowLength));
            return C_rect;
        }
        public void SetActive(bool active) {
            D_textField.SetActive(active);
        }
    }
    public class D_print {
        public static void P_printArray<T>(T[] array) {
            for (int i = 0; i < array.Length; i++) {
                Debug.Log(array[i]);
            }
        }
        public static void P_print<T>(T value) {
            Debug.Log(value);
        }
    }
}