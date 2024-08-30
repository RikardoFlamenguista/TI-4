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

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ApplyGravity();

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
        velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);


        jumpTimeCounter = 0f;

        controller.Move(velocity * Time.deltaTime);

    }

    public void StartBaseJumpCorrotine(float maxJumpTime, float minJumpTime, float extraJumpForce)
    {
        jumpCoroutine = StartCoroutine(IncreaseJumpTime(maxJumpTime, minJumpTime, extraJumpForce));

    }

    public void StopBaseJumpCorrotine()
    {
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
