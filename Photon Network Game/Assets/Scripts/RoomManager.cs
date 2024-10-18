using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform parentTransform;
    [SerializeField] InputField roomNameInpuField;
    [SerializeField] InputField roomCapacityInputField;

    private Dictionary<string, RoomInfo> dictionary = new Dictionary<string, RoomInfo>();

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game Scene");
    }

    public void OnCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();

        roomOptions.MaxPlayers = byte.Parse(roomCapacityInputField.text);

        roomOptions.IsOpen = true;

        roomOptions.IsVisible = true;

        PhotonNetwork.CreateRoom(roomNameInpuField.text, roomOptions);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        InstantiateRoom();
    }

    public GameObject InstantiateRoom()
    {
        //1.Room ������Ʈ�� ����
        GameObject room = Instantiate(Resources.Load<GameObject>("Room"));

        //2.Room ������Ʈ�� �θ� ��ġ ����
        room.transform.SetParent(parentTransform);

        //3. Room ������Ʈ�� ��ȯ
        return room;
    }
}