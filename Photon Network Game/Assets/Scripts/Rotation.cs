using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float mouseX;
    [SerializeField] float mouseY;

    public void OnKeyUpadate()
    {
        //MouseX에 마우스로 입력한 값을 저장
        mouseX += Input.GetAxisRaw("Mouse X") * speed * Time.deltaTime;
    }

    public void RotateY(Rigidbody rigidbody)
    {
        rigidbody.transform.eulerAngles = new Vector3(0, mouseX, 0);
    }

    public void RotateX()
    {
        //mouseY에 마우스로 입력한 값 저장 Mouse Y
        mouseY = Input.GetAxisRaw("Mouse Y")*speed*Time.deltaTime;

        //MouseY 값을 -65~65 사이의 값으로 제한
        //Mathf.Clamp(제한하려는 값, 최소값, 최대값)
        mouseY = Mathf.Clamp(mouseY, -65, 65);
        
        transform.eulerAngles += new Vector3(-mouseY, 0, 0);
    }
}