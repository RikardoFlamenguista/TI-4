using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirHandle : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 velocity;
    public float gravity = -20f;

    private float jumpTimeCounter;

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

    private void ApplyGravity()
    {
        // Verifica se o personagem está no chão
        if (Player.Instance.IsGrounded && velocity.y < 0)
        {
            velocity.y = 0f; // Reseta a velocidade vertical ao tocar no chão
        }

        // Aplica a gravidade
        velocity.y += gravity * Time.deltaTime;

        // Move o personagem com base na gravidade
        controller.Move(velocity * Time.deltaTime);
    }




    public void HandleBaseJump(float jumpForce)
    {
        // Inicia o pulo e o contador de tempo de pulo
        velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);


        // Reseta o contador do buffer de pulo
        jumpTimeCounter = 0f;

      
        // Move o personagem com a forca aplicada
         controller.Move(velocity * Time.deltaTime);

    }

    public void HandleDoubleJump(float doubleJumpForce)
    {
        velocity.y = Mathf.Sqrt(doubleJumpForce * -2f * gravity);


      
         controller.Move(velocity * Time.deltaTime);
    }







    private bool isDashing = false;
    private float lastDashTime = -1f;
    public void HandleDash(float dashSpeed,float maxDashSpeed, Vector3 dashDirection, float dashTimeLeft, float dashDuration)
    {

        StartCoroutine(HandleDashIE(maxDashSpeed, dashDirection, dashDuration));
        lastDashTime = Time.time;

        /*controller.Move(dashDirection * dashSpeed * Time.deltaTime);
        dashTimeLeft -= Time.deltaTime;
        dashSpeed = Mathf.Lerp(maxDashSpeed, 0f, 1 - (dashTimeLeft / dashDuration));
        */





    }


    public IEnumerator HandleDashIE(float dashSpeed, Vector3 dashDirection, float dashDuration)
    {
        isDashing = true;

        // Temporariamente desativa a gravidade
        float originalGravity = gravity;
        gravity = 0f;

        float dashTimeLeft = dashDuration;

        while (dashTimeLeft > 0)
        {
            // Move o personagem na direção do dash
            controller.Move(dashDirection * dashSpeed * Time.deltaTime);

            // Reduz a duração do dash
            dashTimeLeft -= Time.deltaTime;

            // Desacelera a velocidade do dash ao longo do tempo
            dashSpeed = Mathf.Lerp(dashSpeed, 0f, 1 - (dashTimeLeft / dashDuration));

            yield return null;  // Espera o próximo frame
        }

        Debug.Log("codigo chegou aqui");
        // Reativa a gravidade quando o dash termina
        gravity = originalGravity;
        isDashing = false;
    }










    public void StartBaseJumpCorroutine(float maxJumpTime, float minJumpTime, float extraJumpForce)
    {
      //  Debug.Log("corrotina iniciada");
        jumpCoroutine = StartCoroutine(IncreaseJumpTime(maxJumpTime, minJumpTime, extraJumpForce));

    }

    public void StopBaseJumpCorroutine()
    {
      //  Debug.Log("corrotina encerrada");
        StopCoroutine(jumpCoroutine);
        jumpCoroutine = null;

    }

    IEnumerator IncreaseJumpTime( float maxJumpTime, float minJumpTime, float extraJumpForce)
    {
        bool hasAppliedExtraForce = false; // Flag para garantir que a forca extra seja aplicada apenas uma vez

        while (jumpTimeCounter < maxJumpTime)
        {
            jumpTimeCounter += Time.deltaTime;

            // Aplica a força de pulo adicional uma única vez quando o tempo de pulo ultrapassar minJumpTime
            if (jumpTimeCounter > minJumpTime && !hasAppliedExtraForce)
            {
                velocity.y += Mathf.Sqrt(extraJumpForce * -2f * gravity);
                hasAppliedExtraForce = true;

            }

            yield return null; // Espera até o próximo frame
        }
    }
}
