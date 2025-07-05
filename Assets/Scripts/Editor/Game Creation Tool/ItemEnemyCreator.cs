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
    int spawnChance = 0;
    Sprite icon = null;
    GameObject test = null;

    void OnGUI()
    {
        float width = this.position.width;

        PoketEditorStyle baseStyle = new(0, 20, fixedEndPixel: 290, fixedStartPixel: 100);

        newName = PoketEditorComponents.TextField(newName, "Name:", 0, 20, baseStyle);
        spawnChance = PoketEditorComponents.IntField(spawnChance, "Spawn Chance:", 0, 45, baseStyle);

        test = PoketEditorComponents.GameObjectField(test, "obj", 0, 70, new(290, 19, fixedStartPixel: 97, fixedEndPixel: 8,dynamicYOffset:70));
        test = PoketEditorComponents.GameObjectField(test, "obj", 0, 95, new(290, 19, fixedStartPixel: 97, fixedEndPixel: 8,dynamicYOffset:-75));

    }
}
