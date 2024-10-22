using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float mouseX;
    [SerializeField] float mouseY;

    public void RotateX()
    {
        //mouseY�� ���콺�� �Է��� �� ���� Mouse Y
        mouseY = Input.GetAxisRaw("Mouse Y")*speed*Time.deltaTime;

        //MouseY ���� -65~65 ������ ������ ����
        //Mathf.Clamp(�����Ϸ��� ��, �ּҰ�, �ִ밪)
        mouseY = Mathf.Clamp(mouseY, -65, 65);
        
        transform.eulerAngles += new Vector3(-mouseY, 0, 0);
    }
}