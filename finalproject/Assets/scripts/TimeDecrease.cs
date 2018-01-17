using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDecrease : MonoBehaviour {
    

    
    public GameObject Timebox;
    public GameObject prefabiceman;
    Text txt;
    int time;
    public int dectime;
    public string killplayer;
    Animator mAnimator;
    AudioSource hit;
    AudioSource die;

    int Ctime = 0;
    void update()
    {
        mAnimator = GameObject.Find("player").GetComponent<Animator>();
    }





private void OnCollisionEnter2D(Collision2D coll)
    {
        if (killplayer=="yes")
        {
            if (GameObject.Find("player").GetComponent<moveplayerscript>().playertype =="iceman")
            {
                GameObject.Find("player").GetComponent<Animator>().Play("playerdie");
                Destroy(coll.gameObject, 1.80f);
                GameObject.Find("die").GetComponent<AudioSource>().Play();
                GameObject.Find("Time").GetComponent<TimeAndScoreKeeper>().die();
            }
            else if (GameObject.Find("player").GetComponent<moveplayerscript>().playertype == "skaterboy")
            {
                Destroy(coll.gameObject);
                Destroy(coll.gameObject, 1.0f);
                Instantiate(prefabiceman, transform.position, transform.rotation);
                GameObject.Find("hit").GetComponent<AudioSource>().Play();
                GameObject.Find("Time").GetComponent<TimeAndScoreKeeper>().die();



                GameObject.Find("player").GetComponent<moveplayerscript>().playertype = "iceman";
            }
           
           
            
        }
        else
        {
            Text txt = Timebox.GetComponent<Text>();
            int time = int.Parse(txt.text);
            if (coll.gameObject.layer == LayerMask.NameToLayer("Player"))
            {

                time = time - dectime;

                txt.text = "" + time.ToString();

                GameObject.Find("player").GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300);
                mAnimator.SetTrigger("isColliding");
            }


        }



    }
}
