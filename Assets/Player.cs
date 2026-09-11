using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0,500,0), ForceMode.Force);
        }
    }
}
