using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashStrategy : MonoBehaviour, IAirAction
{
    public float dashSpeed = 10.0f;
    public float dashDuration = 0.3f;
    public float maxDashSpeed = 10.0f;

    private float dashTimeLeft;

    private bool isDashing = false;

    public void HandleMove()
    {

        StartCoroutine(HandleDashIE(maxDashSpeed, new Vector3(1.0f, 0.0f, 0.0f), dashDuration));
    }

    //corrotina que desativa gravidade enquanto jogador está dando dash e move o personagem para frente
    public IEnumerator HandleDashIE(float dashSpeed, Vector3 dashDirection, float dashDuration)
    {
        // Bloqueia controle do jogador durante o dash
        isDashing = true;

        // Temporariamente desativa a gravidade
        float originalGravity = GravityPDJTEMP.instance.gravity;
        GravityPDJTEMP.instance.gravity = 0f;

        // Converte o dashDirection para o espaço local do jogador
        dashDirection = transform.TransformDirection(dashDirection);

        dashTimeLeft = dashDuration;  // Usa a variável já declarada fora

        while (dashTimeLeft > 0)
        {
            // Move o personagem na direção do dash (considerando a rotação do jogador)
            Player.Instance.controller.Move(dashDirection * dashSpeed * Time.deltaTime);

            // Reduz a duração do dash
            dashTimeLeft -= Time.deltaTime;

            // Desacelera a velocidade do dash ao longo do tempo
            dashSpeed = Mathf.Lerp(dashSpeed, 0f, 1 - (dashTimeLeft / dashDuration));

            yield return null;  // Espera o próximo frame
        }

        Debug.Log("Dash terminou");

        // Reativa a gravidade quando o dash termina
        GravityPDJTEMP.instance.gravity = originalGravity;
        isDashing = false;
    }
}
