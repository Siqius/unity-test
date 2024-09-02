using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    private PlayerInputHandler inputHandler;

    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputHandler = PlayerInputHandler.instance;
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
    }
}
