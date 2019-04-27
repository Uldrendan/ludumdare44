using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFollow : MonoBehaviour
{
    //TODO: get rid of this

    public Transform player;

    private void Update()
    {
        transform.position = new Vector2(transform.position.x, player.position.y);
    }
}
