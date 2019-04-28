using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


public class LevelGenerator : MonoBehaviour
{

    public GameObject Wall;
    public GameObject Floor;
    public GameObject BreakableFloor;

    protected FileInfo theSourceFile = null;
    protected StreamReader reader = null;
    protected string text = " ";
    protected string[] levelLine;


    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        theSourceFile = new FileInfo("Assets/Level_Data/level1.txt");
        reader = theSourceFile.OpenText();
        int x;
        int y = 0;

        while (text != null)
        {
            x = -7;

            text = reader.ReadLine();
            if (text != null)
            {
                levelLine = text.Split(',');
                foreach (string letter in levelLine)
                {
                    x++;
                    if (letter == "w")
                    {
                        Instantiate(Wall, new Vector3(x, y, 0), Quaternion.identity);
                    }
                    else if (letter == "f")
                    {
                        Instantiate(Floor, new Vector3(x, y, 0), Quaternion.identity);
                    }
                    else if (letter == "b")
                    {
                        GameObject breakable = Instantiate(BreakableFloor, new Vector3(x, y, 0), Quaternion.identity);
                        breakable.name = "Breakable";
                    }
                }
                y--;
            }
        }
    }
}