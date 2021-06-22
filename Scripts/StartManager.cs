using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public InputField Username;
    public InputField Roomname;
    public GameObject StartButtton;
    public GameObject ListPanel;
    public Text PlayerList;

    void Awake()
    {
        PhotonNetwork.ConnectUsingSettings("1st");
    }
    void OnConnectedToMaster()
    {
        Debug.Log("Connected");
    }
    public void SetUserName()
    {
        PhotonNetwork.playerName = Username.text;
    }
    public void JoinGame()
    {
        PhotonNetwork.JoinOrCreateRoom(Roomname.text, new RoomOptions(){MaxPlayers=3}, TypedLobby.Default );
        //ListPanel.SetActive(true);
    }
    void OnJoinedRoom()
    {
        Debug.Log("Enterred Room");

        PhotonNetwork.LoadLevel("LoadingScene");
    }
    void Update()
    {
        if(Username.text != null && Roomname.text != null)
            StartButtton.SetActive(true);

    }
}
