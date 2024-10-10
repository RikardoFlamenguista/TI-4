using Unity.VisualScripting;
using UnityEngine;

// Gerencia o movimento em solo do jogador
public class PlayerMovementCC : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidade fixa do jogador

    public GameObject mainCamera;

    private CharacterController controller;

    private bool speedBoost;
    public float speedBoostForce = 2;

    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    void Update()
    {
        //se nao tem nada que impede o movimento, o metodo eh chamado
        if(!Player.Instance.LockPlayer) Move();
        AlignRotationWithCamera();

        DetectBoostInput();

    }

    // Alinha a rotação do personagem com a câmera
    void AlignRotationWithCamera()
    {
        // Obtem a rotaçao da câmera em torno do eixo Y apenas
        Vector3 cameraForward = mainCamera.transform.forward;
        cameraForward.y = 0f; 

        if (cameraForward.magnitude > 0)
        {
            // Define a rotaçco do personagem para a direção da câmera
            transform.rotation = Quaternion.LookRotation(cameraForward);
        }
    }

    private void DetectBoostInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) speedBoost = true;
        if (Input.GetKeyUp(KeyCode.LeftShift)) speedBoost = false;

    }

    // Move o jogador com base nos eixos locais
    void Move()
    {
        // Cria um vetor de movimento com base nas entradas
        Vector3 movement = SaveMoveInput();

        if (movement.magnitude > 0)
        {
            // Aplica a movimentação no CharacterController com velocidade constante
            // Considera os eixos locais do personagem (direção atual do personagem)
            if (!speedBoost || !Player.Instance.IsGrounded) controller.Move((transform.right * movement.x + transform.forward * movement.z) * moveSpeed * Time.deltaTime);
            else controller.Move((transform.right * movement.x + transform.forward * movement.z) * moveSpeed * speedBoostForce * Time.deltaTime);
        }
        else
        {
            // Para completamente o movimento quando não houver input
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
