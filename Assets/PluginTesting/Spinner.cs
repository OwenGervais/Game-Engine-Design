using UnityEngine;

public class Spinner : MonoBehaviour
{
    private float newRotation;

    void Update()
    {
        newRotation += MyPlugin.Rotation;

        this.transform.rotation = Quaternion.Euler(0, 0, newRotation);
    }
}
