using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        transform.position = new Vector2(0, target.position.y);
    }
}
