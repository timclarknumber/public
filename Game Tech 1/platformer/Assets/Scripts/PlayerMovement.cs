using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float xSpeed = 10f;
    [SerializeField] private float jumpForce = 800f;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D _rb;

    private float _xMoveInput;

    private bool _shouldJump;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        _xMoveInput = Input.GetAxis("Horizontal") * xSpeed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _shouldJump = true;
        }
    }

    private void FixedUpdate()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);
        bool isGrounded = col != null;
        _rb.velocity = new Vector2(_xMoveInput, _rb.velocity.y);
        if (_shouldJump)
        {
            if (isGrounded)
            {
                _rb.AddForce(Vector2.up * jumpForce * Time.deltaTime);
            }
            _shouldJump=false;
        }
    }
}
