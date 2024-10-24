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

    private Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();

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
        GameObject roomPrefab;

        foreach (RoomInfo room in roomList)
        {
            // 룸이 삭제된 경우
            if(room.RemovedFromList==true)
            {
                dictionary.TryGetValue(room.Name, out roomPrefab);

                Destroy(roomPrefab);

                dictionary.Remove(room.Name);
            }
            else//룸의 정보가 변경된 경우
            {
                if (dictionary.ContainsKey(room.Name) == false)//룸이 처음 생성된 경우
                {
                    GameObject roomObject = InstantiateRoom();

                    roomObject.GetComponent<Information>().SetData
                        (
                            room.Name,
                            room.PlayerCount,
                            room.MaxPlayers
                        );

                    dictionary.Add(room.Name, roomObject);
                }
                else//룸의 정보가 변경된 경우
                {
                    dictionary.TryGetValue(room.Name, out roomPrefab);

                    roomPrefab.GetComponent<Information>().SetData
                        (
                            room.Name,
                            room.PlayerCount,
                            room.MaxPlayers
                        );
                }
            }
        }
    }

    public GameObject InstantiateRoom()
    {
        //1.Room 오브젝트를 생성
        GameObject room = Instantiate(Resources.Load<GameObject>("Room"));

        //2.Room 오브젝트의 부모 위치 설정
        room.transform.SetParent(parentTransform);

        //3. Room 오브젝트를 반환
        return room;
    }
}