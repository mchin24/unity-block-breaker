using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBall : BasePowerUp
{
    public GameObject BallPrefab;

    public float minSpeed = 10;
    public float maxSpeed = 20;

    public float minVerticalMovement = 0.5f;

    protected override void OnPickup()
    {
        base.OnPickup();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Paddle")
        {
            launchBall();
        }
    }

    public void launchBall()
    {
        Vector2 direction = GetComponent<Rigidbody2D>().velocity;

        float speed = direction.magnitude;
        direction.Normalize();

        if (direction.x > -minVerticalMovement && direction.x < minVerticalMovement)
        {
            direction.x = direction.x < 0 ? -minVerticalMovement : minVerticalMovement;
            direction.y = direction.y < 0 ? -1 + minVerticalMovement : 1 - minVerticalMovement;
            
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }

        if (speed < minSpeed || speed > maxSpeed)
        {
            speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }
}
