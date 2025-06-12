using UnityEngine;

public class IT_Reverse : B_Item
{
    [SerializeField] float reverseTime = 2;
    [SerializeField] int scoreMultiplier = 3;
    public override void HitPlayer(GameObject player = null)
    {
        Reversable rev = player.GetComponent<Reversable>();

        if (rev == null)
            return;

        rev.Reverse(reverseTime,scoreMultiplier,kajiaSystem);
    }


}
