using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(AudioSource))]
public class BasePowerUp : MonoBehaviour
{
    public float dropSpeed = 1;
    public AudioClip sound;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
    }

    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Paddle")
        {
            print("Power up collected");
            OnPickup();
            
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Renderer>().enabled = false;
            
            GetComponent<AudioSource>().pitch = Time.timeScale;
            GetComponent<AudioSource>().PlayOneShot(sound);
            
            yield return new WaitForSeconds(sound.length);
        }
    }

    protected virtual void OnPickup()
    {
        
    }
}
