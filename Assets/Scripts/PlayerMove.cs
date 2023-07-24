using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using static Platformer.Core.Simulation;

public class PlayerMove : MonoBehaviour
{
    Animator animator;
    public float speed = 10f;
    public float jumpSpeed = 10f;
    public float bulletSpeed = 10f;
    public JumpState jumpState = JumpState.Grounded;
    private bool stopJump;
    private Rigidbody2D rb2d;
    AudioSource fxSound;
    public AudioClip jumpAudio;
    private bool isShooting;
    private float shootDelay = 1f;


    //public Health health; //Pitää importaa jotain?

    // Start is called before the first frame update
    void Start()
    {
      //Reference to rigidbody component
      rb2d = GetComponent<Rigidbody2D> ();
      fxSound = GetComponent<AudioSource> ();
      fxSound.clip = jumpAudio;
    }

    // Update is called once per frame
    void Update()
    {
        //To which direction moves (detect input) and how much
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveX,0, 0);
        if (Input.GetButtonDown("Jump")) {
              rb2d.AddForce(new Vector2(0,jumpSpeed),ForceMode2D.Impulse);
              fxSound.Play();
        }
        // if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
        //     jumpState = JumpState.PrepareToJump;
        // else if (Input.GetButtonUp("Jump"))
        // {
        //     stopJump = true;
        //     rb2d.AddForce(new Vector2(0,jumpSpeed),ForceMode2D.Impulse);
        //     fxSound.Play();
        //     //Schedule<PlayerStopJump>().player = this;
        //
        // }
        //transform.position += move * speed * Time.deltaTime;
        
        //transform.Rotate(0f, speed * Time.deltaTime, 0f, Space.Self);
        transform.Translate(move * speed * Time.deltaTime);
        //rb2d.AddForce (move * speed);

    }
    void ResetShot()
    {
      isShooting = false;
    }
    // void UpdateJumpState()
    // {
    //     jump = false;
    //     switch (jumpState)
    //     {
    //         case JumpState.PrepareToJump:
    //             jumpState = JumpState.Jumping;
    //             jump = true;
    //             stopJump = false;
    //             break;
    //         case JumpState.Jumping:
    //             if (!IsGrounded)
    //             {
    //                 Schedule<PlayerJumped>().player = this;
    //                 jumpState = JumpState.InFlight;
    //             }
    //             break;
    //         case JumpState.InFlight:
    //             if (IsGrounded)
    //             {
    //                 Schedule<PlayerLanded>().player = this;
    //                 jumpState = JumpState.Landed;
    //             }
    //             break;
    //         case JumpState.Landed:
    //             jumpState = JumpState.Grounded;
    //             break;
    //     }
    // }
    public enum JumpState
    {
        Grounded,
        PrepareToJump,
        Jumping,
        InFlight,
        Landed
    }
}
// public class PlayerStopJump : Simulation.Event<PlayerStopJump>
// {
//     public PlayerController player;
//
//     public override void Execute()
//     {
//
//     }
// }
