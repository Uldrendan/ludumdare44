using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float oxygen = 100;

    public GameObject gameOverPanel;
    public PlayerController player;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        Time.timeScale = 1;
    }

    private void Update()
    {
        oxygen -= Time.deltaTime;
        if (oxygen <= 0)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
            
    }

    public void PurchaseDrill(bool refund)
    {
        if (!refund && oxygen > 0)
        {
            oxygen -= 25;
            player.Drills += 1;
        }
        else if(refund && player.Drills > 0)
        {
            oxygen += 25;
            player.Drills -= 1;
        }
    }
    public void PurchaseBoost(bool refund)
    {
        if (!refund && oxygen > 0)
        {
            oxygen -= 25;
            player.Boosts += 1;
        }
        else if (refund && player.Boosts > 0)
        {
            oxygen += 25;
            player.Boosts -= 1;
        }
    }
    public void PurchaseBlink(bool refund)
    {
        if (!refund && oxygen > 0)
        {
            oxygen -= 25;
            player.Blinks += 1;
        }
        else if (refund && player.Blinks > 0)
        {
            oxygen += 25;
            player.Blinks -= 1;
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}