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
        if (Input.GetKeyDown(KeyCode.B))
        {
            Blink();
        }
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.55f), Vector2.down, 0.1f);
        Debug.DrawRay(new Vector2(transform.position.x,transform.position.y-0.5f), Vector2.down, Color.red);
        if (hit.collider != null && hit.collider.gameObject.tag == "Ground")
            _anim.SetBool("Falling", false);
        else
            _anim.SetBool("Falling", true);

        Vector2 move = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, -Mathf.Max(_rb.velocity.y,maxFallSpeed));
        if (move.x < 0)
            _sr.flipX = true;
        else if(move.x > 0)
            _sr.flipX = false;
        _anim.SetFloat("WalkSpeed", Mathf.Abs(move.x));
        _rb.velocity = move;  
    }

    void Blink()
    {
        Vector3 blinkDir = Vector2.zero;
        if (Input.GetAxis("Horizontal") > 0)
            blinkDir = Vector2.right;
        else if (Input.GetAxis("Horizontal") < 0)
            blinkDir = Vector2.left;
        else
            blinkDir = Vector2.down;

        transform.position += blinkDir;
    }
}