using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float oxygen = 100;

    public GameObject gameOverPanel;

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
}