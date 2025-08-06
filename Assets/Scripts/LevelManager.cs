using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject[] bricks;
    public int count = 0;
    private GameManager _gameManager;
    public string finishTime;

    // Update is called once per frame
    void Update()
    {
        bricks = GameObject.FindGameObjectsWithTag("Brick");
        count = bricks.Length;
        Debug.Log("Brick count: " + count);

        if (count == 0)
        {
            Debug.Log("All bricks are gone");
            StartCoroutine(Pause());
        }
    }

    IEnumerator Pause()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _gameManager.SwitchState(GameState.Completed);
        _gameManager.ChangeText("You Win!");
        finishTime = _gameManager.formattedTime;
        
        Debug.Log("Total time: " + finishTime);
        
        yield return new WaitForSeconds(5);
        
        LoadScene(0);
    }

    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }
}
