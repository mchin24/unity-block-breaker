using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    private Ball ball;
    private GameManager gameManager;
    public GameObject[] players;
    public GameObject[] extras;

    IEnumerator Pause()
    {
        print("Waiting 2 seconds");
        gameManager = FindAnyObjectByType<GameManager>();
        gameManager.Tries--;
        gameManager.SwitchState(GameState.Failed);
        yield return new WaitForSeconds(2);
        
        if (gameManager.Tries == 0)
        {
            gameManager.EnableButtons();
        }
        else
        {
            ball = GameObject.FindAnyObjectByType<Ball>();
            gameManager.SwitchState(GameState.NotStarted);
            ball.gameStarted = false;
        }
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("Done waiting");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Ball")
        {
            StartCoroutine(Pause());
        }
    }
}
