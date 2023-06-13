using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed;

    GameController controller;
    UIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<GameController>();
        uIManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DestroyZone"))
        {
            controller.IncreaseScore();
            uIManager.txtScore.text = "Score: " + controller.GetScore();
            Destroy(gameObject);
        }
    }
}
