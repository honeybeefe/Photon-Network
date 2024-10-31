using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class DialogManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputField;
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] Transform parentTransform;
    
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            inputField.ActivateInputField();

            if (inputField.text.Length <= 0) return;

            //inputField�� �ִ� �ؽ�Ʈ�� �����´�
            //(string ����) <- Photon �г��� + : + InputField�� ������ ���ڿ�
            string talk = PhotonNetwork.LocalPlayer.NickName + ":" + inputField.text;

            //RPC Targer.All : ���� �뿡 �ִ� ��� Ŭ���̾�Ʈ���� Talk() �Լ��� �����϶�� ��� ����
            photonView.RPC("Talk", RpcTarget.All, talk);

            //��ũ���� ��ġ�� �ʱ�ȭ
            scrollRect.verticalNormalizedPosition = 0.0f;
        }
    }

    [PunRPC]
    public void Talk(string message)
    {
        //Prefab�� �ϳ� ������ ���� text ���� ����
        GameObject talk = Instantiate(Resources.Load<GameObject>("String"));
        //Prefab ������Ʈ�� Text ������Ʈ�� �����ؼ� text�� ���� ����
        talk.GetComponent<Text>().text = message;
        //��ũ�� �� - content ������Ʈ�� �ڽ����� ���
        talk.transform.SetParent(parentTransform);
        //ä���� �Է��� �Ŀ��� �̾ �Է��� �� �ֵ��� ����
        inputField.ActivateInputField();

        //��ũ���� ��ġ�� �ʱ�ȭ
        scrollRect.verticalNormalizedPosition = 0.0f;

        //inputField�� �ؽ�Ʈ�� �ʱ�ȭ
        inputField.text = "";
    }
}