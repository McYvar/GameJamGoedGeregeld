using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(1f, 100f)] private float speed;
    [SerializeField, Range(1f, 100f)] private float jumpForce;
    [SerializeField] private LayerMask GroundLayer;

    private Rigidbody2D rb;

    private bool leftInput;
    private bool rightInput;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int moveDirection = 0;
        if (leftInput)
        {
            moveDirection -= 1;
        }
        if (rightInput)
        {
            moveDirection += 1;
        }
        rb.velocity = new Vector2(speed * moveDirection, rb.velocity.y);
        if (moveDirection != 0) animator.SetBool("isWalking", true);
        else animator.SetBool("isWalking", false);

        if (moveDirection > 0) transform.localEulerAngles = new Vector3(0, 0, 0);
        else if (moveDirection < 0) transform.localEulerAngles = new Vector3(0, 180, 0);
        animator.SetBool("isGrounded", IsGrounded());
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, 0.1f, GroundLayer);
    }

    public void MoveLeft(InputAction.CallbackContext cc)
    {
        if (cc.started)
        {
            leftInput = true;
        }

        if (cc.canceled)
        {
            leftInput = false;
        }
    }

    public void MoveRight(InputAction.CallbackContext cc)
    {
        if (cc.started)
        {
            rightInput = true;
        }

        if (cc.canceled)
        {
            rightInput = false;
        }
    }

    public void Jump(InputAction.CallbackContext cc)
    {
        if (cc.started)
        {
            if (IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        if (cc.canceled)
        {
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y), 0.1f);
    }
}
