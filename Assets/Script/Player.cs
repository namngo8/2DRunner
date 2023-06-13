using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;

    Rigidbody2D rigidbody2D;
    GameController controller;
    bool isJump = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        controller = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJump)
            {
                PlayerJump();
                isJump = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            controller.SetGameOver(true);
        }
    }

    private void PlayerJump()
    {
        rigidbody2D.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
    }
}
