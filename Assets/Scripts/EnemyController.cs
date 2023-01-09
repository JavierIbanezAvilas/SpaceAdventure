using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private float damage;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float tiempoParada;
    [SerializeField] private float radioDeteccion;
    [SerializeField] private int vidaGolpes;
    [SerializeField] private int fuerzaImpacto;
    private PlayerController player;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private string enemyAction;
    private Transform playerPosition;
    private Rigidbody playerRB;
    private float tolerancia = 0.2f;
    private bool wait;
    private int i;

    private void Start()
    {
        playerPosition = GameObject.Find("T.R.O.N.").transform;
        playerRB = GameObject.Find("T.R.O.N.").GetComponent<Rigidbody>();
        player = GameObject.Find("T.R.O.N.").GetComponent<PlayerController>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator= GetComponent<Animator>();
        enemyAction = "Patrulla";
    }

    private void Update()
    {
        if (navMeshAgent.enabled == true)
        {

            switch (enemyAction)
            {
                case "Patrulla":
                    Patrullar();
                    break;
                case "Perseguir":
                    Perseguir();
                    break;
                case "Ataque":
                    Atacar();
                    break;
            }

            if (Vector3.Distance(playerPosition.position, transform.position) > radioDeteccion)
            {
                enemyAction = "Patrulla";
            }
            else
            {
                enemyAction = "Perseguir";
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<GestorSalud>().BajarSalud(damage);
            //knockback con RB y fx sonido
            if(player.IsFloor)
            {
                playerRB.AddExplosionForce(fuerzaImpacto, transform.position, 2f);
                GameManager.instFx.InstantiateHitEnemigoFX(player.transform.position + Vector3.up);
                GameManager.instSonido.sonidoHitEnemigo();
            }
            
        }
    }
    

    private void Patrullar()
    {
       
        navMeshAgent.SetDestination(waypoints[i].position);
        if (Vector3.Distance(transform.position, waypoints[i].position) <= tolerancia)
        {
            
            if (waypoints.Length - 1 > i)
            {
                i++;
            }
            else
            {
                i = 0;
            }     
        }
    }
    private void Perseguir()
    {
        navMeshAgent.SetDestination(playerPosition.position);
    }
    private void Atacar()
    {

    }
    public void TakeDamage()
    {
        if(vidaGolpes-1>0)
        {
            vidaGolpes--;
        }
        else
        {
            Die();
        }
    }
    private void Die()
    {
        navMeshAgent.enabled = false;
        
        StartCoroutine(DesactivarCollider());
        animator.Play("Die");
        Destroy(gameObject, 5);
        //fx y sonido
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radioDeteccion);
    }

    IEnumerator DesactivarCollider()
    {
        yield return new WaitForSeconds(0.3f);
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }
}
