using System;
using UnityEngine;

public class Freezeble : MonoBehaviour
{
    private float leftFreezeTime = 0f;
    private bool blockFreeze = false;
    [SerializeField] B_Entities toFreezeEntity;
    [SerializeField] E_FreezeState freezeState;
    [SerializeField] SpriteRenderer spriteRenderer;
    private E_FreezeState lastFreezeState;

    public void Freeze(float freezeTime)
    {
        leftFreezeTime += freezeTime;
        spriteRenderer.color = Color.blue;

        if (lastFreezeState == E_FreezeState.None)
            lastFreezeState = toFreezeEntity.E_FreezeState;
            
        toFreezeEntity.E_FreezeState = freezeState;
        blockFreeze = false;
    }

    void Update()
    {
        if (blockFreeze)
            return;

        leftFreezeTime -= Time.deltaTime;

        if (leftFreezeTime <= 0)
            UnFreeze();
    }

    public void UnFreeze()
    {
        leftFreezeTime = 0;
        spriteRenderer.color = Color.white;
        toFreezeEntity.E_FreezeState = lastFreezeState;
        lastFreezeState = E_FreezeState.None;
        blockFreeze = true;
    }
    void OnDisable()
    {
        UnFreeze();
    }
}
