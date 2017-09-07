//Attach this script to a parent gO inside the Canvas gO.
//Vanishes all children by default.
//Public methods can be called to reveal the children (= the game over menu).

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameOverScript : MonoBehaviour
{
    private bool enableMenu;



    void Awake() {
        HideChildren();
    }


    void Update()
    {
        if (enableMenu)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Level", LoadSceneMode.Single);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            }
        }
    }


    public void HideChildren() {
        enableMenu = false;
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void ShowChildren() {
        StartCoroutine(activateMenu(0.5f));
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }


    IEnumerator activateMenu(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        enableMenu = true;
    }

}