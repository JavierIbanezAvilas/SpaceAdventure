using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;
    public static GestorSonido instSonido;
    public static GestorFX instFx;
    private void Awake()
    {
        if(GameManager.inst == null)
        {
            GameManager.inst = this;
            DontDestroyOnLoad(gameObject);
            instSonido=GetComponentInChildren<GestorSonido>();
            instFx=GetComponent<GestorFX>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
