using UnityEngine;

public class PlayerMovementCC : MonoBehaviour
{
    public float startingSpeed = 5f;
    public float maximumSpeed = 10f;
    public float acceleration = 1f;
    public float breakSpeed = 1f;
    //public float gravity = -20f; // Força da gravidade
    public float jumpForce = 10f; // Força do pulo

    private float currentSpeed; // Velocidade atual do personagem
    private CharacterController controller;
    private Vector3 velocity; // Velocidade vertical
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = startingSpeed; // Define a velocidade inicial como startingSpeed
    }

    void Update()
    {
        Move();
      //  ApplyGravity();
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D ou Setas Esquerda/Direita
        float moveVertical = Input.GetAxis("Vertical");     // W/S ou Setas Cima/Baixo

        // Cria um vetor de movimento com base nas entradas
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement.magnitude > 0)
        {
            // Aumenta a velocidade atual até o limite de maximumSpeed
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Min(currentSpeed, maximumSpeed); // Garante que a velocidade não exceda o máximo

            // Aplica a movimentação no CharacterController
            controller.Move(movement.normalized * currentSpeed * Time.deltaTime);
        }
        else
        {
            // Diminui a velocidade assim que o Input se encerra
            currentSpeed = breakSpeed + (currentSpeed / 10);
        }
    }
}
