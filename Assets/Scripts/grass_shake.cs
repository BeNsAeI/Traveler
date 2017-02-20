using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grass_shake : MonoBehaviour {
    private Animator anim;
    public GameObject sprite;
    void Start()
    {
        anim = sprite.gameObject.GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        anim.SetBool("wiggle", true);
    }
    void OnTriggerStay2D(Collider2D col)
    {
        anim.SetBool("wiggle", true);
    }
    void OnTriggerExit2D(Collider2D col)
    {
        anim.SetBool("wiggle", false);
    }
}
