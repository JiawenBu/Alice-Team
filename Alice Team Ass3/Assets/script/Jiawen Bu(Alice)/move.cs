using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    private CharacterController characterController;
    private float rotSpeed = 2f;

    public bool ismove;
    public Animator animator;

    //计数的金币
    public Text Goldtext;
    int number;

    //倒计时
    public Text timetext;
    float time = 160;


    //出现提示
    public GameObject Tipsimg;
    //知道了按钮
    public Button button;

    //显示解救伙伴
    public GameObject partner;
    //解决开关
    bool off = false;

    //同伴的显示
    public GameObject partnerObj;
    // Start is called before the first frame update
    void Start()
    {
        characterController = this.GetComponent<CharacterController>();
        //添加解救提示方法
        button.onClick.AddListener(enve);
    }

    // Update is called once per frame
    void Update()
    {

        //倒计时
        time -= Time.deltaTime;
        int times = (int)time % 181;
        timetext.text = string.Format("Time ：" + times);

        
        characterController.Move(-Vector3.up * 10 * Time.deltaTime);

        //按下指定按钮触发人物的动画切换和移动
        if (Input.GetKey(KeyCode.A))
        {
            ismove = true;
            animator.SetBool("ldle", false);
            animator.SetBool("walk", true);
            //characterController.Move(Vector3.left * 10 * Time.deltaTime);
            this.transform.eulerAngles -= new Vector3(0, rotSpeed, 0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            if (ismove)
            {
                ismove = false;
                animator.SetBool("ldle", true);
                animator.SetBool("walk", false);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            ismove = true;
            animator.SetBool("ldle", false);
            animator.SetBool("walk", true);
            //characterController.Move(Vector3.right * 10 * Time.deltaTime);
            this.transform.eulerAngles += new Vector3(0, rotSpeed, 0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            if (ismove)
            {
                ismove = false;
                animator.SetBool("ldle", true);
                animator.SetBool("walk", false);
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            ismove = true;
            animator.SetBool("ldle", false);
            animator.SetBool("walk", true);
            characterController.Move(this.transform.forward * 10 * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            if (ismove)
            {
                ismove = false;
                animator.SetBool("ldle", true);
                animator.SetBool("walk", false);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            ismove = true;
            animator.SetBool("ldle", false);
            animator.SetBool("walk", true);
            characterController.Move(-this.transform.forward * 10 * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            if (ismove)
            {
                ismove = false;
                animator.SetBool("ldle", true);
                animator.SetBool("walk", false);
            }
        }

        //鼠标右键实现视角转动，类似第一人称视角  
        if (Input.GetMouseButton(0))
        {
            float rotationX = Input.GetAxis("Mouse X") * 2;
            transform.Rotate(0, rotationX, 0);
        }

        //解救方法
        if (off==true&&Input.GetKey(KeyCode.H))
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (time<=0)
        {
            SceneManager.LoadScene("SampleScene 1");
        }
       
    }

    //显示解救提示方法
    public void enve()
    {
        Tipsimg.SetActive(false);
    }
    public void OnTriggerEnter(Collider collider)
    {

        //碰到金币就加金币的数量
        if (collider.gameObject.tag== "Gold")
        {
            Destroy(collider.gameObject);
            number++;
            Goldtext.text = string.Format("Gold ："+ number);
            if (number >= 10 && time > 0)
            {
                Tipsimg.SetActive(true);
                partnerObj.SetActive(true);
            }
        }
        //如果碰到伙伴就触发解救提示 并打开解救按钮的开关
        if (collider.gameObject.tag== "partner")
        {
            partner.SetActive(true);
            off = true;
        }
    }
}
