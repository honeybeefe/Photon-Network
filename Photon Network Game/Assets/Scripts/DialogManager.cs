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

            //inputField에 있는 텍스트를 가져온다
            //(string 변수) <- Photon 닉네임 + : + InputField로 설정한 문자열
            string talk = PhotonNetwork.LocalPlayer.NickName + ":" + inputField.text;

            //RPC Targer.All : 현재 룸에 있는 모든 클라이언트에게 Talk() 함수를 실행하라는 명령 전달
            photonView.RPC("Talk", RpcTarget.All, talk);

            //스크롤의 위치를 초기화
            scrollRect.verticalNormalizedPosition = 0.0f;
        }
    }

    [PunRPC]
    public void Talk(string message)
    {
        //Prefab을 하나 생성한 다음 text 값을 설정
        GameObject talk = Instantiate(Resources.Load<GameObject>("String"));
        //Prefab 오브젝트의 Text 컴포넌트로 접근해서 text의 값을 설정
        talk.GetComponent<Text>().text = message;
        //스크롤 뷰 - content 오브젝트의 자식으로 등록
        talk.transform.SetParent(parentTransform);
        //채팅을 입력한 후에도 이어서 입력할 수 있도록 설정
        inputField.ActivateInputField();

        //스크롤의 위치를 초기화
        scrollRect.verticalNormalizedPosition = 0.0f;

        //inputField의 텍스트를 초기화
        inputField.text = "";
    }
}