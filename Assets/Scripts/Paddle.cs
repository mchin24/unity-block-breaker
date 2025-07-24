using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Paddle : MonoBehaviour
{
    public int i = 0;
    public AudioClip sound;
    private BoxCollider backgroundCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        backgroundCollider = GameObject.Find("background").GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 paddlePos = new Vector3(transform.position.x, transform.position.y, 0f);
        float mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        paddlePos.x = Mathf.Clamp(mousePos, backgroundCollider.bounds.min.x + .5f, backgroundCollider.bounds.max.x - .5f);
        transform.position = paddlePos;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().pitch = Time.timeScale;
        GetComponent<AudioSource>().PlayOneShot(sound);
        
        Rigidbody2D collisionRb = collision.gameObject.GetComponent<Rigidbody2D>(); 
        
        // If the ball hits the left side of the paddle but was travelling to the right, send it back left
        if (collision.transform.position.x < transform.position.x && collisionRb.velocity.x > 0)
        {
            collisionRb.velocity = new Vector2(-collisionRb.velocity.x, 10f);
        }
        // If the ball hits the right side of the paddle but was travelling to the left, send it back right
        else if (collision.transform.position.x > transform.position.x && collisionRb.velocity.x < 0)
        {
            collisionRb.velocity = new Vector2(-collisionRb.velocity.x, 10f);
        }
        
    }
}
