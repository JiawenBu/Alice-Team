using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class EndControl : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOver;
    public Button exitbtn;
    public Button rebtn;
    int endScore;
    // Start is called before the first frame update
    void Start()
    {
        gameOver.gameObject.SetActive(false);
        endScore = 10;
        exitbtn.onClick.AddListener(() =>
		{
			Application.Quit();
		});
        rebtn.onClick.AddListener(() =>
		{
			SceneManager.LoadScene("Desert_Menu"); 
		});
    }

    // Update is called once per frame
    void Update()
    {
        //If win 
        if(player.GetComponent<PlayerCollider>().rubbishCnt==endScore){
            Time.timeScale = 0;
            gameOver.gameObject.SetActive(true);
            GameObject finalScore = GameObject.Find("FinalScore");
            finalScore.GetComponent<Text>().text = string.Format("Score:{0}", player.GetComponent<PlayerCollider>().rubbishCnt);
        }else {
             Time.timeScale = 1;
        }
    }
}
