using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GestorPuntuacion : MonoBehaviour
{
    private TextMeshProUGUI puntuacion;
    private int energiaTotal;
    private int energiaAcumulada;
    public int EnergiaAcumulada
    {
        get { return energiaAcumulada; }
        set { energiaAcumulada = value; }
    }

    private void Start()
    {

        puntuacion= GameObject.Find("EnergyTxt").GetComponent<TextMeshProUGUI>();
        energiaTotal = GameObject.Find("Orbes").GetComponentsInChildren<ColeccionableController>().Length;
    }
    private void Update()
    {
        puntuacion.text = energiaAcumulada.ToString()+" / "+ energiaTotal.ToString();
    }
    

}
