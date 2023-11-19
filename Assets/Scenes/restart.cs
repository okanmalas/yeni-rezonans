using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//bunu kes burdan ayn� leveli ba�a sarmak i�in bunu yap��t�r
    }
    public void ExittGame()
    {
        Application.Quit();

    }
}