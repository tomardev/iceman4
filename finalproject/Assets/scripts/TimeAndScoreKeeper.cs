using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimeAndScoreKeeper : MonoBehaviour
{
    public GameObject ScoreBox;
    public GameObject TimeBox;
    public GameObject LifeBox;
    int time = 60;
    static int life = 3;
    static int score ;
    Text txt;
    void Start()
    {
        InvokeRepeating("timeUpdate", 0, 1.0f);
        txt = LifeBox.GetComponent<Text>();
        txt.text = "Life:" + life.ToString();
        txt = ScoreBox.GetComponent<Text>();
        txt.text = "Score:" + score.ToString();

    }

    public void Time(int tm)
    {
        time = time + tm;
        txt = TimeBox.GetComponent<Text>();
        txt.text = "" + time.ToString();
        if (int.Parse(txt.text)>60)
        {
            txt.text = "" + 60;
        }
        if (tm >= 0 && tm <= 15)
        {
            score = score+ tm;
            txt = ScoreBox.GetComponent<Text>();
            txt.text = "Score:" + score.ToString();
            if (score == 3000)
            {
                score = 1;
                txt = ScoreBox.GetComponent<Text>();
                txt.text = "Score:" + score.ToString();
                life++;
                txt = LifeBox.GetComponent<Text>();
                txt.text = "Life:" + life.ToString();

            }


        }
        if (tm >16 && tm <= 50)
        {
            score = score +tm;
            txt = ScoreBox.GetComponent<Text>();
            txt.text = "Score:" + score.ToString();
            if (score == 3000)
            {
                score = 1;
                txt = ScoreBox.GetComponent<Text>();
                txt.text = "Score:" + score.ToString();
                life++;
                txt = LifeBox.GetComponent<Text>();
                txt.text = "Life:" + life.ToString();

            }


        }
        if (tm >50 )
        {
            score = score + tm ; ;
            txt = ScoreBox.GetComponent<Text>();
            txt.text = "Score:" + score.ToString();
            if (score == 3000)
            {
                score = 1;
                txt = ScoreBox.GetComponent<Text>();
                txt.text = "Score:" + score.ToString();
                life++;
                txt = LifeBox.GetComponent<Text>();
                txt.text = "Life:" + life.ToString();

            }


        }
    }
    public void die()
    {
        if (life>=1)
        {
            life--;
            txt = LifeBox.GetComponent<Text>();
            txt.text = "Life:" + life.ToString();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        else if (life==0)
        {
            SceneManager.LoadScene(0);
        }
    }

    
    private void timeUpdate()
    {
        int timern;
        timern = int.Parse(TimeBox.GetComponent<Text>().text);
           int timetodisplay=timern-1;
        txt = TimeBox.GetComponent<Text>();

        txt.text = "" + timetodisplay.ToString();
        if (timetodisplay<=0)
        {
            GameObject.Find("player").GetComponent<Animator>().Play("playerdie");
          
          
            Destroy(GameObject.Find("player"), .80f);
            SceneManager.LoadScene("level1");
        }
    }
}
