using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float maxWalkingSpeed = 10;
    public float maxFallSpeed = 7;

    public TextMeshProUGUI drillDisplay;
    public TextMeshProUGUI blinkDisplay;
    public TextMeshProUGUI dashDisplay;

    int _drills;
    public int Drills
    {
        get { return _drills; }
        set
        {
            _drills = value;
            drillDisplay.text = _drills.ToString();
        }
    }

    int _blinks;
    public int Blinks
    {
        get { return _blinks; }
        set
        {
            _blinks = value;
            blinkDisplay.text = _blinks.ToString();
        }
    }

    int _boosts;
    public int Boosts
    {
        get { return _boosts; }
        set
        {
            _boosts = value;
            dashDisplay.text = _boosts.ToString();
        }
    }

    public AudioClip blinkSound;
    public AudioClip drillSound;
    public AudioClip dashSound;
    public AudioClip landingSound;

    Rigidbody2D _rb;
    SpriteRenderer _sr;
    Animator _anim;
    AudioSource _audioSource;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.55f), Vector2.down, 0.1f);
        if (hit.collider != null && hit.collider.gameObject.tag == "Ground")
        {
            if (_anim.GetBool("Falling") == true)
            {
                _audioSource.PlayOneShot(landingSound, 1.0f);
            }
            _anim.SetBool("Falling", false);
        }
        else
            _anim.SetBool("Falling", true);

        Vector2 move = new Vector2(Input.GetAxis("Horizontal") * maxWalkingSpeed,0);
        if (move.x < 0)
            _sr.flipX = true;
        else if(move.x > 0)
            _sr.flipX = false;
        _anim.SetFloat("WalkSpeed", Mathf.Abs(move.x));
        _rb.AddForce(move);

        if (Input.GetKeyDown(KeyCode.B) && Blinks > 0)
            Blink();
        if (Input.GetKeyDown(KeyCode.V) && Boosts > 0)
            Shift();
        if (Input.GetKeyDown(KeyCode.C) && Drills > 0)
            Dig();

        if (Mathf.Abs(_rb.velocity.x) > maxWalkingSpeed)
            _rb.velocity = new Vector2(!_sr.flipX ? maxWalkingSpeed : -maxWalkingSpeed, _rb.velocity.y);
        if (Mathf.Abs(_rb.velocity.y) > maxFallSpeed)
            _rb.velocity = new Vector2(_rb.velocity.x, -maxFallSpeed);
    }

    void Blink()
    {
        Vector3 blinkDir = Vector2.down*2;

        transform.position += blinkDir;
        Blinks -= 1;
        _audioSource.PlayOneShot(blinkSound, 1.0f);
    }

    void Shift()
    {
        Vector3 shiftForce = Vector3.zero;

        if (!_sr.flipX)
            shiftForce = new Vector2(300,150);
        else
            shiftForce = new Vector2(-300, 150);
        _rb.AddForce(shiftForce);
        _anim.SetTrigger("Dashing");
        Boosts -= 1;
        _audioSource.PlayOneShot(dashSound, 1.0f);
    }

    void Dig()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.55f), Vector2.down, 0.1f);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 0.5f), Vector2.down, Color.green);
        if (hit.collider != null && hit.collider.gameObject.name == "Breakable")
            Destroy(hit.collider.gameObject);
        Drills -= 1;
        _audioSource.PlayOneShot(drillSound, 1.0f);
    }
}