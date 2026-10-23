using UnityEngine;

public class PluginTest : MonoBehaviour
{
    private void Start()
    {
        MyPlugin.ID = 10;
        Debug.Log(MyPlugin.ID);
    }
}