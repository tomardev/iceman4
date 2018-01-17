using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunTypeandFire : MonoBehaviour {
    public GameObject snowballbulletprefab;
    public GameObject bulletprefab;
    public GameObject boomerangprefab;
    public float delaytime=0.25f;
    public string bullettype;
    Animation ani;
    AudioSource Boomerang;
    AudioSource gun;
    AudioSource rock;

    float cooldown=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        cooldown -= Time.deltaTime;
        if (bullettype=="snowball")
        {
            if (Input.GetButtonUp("Fire") & cooldown <= 0)
            {
                cooldown = delaytime;
                Instantiate(snowballbulletprefab, transform.position, transform.rotation);
                GameObject.Find("player").GetComponent<Animator>().SetTrigger("isShooting");
                GameObject.Find("rock").GetComponent<AudioSource>().Play();
            }
        }
        else if (bullettype == "bullet")
        {
            if (Input.GetButtonUp("Fire") & cooldown <= 0)
            {
                Vector2 pos;
                pos.x = transform.position.x+ 0.6f;
                pos.y = transform.position.y + 1.3f;
                
                cooldown = delaytime;
                Instantiate(bulletprefab, pos, Quaternion.Euler(0,0,0));
               
                
                GameObject.Find("player").GetComponent<Animator>().SetTrigger("isShooting");
                GameObject.Find("gun").GetComponent<AudioSource>().Play();
            }
        }
        else if (bullettype == "boomerang")
        {
            if (Input.GetButtonUp("Fire") & cooldown <= 0)
            {
                Vector2 pos;
                pos.x = transform.position.x + 0.9f;
                pos.y = transform.position.y + 1.7f;

                cooldown = delaytime;
                Instantiate(boomerangprefab, pos, Quaternion.Euler(0, 0, 0));


                GameObject.Find("player").GetComponent<Animator>().SetTrigger("isShooting");
                 bullettype = "nothing";
                GameObject.Find("Boomerang").GetComponent<AudioSource>().Play();
                
            }
        }



    }
}
