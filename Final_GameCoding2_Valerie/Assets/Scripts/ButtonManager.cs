using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
   public void StartGame() 
   {
        SceneManager.LoadScene(1);
   }
    public void StartScreen() 
    { 
        SceneManager.LoadScene(0);
    }
    public void FishEasy() 
    {
        SceneManager.LoadScene(3);
    }
    public void FishHard() 
    {
        SceneManager.LoadScene(2);
    }

}
