using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    private Animator anim;
    public GameObject sprite;
    public GameObject Jet;
    public float darkness = 0.20f;
    private AudioSource Audio;
    void Start()
    {
        anim = sprite.gameObject.GetComponent<Animator>();
        Audio = this.GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        anim.SetBool("active",true);
        sprite.GetComponent<Collider2D>().enabled = true;
        Jet.GetComponent<Renderer>().material.color = new Color(darkness, darkness, darkness);
        Audio.Play();
        
    }
    void OnTriggerStay2D(Collider2D col)
    {
        anim.SetBool("active", true);
        sprite.GetComponent<Collider2D>().enabled = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        anim.SetBool("active", true);
        sprite.GetComponent<Collider2D>().enabled = false;
        this.GetComponent<Collider2D>().enabled = false;
    }
}
