using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class GameManager : MonoBehaviourPunCallbacks
{
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Execute();
    }

    public void Execute()
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount>=3)
        {
            Debug.Log("Start");
        }
    }
}