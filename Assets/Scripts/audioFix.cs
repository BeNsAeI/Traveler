using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioFix : MonoBehaviour {
    private AudioSource shot;
    private bool playing = false;
    // Use this for initialization
    void Start () {
        shot = this.GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
        if (!playing)
        {
            shot.Play();
            playing = true;
        }
        else
        {
            shot.Stop();
            playing = false;
        }
    }
}
