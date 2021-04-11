using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class manager : MonoBehaviour
{
  public void RunStart()
    {
        SceneManager.LoadScene("Start");
    }
   public void VegetableStart()
    {
        SceneManager.LoadScene("vegetable");
    }


   public void TicTacToe()
    {
        SceneManager.LoadScene("Main");
    }

}
