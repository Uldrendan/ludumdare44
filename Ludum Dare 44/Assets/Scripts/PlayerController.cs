using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 7;
    public float maxFallSpeed = 7;
    public float acceleration = 1;

    Rigidbody2D _rb;
    SpriteRenderer _sr;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, Mathf.Min(_rb.velocity.y,-maxFallSpeed));
        if (move.x < 0)
            _sr.flipX = true;
        else if(move.x > 0)
            _sr.flipX = false;

        _rb.velocity = move;        
    }
}
