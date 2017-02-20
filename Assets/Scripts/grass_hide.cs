using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grass_hide : MonoBehaviour {
    public GameObject player;
    public float darkness = 0.20f;

    void OnTriggerEnter2D(Collider2D col)
    {
            player.GetComponent<Renderer>().material.color = new Color(darkness, darkness, darkness);
    }
    void OnTriggerStay2D(Collider2D col)
    {
            player.GetComponent<Renderer>().material.color = new Color(darkness, darkness, darkness);
    }
    void OnTriggerExit2D(Collider2D col)
    {
            player.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
    }
}
