using UnityEngine;
using UnityEditor;
using PoketAPI.Editor;
using PEC = PoketAPI.Editor.PoketEditorComponents;
using System;
using System.Reflection;
using System.Linq;
using UnityEditor.EditorTools;

public class ItemEnemyCreator : EditorWindow
{
    
        private static SCR_Events loadedEvent = null;
    private static E_Types e_Types;
    public static void CreateWindow(SCR_Events loadWithEvent, E_Types _e_Types)
    {
        loadedEvent = loadWithEvent;
        e_Types = _e_Types;
        EditorWindow ItemEnemyWindow = BaseEditor.CreateWindow<ItemEnemyCreator>(loadWithEvent.eventName, 300, 600);
        ItemEnemyWindow.Focus();
    }

    private SCR_Events loaded = null;
    private E_Types localEType = E_Types.None;

    //SCR Values
    private Sprite icon = null;
    private int spawnChance = 0;
    private string newName = "new";
    //Object Values
    private string objName = "";
    private Sprite objSprite = null;
    private MonoScript[] scriptsOnObj = new MonoScript[0];

    private bool finished = false;

    void OnEnable()
    {


        //Window Values
        loaded = loadedEvent;
        loadedEvent = null;

        localEType = e_Types;
        e_Types = E_Types.None;

        if (loaded == null)
            return;
        //SCR Values
        newName = loaded.eventName;
        spawnChance = loaded.chance;
        icon = loaded.icon;

        if (loaded.eventObject == null)
            return;
        //Spawn obj Values
        objName = loaded.eventObject.name;
        objSprite = loaded.eventObject.GetComponent<SpriteRenderer>().sprite;

        MonoBehaviour[] behaviour = loaded.eventObject.GetComponents<MonoBehaviour>();

        scriptsOnObj = behaviour.Where(c => c != null).Select(c => MonoScript.FromMonoBehaviour(c)).ToArray();
    }
    //On GUI
    private PoketEditorStyle baseStyle = new(0, 20, fixedEndPixel: 290, fixedStartPixel: 100);

    void OnGUI()
    {
        if (finished)
        {
            FinishView();
            return;
        }
        //Show error box that no type was found
        if (localEType == E_Types.None || localEType == E_Types.Perk || localEType == E_Types.Event)
        {
            EditorGUI.HelpBox(new(0, 0, 300, 150), "Wrong type was given: " + localEType.ToString(), MessageType.Warning);
            return;
        }

        //Defoult values
        float width = this.position.width;


        // SCR Values
        newName = PEC.TextField(newName, "Name:", 0, 20, baseStyle);
        spawnChance = PEC.IntField(spawnChance, "Spawn Chance:", 0, 45, baseStyle);
        icon = PEC.ObjectField(icon, "Icon:", 0, 70, new(290, 19, fixedStartPixel: 97, fixedEndPixel: 8, dynamicYOffset: 70));

        //Event Obj
        PEC.LabelField("Event Object", 150 - PEC.GetLabelWidth("Event Object") / 2, 105);
        objSprite = PEC.ObjectField(objSprite, "Object Sprite:", 0, 120, new(290, 19, fixedStartPixel: 97, fixedEndPixel: 8, dynamicYOffset: -47));
        objName = PEC.TextField(objName, "Object Name:", 0, 145, baseStyle);

        //Show script array
        PEC.LabelField("Scripts On Fall Object:", 0, 160);
        EditorGUILayout.BeginVertical();
        float lastY = 180;
        for (int i = 0; i < scriptsOnObj.Length; i++)
        {
            scriptsOnObj[i] = PEC.ObjectField(scriptsOnObj[i], "Script" + i, 0, lastY, new(290, 19, fixedStartPixel: 97, fixedEndPixel: 8, dynamicYOffset: -40));
            EditorGUILayout.Space(-36);
            lastY += 20;
        }
        EditorGUILayout.EndVertical();

        lastY += 10;

        //Add Script to element
        if (GUI.Button(new(50, lastY, 100, 30), "+"))
        {
            RebuildArray(1);
        }

        //Remove script element
        if (GUI.Button(new(150, lastY, 100, 30), "-"))
        {
            if (scriptsOnObj.Length == 0)
                return;

            RebuildArray(-1);
        }

        lastY += 60;
        Handles.BeginGUI();
        Handles.DrawLine(new(0, lastY), new(width, lastY));
        Handles.EndGUI();
        lastY += 10;

        //Add Script to element
        if (GUI.Button(new(50, lastY, 100, 30), "Finish"))
        {
            Finish();
        }
        //Remove script element
        if (GUI.Button(new(150, lastY, 100, 30), "Save State"))
        {

        }
    }

