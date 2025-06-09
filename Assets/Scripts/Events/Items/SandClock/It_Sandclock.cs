using UnityEngine;

public class It_Sandclock : B_Item
{
    [SerializeField] private float slowDownValue;
    [SerializeField] private float slowforSeconds;
    public override void HitPlayer(GameObject player = null)
    {
        GameTime.Instance.SlowTimeDown(slowDownValue,slowforSeconds, E_Time.EventTime);
    }
}
