using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
   public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(WaitToLoad());
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene(0);

    }
    IEnumerator WaitToLoad()
    {
        yield return new WaitForEndOfFrame();
        GameManager.inst.GetComponent<GestorPuntuacion>().enabled = true;
    }
}
