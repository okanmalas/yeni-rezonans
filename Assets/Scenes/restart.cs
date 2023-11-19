using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//bunu kes burdan ayný leveli baþa sarmak için bunu yapýþtýr
    }
    public void ExittGame()
    {
        Application.Quit();

    }
}