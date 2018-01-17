using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    public GameObject mTarget;


    float stepOverThreshold = 0.05f;

    void Update ()
    {
        
             mTarget = GameObject.Find("player");
        
        
        if (mTarget != null)
        {
            Vector3 targetPosition = new Vector3(mTarget.transform.position.x, mTarget.transform.position.y, transform.position.z);
            Vector3 direction = targetPosition - transform.position;

           
                // If close enough, just step over
                transform.position = targetPosition;
            
        }
    }
}
