using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gemsIncreaseEnergy : MonoBehaviour {
    
    public int Timeincrese;
    public float followrange=10;
    AudioSource coin;



    private void OnTriggerEnter2D(Collider2D coll)
    {

        
            if (coll.gameObject.layer == LayerMask.NameToLayer("Player"))
            {

                GameObject.Find("Time").GetComponent<TimeAndScoreKeeper>().Time(Timeincrese);
                Destroy(gameObject);
            GameObject.Find("coin").GetComponent<AudioSource>().Play();
        }

        
    }
    

}
