using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSB : MonoBehaviour {

    public float speed;
    Rigidbody2D rigidbody2d;
    
     void Awake()
    {
        Vector2 dir=GameObject.Find("player").GetComponent<moveplayerscript>().GetFaceDirection();
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.velocity = dir * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Killobj"))
        {
            Destroy(collision.gameObject);
        }

    }
    
	
	
	void Update () {
		
	}
}
