using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Button checkButton;
    public GameObject successPanel;
    public GameObject failPanel;
    public GameObject initialPanel;

    

    void Start()
        {
            checkButton = GameObject.FindGameObjectWithTag("CheckButton").GetComponent<Button>();

       
            initialPanel = GameObject.FindGameObjectWithTag("InitialPanel");

            checkButton.onClick.AddListener(CheckSlots);
        }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private void CheckSlots()
    {
        bool allCorrect = true;

        foreach (Slot slot in FindObjectsOfType<Slot>())
        {
            if (!slot.HasCorrectObject())
            {
                allCorrect = false;
                break;
            }
        }

        // Make sure all panels are initially set to inactive
        initialPanel.SetActive(false);
        successPanel.SetActive(false);
        failPanel.SetActive(false);

        if (allCorrect)
        {
            successPanel.SetActive(true);
        }
        else
        {
            failPanel.SetActive(true);
        }
    }

    public void RestartScene()
    {


        // Reload the current scene
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
