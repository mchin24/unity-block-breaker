using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Paddle paddle;
    public bool gameStarted = false;
    private Vector3 paddleVector;
    private Rigidbody2D rb;
    private TrailRenderer _trailRenderer;
    private GameManager _gameManager;

    public float minSpeed = 10;
    public float maxSpeed = 20;

    public float minVerticalMovement = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        // Create vector based on ball's radius and paddle's position. Will be used to position ball before launch.
        paddleVector = new Vector3(0, (GetComponent<CircleCollider2D>().radius) + (paddle.GetComponent<BoxCollider2D>().size.y / 2) , 0);
        rb = GetComponent<Rigidbody2D>();
        _trailRenderer = GetComponent<TrailRenderer>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager.GetGameState() == GameState.NotStarted)
        {
            transform.position = paddle.transform.position + paddleVector;
            _trailRenderer.enabled = false;

            if (Input.GetMouseButtonDown(0))
            {
                gameStarted = true;
                rb.velocity = new Vector2(Random.Range(-2.0f, 2.0f), 10f);
                _trailRenderer.enabled = true;
            }
        }

        launchBall();
    }

    public void launchBall()
    {
        Vector2 direction = rb.velocity;
        float speed = direction.magnitude;
        direction.Normalize();

        if (direction.x > -minVerticalMovement && direction.x < minVerticalMovement)
        {
            direction.x = direction.x < 0 ? -minVerticalMovement : minVerticalMovement;
            direction.y = direction.y < 0 ? -1 + minVerticalMovement : 1 - minVerticalMovement;
            
            rb.velocity = direction * speed;
        }

        if (speed < minSpeed || speed > maxSpeed)
        {
            speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
            rb.velocity = direction * speed;
        }
    }
}
