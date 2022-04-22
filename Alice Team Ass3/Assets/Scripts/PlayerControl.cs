using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{   
    public GameObject player;
    public void rotate(){
        player.transform.Rotate(10f,0f,10f);
    }
    //0 means still 1 means forward  2 means backward   3 means left  4 means right
    public void up(){
        player.GetComponent<Player>().status = 1;
        //player.transform.position += new Vector3(0,0,1f);
    }
    public void down(){
        player.GetComponent<Player>().status = 2;
    }
    public void left(){
        player.GetComponent<Player>().status = 3;
    }
    public void right(){
        player.GetComponent<Player>().status = 4;
    }
}
