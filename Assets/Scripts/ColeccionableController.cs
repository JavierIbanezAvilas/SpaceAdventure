using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Coleccionable {orbe,vida};

public class ColeccionableController : MonoBehaviour
{
    [SerializeField] Coleccionable coleccionable;
    private GestorPuntuacion gestorPuntuacion;
    private GestorFX gestorFX;


    private void Awake()
    {
        gestorFX= GameObject.Find("GameManager").GetComponent<GestorFX>();
        gestorPuntuacion= GameObject.Find("GameManager").GetComponent<GestorPuntuacion>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(coleccionable == Coleccionable.orbe )
            {
                //Subir Marcador
                gestorPuntuacion.EnergiaAcumulada++;
                //fx
                GameManager.instFx.InstantiateEnergyFX(transform.position);
                //sonido
                GameManager.instSonido.sonidoEnergia();

            }
            if (coleccionable == Coleccionable.vida)
            {
                //Subir Vida
                GestorSalud gestorSalud= other.GetComponent<GestorSalud>();
                gestorSalud.SubirSalud(50);
                //fx
                GameManager.instFx.InstantiateVidaFX(transform.position);
                //sonido
                GameManager.instSonido.sonidoVida();

                
            }

            Destroy(gameObject, 0.1f);
        }
    }
}
