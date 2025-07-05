using UnityEngine;

public class B_ID : MonoBehaviour
{
    [SerializeField] private string objID;

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