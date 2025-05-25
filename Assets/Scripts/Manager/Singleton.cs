using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance;
    public virtual void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this as T;
    }
}
