using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject[] bricks;
    private GameManager _gameManager;
    public string finishTime;

    // Update is called once per frame
    void Update()
    {
        // Check how many bricks we have left. 0 bricks means the player has won.
        Brick[] bricks = FindObjectsByType<Brick>(FindObjectsSortMode.None);
        if (bricks.Length == 0)
        { 
            StartCoroutine(WinAction());
        }
    }

    IEnumerator WinAction()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
        _gameManager.SwitchState(GameState.Completed);
        _gameManager.ChangeText("You Win!");
        finishTime = _gameManager.formattedTime;
        
        // Wait 3 seconds before reloading the intro screen
        yield return new WaitForSeconds(5);
        
        // Is there another level after this?
        Scene thisScene = SceneManager.GetActiveScene();
        if (thisScene.buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            LoadScene(thisScene.buildIndex + 1);
        }
        else
        {
            /*
             * If not, load the first scene, which should be the title page. In the future
             * we might load a credits scene instead.
             */
            
            LoadScene(0);
        }
    }

    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }
}
