using System.Collections;
using UnityEngine;

public class PlayerJumpCC : MonoBehaviour
{
    public float jumpForce = 5f; // For�a do pulo
    public float extraJumpForce = 2f; // For�a adicional ap�s minJumpTime
    public float gravity = -20f; // For�a da gravidade
    public float maxJumpTime = 0.2f; // Tempo m�ximo que o pulo pode ser sustentado
    public float minJumpTime = 0.1f; // Tempo m�nimo para adicionar extraJumpForce

    private float jumpTimeCounter;
    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    private CharacterController controller;
    private Vector3 velocity;

    private Coroutine jumpCoroutine;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        ApplyGravity();
        HandleJump();
    }

    void ApplyGravity()
    {
        // Verifica se o personagem est� no ch�o
        if (Player.Instance.IsGrounded && velocity.y < 0)
        {
            velocity.y = 0f; // Reseta a velocidade vertical ao tocar no ch�o
        }

        // Aplica a gravidade
        velocity.y += gravity * Time.deltaTime;

        // Move o personagem com base na gravidade
        controller.Move(velocity * Time.deltaTime);
    }

    void HandleJump()
    {
        // Se houver buffer de pulo e o personagem est� no ch�o
        if (Player.Instance.IsGrounded && jumpBufferCounter > 0f)
        {
            // Inicia o pulo e o contador de tempo de pulo
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            jumpTimeCounter = 0f;

            // Reseta o contador do buffer de pulo
            jumpBufferCounter = 0f;

            // Inicia a corrotina para incrementar o tempo de pulo enquanto a tecla estiver pressionada
          
            jumpCoroutine = StartCoroutine(IncreaseJumpTime());
        }

        // Para a corrotina quando a tecla for solta
        if (Input.GetKeyUp(KeyCode.Space) && jumpCoroutine != null)
        {
            StopCoroutine(jumpCoroutine);
            jumpCoroutine = null;
        }
        // Move o personagem com a for�a aplicada
        controller.Move(velocity * Time.deltaTime);
    }

    IEnumerator IncreaseJumpTime()
    {
        bool hasAppliedExtraForce = false; // Flag para garantir que a forca extra seja aplicada apenas uma vez
        int cont = 0;

        while (jumpTimeCounter < maxJumpTime)
        {
            jumpTimeCounter += Time.deltaTime;

            // Aplica a for�a de pulo adicional uma �nica vez quando o tempo de pulo ultrapassar minJumpTime
            if (jumpTimeCounter > minJumpTime && !hasAppliedExtraForce)
            {
                velocity.y += Mathf.Sqrt(extraJumpForce * -2f * gravity);
                hasAppliedExtraForce = true;
            }

            yield return null; // Espera at� o pr�ximo frame
        }
    }

}
