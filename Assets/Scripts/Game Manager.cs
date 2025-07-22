using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

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
    private TMP_Text _text;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        
        _allBricks = FindObjectsOfType(typeof(Brick)) as Brick[];
        _allBalls = FindObjectsOfType(typeof(Ball)) as Ball[];

        _paddle = FindObjectOfType<Paddle>();
        
        print("Bricks: " + _allBricks.Length);
        print("Balls: " + _allBalls.Length);
        print("Paddle: " + _paddle);

        _text = FindAnyObjectByType<TMP_Text>();
        _text.text = "Click to begin";
        
        SwitchState(GameState.NotStarted);
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentState)
        {
            case GameState.NotStarted:
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
                
                print(formattedTime);

                bool allBlocksDestroyed = false;

                if (FindObjectOfType(typeof(Ball)) == null)
                {
                    SwitchState(GameState.Failed);
                }

                if (FindObjectsOfType(typeof(Brick)) == null)
                {
                    allBlocksDestroyed = true;
                    SwitchState(GameState.Completed);
                }
            }
                break;
            case GameState.Failed:
                break;
            case GameState.Completed:
                bool allBlocksDestroyedFinal = false;
                Ball[] others = FindObjectsOfType(typeof(Ball)) as Ball[];
                foreach (Ball other in others)
                {
                    Destroy(other.gameObject);
                }
                break;
        }
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
                //GetComponent<AudioSource>().PlayOneShot(startSound);
                break;
            case GameState.Completed:
                //GetComponent<AudioSource>().PlayOneShot(startSound);
                break;
            case GameState.Failed:
                //GetComponent<AudioSource>().PlayOneShot(failedSound);
                break;
        }
    }
}
