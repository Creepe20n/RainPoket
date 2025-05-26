using UnityEngine;

public interface I_KajiaControlls
{
    public void KillObj();
    public void EndObjAction();
    public void FullfillAction();
    /// <summary>
    /// Called only once when spawned
    /// </summary>
    /// <param name="kajia"></param>
    public void SetKajiaValues(KajiaSystem kajia);
}
