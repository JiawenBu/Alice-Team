using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   public int status;//0 means still 1 means forward  2 means backward   3 means left  4 means right
    public float speed;
    public int time;
    // Start is called before the first frame update
    void Start()
    {
        time =0;
        speed = 1f;
        status =0 ;
    }

    // Update is called once per frame
    void Update()
    {
        if(time>10){
            status = 0;
            time=0;
        }
        switch(status){
            case 0:
                break;
            case 1:
                up();
                time++;
                break;
            case 2:
                down();
                time++;
                break;
            case 3:
                left();
                time++;
                break;
            case 4:
                right();
                time++;
                break;
        }
    }
    public void up(){
        transform.Translate(Vector3.forward*Time.deltaTime*speed,Space.Self);
    }
    public void down(){
        transform.Translate(Vector3.back*Time.deltaTime*speed,Space.Self);
    }
    public void left(){
        transform.Translate(Vector3.left*Time.deltaTime*speed,Space.Self);
    }
    public void right(){
        transform.Translate(Vector3.right*Time.deltaTime*speed,Space.Self);
    }
}
