using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controla a aplicacao de fisica aerea do jogador. Gravidade, salto, salto duplo e dash
public class PlayerAirHandle : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 velocity;

    public float gravity = -20f;

    private float jumpTimeCounter;

    private bool isDashing = false;
    private float lastDashTime = -1f;

    private Coroutine jumpCoroutine;
    public Coroutine JumpCoroutine { get { return jumpCoroutine; } }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ApplyGravity();

        //caso o jogador esteja em um dash, zera sua velocidade vertical;
        if (isDashing)
        {
            velocity.y = 0;
            controller.Move(velocity * Time.deltaTime);

        }
    }

    //aplica gravidade no jogador
    private void ApplyGravity()
    {
        if (Player.Instance.IsGrounded && velocity.y < 0)
        {
            velocity.y = 0.01f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }



    //gerencia a aplicacao de forca do salto base do jogador, a deteccao de Input eh feita em PlayerBaseJump
    public void HandleBaseJump(float jumpForce)
    {
        Debug.Log("lidando com pulo base");
      
        // Inicia o pulo e o contador de tempo de pulo
        velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);


        // Reseta o contador do buffer de pulo
        jumpTimeCounter = 0f;

      
        // Move o personagem com a forca aplicada
         controller.Move(velocity * Time.deltaTime);

    }

    //gerencia a aplicacao de forca do salto duplo do jogador, a deteccao de Input eh feita em PlayerDoubleJump
    public void HandleDoubleJump(float doubleJumpForce)
    {
        Debug.Log("lidando com pulo duplo");
        velocity.y = Mathf.Sqrt(doubleJumpForce * -2f * gravity);


      
         controller.Move(velocity * Time.deltaTime);
    }

   //gerencia a aplicacao de forca do dash, a detecao de Input eh feita em PlayerDash
    public void HandleDash(float dashSpeed,float maxDashSpeed, Vector3 dashDirection, float dashTimeLeft, float dashDuration)
    {

        StartCoroutine(HandleDashIE(maxDashSpeed, dashDirection, dashDuration));
        lastDashTime = Time.time;

    }

    //corrotina que desativa gravidade enquanto jogador esta dando dash e move o personagem para frente
    public IEnumerator HandleDashIE(float dashSpeed, Vector3 dashDirection, float dashDuration)
    {
        //bloqueia controle do jogador durante o dash
        //Player.Instance.LockPlayer = true;

        isDashing = true;

        // Temporariamente desativa a gravidade
        float originalGravity = gravity;
        gravity = 0f;

        // Converte o dashDirection para o espaço local do jogador
        dashDirection = transform.TransformDirection(dashDirection);

        float dashTimeLeft = dashDuration;

        while (dashTimeLeft > 0)
        {
            // Move o personagem na direção do dash (considerando a rotação do jogador)
            controller.Move(dashDirection * dashSpeed * Time.deltaTime);

            // Reduz a duração do dash
            dashTimeLeft -= Time.deltaTime;

            // Desacelera a velocidade do dash ao longo do tempo
            dashSpeed = Mathf.Lerp(dashSpeed, 0f, 1 - (dashTimeLeft / dashDuration));

            yield return null;  // Espera o próximo frame
        }

        Debug.Log("Dash terminou");

        // Reativa a gravidade quando o dash termina
        gravity = originalGravity;
        isDashing = false;
        //restaura controle apos dash
        //Player.Instance.LockPlayer = false;
    }










    //inicia a corrotina de buffer do pulo base, chamado por PlayerBaseJump
    public void StartBaseJumpCorroutine(float maxJumpTime, float minJumpTime, float extraJumpForce)
    {
        jumpCoroutine = StartCoroutine(IncreaseJumpTime(maxJumpTime, minJumpTime, extraJumpForce));

    }

    //encerra a corrotina de buffer do pulo base, chamado por PlayerBaseJump
    public void StopBaseJumpCorroutine()
    {
        StopCoroutine(jumpCoroutine);
        jumpCoroutine = null;

    }

    //corrotina que controla a forca do salto do jogador baseado no tempo que a tecla se manteve pressionada
    IEnumerator IncreaseJumpTime( float maxJumpTime, float minJumpTime, float extraJumpForce)
    {
        bool hasAppliedExtraForce = false; // garante que a forca extra seja aplicada apenas uma vez

        while (jumpTimeCounter < maxJumpTime)
        {
            jumpTimeCounter += Time.deltaTime;

            // Aplica a forca de pulo adicional uma única vez quando o tempo de pulo ultrapassar minJumpTime
            if (jumpTimeCounter > minJumpTime && !hasAppliedExtraForce)
            {
                velocity.y += Mathf.Sqrt(extraJumpForce * -2f * gravity);
                hasAppliedExtraForce = true;

            }

            yield return null;
        }
    }
}
