using UnityEngine;
using UnityEditor;
using PoketAPI.Editor;
public class ItemEnemyCreator : EditorWindow
{
    public static void CreateWindow(SCR_Events loadWithEvent)
    {
        EditorWindow ItemEnemyWindow = BaseEditor.CreateWindow<ItemEnemyCreator>(loadWithEvent.eventName, 300, 600);

        ItemEnemyWindow.Focus();
            
    }

    string newName = "new";

    void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();

        
        newName = EditorGUILayout.TextField("Name: ", GUILayout.MinWidth(10));

        EditorGUILayout.EndHorizontal();
    }
}
