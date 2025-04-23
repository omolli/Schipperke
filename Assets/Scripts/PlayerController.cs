using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 5f;
    public GameObject projectilePrefab;

    float moveX;
    bool jumping = false;

    Rigidbody2D _rb;
    SpriteRenderer _spriteRenderer;
    Animator _animator;

    private enum MovementState { idle, running, jumping, flying, falling }
    private MovementState movemenState = MovementState.idle;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.flipX = false;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerShoot();
        UpdateAnimationState();
    }

    private void PlayerMovement()
    {
        moveX = Input.GetAxis("Horizontal");
        movemenState = MovementState.running;
        if (moveX > 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (moveX < 0)
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            movemenState = MovementState.idle;
        }
        if (Input.GetButtonDown("Jump"))
        {
            jumping = true;
            _rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
            //fxSound.Play();
        }
        else
        {
            jumping = false;
        }
        transform.Translate(Vector2.right * Time.deltaTime * speed * moveX);
    }

    private void PlayerShoot()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var rotation = (_spriteRenderer.flipX) ? Quaternion.Inverse(projectilePrefab.transform.rotation) : projectilePrefab.transform.rotation;
            Vector3 spawnPosition = (_spriteRenderer.flipX) ? transform.position + transform.right : transform.position - transform.right;
            GameObject projectile = Instantiate(projectilePrefab, spawnPosition, projectilePrefab.transform.rotation);
            if (_spriteRenderer.flipX)
            {
                projectile.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }

            //Instantiate(projectilePrefab, transform.position, (_spriteRenderer.flipX ? projectilePrefab.transform.rotation : projectilePrefab.transform.rotation) );
        }
    }

        void UpdateAnimationState()
    {
        MovementState currentState;
        if (Mathf.Abs(moveX) > 0) {
            currentState = MovementState.running;
        } else
        {
            currentState = MovementState.idle;
        }

        if (jumping)
        {
            currentState = MovementState.jumping;
        } else if (_rb.linearVelocity.y > 0.1f)
        {
            currentState = MovementState.flying;
        } else if (_rb.linearVelocity.y < -0.1f)
        {
            currentState = MovementState.falling;
        }
        _animator.SetInteger("state", (int)currentState);
    }
}
