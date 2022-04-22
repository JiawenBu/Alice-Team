using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GuideScript : MonoBehaviour
{
    public GameObject help;
    // Start is called before the first frame update
    void Start()
    {
        help.SetActive(false);
    }
    public void showHelp(){
         help.SetActive(true);  
    }
    public void closeHelp(){
         help.SetActive(false);
    }
}
