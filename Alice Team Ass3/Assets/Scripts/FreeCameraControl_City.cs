/**
 * Reference: https://gitee.com/studyLys/prg-sub-code-unity3d?_from=gitee_search
 */

using System.Collections.Generic;
using UnityEngine;

public class FreeCameraControl_City : MonoBehaviour
{


    public float scrollSpeed = 5;//�����Ұ����ϵ��
    public float distance;//�����Ŀ��ľ���
    public float rotateSpeed = 2;//�����Ұ��תϵ��

    private Vector3 offsetPosition;//λ��ƫ��
    private bool isRotating = false;//�����ж��Ƿ�������ת

    [SerializeField]
    private List<Transform> m_targets = null;//������̨�ϵ����壨�����ɫ��
    private int m_currentIndex = 0;//������ǰ�����ɫ�ı��
    private Transform m_currentTarget = null;//������̨�ϵ�����

    private void Start()
    {
        //����Ŀ������
        if (m_targets.Count > 0)
        {
            m_currentIndex = 0;//Ϊ��̨�н�ɫ���Ϊ0
            m_currentTarget = m_targets[m_currentIndex];//��ʼ����ǰ��̨�ϵĽ�ɫΪList�е����塪����ȡ����Ŀ��
        }

        transform.LookAt(m_currentTarget.position);//ʹ�������Ŀ��
        offsetPosition = transform.position - m_currentTarget.position;//��������Ŀ���λ�õ�ƫ����

    }

    /*
     * ����
     */
    private void Update()
    {
        //��̨��û�����壬�򷵻�
        if (m_targets.Count == 0)
        {
            return;
        }
    }

    /*
     * ���ڸ��£�LateUpdate��������Update�������ú󱻵���
     */
    private void LateUpdate()
    {
        if (m_currentTarget == null)
        {
            return;
        }

        transform.position = offsetPosition + m_currentTarget.position;//ʵ���������
        //������Ұ����ת
        RotateView();
        //������Ұ��������ԶЧ��
        ScrollView();
    }

    void ScrollView()
    {
        distance = offsetPosition.magnitude;//�õ�ƫ�������ĳ���
        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;//��ȡ����м�*�����Ұ����ϵ��
        distance = Mathf.Clamp(distance, 2.5f, 15);//�޶�������С�����ֵ
        offsetPosition = offsetPosition.normalized * distance;//����λ��ƫ��
    }

    void RotateView()
    {
        //      Input.GetAxis ("Mouse X");//�õ������ˮƽ����Ļ���
        //      Input.GetAxis ("Mouse Y");//�õ�����ڴ�ֱ����Ļ���
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }

        if (isRotating)
        {
            Vector3 originalPos = transform.position;//���������ǰ��λ��
            Quaternion originalRotation = transform.rotation;//���������ǰ����ת
            transform.RotateAround(m_currentTarget.position, m_currentTarget.up, rotateSpeed * Input.GetAxis("Mouse X"));//��Ŀ��y����ˮƽ������ת
            transform.RotateAround(m_currentTarget.position, transform.right, -rotateSpeed * Input.GetAxis("Mouse Y"));//������x������ֱ������ת
            float x = transform.eulerAngles.x;//���x��ĽǶ�
            if (x < 10 || x > 80)
            {//����x�����ת��10��80֮��
                transform.position = originalPos;
                transform.rotation = originalRotation;
            }
        }

        offsetPosition = transform.position - m_currentTarget.position;//����λ��ƫ����
    }
}
