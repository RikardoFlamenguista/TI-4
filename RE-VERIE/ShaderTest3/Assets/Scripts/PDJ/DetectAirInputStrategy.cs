using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectAirInputStrategy : MonoBehaviour
{
    private IAirAction action;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    public bool canDoubleJump = true;

    private bool canDash = true;
    private void Update()
    {
        SetCanDash();



        if(action != null) action.HandleMove();



        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (Player.Instance.LockPlayer) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //primeiro verifica se o player esta no chao, e com input de salto dentro do prazo, se sim, pulo base acontece
            if (Player.Instance.IsGrounded && jumpBufferCounter > 0f)
            {

                action = new BaseJumpStrategy();
                action.HandleMove();

                // Reseta o contador do buffer de pulo
                jumpBufferCounter = 0f;


            }

            // caso o jogador esteja no ar, longe o suficiente do chao e pode dar double jump, pulo duplo acontece
          /*  else if (canDoubleJump && Player.Instance.IsGroundedDoubleJump == false)
            {
                Debug.Log("double jump");

                action = new DoubleJumpStrategy();

                canDoubleJump = false;
            }
          */
          
        }

        //problemas com Monobehaviour, talvez colocar o GameObject como referencia no metodo? Sera que tem como mandar um monoBehaviour pra la?     (GameObject go, MonoBehaviour mb);
        if (Input.GetKeyDown(KeyCode.F) && Player.Instance.IsGroundedDoubleJump == false && canDash)
        {
            Debug.Log("dash");
            action = new PlayerDashStrategy();
            action.HandleMove();
        }





        //se o player esta no chao e nao tem input, nenhuma acao acontece
        else if (Player.Instance.IsGrounded && jumpBufferCounter < 0f)
        {

            action = null;
        }

        // Reseta o pulo duplo quando o jogador está no chão
        if (Player.Instance.IsGrounded && !canDoubleJump)
        {
            canDoubleJump = true;




        }

        {



        }

    }





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
