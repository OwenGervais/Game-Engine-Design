using UnityEngine;

public class SingletonBaseTesting : MonoBehaviour
{
    void Awake()
    {
        SingletonBase.Instance.TestMethod();
    }
}
