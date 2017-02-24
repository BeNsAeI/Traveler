using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    public float speed = 0.0f;
    public float health = 2f;
    public float fireDamage = 0.1f;
    public float explosionDamamge = 2f;
    public float bulletDamage = 1f;
    private bool grounded = true;
    public bool isDead = false;
    public GameObject sprite;
    public GameObject gun;
    private Animator anim;
    private AudioSource walk;
    public bool isShooting = false;
    public bool moving = false;
    public bool playing = false;
    public float pos;
    public int flip = 1;
    public float offset = 1f;
    void Start()
    {
        walk = this.GetComponent<AudioSource>();
        anim = sprite.GetComponent<Animator>();
        pos = transform.localPosition.x;
        gun.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x >= pos + 5 && flip > 0)
        {
            flip = flip * (-1);
            transform.localPosition = new Vector3(transform.localPosition.x + offset, transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.x < pos - 5 && flip < 0)
        {
            flip = flip * (-1);
            transform.localPosition = new Vector3(transform.localPosition.x - offset, transform.localPosition.y, transform.localPosition.z);
        }
        if(!isDead && !isShooting && grounded)
        {
            speed = flip;
        }else
        {
            speed = 0;
        }
        
        if (speed > 0.1)
        {
            transform.localScale = new Vector3(0.2997612f, 0.2997612f, 0.2997612f);
            transform.localPosition = new Vector3(transform.localPosition.x + (2 * speed / (1.0f / Time.deltaTime)), transform.localPosition.y, transform.localPosition.z);
        }
        if (speed < -0.1)
        {
            transform.localScale = new Vector3(-0.2997612f, 0.2997612f, 0.2997612f);
            transform.localPosition = new Vector3(transform.localPosition.x + (2 * speed / (1.0f / Time.deltaTime)), transform.localPosition.y, transform.localPosition.z);
        }
        if (Mathf.Abs(speed) > 0.1)
        {
            moving = true;
        }
        else
        {
            moving = false;
            playing = false;
        }
        anim.SetBool("grounded", grounded);
        anim.SetFloat("speed", Mathf.Abs(speed));
        anim.SetBool("shooting", isShooting);
        gun.gameObject.SetActive(isShooting);
    }
    void FixedUpdate()
    {
        if (moving)
        {
            if (grounded && !isDead)
            {

                if (!playing)
                {
                    walk.Play();
                    playing = true;
                }

            }
            else
            {
                walk.Stop();
                playing = false;
            }
        }
        else
        {
            walk.Stop();
        }
        if (health < 0)
        {
            isDead = true;
            anim.SetBool("isDead", isDead);
            speed = 0;
        }
    }
}
