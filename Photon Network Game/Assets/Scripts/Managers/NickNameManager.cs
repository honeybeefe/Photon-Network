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
        //1. PhotonNetwork.NickName에 저장된 String 값을 불러온다
        PhotonNetwork.NickName= PlayerPrefs.GetString("NickName");

        //2. PhotonNetwork.NickName 비어 있다면 nickNamePanel 활성화
        if(string.IsNullOrEmpty(PhotonNetwork.NickName))
        {
            nickNamePanel.SetActive(true);
        }
    }

    public void OnSetNickName()
    {
        //1. PhotonNetwork.NickName에 inputField롤 입력한 값을 넣어 준다
        PhotonNetwork.NickName = inputField.text;

        //2. NickName 을 저장
        PlayerPrefs.SetString("NickName", PhotonNetwork.NickName);

        //3. 게임 오브젝트를 비활성화한다
        nickNamePanel.SetActive(false);
    }
}