using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    Transform front;
    Transform back;

    public Transform player;
    public float speedDifference = 2;

    private void Start()
    {
        front = transform.GetChild(1);
        back = transform.GetChild(0);
    }

    private void Update()
    {
        foreach(Transform child in back)
        {
            child.position = new Vector2(child.position.x, child.position.y - Time.deltaTime);
            if (child.position.y <= -80)
                child.position = new Vector2(child.position.x, child.position.y + 160);
        }
        foreach (Transform child in front)
        {
            child.position = new Vector2(child.position.x, child.position.y - Time.deltaTime * speedDifference);
            if (child.position.y <= -80)
                child.position = new Vector2(child.position.x, child.position.y + 160);
        }
    }
}
