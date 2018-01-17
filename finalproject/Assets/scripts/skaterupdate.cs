using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skaterupdate : MonoBehaviour {
    public GameObject prefabskaterboy;

    // Use this for initialization
    void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Instantiate(prefabskaterboy, transform.position, transform.rotation);
            GameObject.Find("skaterboy").name ="player";
            
           
            GameObject.Find("player").GetComponent<moveplayerscript>().playertype = "skaterboy";

        }
    }
}
