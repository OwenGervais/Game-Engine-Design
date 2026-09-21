using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField][Range(1, 100)] private float spinSpeed;

    void Start()
    {
        Debug.Log("Hello World!");
    }
    
    void Update()
    {
        transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
    }
}
