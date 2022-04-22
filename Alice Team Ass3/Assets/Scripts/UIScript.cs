using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public GameObject help;
    public GameObject menu;
    void Start()
    {
        help.SetActive(false);
        menu.SetActive(true);   
    }
    public void showMenu(){
          help.SetActive(false);
          menu.SetActive(true);  
    }
    public void showHelp(){
         menu.SetActive(false);
         help.SetActive(true);  
    }
    public void exit(){
           Application.Quit();
    }
    
}
