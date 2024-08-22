using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoubleJump : MonoBehaviour
{
    public bool canDoubleJump = true;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        DoubleJump();
    }

    private void DoubleJump()
    {
        // Condi��o para permitir o pulo duplo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Player.Instance.IsGrounded)
            {
                // Primeiro salto
                // Adicione o c�digo para o primeiro salto aqui
            }
            else if (canDoubleJump)
            {
                // Pulo duplo
                // Adicione o c�digo para o pulo duplo aqui
                canDoubleJump = false; // Desativa o pulo duplo ap�s o uso
            }
        }

        // Reseta o pulo duplo quando o jogador est� no ch�o
        if (Player.Instance.IsGrounded && !canDoubleJump)
        {
            canDoubleJump = true;
        }
    }
}
