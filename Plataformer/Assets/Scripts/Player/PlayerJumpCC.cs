using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpCC : MonoBehaviour
{
    public float jumpForce = 5f; // Força do pulo
    public LayerMask groundLayer; // Layer do chão para detecção
    public float gravity = -20f; // Força da gravidade

    private CharacterController controller;
    private bool isGrounded;
    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;
    private Vector3 velocity;

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
        Jump();
    }

    void ApplyGravity()
    {
        // Verifica se o personagem está no chão
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f; // Reseta a velocidade vertical ao tocar no chão
        }

        // Aplica a gravidade
        velocity.y += gravity * Time.deltaTime;

        // Move o personagem com base na gravidade
        controller.Move(velocity * Time.deltaTime);
    }

    void Jump()
    {
        // Verifica se o personagem está no chão usando Raycast
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.2f, groundLayer);

        if (isGrounded && jumpBufferCounter > 0f)
        {
            // Zera a velocidade vertical antes de pular
            velocity.y = 0f;

            // Adiciona a força de pulo
            velocity.y += Mathf.Sqrt(jumpForce * -2f * gravity);

            // Aplica o movimento
            controller.Move(velocity * Time.deltaTime);

            // Reseta o contador do buffer de pulo
            jumpBufferCounter = 0f;
        }
    }
}
