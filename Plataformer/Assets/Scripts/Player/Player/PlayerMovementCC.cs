using UnityEngine;

public class PlayerMovementCC : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidade fixa do jogador
    public float jumpForce = 10f; // For�a do pulo

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
      

        // Cria um vetor de movimento com base nas entradas, mas apenas se houver input
        Vector3 movement = SaveMoveInput();

        if (movement.magnitude > 0)
        {
            // Aplica a movimenta��o no CharacterController com velocidade constante
            controller.Move(movement * moveSpeed * Time.deltaTime);
        }
        else
        {
            // Para completamente o movimento quando n�o houver input
            controller.Move(Vector3.zero);
        }
    }

    public Vector3 SaveMoveInput()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal"); // A/D ou Setas Esquerda/Direita
        float moveVertical = Input.GetAxisRaw("Vertical");     // W/S ou Setas Cima/Baixo
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

  
        return movement;
    }
}
