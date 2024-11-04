using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class NickName : MonoBehaviourPunCallbacks
{
    [SerializeField] Text nickNameText;
    [SerializeField] Camera remoteCamera;

    void Start()
    {
        nickNameText.text = photonView.Owner.NickName;
    }

    private void Update()
    {
        transform.LookAt(remoteCamera.transform.localPosition);

        Vector3 euler = transform.localEulerAngles;

        transform.localRotation = Quaternion.Euler(0, euler.y, 0);
    }
}