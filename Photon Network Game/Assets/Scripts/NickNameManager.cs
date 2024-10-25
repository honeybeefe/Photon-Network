using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NickNameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Button button;
    [SerializeField] InputField inputField;
    [SerializeField] GameObject nickNamePanel;

    void Start()
    {
        //1. PhotonNetwork.NickName�� ����� String ���� �ҷ��´�
        PhotonNetwork.NickName= PlayerPrefs.GetString("NickName");

        //2. PhotonNetwork.NickName ��� �ִٸ� nickNamePanel Ȱ��ȭ
        if(string.IsNullOrEmpty(PhotonNetwork.NickName))
        {
            nickNamePanel.SetActive(true);
        }
    }

    public void OnSetNickName()
    {
        //1. PhotonNetwork.NickName�� inputField�� �Է��� ���� �־� �ش�
        PhotonNetwork.NickName = inputField.text;

        //2. NickName �� ����
        PlayerPrefs.SetString("NickName", PhotonNetwork.NickName);

        //3. ���� ������Ʈ�� ��Ȱ��ȭ�Ѵ�
        nickNamePanel.SetActive(false);
    }
}