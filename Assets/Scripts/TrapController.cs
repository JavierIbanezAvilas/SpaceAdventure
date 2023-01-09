using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private bool haceDaño;
    [SerializeField] private bool invulnerable;
    [SerializeField] private float tiempoActivada;
    [SerializeField] private float tiempoDesactivada;
    [SerializeField] private float tiempoInvulnerable;
    private AudioSource audioSource;
    private Transform player;
    private bool activada;

    private void Start()
    {
        audioSource= GetComponent<AudioSource>();
        player = GameObject.Find("T.R.O.N.").transform;
    }

    private void Update()
    {
        if(!activada)
        {
        StartCoroutine(ActivarTrampa());
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && haceDaño && !invulnerable)
        {
            GestorSalud gestorSalud= other.GetComponent<GestorSalud>();
            gestorSalud.BajarSalud(damage);
            GameManager.instFx.InstantiateHitEnemigoFX(player.transform.position + Vector3.up);
            GameManager.instSonido.sonidoHitEnemigo();
            StartCoroutine(Invulnerable());
        }
    }
    IEnumerator ActivarTrampa()
    {
        activada = true;
        yield return new WaitForSeconds(tiempoDesactivada);
        GameObject instFX = GameManager.instFx.InstantiateTrampa(transform.position);
        instFX.transform.SetParent(transform);
        audioSource.Play();
        haceDaño = true;
        yield return new WaitForSeconds(tiempoActivada);
        audioSource.Stop();
        Destroy(instFX);
        haceDaño = false;
        activada = false;
        

    }
    IEnumerator Invulnerable()
    {
        invulnerable = true;
        yield return new WaitForSeconds(tiempoInvulnerable);
        invulnerable = false;
    }
}
