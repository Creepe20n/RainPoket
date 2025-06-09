using System;
using UnityEngine;

public class It_StayAndGo : MonoBehaviour
{
    [SerializeField] private bool onEnable = false;
    [SerializeField] private float timeTillEnd = 2f;

    void OnEnable()
    {
        if (onEnable)
        {
            StartAction();
        }
    }

    public void StartAction(float _timeTillEnd = -1)
    {
        if (_timeTillEnd > 0)
        {
            timeTillEnd = _timeTillEnd;
        }
        Invoke(nameof(EndAction), timeTillEnd);
    }

    private void EndAction()
    {
        gameObject.SetActive(false);
    }
}
