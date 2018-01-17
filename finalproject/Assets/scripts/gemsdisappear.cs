using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemsdisappear : MonoBehaviour {


    GameObject target;
    float timePlayerEnteredFrame = 0;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("the time playe enetred frame is" + timePlayerEnteredFrame);
        Debug.Log("the time  is" + Time.fixedUnscaledTime);

        if (timePlayerEnteredFrame != 0 && Time.fixedUnscaledTime - timePlayerEnteredFrame < 1)
        {
            transform.parent.GetComponent<Renderer>().enabled = false;
            Debug.Log("timePlayerEnteredFrame - Time.fixedUnscaledTime" + (timePlayerEnteredFrame - Time.fixedUnscaledTime));
        }
        if (timePlayerEnteredFrame != 0 && Time.fixedUnscaledTime - timePlayerEnteredFrame < 2)
        {
            transform.parent.GetComponent<Renderer>().enabled = true;
        }
        if (timePlayerEnteredFrame != 0 && Time.fixedUnscaledTime - timePlayerEnteredFrame < 3)
        {
            transform.parent.GetComponent<Renderer>().enabled = true;
        }
        if (timePlayerEnteredFrame != 0 && Time.fixedUnscaledTime - timePlayerEnteredFrame >4 )
        {
            transform.parent.GetComponent<Renderer>().enabled = true;
            Destroy(transform.parent.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Player") )
        {
            Debug.Log("somethinhggggggggggggggggggggggggggggggggggggggggggggg");
            timePlayerEnteredFrame = Time.fixedUnscaledTime;

        }

    }
}
