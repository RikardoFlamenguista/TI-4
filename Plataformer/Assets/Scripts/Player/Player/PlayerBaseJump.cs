using System.Collections;
using UnityEngine;

//gerencia as variaveis que controlam a forca e Input para pulo base do jogador
public class PlayerBaseJump : MonoBehaviour
{
    public float jumpForce = 5f; // Forca do pulo
    public float extraJumpForce = 2f; // For�a adicional ap�s minJumpTime
    public float gravity = -20f; // Forca da gravidade
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
        //salva o input de pulo do jogador caso esteja no ar, para caso encosta no solo em poucos frames o pulo ainda seja efetuado
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

  
    //contra o pulo base do jogador
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
     
    }

   
 
}
