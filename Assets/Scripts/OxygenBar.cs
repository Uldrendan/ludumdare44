using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenBar : MonoBehaviour
{
    private void Update()
    {
        transform.localScale = new Vector2(1, GameManager.instance.oxygen / 100);
    }
}
