using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
public class PlayerColliderCity : MonoBehaviour {

	public int rubbish_cnt;
	public Text score;
	public GameObject end;
	public Button endbtn;

	private Text TimeText;
	public float times = 60;
	private int s;//定义一个秒

    int endScore;
	// Use this for initialization
	void Start () {
		end.gameObject.SetActive(false);
        endScore = 10;
		score.text = string.Format("Score:{0}", rubbish_cnt);
		end.gameObject.SetActive(false);
		endbtn.onClick.AddListener(() =>
		{
			Application.Quit();
		});
		TimeText  = GameObject.Find("TimeText").GetComponent<Text>();
	}

    // Update is called once per frame
    void Update()
    {
		//计时器完成倒计时的功能
		times -= Time.deltaTime;
		s = (int)times % 60; //小数转整数 
		TimeText.text = string.Format("Time:{0}", s);
        //If win 
        if(rubbish_cnt==endScore){
            end.gameObject.SetActive(true);
			GameObject.Find("GameOver").GetComponent<Text>().text = "You Win!";
            GameObject finalScore = GameObject.Find("FinalScore");
            finalScore.GetComponent<Text>().text = string.Format("{0}",rubbish_cnt); 
			Time.timeScale = 0;
        }else if(times<=0){
			end.gameObject.SetActive(true);
			GameObject.Find("GameOver").GetComponent<Text>().text = "You Lose!";
            GameObject finalScore = GameObject.Find("FinalScore");
            finalScore.GetComponent<Text>().text = string.Format("{0}",rubbish_cnt); 
			Time.timeScale = 0;
		}else{
			Time.timeScale = 1;
		}
    }
	


	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "rubbish")
		{
			rubbish_cnt++;
			score.text = string.Format("Score:{0}", rubbish_cnt);
			collider.gameObject.SetActive(false);
		}
	}
}
