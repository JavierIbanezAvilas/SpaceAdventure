using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private bool facingRight;
    [SerializeField] private bool facingLeft;
    [SerializeField] private bool facingUp;
    [SerializeField] private bool facingUpLeft;
    [SerializeField] private bool facingUpRight;
    [SerializeField] private bool facingDown;
    [SerializeField] private bool facingDownLeft;
    [SerializeField] private bool facingDownRight;
    [SerializeField] private bool isFloor;
    public bool IsFloor
    {
        get { return isFloor; }
        set { isFloor = value; }
    }
    private float originalSpeed;
    private Animator playerAnimator;
    private Rigidbody playerRB;
    private Transform playerTransform;
    private GestorEstamina gestorEstamina;
    private float ejeX=0;
    private float ejeZ=0;
    private float eje;
    private int saltosAcumulados=0;
    public int SaltosAcumulados
    {
        get { return saltosAcumulados; }
        set { saltosAcumulados = value; }
    }
    private void Start()
    {
        playerAnimator= GetComponent<Animator>();
        playerRB= GetComponent<Rigidbody>();
        playerTransform= GetComponent<Transform>();
        gestorEstamina= GetComponent<GestorEstamina>();
        originalSpeed = speed;
    }

    private void Update()
    {

        ejeX = Input.GetAxis("Horizontal");
        ejeZ = Input.GetAxis("Vertical");

        if(Mathf.Abs(ejeX)> Mathf.Abs(ejeZ))
        {
            eje = ejeX;
        }
        else { eje= ejeZ; }
        playerAnimator.SetFloat("Speed", Mathf.Abs(speed*eje));

        playerAnimator.SetBool("IsFloor", isFloor);
       
        if (Input.GetButtonDown("Jump") && saltosAcumulados<2)
        {
            if(isFloor==false)
            {
            DobleSalto();
            }
            else
            Saltar();
        }

        if(Input.GetButtonDown("Fire3") && isFloor && gestorEstamina.Stamina== gestorEstamina.StaminaTotal)
        {
            speed = speed * 1.75f;
            gestorEstamina.BajarEstamina();
            
        }
        if(Input.GetButtonUp("Fire3"))
        {
            speed = originalSpeed;
            gestorEstamina.SubirEstamina();
            
        }
        if (gestorEstamina.Stamina <= 0.1f)
        {
            speed = originalSpeed;
        }
        
        

    }
    private void FixedUpdate()
    {
        Movimiento();
        
    }

    private void Saltar()
    {   
        playerRB.velocity = new Vector3(0, 0, 0);
        playerRB.AddForce(playerRB.velocity.x, fuerzaSalto, playerRB.velocity.z, ForceMode.Impulse);
        isFloor = false;
        saltosAcumulados++;
        playerAnimator.SetTrigger("Jump");
    }
    private void DobleSalto()
    {
        GameManager.instFx.InstantiateDobleSaltoFX(new Vector3(transform.position.x, transform.position.y+0.2f, transform.position.z));
        GameManager.instSonido.sonidoDobleSalto();
        playerRB.velocity = new Vector3(0, 0, 0);
        playerRB.AddForce(playerRB.velocity.x, 0.9f*fuerzaSalto, playerRB.velocity.z, ForceMode.Impulse);
        saltosAcumulados++;
        playerAnimator.Play("Jump");
    }
    private void Movimiento()
    {
        if (ejeX < 0 && !facingLeft)
        {
            playerTransform.rotation = Quaternion.Euler(0, -90, 0);
            playerTransform.localScale = new Vector3(playerTransform.localScale.x, playerTransform.localScale.y, Mathf.Abs(playerTransform.localScale.z));
            facingLeft = true;
            facingRight = false;
            facingUp = false;
            facingDown = false;
            facingUpRight = false;
            facingUpLeft = false;
            facingDownLeft = false;
            facingDownRight = false;
        }
        if (ejeX > 0 && !facingRight)
        {
            playerTransform.rotation = Quaternion.Euler(0, 90, 0);
            playerTransform.localScale = new Vector3(playerTransform.localScale.x, playerTransform.localScale.y, Mathf.Abs(playerTransform.localScale.z));
            facingRight = true;
            facingLeft = false;
            facingUp = false;
            facingDown = false;
            facingUpRight = false;
            facingUpLeft = false;
            facingDownLeft = false;
            facingDownRight = false;
        }
        if (ejeZ < 0 && !facingDown)
        {
            playerTransform.localScale = new Vector3(playerTransform.localScale.x, playerTransform.localScale.y, -Mathf.Abs(playerTransform.localScale.z));
            playerTransform.rotation = Quaternion.identity;
            facingDown = true;
            facingUp = false;
            facingLeft = false;
            facingRight = false;
            facingUpRight = false;
            facingUpLeft = false;
            facingDownLeft = false;
            facingDownRight = false;
        }
        if (ejeZ > 0 && !facingUp)
        {
            playerTransform.localScale = new Vector3(playerTransform.localScale.x, playerTransform.localScale.y, Mathf.Abs(playerTransform.localScale.z));
            playerTransform.rotation = Quaternion.identity;
            facingUp = true;
            facingDown = false;
            facingLeft = false;
            facingRight = false;
            facingUpRight = false;
            facingUpLeft = false;
            facingDownLeft = false;
            facingDownRight = false;
        }
        if (ejeX<0 && ejeZ>0 && !facingUpLeft)
        {

            playerTransform.rotation = Quaternion.Euler(0, -45, 0);
            playerTransform.localScale = new Vector3(playerTransform.localScale.x, playerTransform.localScale.y, Mathf.Abs(playerTransform.localScale.z));
            facingRight = false;
            facingLeft = false;
            facingUp = false;
            facingDown = false;
            facingUpRight= false;
            facingUpLeft = true;
            facingDownLeft = false;
            facingDownRight = false;
        }
        if (ejeX > 0 && ejeZ > 0 && !facingUpRight)
        {

            playerTransform.rotation = Quaternion.Euler(0, 45, 0);
            playerTransform.localScale = new Vector3(playerTransform.localScale.x, playerTransform.localScale.y, Mathf.Abs(playerTransform.localScale.z));
            facingRight = false;
            facingLeft = false;
            facingUp = false;
            facingDown = false;
            facingUpRight = true;
            facingUpLeft = false;
            facingDownLeft = false;
            facingDownRight = false;
        }
        if (ejeZ < 0 && ejeX< 0 && !facingDownLeft)
        {
            playerTransform.rotation = Quaternion.Euler(0,-135, 0);
            playerTransform.localScale = new Vector3(playerTransform.localScale.x, playerTransform.localScale.y, Mathf.Abs(playerTransform.localScale.z));
            facingDown = false;
            facingUp = false;
            facingLeft = false;
            facingRight = false;
            facingUpRight = false;
            facingUpLeft = false;
            facingDownLeft = true;
            facingDownRight = false;
        }
        if (ejeZ < 0 && ejeX > 0 && !facingDownRight)
        {
            playerTransform.rotation = Quaternion.Euler(0, 135, 0);
            playerTransform.localScale = new Vector3(playerTransform.localScale.x, playerTransform.localScale.y, Mathf.Abs(playerTransform.localScale.z));
            facingDown = false;
            facingUp = false;
            facingLeft = false;
            facingRight = false;
            facingUpRight = false;
            facingUpLeft = false;
            facingDownLeft = false;
            facingDownRight = true;
        }

        playerRB.velocity = new Vector3(ejeX * speed, playerRB.velocity.y, ejeZ * speed) ;
    }

    

}
