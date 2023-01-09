using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Vector3 posicionInicial;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.position = posicionInicial;
        }
    }
}
