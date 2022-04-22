using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    private Text TimeText;
	public float times = 60;
	private int s;//定义一个秒
	
	void Start () {
		TimeText  = GameObject.Find("TimeText").GetComponent<Text>();
	}
	
	void Update (){
		//计时器完成倒计时的功能
		times -= Time.deltaTime;
		s = (int)times % 60; //小数转整数 
		TimeText.text = string.Format("Time:{0}", s);
		if(times <= 0){
			//判定倒计时结束时该做什么
		}
	}
}
