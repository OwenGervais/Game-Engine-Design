using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField] private float speed = 10f;

    private void Awake()
    {
        //For ideal smooth movement I lock the frame rate at 60 frames per second.
        Time.captureFramerate = 60;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //Ternary operation cause its clean af
        float focusSpeed = Input.GetKey(KeyCode.LeftShift) ? 0.5f : 1f;

        Vector3 movement = new Vector3(horizontal, vertical, 0f);

        movement.Normalize();

        movement = new Vector3(movement.x * speed * focusSpeed, movement.y * speed * focusSpeed, 0f);

        rb.linearVelocity = movement;
    }
}