using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{

    public InputField LobbyName;
    
    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.BroadcastPropsChangeToAll = true;
        
        if (LobbyName != null) {
            PhotonNetwork.CreateRoom(LobbyName.text, roomOptions, null);
        }

    }

    public void JoinRoom() {
        Debug.Log("moi");
        PhotonNetwork.JoinRoom(LobbyName.text);
    }

    public override void OnJoinRoomFailed(short returnCode, string message) {
        CreateRoom();
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GameLobby");
    }

}
