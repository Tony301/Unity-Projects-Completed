using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {

            Debug.Log("end");
            Destroy(gameObject);
            SceneManager.LoadScene("retry");
        }
    }
}
