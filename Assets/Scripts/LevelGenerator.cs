﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;


public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance;

    public GameObject Wall;
    public GameObject Floor;
    public GameObject BreakableFloor;
    public GameObject UpgradeRoom;

    protected FileInfo theSourceFile;
    protected StreamReader reader;
    protected string text = " ";
    protected string[] levelLine;

    public int currentLevel = 1;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        GenerateLevel(currentLevel);
    }

    int x;
    int y;
    public void GenerateLevel(int level)
    {
        Transform levelHolder = transform.Find("LevelHolder");
        foreach (Transform child in levelHolder) //clear previous level
            Destroy(child.gameObject);

        theSourceFile = new FileInfo(Application.dataPath + "/LevelData/level" + level + ".txt");
        if (theSourceFile.Exists)
        {
            reader = theSourceFile.OpenText();

            while ((text = reader.ReadLine()) != null)
            {
                x = -7;
                if (text != null)
                {
                    levelLine = text.Split(',');
                    foreach (string letter in levelLine)
                    {
                        GameObject newSpace = null;
                        x++;
                        switch (letter)
                        {
                            case "w":
                                newSpace = Instantiate(Wall, new Vector2(x, y), Quaternion.identity);
                                break;
                            case "f":
                                newSpace = Instantiate(Floor, new Vector2(x, y), Quaternion.identity);
                                break;
                            case "b":
                                newSpace = Instantiate(BreakableFloor, new Vector2(x, y), Quaternion.identity);
                                newSpace.name = "Breakable";
                                break;
                        }
                        if (newSpace != null)
                            newSpace.transform.parent = levelHolder;
                    }
                    y--;
                }
            }

            Instantiate(UpgradeRoom, new Vector2(-0.5f,y-5), Quaternion.identity);
        }
        else
        {
            SceneManager.LoadScene("End");
        }
    }
}