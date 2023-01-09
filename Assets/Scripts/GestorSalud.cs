using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestorSalud : MonoBehaviour
{
    [SerializeField] private float saludTotal;
    [SerializeField] private float salud;
    private Animator animator;
        public float Salud
    {
        get { return salud; }
        set { salud = value; }
    }
    public float SaludTotal
    {
        get { return saludTotal; }
        set { saludTotal = value; }
    }
    [SerializeField] private Image barraSalud;

    private void Start()
    {
        animator = GetComponent<Animator>();
        salud = saludTotal;
        ActualizarSalud();
    }

    public void BajarSalud(float damage)
    {
        if(salud-damage> 0)
        {
            salud -= damage;
        }
        else
        {
            salud = 0;
            Die();
        }
        ActualizarSalud();
    }
    public void SubirSalud(float amount)
    {
        if(salud+amount<saludTotal)
        {
            salud += amount;
        }
        else
        {
            salud = saludTotal;
        }
        ActualizarSalud();
    }
    public void ActualizarSalud()
    {
        barraSalud.fillAmount = salud / saludTotal;
    }

    public void Die()
    {
        //animacion morir
        animator.Play("Die");
        //desactivaRB
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponentInChildren<SphereCollider>().enabled = false;
        //desactivar playercontroler
        if(TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            playerController.enabled= false;
        }
        //sonido y fx
        //reiniciar escena
        StartCoroutine(WaitToLoad());
    }

    IEnumerator WaitToLoad()
    {
        yield return new WaitForSeconds(5);
        GameManager.inst.GetComponent<ScenesController>().Reiniciar();

    }
}

