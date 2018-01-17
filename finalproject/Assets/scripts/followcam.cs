using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class followcam : MonoBehaviour {
    [SerializeField]
    public GameObject mTarget;

    Vector3 distance;


    // Use this for initialization
    void Start () {
        mTarget = GameObject.Find("Main Camera");
    Vector3 targetPosition = new Vector3(mTarget.transform.position.x, transform.position.y, transform.position.z);
        Vector3 distance = targetPosition - transform.position;
        Debug.Log("distance bw wall and camera is"+distance.magnitude);

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPosition = new Vector3(mTarget.transform.position.x, transform.position.y, transform.position.z);
        Vector3 newdistance = targetPosition - transform.position;
        if (newdistance.magnitude>9.6f)
        {
            transform.Translate(newdistance.normalized * 3.5f * Time.deltaTime);
        }

        
		
	}
}
