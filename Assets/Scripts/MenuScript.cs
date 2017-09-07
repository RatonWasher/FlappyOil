//Attach this script to a global scripting purpose gO.
//Used for menu's functionalities.

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    public string LevelToLoad;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(LevelToLoad, LoadSceneMode.Single);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

}
