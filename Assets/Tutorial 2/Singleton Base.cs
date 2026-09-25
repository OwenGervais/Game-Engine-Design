using UnityEngine;
public class SingletonBase : MonoBehaviour
{
    public static SingletonBase Instance { get; private set; }

    public virtual void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }


    public void TestMethod()
    {
        Debug.Log("Test Working");
    }
}

