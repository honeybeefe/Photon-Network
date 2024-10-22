using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Move))]
public class Character : MonoBehaviourPun
{
    [SerializeField] Move move;
    [SerializeField] Camera remoteCamera;
    [SerializeField] Rigidbody rigidbody;

    private void Awake()
    {
        move = GetComponent<Move>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        DisableCamera();
    }

    void Update()
    {
        move.OnKeyUpdate();
    }

    private void FixedUpdate()
    {
        move.OnMove(rigidbody);
    }

    public void DisableCamera()
    {
        //현재 플러이어가 나 자신이라면
        if (photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            remoteCamera.gameObject.SetActive(false);
        }
    }
}