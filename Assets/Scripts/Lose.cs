using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    private Ball ball;

    IEnumerator Pause()
    {
        print("Waiting 2 seconds");
        yield return new WaitForSeconds(2);
        
        ball = GameObject.FindObjectOfType<Ball>();
        ball.gameStarted = false;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("Done waiting");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(Pause());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
