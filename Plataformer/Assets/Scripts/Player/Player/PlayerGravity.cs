using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    private PlayerJumpCC jumpScript;
    private bool isGrounded;

    public float gravity = -20f; // Força da gravidade
    private void Start()
    {
    

        jumpScript = GetComponent<PlayerJumpCC>();
    }

    void Update()
    {


        ApplyGravity();
    }

    void ApplyGravity()
    {
        // Verifica se o personagem está no chão
        isGrounded = Player.Instance.controller.isGrounded;

        if (
           isGrounded && Player.Instance.velocity.y < 0)
        {
            Player.Instance.velocity.y = 0f; // Reseta a velocidade vertical ao tocar no chão

        }

        // Aplica a gravidade

        Player.Instance.velocity.y += Player.Instance.Gravity * Time.deltaTime;

        // Move o personagem com base na gravidade
        Player.Instance.controller.Move(Player.Instance.velocity * Time.deltaTime);
    }
}
