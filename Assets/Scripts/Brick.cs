using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource), typeof(Animation))]
public class Brick : MonoBehaviour
{
    public int maxHits;
    public int timesHit;
    private Collider2D _collider2D;
    private AudioSource _audioSource;
    private Renderer _renderer;

    public AudioClip hitSound;
    public float pitchStep;
    public float maxPitch;

    public static float Pitch = 1;

    public bool fallDown = false;

    [HideInInspector] public bool isDestroyed = false;

    private Vector2 _velocity = Vector2.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        timesHit = 0;
        _collider2D = GetComponent<Collider2D>();
        _audioSource = GetComponent<AudioSource>();
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fallDown && _velocity != Vector2.zero)
        {
            Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        }
    }

    private void OnBecameInvisible()
    {
        isDestroyed = true;
        Destroy(gameObject);
    }

    private IEnumerator OnCollisionExit2D(Collision2D collision)
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            _collider2D.enabled = false;
            GetComponent<Animation>().Play();
            
            yield return new WaitForSeconds(GetComponent<Animation>()["Woggle"].length);

            if (fallDown)
            {
                _velocity = new Vector2(0, Random.Range(1, 12.0f) * -1);
            }
            else
            {
                _renderer.enabled = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        timesHit++;
        Pitch += pitchStep;

        if (Pitch > maxPitch)
        {
            Pitch = 1;
        }

        _audioSource.pitch = Pitch;
        _audioSource.PlayOneShot(hitSound);
        
        StartCoroutine(OnCollisionExit2D(other));
    }
}
