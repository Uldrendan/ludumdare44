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
            player.numDrills += 1;
        }
        else if(refund && player.numDrills > 0)
        {
            oxygen += 25;
            player.numDrills -= 1;
        }
    }
    public void PurchaseBoost(bool refund)
    {
        if (!refund && oxygen > 0)
        {
            oxygen -= 25;
            player.numBoosts += 1;
        }
        else if (refund && player.numDrills > 0)
        {
            oxygen += 25;
            player.numBoosts -= 1;
        }
    }
    public void PurchaseBlink(bool refund)
    {
        if (!refund && oxygen > 0)
        {
            oxygen -= 25;
            player.numBlinks += 1;
        }
        else if (refund && player.numDrills > 0)
        {
            oxygen += 25;
            player.numBlinks -= 1;
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