using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour {
    public GameObject Player;
    public bool menu = false;
    private Animator play;
    public GameObject PB;
    private Animator stop;
    public GameObject SB;
    public bool selectedPlay = true;
    public GameObject screen;
    public GameObject Deathscreen;
    public float shade = 1f;
    public float shadeRate = 0.1f;
    public float playerOffset = -5;
    private AudioSource main0;
    private AudioSource main1;
    // Use this for initialization
    void Start () {
        Player.gameObject.SetActive(false);
        play = PB.gameObject.GetComponent<Animator>();
        stop = SB.gameObject.GetComponent<Animator>();
        screen.SetActive(true);
        screen.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 1f);
        Deathscreen.SetActive(false);
        main0 = this.GetComponent<AudioSource>();
        main1 = PB.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.localPosition = new Vector3(Player.GetComponent<Player>().x+ playerOffset, this.transform.localPosition.y,this.transform.localPosition.z);
        if (Player.GetComponent <Player>().isDead)
        {
            if (shade < 1)
                shade = shade + shadeRate/2;
            screen.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, shade);
            if (shade >= 1)
            {
                Deathscreen.SetActive(true);
            }
                
            if (Input.GetKeyDown(KeyCode.Return))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (!menu)
        {
            Player.gameObject.SetActive(true);
            this.GetComponentInChildren<Camera>().enabled = false;
            if(shade > 0 && !Player.GetComponent<Player>().isDead)
                shade = shade - shadeRate;
            main0.volume = shade/2;
            main1.volume = 0.5f - (shade / 2);
            screen.GetComponent<Renderer>().material.color = new Color(1f,1f,1f,shade);
            if (Input.GetKeyDown(KeyCode.Escape) && !Player.GetComponent<Player>().isDead)
                menu = true;
        }
        else
        {
            if(shade < 1)
                shade = shade + shadeRate;
            main0.volume = shade/2;
            main1.volume = 0.5f - (shade / 2);
            screen.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, shade);
            Player.gameObject.SetActive(false);
            this.GetComponentInChildren<Camera>().enabled = true;
        }
        if(selectedPlay)
        {
            play.SetBool("play", true);
            stop.SetBool("exit", false);
        }
        else
        {
            play.SetBool("play", false);
            stop.SetBool("exit", true);
        }
        if(Input.GetAxis("Vertical") > 0)
        {
            selectedPlay = true;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            selectedPlay = false;
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (selectedPlay)
                menu = false;
            else
                Application.Quit();
        }

    }
}
