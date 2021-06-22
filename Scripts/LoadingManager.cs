using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public Text PlayerList;
    // Start is called before the first frame update
    void Start()
    {
        foreach (PhotonPlayer player in PhotonNetwork.playerList) 
        {
            PlayerList.text = PlayerList.text + player.NickName + "\n";
        }
    }
    public void ready()
    {
        PhotonNetwork.LoadLevel("GameScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
