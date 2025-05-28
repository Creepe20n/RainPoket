using UnityEngine;

[CreateAssetMenu(fileName = "SCR_Events", menuName = "Game/SCR_Events")]
public class SCR_Events : ScriptableObject
{
    public GameObject eventObject;
    public string eventName;
    public int chance;
    public Sprite icon;
}
