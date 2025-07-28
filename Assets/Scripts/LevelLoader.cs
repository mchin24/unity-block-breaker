using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadScene(int level)
    {
        string[] scenes = new []{"Intro", "Main"};
        SceneManager.LoadScene(scenes[level]);
    } 
}
