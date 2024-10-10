using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoubleJump : MonoBehaviour
{
    public bool canDoubleJump = true;
    private CharacterController controller;
    public float doubleJumpForce;

    private PlayerAirHandle playerAir;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerAir = GetComponent<PlayerAirHandle>();
    }

    void Update()
    {
        DoubleJump();
    }

    //controla o pulo duplo do jogador
    private void DoubleJump()
    {
        // Condição para permitir o pulo duplo
        if (Input.GetKeyDown(KeyCode.Space))
        {
      
            if (canDoubleJump && Player.Instance.IsGroundedDoubleJump == false)
            {
                // Pulo duplo
                playerAir.HandleDoubleJump(doubleJumpForce);
                canDoubleJump = false; // Desativa o pulo duplo após o uso
            }
        }

        // Reseta o pulo duplo quando o jogador está no chão
        if (Player.Instance.IsGrounded && !canDoubleJump)
        {
            canDoubleJump = true;
        }
    }
}
