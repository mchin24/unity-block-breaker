using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    private AudioSource _audioSource;
    private GameState _currentState = GameState.NotStarted;
    private Brick[] _allBricks;
    private Ball[] _allBalls;
    private Paddle _paddle;
    private float _timer = 0.0f;
    private int _minutes;
    private int _seconds;
    public string formattedTime;
    private TMP_Text _text;
    public int Tries = 3;

    public GameObject restartButton;
    public GameObject mainButton;
    public GameObject buttonBackground;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        
        _allBricks = FindObjectsByType<Brick>(FindObjectsSortMode.None) as Brick[];
        _allBalls = FindObjectsByType<Ball>(FindObjectsSortMode.None) as Ball[];
        _audioSource = GetComponent<AudioSource>();

        _paddle = FindAnyObjectByType<Paddle>();
        
        print("Bricks: " + _allBricks.Length);
        print("Balls: " + _allBalls.Length);
        print("Paddle: " + _paddle);

        _text = FindAnyObjectByType<TMP_Text>();
        ChangeText("Click to begin");
        
        SwitchState(GameState.NotStarted);
    }

    public int UpdateBrickCount()
    {
        _allBricks = FindObjectsByType<Brick>(FindObjectsSortMode.None);
        return GetBrickCount();
    }

    private int GetBrickCount()
    {
        Debug.Log("Bricks: " + _allBricks.Length);
        return _allBricks.Length;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentState)
        {
            case GameState.NotStarted:
                ChangeText("Click to begin");
                if (Input.GetMouseButtonDown(0))
                {
                    SwitchState(GameState.Playing);
                }
                break;
            case GameState.Playing:
            {
                _timer += Time.deltaTime;
                _minutes = (int)(_timer / 60);
                _seconds = (int)(_timer - _minutes * 60);
                formattedTime = string.Format("{0:00}:{1:00}", _minutes, _seconds);
                
                ChangeText("Time: " + formattedTime);

                if (FindAnyObjectByType(typeof(Ball)) == null)
                {
                    SwitchState(GameState.Failed);
                }

                if (FindObjectsByType<Brick>(FindObjectsSortMode.None) == null)
                {
                    SwitchState(GameState.Completed);
                }
            }
                break;
            case GameState.Failed:
                ChangeText("You Lose!");
                break;
            case GameState.Completed:
                Ball[] others = FindObjectsByType<Ball>(FindObjectsSortMode.None) as Ball[];
                foreach (Ball other in others)
                {
                    Destroy(other.gameObject);
                }
                break;
        }
    }

    public void EnableButtons()
    {
        restartButton.SetActive(true);
        mainButton.SetActive(true);
        buttonBackground.SetActive(true);
    }

    public GameState GetGameState()
    {
        return _currentState;
    }

    public void SwitchState(GameState newState)
    {
        _currentState = newState;

        switch (_currentState)
        {
            default:
            case GameState.NotStarted:
                break;
            case GameState.Playing:
                _audioSource.PlayOneShot(startSound);
                break;
            case GameState.Completed:
                _audioSource.PlayOneShot(startSound);
                break;
            case GameState.Failed:
                _audioSource.PlayOneShot(failedSound);
                break;
        }
    }

    public void ChangeText(string text)
    {
        _text.text = text;
    }
}
