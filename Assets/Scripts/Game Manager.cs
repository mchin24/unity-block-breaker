using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    NotStarted,
    Playing,
    Completed,
    Failed
}

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    public AudioClip StartSound;
    public AudioClip FailedSound;
    private GameState currentState = GameState.NotStarted;
    private Brick[] allBricks;
    private Ball[] allBalls;
    private Paddle paddle;
    private float Timer = 0.0f;
    private int minutes;
    private int seconds;
    public string formattedTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
