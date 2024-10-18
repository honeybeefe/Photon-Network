using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Canvas canvas;
    [SerializeField] Dropdown dropdown;

    private void Awake()
    {
        if(PhotonNetwork.IsConnected)
        {
            canvas.gameObject.SetActive(false);
        }
    }

    public void Connect()
    {
        //서버에 접속하는 함수
        PhotonNetwork.ConnectUsingSettings();

        canvas.gameObject.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        //JoinLobby : 특정 로비를 생성하여 진입하는 함수

        PhotonNetwork.JoinLobby
        (
            new TypedLobby
            (
                dropdown.options[dropdown.value].text,
                LobbyType.Default
            )
        );
    }
}