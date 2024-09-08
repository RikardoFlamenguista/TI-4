using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private PlayerAirHandle playerAir;
    public float dashSpeed = 10.0f;
    public float dashDuration = 0.3f;
    public float maxDashSpeed = 10.0f;

    private bool canDash = true;

    private Vector3 dashDirection = new Vector3(0.0f,0.0f,1.0f);
    private PlayerMovementCC playerMovement;
    private float dashTimeLeft;

    private float lastDashTime = -1.0f;
    void Start()
    {
        playerAir = GetComponent<PlayerAirHandle>();
        playerMovement = GetComponent<PlayerMovementCC>();
    }

    // Update is called once per frame
    void Update()
    {
        GetDashDirection();
        SetCanDash();
        HandleDash();
        
    }


    public void GetDashDirection()
    {
        if(playerMovement.SaveMoveInput() != new Vector3(0.0f,0.0f,0.0f))  dashDirection = playerMovement.SaveMoveInput();

    
    }

    public void HandleDash()
    {
        //como o dash so pode ser feito no ar, IsGrounded deve ser falso
        if (Input.GetKeyDown(KeyCode.F) && Player.Instance.IsGroundedDoubleJump == false && canDash)
        {
            //variaveis para controle do dash
            dashSpeed = maxDashSpeed;
            dashTimeLeft = dashDuration;
            lastDashTime = Time.time;

            dashTimeLeft -= Time.deltaTime;
            dashSpeed = Mathf.Lerp(maxDashSpeed, 0f, 1 - (dashTimeLeft / dashDuration));

            //canDash deve se tornar falso quando um dash acontecer, para assim o jogador só conseguir fazer 1 dash por vez no ar
            canDash = false;

            //no HandleDash dentro de "PlayerAirHandle" que toda a logica de aplicacao da forca sera feita
            playerAir.HandleDash(dashSpeed, maxDashSpeed,dashDirection, dashTimeLeft, dashDuration);
        
        
        }
    }

    //verifica todo frame se o jogador pode dar dash
    public void SetCanDash()
    {
        //primeiro verifica se canDash ja esta verdadeiro
        if (canDash == false)
        {

            //se o jogador estiver no chao, can Dash eh restaurado
            if (Player.Instance.IsGroundedDoubleJump == true)
            {
                canDash = true;

            }
        }
        


    }
}
