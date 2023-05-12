using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] // expose in the Inspector
    private Button checkButton;

    [SerializeField] // expose in the Inspector
    private GameObject successPanel;

    [SerializeField] // expose in the Inspector
    private GameObject failPanel;

    [SerializeField] // expose in the Inspector
    private GameObject initialPanel;

    private Slot[] slots;

    private void Start()
    {
        slots = FindObjectsOfType<Slot>();

        checkButton.onClick.AddListener(CheckSlots);
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private void CheckSlots()
    {
        bool allCorrect = true;

        foreach (Slot slot in slots)
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
