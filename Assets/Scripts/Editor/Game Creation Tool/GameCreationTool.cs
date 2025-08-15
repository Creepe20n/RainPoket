using UnityEngine;
using UnityEditor;
using PoketAPI.Editor;
public class GameCreationTool : EditorWindow
{
    public static EditorWindow toolSelectorWindow = null;

    [MenuItem("Window/Game Creation Tool")]
    public static void OpenToolSelectorWindow()
    {
        if (toolSelectorWindow == null)
            toolSelectorWindow = BaseEditor.CreateWindow<GameCreationTool>("Tool Selector", 600, 400);

        toolSelectorWindow.Focus();
    }

    SCR_Events[] allEvents = null;
    E_Types viewType = E_Types.Item;
    void OnEnable()
    {
        allEvents = EditorFunctions.GetAllEvents("Assets\\Settings\\SCR\\Items");
    }

    void OnGUI()
    {
        float width = toolSelectorWindow.position.width;
        float height = toolSelectorWindow.position.height;

        //Draw right side menu
        //Draw background

        Rect sidePanelRect = new(0, 0, width * 0.3f, height);

        EditorGUI.DrawRect(sidePanelRect, new Color(0.15f, 0.15f, 0.15f));

        Handles.BeginGUI();

        Vector2 startSeperatorLine = new(sidePanelRect.width, 0);
        Vector2 enedSeperatorLine = new(sidePanelRect.width, height);

        Handles.color = Color.black;

        Handles.DrawLine(startSeperatorLine, enedSeperatorLine);

        Handles.EndGUI();
        //draw content
        GUI.color = new Color(0.65f, 0.65f, 0.65f);
        if (GUI.Button(new Rect(sidePanelRect.x, sidePanelRect.y, sidePanelRect.width, 50), "Items"))
        {

            allEvents = EditorFunctions.GetAllEvents("Assets\\Settings\\SCR\\Items");
            viewType = E_Types.Item;
        }
        if (GUI.Button(new Rect(sidePanelRect.x, sidePanelRect.y + 50, sidePanelRect.width, 50), "Enemys"))
        {

            allEvents = EditorFunctions.GetAllEvents("Assets\\Settings\\SCR\\Enemies");
            viewType = E_Types.Enemy;

        }
        if (GUI.Button(new Rect(sidePanelRect.x, sidePanelRect.y + 100, sidePanelRect.width, 50), "Perks"))
        {

            allEvents = EditorFunctions.GetAllEvents("Assets\\Settings\\SCR\\Perks");
            viewType = E_Types.Perk;
        }

        //Create menu Buttons
        GUI.color = new Color(0.75f, 0.75f, 0.75f);

        if (GUI.Button(new Rect(sidePanelRect.width + 20, sidePanelRect.y + 20, 50, 50), "+"))
        {
            switch (viewType)
            {
                case E_Types.Item:
                    SCR_Events itemEvent = CreateInstance<SCR_Events>();
                    itemEvent.eventName = "new Item";

                    ItemEnemyCreator.CreateWindow(itemEvent, E_Types.Item);
                    break;
                case E_Types.Enemy:
                    SCR_Events enemyEvent = CreateInstance<SCR_Events>();
                    enemyEvent.eventName = "new Enemy";

                    ItemEnemyCreator.CreateWindow(enemyEvent, E_Types.None);
                    break;
            }
        }
        GUI.Label(new Rect(sidePanelRect.width + 20, sidePanelRect.y + 70, 70, 13), "Create " + viewType);

        if (allEvents != null)
            GenerateAccesButtons(sidePanelRect, width);

    }

    private void GenerateAccesButtons(Rect sidePanelRect, float windowWidth)
    {
        float startX = sidePanelRect.width + 20;
        float activeX = startX;

        float startY = sidePanelRect.y + 20;

        const float plusX = 70;
        const float plusY = 70;

        float endX = ((sidePanelRect.x + sidePanelRect.width) + (windowWidth - sidePanelRect.width)) - 120;

        for (int i = 0; i < allEvents.Length; i++)
        {
            if (activeX >= endX)
            {
                startY += plusY;
                activeX = startX;
            }
            else
            {
                activeX += plusX;
            }

            if (GUI.Button(new Rect(activeX, startY, 50, 50), viewType.ToString()))
            {
                ItemEnemyCreator.CreateWindow(allEvents[i], viewType);
                return;
            }
            GUI.Label(new Rect(activeX, startY + 50, 70, 13), allEvents[i].eventName);

        }
    }
}
