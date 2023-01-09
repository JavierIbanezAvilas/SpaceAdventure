using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootTrigger : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private float fuerzaRebote;
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            player.IsFloor = true;
            player.SaltosAcumulados = 0;
        }
        if (other.CompareTag("Enemy"))
        { 
            other.gameObject.GetComponent<EnemyController>().TakeDamage();
            playerRB.velocity = new Vector3(playerRB.velocity.x, fuerzaRebote, playerRB.velocity.z);
            //fx y sonido salto sobr enemigo
            GameManager.instFx.InstantiateHit(new Vector3(transform.position.x,transform.position.y-0.1f,transform.position.z));
            GameManager.instSonido.sonidoHit();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            player.IsFloor = true;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            player.IsFloor = false;
            
        }
    }
}