    //Finish Values
    private string scrPath = "";
    private string objPath = "";
    private string scrName = "";
    private SCR_Events folderEvent = null;
    private bool backupFiles = true;
    private void Finish()
    {
        switch (localEType)
        {
            case E_Types.Item:
                scrPath = scrPath == "" ? "Assets\\Settings\\SCR\\Items" : scrPath;
                objPath = objPath == "" ? "Assets\\Prefabs\\Items\\" + objName : objPath;
                scrName = scrName == "" ? "IT_" + newName : scrName;
                break;

            case E_Types.Enemy:
                scrPath = scrPath == "" ? "Assets\\Settings\\SCR\\Enemies" : scrPath;
                objPath = objPath == "" ? "Assets\\Prefabs\\Items\\Enemies\\" + objName : objPath;
                scrName = "EY_" + newName;
                break;
        }

        folderEvent = EditorFunctions.GetEvent(scrPath, loaded.eventName);
        finished = true;
    }
    //Finish View 
    private void FinishView()
    {
        int yPx = 20;

        PEC.LabelField("Settings for Build", x: 20);

        if (folderEvent != null)
        {
            backupFiles = PEC.Toggle(backupFiles, "Backup files", 0, yPx, baseStyle);
            yPx += 25;
        }

        PEC.LabelField("File Settings:", 20, yPx, baseStyle);
        yPx += 25;

        scrName = PEC.TextField(scrName, "SCR Name", x: 0, y: yPx, baseStyle);
        yPx += 20;

        PEC.LabelField("Save to path:", y: yPx, x: 20);
        yPx += 25;

        scrPath = PEC.FolderField(scrPath, "SCR Path", 0, yPx, baseStyle);
        yPx += 20;

        objPath = PEC.FolderField(objPath, "Obj Path", 0, yPx, baseStyle);
        yPx += 25;

        Handles.BeginGUI();
        Handles.DrawLine(new(0, yPx), new(position.width, yPx));
        Handles.EndGUI();
        yPx += 5;


        //Add Script to element
        if (GUI.Button(new(50, yPx, 100, 30), "Build"))
        {
            Finish();
        }
        //Remove script element
        if (GUI.Button(new(150, yPx, 100, 30), "Back"))
        {
            finished = false;
        }

    }

    private void ShowMonoPropertys(float lastY, PoketEditorStyle baseStyle)
    {
        //Show script propertys
        for (int i = 0; i < scriptsOnObj.Length; i++)
        {
            if (scriptsOnObj[i] == null)
            {
                continue;
            }

            Type scriptClass = scriptsOnObj[i].GetClass();

            if (scriptClass == null)
                continue;

            var fields = scriptClass.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(f => f.IsPublic || f.GetCustomAttribute<SerializeField>() != null);

            foreach (var x in fields)
            {
                PEC.LabelField(x.FieldType.Name, 0, lastY, baseStyle);
                lastY += 20;
            }
            lastY += 20;

        }
    }

    private void RebuildArray(int changeDirection)
    {
        MonoScript[] tempArray = scriptsOnObj;
        scriptsOnObj = new MonoScript[scriptsOnObj.Length + changeDirection];

        int leangth = changeDirection > 0 ? tempArray.Length : scriptsOnObj.Length;

        for (int i = 0; i < leangth; i++)
        {
            scriptsOnObj[i] = tempArray[i];
        }
    }
}
