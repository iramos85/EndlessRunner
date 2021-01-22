using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{
    [SerializeField] Text distanceTraveled;
    [SerializeField] Text collectedCoins;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Player player;
    [SerializeField] GameObject gameMusic;
    [SerializeField] GameObject sky;

 
    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        gameMusic.SetActive(false);
        sky.SetActive(false);
        float roundedDistance = Mathf.Ceil(player.distanceTraveled);
        distanceTraveled.text = "" + roundedDistance;
        //same as:
        //distanceTraveled.text = player.distanceTraveled.ToString();
        collectedCoins.text = player.collectedCoins.ToString();
    }

    public void GameRestart()
    {
        Debug.Log("Restart the game");
        SceneManager.LoadScene("EndlessRunner");
    }
}
