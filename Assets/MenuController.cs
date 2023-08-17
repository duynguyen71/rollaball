using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    private void Start()
    {
        PlayerController.onHitTheWall += OnGameOver;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnGameOver()
    {
        //StartCoroutine(ReturnMainMenuAfterSecs(3));
        ReturnMainMenu();
    }

    IEnumerator ReturnMainMenuAfterSecs(int secs)
    {
        yield return new WaitForSeconds(secs);
    }

}
