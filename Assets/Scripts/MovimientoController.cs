using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MovimientoController : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    [SerializeField] private float tiempoParada;
    [SerializeField] private Transform transformPlayer;
    private GameObject player;
    private PlayerController playerController;
    private int i;
    private float tolerancia = 0.1f;
    private bool wait;
    
    Vector3 posicionActual;
    Vector3 posicionAnterior;

    private void Start()
    {
        player = GameObject.Find("T.R.O.N.");
        playerController = player.GetComponent<PlayerController>();

    }
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[i].position,speed*Time.fixedDeltaTime);

        if(Vector3.Distance(transform.position, waypoints[i].position) <= tolerancia && !wait)
        {
            StartCoroutine(TimeWait());
            if(waypoints.Length-1> i) 
            {
                i++;
            }
            else
            {
                i = 0;
            }
            
        }
    }
        IEnumerator TimeWait()
    {
        wait = true;
        yield return new WaitForSeconds(tiempoParada);
        wait = false;
    }

    private void OnTriggerStay(Collider other)
    {
      
        if (other.CompareTag("PlayerFoot"))
        {
            player.transform.SetParent(transform, true);
        }
          
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerFoot"))
        {
            player.transform.SetParent(transformPlayer, true);
       
        }
    }

}
