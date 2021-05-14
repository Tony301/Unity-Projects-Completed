using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private string VersionName = "0.1";
    [SerializeField] private GameObject UsernameMenu;
    [SerializeField] private GameObject ConnectPanel;

    [SerializeField] private InputField UsernameInput;
    [SerializeField] private InputField CreateGameInput;
    [SerializeField] private InputField JoinGameInput;

    [SerializeField] private GameObject StartButton;



    public GameObject tabMain;//
    public GameObject tabRooms;//
    public GameObject ButtonRooms;//

    private List<RoomInfo> roomList;//

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(VersionName);
    }

    private void Start()
    {
        UsernameMenu.SetActive(true);
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }



    public void ChangeUserNameInput()
    {
        if (UsernameInput.text.Length >= 3)
        {
            StartButton.SetActive(true);
        }
        else
        {
            StartButton.SetActive(false);
        }
    }

    public void SetUserName()
    {
        UsernameMenu.SetActive(false);
        PhotonNetwork.playerName = UsernameInput.text;
    }

    public void CreateGame()
    {
       // RoomOptions options = new RoomOptions();//
       // options.MaxPlayers = 5;//
        PhotonNetwork.CreateRoom(CreateGameInput.text, new RoomOptions() { MaxPlayers = 5 }, null);
    }


    private void ClearRoomlist()//
    {

        Transform content = tabRooms.transform.Find("Scrool View/Viewport/Content");
        foreach (Transform a in content) Destroy(a.gameObject);
    }

    public  void OnRoomListUpdate(List<RoomInfo> p_list)//
    {
        roomList = p_list;
        ClearRoomlist();
         
        Debug.Log("LOADED ROOMS @ " + Time.time);
        Transform content = tabRooms.transform.Find("Scrool View/Viewport/Content");

        foreach(RoomInfo a in roomList)
        {
            GameObject newRoomButton = Instantiate(ButtonRooms, content) as GameObject;

            newRoomButton.transform.Find("Name").GetComponent<Text>().text = a.Name;
            newRoomButton.transform.Find("Players").GetComponent<Text>().text = a.PlayerCount+"/"+a.MaxPlayers;

            newRoomButton.GetComponent<Button>().onClick.AddListener(delegate { JoinRoom(newRoomButton.transform); });

        }
        //base.OnRoomListUpdate(roomList);
    }

    public void JoinRoom(Transform p_button)//
    {
        Debug.Log("JOINING ROOM @ " + Time.time);
        string t_roomName = p_button.Find("Name").GetComponent<Text>().text;
        PhotonNetwork.JoinRoom(t_roomName);
    }
    public void JoinGame()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 5;
        PhotonNetwork.JoinOrCreateRoom(JoinGameInput.text, roomOptions, TypedLobby.Default);

    }

    private void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Main");
    }
}
