using UnityEngine;

public class Reversable : MonoBehaviour
{
    [SerializeField] private B_Entities b_Entities;
    private float activeReverseTime;
    private KajiaSystem kajia;
    private int activeMutliply;
    private bool blockUnreverse = true;
    public void Reverse(float reverseTime, int scoreMultiplier = 0, KajiaSystem kajiaSystem = null)
    {
        activeReverseTime += reverseTime;

        if (b_Entities.MovementSpeed > 0)
            b_Entities.MovementSpeed *= -1;

        blockUnreverse = false;

        if (kajiaSystem == null)
            return;

        kajia = kajiaSystem;
        activeMutliply += scoreMultiplier;

        kajiaSystem.gameManager.ScoreMultiplier += scoreMultiplier;

    }
    void Update()
    {
        if (activeReverseTime <= 0)
        {
            if(!blockUnreverse)
                UnReverse();
            return;
        }
        activeReverseTime -= Time.deltaTime;
    }
    public void UnReverse()
    {
        activeReverseTime = 0;
        kajia.gameManager.ScoreMultiplier -= activeMutliply;

        if (b_Entities.MovementSpeed < 0)
            b_Entities.MovementSpeed *= -1;
    }
}
