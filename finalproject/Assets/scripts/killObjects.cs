using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killObjects : MonoBehaviour {
    GameObject mplayerdieprefab;

    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="killobj")
        {
            Instantiate(mplayerdieprefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
