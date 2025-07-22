using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class Brick : MonoBehaviour
{
    public int maxHits;
    public int timesHit = 0;
    private bool _isDestroyed = false;

    public AudioClip HitSound;
    public float PitchStep;
    public float MaxPitch;

    public static float pitch = 1;

    public bool FallDown = false;

    [HideInInspector] public bool IsDestroyed = false;

    private Vector2 _velocity = Vector2.Zero;
    
    // Start is called before the first frame update
    void Start()
    {
        timesHit = 0;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnBecameInvisible()
    {
        IsDestroyed = true;
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            Destroy(gameObject);
        }
    }
}
