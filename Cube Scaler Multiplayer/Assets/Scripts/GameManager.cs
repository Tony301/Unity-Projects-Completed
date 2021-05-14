using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject PlayerPrefabCircle;
   
    public GameObject GameCanvas;
    public GameObject SceneCamera;
    public Text PingText;


    private void Awake()
    {
        GameCanvas.SetActive(true);
    }

    private void Update()
    {
        PingText.text = "Ping:" + PhotonNetwork.GetPing();
    }

    public void SpawnPlayer()
    {
        float randomValue = Random.Range(-1, 1);

        PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3(this.transform.position.x * randomValue, 0, this.transform.position.z * randomValue), Quaternion.identity, 0);
        GameCanvas.SetActive(false);
        SceneCamera.SetActive(false);
    }

    public void SpawnPlayerCircle()
    {
        float randomValue = Random.Range(-1, 1);

        PhotonNetwork.Instantiate(PlayerPrefabCircle.name, new Vector3(this.transform.position.x * randomValue, 0, this.transform.position.z * randomValue), Quaternion.identity, 0);
        GameCanvas.SetActive(false);
        SceneCamera.SetActive(false);
    }




}
