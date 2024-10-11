using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveStrategy : IAirAction
{
    public float moveSpeed = 25f;  // Velocidade fixa do jogador

    public void HandleMove(GameObject go)
    {

        Vector3 movement = SaveMoveInput();
        CharacterController controller = go.GetComponent<CharacterController>();


        // Salva os inputs de movimento do jogador, acessado pelo PlayerDash para obter a direcao de movimento 
         Vector3 SaveMoveInput()
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal"); // A/D ou Setas Esquerda/Direita
            float moveVertical = Input.GetAxisRaw("Vertical");     // W/S ou Setas Cima/Baixo
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

            return movement;
        }

        if (movement.magnitude > 0)
        {
            // Aplica a movimentação no CharacterController com velocidade constante
            // Considera os eixos locais do personagem (direção atual do personagem)
            controller.Move((go.transform.right * movement.x + go.transform.forward * movement.z) * moveSpeed * Time.deltaTime);
        }
        else
        {
            // Para completamente o movimento quando não houver input
            Player.Instance.controller.Move(Vector3.zero);
        }

    }
}
