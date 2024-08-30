using System.Collections;
using UnityEngine;

public class PlayerBaseJump : MonoBehaviour
{
    public float jumpForce = 5f; // For�a do pulo
    public float extraJumpForce = 2f; // For�a adicional ap�s minJumpTime
    public float gravity = -20f; // For�a da gravidade
    public float maxJumpTime = 0.2f; // Tempo m�ximo que o pulo pode ser sustentado
    public float minJumpTime = 0.1f; // Tempo m�nimo para adicionar extraJumpForce

    private float jumpTimeCounter;
    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    
    private Vector3 velocity;

    private Coroutine jumpCoroutine;
    private PlayerAirHandle playerAir;

    void Start()
    {
        playerAir = GetComponent<PlayerAirHandle>();
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


        HandleJump();
    }

  

    void HandleJump()
    {
        // Se houver buffer de pulo e o personagem est� no ch�o
        if (Player.Instance.IsGrounded && jumpBufferCounter > 0f)
        {
            playerAir.HandleBaseJump(jumpForce);

            // Reseta o contador do buffer de pulo
            jumpBufferCounter = 0f;

            // Inicia a corrotina para incrementar o tempo de pulo enquanto a tecla estiver pressionada

            playerAir.StartBaseJumpCorroutine(maxJumpTime, minJumpTime, extraJumpForce);
        }

        // Para a corrotina quando a tecla for solta
        if (Input.GetKeyUp(KeyCode.Space) && playerAir.JumpCoroutine != null)
        {
            playerAir.StopBaseJumpCorroutine();
        }
        // Move o personagem com a for�a aplicada
     
    }

    /*
    public void HandleDoubleJump(float doubleJumpForce)
    {
        velocity.y = Mathf.Sqrt(doubleJumpForce * -2f * gravity);

        playerAir.controller.Move(velocity * Time.deltaTime);


    }
    */
 
}
