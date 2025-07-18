using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Paddle paddle;
    private bool gameStarted = false;
    private Vector3 paddleVector;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        paddleVector = new Vector3(0, (GetComponent<CircleCollider2D>().radius * 2) + (paddle.GetComponent<BoxCollider2D>().size.y / 2) , 0);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            transform.position = paddle.transform.position + paddleVector;

            if (Input.GetMouseButtonDown(0))
            {
                gameStarted = true;
                rb.velocity = new Vector2(2f, 10f);
            }
        }
    }
}
