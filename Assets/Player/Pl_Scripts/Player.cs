using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField] private float speed = 1.5f;

    //Singular Frame of input
    private struct Frame
    {
        public float horizontal;
        public float vertical;
        public bool focus;
    }

    //List of frames recorded. Static so that it persists across scene reloads.
    private static readonly List<Frame> run = new List<Frame>();

    //Number of frames recorded.
    private int replayLength; 

    //Current frame
    private int currentFrame;

    private void Awake()
    {
        //For ideal smooth movement I lock the frame rate at 60 frames per second.
        Time.captureFramerate = 60;
        rb = GetComponent<Rigidbody2D>();

        replayLength = run.Count;
    }

    // Update is called once per frame
    void Update()
    {
        // R restarts the scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }

        Frame frame;

        //Replay
        if (currentFrame < replayLength)
        {
            //Make current inputs equal to the inputs recorded in the current frame.
            frame = run[currentFrame++];
        }

        //Record
        else
        {
            frame.horizontal = Input.GetAxisRaw("Horizontal");
            frame.vertical = Input.GetAxisRaw("Vertical");
            frame.focus = Input.GetKey(KeyCode.LeftShift);

            //Add the current inputs as a frame to the run list.
            run.Add(frame);
        }

        //Ternary operation cause its clean af
        float focusSpeed = frame.focus ? 0.5f : 1f;

        Vector3 movement = new Vector3(frame.horizontal, frame.vertical, 0f);

        movement.Normalize();

        movement = new Vector3(movement.x * speed * focusSpeed, movement.y * speed * focusSpeed, 0f);

        rb.linearVelocity = movement;
    }
}
