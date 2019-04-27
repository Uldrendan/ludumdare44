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
    Animator _anim;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, -Mathf.Max(_rb.velocity.y,maxFallSpeed));
        if (move.x < 0)
            _sr.flipX = true;
        else if(move.x > 0)
            _sr.flipX = false;
        _anim.SetFloat("WalkSpeed", Mathf.Abs(move.x));
        _rb.velocity = move;        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
            _anim.SetBool("Falling", false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
            _anim.SetBool("Falling", true);
    }
}
