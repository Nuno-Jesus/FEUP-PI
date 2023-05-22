using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_swicher : MonoBehaviour
{
    public string sceneName;

    public void changeScene()
    {
        SceneManager.LoadScene(sceneName);
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
