using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletUpgeade : MonoBehaviour {
    public string bullettype;
    AudioSource Boomerang;
    AudioSource gun;
    AudioSource rock;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}
    private void  OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")&& bullettype=="bullet")
        {
            GameObject.Find("player").GetComponent<gunTypeandFire>().bullettype = "bullet";
            Destroy(gameObject);
            GameObject.Find("gun").GetComponent<AudioSource>().Play();
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && bullettype == "snowball")
        {
            GameObject.Find("player").GetComponent<gunTypeandFire>().bullettype = "snowball";
            Destroy(gameObject);
            GameObject.Find("rock").GetComponent<AudioSource>().Play();
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && bullettype == "boomerang")
        {
            GameObject.Find("player").GetComponent<gunTypeandFire>().bullettype = "boomerang";
            Destroy(gameObject);
            GameObject.Find("Boomerang").GetComponent<AudioSource>().Play();
        }
    }
}
