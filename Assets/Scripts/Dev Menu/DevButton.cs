using UnityEngine;

public class DevButton : MonoBehaviour
{
    private SCR_Events scr_event;
    private Dev_MenuManager dev_MenuManager;

    public void SetValues(SCR_Events _scr_event, Dev_MenuManager _dev_MenuManager)
    {
        scr_event = _scr_event;
        dev_MenuManager = _dev_MenuManager;
    }

    public void ButtonPress()
    {
        dev_MenuManager.TriggerEvent(scr_event);
    }
}
