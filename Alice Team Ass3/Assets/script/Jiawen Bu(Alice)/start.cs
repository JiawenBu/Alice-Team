using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{

    //开始按钮
    public Button startbtn;
    //退出按钮
    public Button quitbtn;
    //帮助按钮
    public Button helpbtn;
    //关闭帮助按钮
    public Button button;

    //帮助界面
    public GameObject help;
    // Start is called before the first frame update
    void Start()
    {
        //开始按钮跳转场景
        startbtn.onClick.AddListener(() => SceneManager.LoadScene("TropicalIslands_Demo"));
        //添加退出按钮方法
        quitbtn.onClick.AddListener(quitenve);
        //添加帮助方法
        helpbtn.onClick.AddListener(helpenve);
        //关闭帮助界面
        button.onClick.AddListener(() => help.SetActive(false));
    }

    //退出方法
    public void quitenve()
    {
        //#if UNITY_EDITOR
        //        UnityEditor.EditorApplication.isPlaying = false;
        //#else
        //Application.Quit();
        //#endif

        SceneManager.LoadScene("Menu");

    }

    //帮助方法
    public void helpenve()
    {
        help.SetActive(true);
    }

}
