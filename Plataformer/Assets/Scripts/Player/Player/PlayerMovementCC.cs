using Unity.VisualScripting;
using UnityEngine;

// Gerencia o movimento em solo do jogador
public class PlayerMovementCC : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidade fixa do jogador
    public float jumpForce = 10f; // For�a do pulo

    public GameObject mainCamera;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        
    }

    void Update()
    {
        //se nao tem nada que impede o movimento, o metodo eh chamado
        if(!Player.Instance.LockPlayer) Move();
        
        
        AlignRotationWithCamera();
    }

    // Alinha a rota��o do personagem com a c�mera
    void AlignRotationWithCamera()
    {
        // Obtem a rota�ao da c�mera em torno do eixo Y apenas
        Vector3 cameraForward = mainCamera.transform.forward;
        cameraForward.y = 0f; 

        if (cameraForward.magnitude > 0)
        {
            // Define a rota�co do personagem para a dire��o da c�mera
            transform.rotation = Quaternion.LookRotation(cameraForward);
        }
    }

    // Move o jogador com base nos eixos locais
    void Move()
    {
        // Cria um vetor de movimento com base nas entradas
        Vector3 movement = SaveMoveInput();

        if (movement.magnitude > 0)
        {
            // Aplica a movimenta��o no CharacterController com velocidade constante
            // Considera os eixos locais do personagem (dire��o atual do personagem)
            controller.Move((transform.right * movement.x + transform.forward * movement.z) * moveSpeed * Time.deltaTime);
        }
        else
        {
            // Para completamente o movimento quando n�o houver input
            controller.Move(Vector3.zero);
        }
    }

    // Salva os inputs de movimento do jogador, acessado pelo PlayerDash para obter a direcao de movimento 
    public Vector3 SaveMoveInput()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal"); // A/D ou Setas Esquerda/Direita
        float moveVertical = Input.GetAxisRaw("Vertical");     // W/S ou Setas Cima/Baixo
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        return movement;
    }
}
