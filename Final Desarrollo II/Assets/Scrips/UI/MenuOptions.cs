using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{

    public void GoToGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }   
    
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void ExitGame()
    {

#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#else   

        Application.Quit();
#endif

    }


}
