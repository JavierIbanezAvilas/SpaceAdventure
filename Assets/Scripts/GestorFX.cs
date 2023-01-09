using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorFX : MonoBehaviour
{
    [SerializeField] private GameObject[] fxs;

    public GameObject InstantiateTrampa(Vector3 position)
    {
        return Instantiate(fxs[0], position,Quaternion.identity);
    }
    public GameObject InstantiateHit(Vector3 position)
    {
        return Instantiate(fxs[1],position, Quaternion.identity);
    }
    public GameObject InstantiateEnergyFX(Vector3 position)
    {
        return Instantiate(fxs[2], position, Quaternion.identity);
    }
    public GameObject InstantiateVidaFX(Vector3 position)
    {
        return Instantiate(fxs[3], position, Quaternion.identity);
    }
    public GameObject InstantiateDobleSaltoFX(Vector3 position)
    {
        return Instantiate(fxs[4], position, Quaternion.identity);
    }
    public GameObject InstantiateHitEnemigoFX(Vector3 position)
    {
        return Instantiate(fxs[5], position, Quaternion.identity);
    }
}
