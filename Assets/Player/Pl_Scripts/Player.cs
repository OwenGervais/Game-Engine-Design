using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    public Collider2D col;

    [SerializeField] private float speed = 1.5f;

    // One entry per frame of input.
    private struct Frame
    {
        public float horizontal;
        public float vertical;
        public bool focus;
    }

    // static so the recording survives the scene reload
    private static readonly List<Frame> run = new List<Frame>();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetStatics() => run.Clear();

    private int replayLength;   // how many recorded frames to replay this time
    private int playIndex;

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
        if (playIndex < replayLength)
        {
            frame = run[playIndex++];
        }

        //Record
        else
        {
            frame.horizontal = Input.GetAxisRaw("Horizontal");
            frame.vertical = Input.GetAxisRaw("Vertical");
            frame.focus = Input.GetKey(KeyCode.LeftShift);
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
