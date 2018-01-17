using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomerangmove : MonoBehaviour {
    [SerializeField]
    public float speed;
    Rigidbody2D rigidbody2d;
    public GameObject target;
    Vector2 dir;
    // Use this for initialization
    void Start () {
        
         
	}

    void Awake()
    {
        Vector2 dir = GameObject.Find("player").GetComponent<moveplayerscript>().GetFaceDirection();
        rigidbody2d = GetComponent<Rigidbody2D>();
        if (dir.x>0)
        {
            rigidbody2d.AddForce(Vector2.right * dir.magnitude * speed * 13 * 0.866025404f);
            rigidbody2d.AddForce(Vector2.up * dir.magnitude * speed * 15 * 0.5f);
        }
        else
        {
            rigidbody2d.AddForce(Vector2.left * dir.magnitude * speed * 13 * 0.866025404f);
            rigidbody2d.AddForce(Vector2.up * dir.magnitude * speed * 15 * 0.5f);
        }
        
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Killobj"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
            GameObject.Find("player").GetComponent<gunTypeandFire>().bullettype = "boomerang";
        }

    }
    // Update is called once per frame
    void Update () {
        if (target == null)
        {
            target = GameObject.Find("player");

        }
        if (gameObject!= null&& target.gameObject != null)
        {
            Vector2 direction = target.transform.position - transform.position;
            if (rigidbody2d.velocity.y < 0 && direction.magnitude > 0.05f)
            {
                transform.Translate(direction.normalized * 18 * 0.866025404f * Time.deltaTime, Space.World);
            }
            else if (rigidbody2d.velocity.y < 0 && direction.magnitude < 0.05f)
            {

                transform.position = target.transform.position;
            }
        }
        
        
       

    }
}
