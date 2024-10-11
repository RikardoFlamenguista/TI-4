using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//existem 3 acoes no Strategy: pulo, teleporte e movimento
public class DetectAirInputStrategy : MonoBehaviour
{
    private IAirAction action;
    private IAirAction moveAction;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    private bool canTeleport = true;
    private void Update()
    {
        if (Player.Instance.LockPlayer) return;

        //verifica se os requisitos para poder se teleportar novamente foram atingidos
        SetCanTeleport();

        //se tiver alguma acao salva, ela eh executada. Existem 2 variaveis de acoes diferentes, ja que podem acontecer ao mesmo tempo, uma para controlar pulo e teleporte, e outro para movimento
        if(action != null) action.HandleMove(this.gameObject);
        if (moveAction != null) moveAction.HandleMove(this.gameObject);


        //detecta input de pulo e inicia o timer do buffer
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }


       

            //primeiro verifica se o player esta no chao, e com input de salto dentro do prazo, se sim, pulo base acontece
            if (Player.Instance.IsGrounded && jumpBufferCounter > 0f)
            {
       
                action = new BaseJumpStrategy();
                action.HandleMove(this.gameObject);

                // Reseta o contador do buffer de pulo
                jumpBufferCounter = 0f;


            }

          
          
        

        //problemas com Monobehaviour, talvez colocar o GameObject como referencia no metodo? Sera que tem como mandar um monoBehaviour pra la?     (GameObject go, MonoBehaviour mb);
        if (Input.GetKeyDown(KeyCode.F) && Player.Instance.IsGrounded)
        {
            action = new PlayerTeleportStrategy();
           action.HandleMove(this.gameObject);
            action = null;
        }

        //deteca inputs de movimento
        if (Input.GetAxisRaw("Horizontal") != 0|| Input.GetAxisRaw("Vertical") != 0)
        {
            if(moveAction == null) moveAction = new PlayerMoveStrategy();

        }

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0) moveAction = null;







        //se o player esta no chao e nao tem input, nenhuma acao acontece
         if (Player.Instance.IsGrounded && jumpBufferCounter < 0f)
        {
            action = null;
        }

     

        {



        }

    }





    public void SetCanTeleport()
    {
        //primeiro verifica se canDash ja esta verdadeiro
        if (canTeleport == false)
        {

            //se o jogador estiver no chao, can Dash eh restaurado
            if (Player.Instance.IsGroundedDoubleJump == true)
            {
                canTeleport = true;

            }
        }



    }








}
