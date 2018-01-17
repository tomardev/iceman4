using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveenimy : MonoBehaviour
{
    public GameObject target;
    SpriteRenderer spriteRenderer;
    public string enemyMovementType;
    public float followspeed;
    public float followrange;
    public float arriveThershold = 0.05f;
    public float frequency=50.0f;//speed of sin mo.
    public float magnitude=10f;//size of sin movement
    Vector3 myposition;



    bool LookingRight = true;

    private void Start()
    {
       
        myposition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }



    // Update is called once per frame
    void Update()
    {
        
            GameObject target = GameObject.Find("player");

        

        Vector2 direction = target.transform.position - transform.position;
        Vector3 axis = -transform.up;
        if (enemyMovementType =="follow")


     {
         if (target != null)
         {

             if (direction.magnitude <= followrange)
             {
                 if (direction.magnitude > arriveThershold)
                 {
                     FaceDirection(direction);
                     transform.Translate(direction.normalized * followspeed * Time.deltaTime, Space.World);
                 }

                 else
                 {
                
                     transform.position = target.transform.position;
                 }
             }
         }

     }
        if (enemyMovementType == "justMove")
        {
            if (target != null && direction.magnitude <= followrange)
            {

                if (direction.magnitude > arriveThershold) //not too close
                {
                    FaceDirection(-direction);
                    transform.Translate(direction.normalized.x * (followspeed-0.5f) * Time.deltaTime, 0, 0);
                    
                }

                else
                {
                    transform.position = target.transform.position;
                       

                }
                
            }
        }
        if (enemyMovementType == "spiral")
        {
           
            if (target != null && direction.magnitude <= followrange)
            {

                if (direction.magnitude > arriveThershold) //not too close
                {
                    myposition += (-transform.right) * Time.deltaTime;
                    transform.position = myposition + axis * Mathf.Sin(Time.time * frequency) * magnitude;
                }

                else
                {
                    transform.position = target.transform.position;


                }

            }
        }
    }



    public void SetTarget(GameObject target1)
    {
        target = target1;
    }


    private void FaceDirection(Vector2 direction)
    {
      
        if (direction.x == 0) { return; }  //Don't change look.

       

        if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
            

        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }

    }
}