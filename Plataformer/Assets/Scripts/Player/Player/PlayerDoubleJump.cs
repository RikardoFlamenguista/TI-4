using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoubleJump : MonoBehaviour
{
    public bool canDoubleJump = true;
    private CharacterController controller;
    public float doubleJumpForce;

    private PlayerBaseJump jumpScript;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        jumpScript = GetComponent<PlayerBaseJump>();
    }

    void Update()
    {
        DoubleJump();
    }

    private void DoubleJump()
    {
        // Condição para permitir o pulo duplo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Player.Instance.IsGrounded)
            {
                // Primeiro salto
                // Adicione o código para o primeiro salto aqui
            }
            else if (canDoubleJump)
            {
                // Pulo duplo
                // Adicione o código para o pulo duplo aqui
                canDoubleJump = false; // Desativa o pulo duplo após o uso
              //  jumpScript.HandleDoubleJump(doubleJumpForce);
            }
        }

        // Reseta o pulo duplo quando o jogador está no chão
        if (Player.Instance.IsGrounded && !canDoubleJump)
        {
            canDoubleJump = true;
        }
    }
}
