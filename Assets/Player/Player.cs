using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    float focusSpeed = 1f;

    [SerializeField] private float speed = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //could use Ternary operation here instead
        if(Input.GetKey(KeyCode.LeftShift)) {focusSpeed = 0.5f;}
        else {focusSpeed = 1f;}

        Vector3 movement = new Vector3(horizontal * speed * focusSpeed * Time.deltaTime, vertical * speed * focusSpeed * Time.deltaTime, 0f);

        transform.position = transform.position + movement;
    }
}