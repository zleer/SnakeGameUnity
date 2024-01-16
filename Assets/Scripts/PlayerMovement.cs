using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public InputAction playerMovement;
    public Animator animator;


    Vector2 moveDirection = Vector2.zero;

    private void OnEnable()
    {
        playerMovement.Enable();
    }

    private void OnDisable()
    {
        playerMovement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        if (moveDirection != Vector2.zero)
        {
            animator.SetFloat("HorizontalIdle", moveDirection.x);
            animator.SetFloat("VerticalIdle", moveDirection.y);
        }

        moveDirection = playerMovement.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
