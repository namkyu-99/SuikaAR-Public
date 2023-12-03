using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    String scene;
    float delay = 0.2f;

    public void Title()
    {
        scene = "Title";
        Invoke("loadScene", delay);
    }

    public void inGame()
    {
        scene = "inGame";
        Invoke("loadScene", delay);
    }

    public void Tutorial()
    {
        scene = "Tutorial";
        Invoke("loadScene", delay);
    }

    public void Setting()
    {
        scene = "Setting";
        Invoke("loadScene", delay);
    }

    void loadScene()
    {
        SceneManager.LoadScene(scene);
    }
}
