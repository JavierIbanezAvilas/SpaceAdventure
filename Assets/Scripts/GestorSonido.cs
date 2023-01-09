using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorSonido : MonoBehaviour
{
    [SerializeField] private AudioClip[] audiofx;
    [SerializeField] private AudioSource audioSource;

    public void sonidoEnergia()
    {
        audioSource.volume = 1f;
        audioSource.PlayOneShot(audiofx[0]);
    }
    public void sonidoHit()
    {
        audioSource.volume = 0.85f;
        audioSource.PlayOneShot(audiofx[1]);
    }
    public void sonidoDobleSalto()
    {
        audioSource.volume = 0.5f;
        audioSource.clip = audiofx[2];
        audioSource.Play();
    }
        
    public void sonidoVida()
    {
        audioSource.volume = 1f;
        
        audioSource.PlayOneShot(audiofx[3]);
    }

    public void sonidoHitEnemigo()
    {
        audioSource.volume = 1f;

        audioSource.PlayOneShot(audiofx[4]);
    }
}
