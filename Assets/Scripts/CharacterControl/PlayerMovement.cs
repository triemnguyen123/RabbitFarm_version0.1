using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    Vector2 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.gravityScale = 0f; // Tắt trọng lực để di chuyển top-down
    }

    void FixedUpdate()
    {
        MoveCharacter();
    }
    private void Update()
    {
        
    }

    public void MoveCharacter()
    {
        float moveInputHorizontal = Input.GetAxis("Horizontal");
        float moveInputVertical = Input.GetAxis("Vertical");
        animator.SetFloat("Horizontal", moveInputHorizontal);
        animator.SetFloat("Vertical", moveInputVertical);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        movement = new Vector2(moveInputHorizontal, moveInputVertical).normalized * moveSpeed;

        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        
    }
}
