using UnityEngine;

public class B_ID : MonoBehaviour
{
    [SerializeField] private string objID;
    [SerializeField] protected E_IETypes objType;

    public string ObjID
    {
        private set { }
        get => objID;
        
    }

#if UNITY_EDITOR
    void Start()
    {
        if (ObjID != "")
            return;

        throw new System.NotImplementedException();
    }
}
#endif