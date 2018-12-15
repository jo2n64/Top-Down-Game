using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Vector2 playerPos;
    public VectorValue storePos;
    public string sceneToLoad;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            storePos.initialValue = playerPos;
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void QuitGame()
    {
        Application.Quit(0);
    }
}
