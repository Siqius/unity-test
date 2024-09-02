using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Body and Animation")]
    [SerializeField] Animator animator;
    [SerializeField] Transform bodyHolder;

    [Header("Movement")]
    [SerializeField] float moveSpeed = 2f;


    [SerializeField] PlayerInputHandler inputHandler;

    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void MovePlayer()
    {
        float x = inputHandler.MoveInput.x;
        float y = inputHandler.MoveInput.y;

        Vector2 move = new Vector2(x, y).normalized * moveSpeed;

        animator.SetFloat("Speed", move.magnitude);

        rb.velocity = move;
    }

    private void RotatePlayer()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        float dx = mousePosition.x - transform.position.x;
        float dy = mousePosition.y - transform.position.y;
        Vector2 direction = new Vector2(dx, dy);

        transform.up = direction;
        bodyHolder.up = Vector2.up;
    }
}
