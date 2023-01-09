using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestorEstamina : MonoBehaviour
{
    [SerializeField] private float staminaTotal;
    [SerializeField] private float stamina;
    private bool bajaEstamina;
    private bool subeEstamina;
    public float Stamina
    { get { return stamina; }
      set { stamina = value; }
    }
    public float StaminaTotal
    { get { return staminaTotal; }
      set { staminaTotal = value; }
    }
    [SerializeField] private float gastoStamina;
    [SerializeField] private float recuStamina;

    [SerializeField] private Image barraStamina;

    private void Start()
    {
        stamina = staminaTotal;
        barraStamina.fillAmount= stamina/staminaTotal;
    }
    private void Update()
    {
        if(bajaEstamina)
        {
            if(stamina>0)
            {
            stamina -= Time.deltaTime*gastoStamina;
            }
            else
            {
                stamina = 0;
                bajaEstamina = false;
                subeEstamina = true;
            }
        barraStamina.fillAmount = stamina / staminaTotal;
        }
        if(subeEstamina)
        {
            if(stamina<staminaTotal)
            {
            stamina += Time.deltaTime*recuStamina;
            }
            else
            {
                stamina = staminaTotal;
            }
        barraStamina.fillAmount = stamina / staminaTotal;
        }
        
    }
    public void BajarEstamina()
    {
        subeEstamina = false;
        bajaEstamina = true;
    }
    public void SubirEstamina()
    {
        bajaEstamina = false;
        subeEstamina = true;
    }
}
