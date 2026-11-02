using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField] private float speed = 1.5f;

    /*Singular Frame of input
    private struct Frame
    {
        public float horizontal;
        public float vertical;
        public bool focus;
    }*/

    //States for commands
    private Vector2 movementDir;
    private bool focused;

    //List of frames recorded. Static so that it persists across scene reloads.
    private static readonly List<ICommand[]> run = new List<ICommand[]>();

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
        //Frame frame;

        ICommand[] frame;

        //Replay
        if (currentFrame < replayLength)
        {
            //Make current inputs equal to the inputs recorded in the current frame.
            frame = run[currentFrame++];
        }

        //Record
        else
        {
            frame = new ICommand[]
            {
                new MoveCommand(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))),
                new FocusCommand(Input.GetKey(KeyCode.LeftShift))
            };
            

            //Add the current inputs as a frame to the run list.
            run.Add(frame);
        }

        foreach (ICommand command in frame)
        {
            command.Execute(this);
        }

        //Ternary operation cause its clean af
        float focusSpeed = focused ? 0.5f : 1f;

        Vector3 movement = new Vector3(movementDir.x, movementDir.y, 0f);

        movement.Normalize();

        movement = new Vector3(movement.x * speed * focusSpeed, movement.y * speed * focusSpeed, 0f);

        rb.linearVelocity = movement;

    }

    public void SetMoveDirection(Vector2 movementDir)
    {
        this.movementDir = movementDir;
    }

    public void SetFocus(bool focused)
    {
        this.focused = focused;
    }
}