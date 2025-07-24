using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Walls : MonoBehaviour
{
    public AudioClip sound;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        GetComponent<AudioSource>().PlayOneShot(sound);
    }
}
