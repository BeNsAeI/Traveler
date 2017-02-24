using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 50f;
    public float health = 10f;
    public float maxspeed = 3;
    public float jump = 300;
    public float fireDamage = 0.1f;
    public float explosionDamamge = 1f;
    public float bulletDamage = 1f;
    public bool grounded = false;
    public bool isDead = false;
    private bool playing = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    private Animator healthanim;
    public GameObject sprite;
    public GameObject healthsprite;
    public Camera camera;
    public GameObject UI;
    public float UIoffset = -7.598874f;
    private AudioSource walk;
    public float x;
    // Use this for initialization
    void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = sprite.gameObject.GetComponent<Animator>();
        healthanim= healthsprite.gameObject.GetComponent<Animator>();
        walk = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        anim.SetBool("ground",grounded);
        anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        healthanim.SetFloat("health", health-0.5f);
        if (Input.GetAxis("Horizontal") > 0.1 && !isDead)
        {
            transform.localScale = new Vector3(3, 3, 3);
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }
        if (Input.GetAxis("Horizontal") < -0.1 && !isDead)
        {
            transform.localScale = new Vector3(-3, 3, 3);
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }
        if (Input.GetButtonDown("Jump") && grounded && !isDead)
            rb2d.AddForce(Vector2.up * jump);
        if (transform.localPosition.x >= 0)
        {
            camera.transform.localPosition = new Vector3(transform.localPosition.x, camera.transform.localPosition.y, camera.transform.localPosition.z);
            UI.transform.localPosition = new Vector3(camera.transform.localPosition.x+ UIoffset, UI.transform.localPosition.y, UI.transform.localPosition.z);
            x = camera.transform.localPosition.x;
        }
        
    }
    void FixedUpdate()
    {
        float h = 0;
        if (Input.GetAxis("Horizontal") != 0)
        {
            h = Input.GetAxis("Horizontal");
            if(grounded && !isDead)
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
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            walk.Stop();
            playing = false;
        }
        rb2d.AddForce(Vector2.right*speed*h);
        if (rb2d.velocity.x > maxspeed)
            rb2d.velocity = new Vector2(maxspeed,rb2d.velocity.y);
        if (rb2d.velocity.x < -maxspeed)
            rb2d.velocity = new Vector2(-maxspeed, rb2d.velocity.y);
        if (health < 10f)
            health = health + 0.005f;
        if (health < 0)
        {
            isDead = true;
            anim.SetBool("isDead", isDead);
            speed = 0;
            maxspeed = 0;
        }
    }
    public GameObject player;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "fire" && health > 0)
            health = health - fireDamage;
        if (col.tag == "explosion" && health > 0 && col.enabled)
            health = health - explosionDamamge;
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "fire" && health > 0)
            health = health - 0.1f;
    }
}
