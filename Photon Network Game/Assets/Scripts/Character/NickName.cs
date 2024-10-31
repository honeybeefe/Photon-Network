using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class NickName : MonoBehaviourPunCallbacks
{
    [SerializeField] Text nickNameText;

    void Start()
    {
        nickNameText.text = photonView.Owner.NickName;
    }

   
}