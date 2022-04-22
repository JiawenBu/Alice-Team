using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour {

	public int rubbishCnt;
	public Text score;
	public GameObject end;
	public Button endbtn;
	// Use this for initialization
	void Start () {
		score.text = string.Format("Score:{0}", rubbishCnt);
		end.gameObject.SetActive(false);
		endbtn.onClick.AddListener(() =>
		{
			Application.Quit();
		});
	}


	void OnTriggerEnter(Collider collider)
	{
	
		if (collider.tag == "rubbish")
		{
			rubbishCnt++;
			score.text = string.Format("Score:{0}", rubbishCnt);
			collider.gameObject.SetActive(false);
		}
	}
}
