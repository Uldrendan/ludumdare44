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
            child.localPosition = new Vector2(child.localPosition.x, child.localPosition.y + Time.deltaTime*0.5f);
            if (child.localPosition.y >= 80)
                child.localPosition = new Vector2(child.localPosition.x, child.localPosition.y - 160);
        }
        foreach (Transform child in front)
        {
            child.localPosition = new Vector2(child.localPosition.x, child.localPosition.y + Time.deltaTime);
            if (child.localPosition.y >= 80)
                child.localPosition = new Vector2(child.localPosition.x, child.localPosition.y - 160);
        }

        if(back.position.y > player.position.y+40)
        {
            back.position = new Vector2(back.position.x, back.position.y - 40);
            front.position = new Vector2(front.position.x, front.position.y - 40);
        }
    }
}
