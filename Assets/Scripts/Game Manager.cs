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
    public AudioClip startSound;
    public AudioClip failedSound;
    private GameState _currentState = GameState.NotStarted;
    private Brick[] _allBricks;
    private Ball[] _allBalls;
    private Paddle _paddle;
    private float _timer = 0.0f;
    private int _minutes;
    private int _seconds;
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
