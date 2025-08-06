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
        gameManager = FindObjectOfType<GameManager>();
        gameManager.Tries--;
        gameManager.SwitchState(GameState.Failed);
        if (gameManager.Tries == 0)
        {
            gameManager.EnableButtons();
        }
        else
        {
            ball = GameObject.FindObjectOfType<Ball>();
            ball.gameStarted = false;
        }
        
        yield return new WaitForSeconds(2);
        
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
