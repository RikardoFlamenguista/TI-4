using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpCC : MonoBehaviour
{
    public float jumpForce = 5f; // For�a do pulo
    public float gravity = -20f; // For�a da gravidade

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    private CharacterController controller;
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
        // Verifica se o personagem est� no ch�o
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f; // Reseta a velocidade vertical ao tocar no ch�o
        }

        // Aplica a gravidade
        velocity.y += gravity * Time.deltaTime;

        // Move o personagem com base na gravidade
        controller.Move(velocity * Time.deltaTime);
    }

    void Jump()
    {
        // Se houver buffer de pulo e o personagem est� no ch�o
        if (controller.isGrounded && jumpBufferCounter > 0f)
        {
            // Adiciona a for�a de pulo
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);

            // Reseta o contador do buffer de pulo
            jumpBufferCounter = 0f;
        }
    }
}
