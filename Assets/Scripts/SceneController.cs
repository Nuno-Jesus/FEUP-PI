using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Scene currentScene;
    public Scene[] scenes = new Scene[3];

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] objects = currentScene.GetRootGameObjects();

        foreach (GameObject obj in objects)
            Debug.Log(obj.name);
    }
}
