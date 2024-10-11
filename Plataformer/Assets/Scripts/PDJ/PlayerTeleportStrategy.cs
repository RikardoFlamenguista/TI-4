using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportStrategy : IAirAction
{
    public float teleportRange = 20f;

    public void HandleMove(GameObject go)
    {
        Debug.Log("dashStrategy");

        // Usa a direção para frente baseada na rotação do jogador
        Vector3 forwardDirection = go.transform.forward;

        Player.Instance.controller.Move((forwardDirection + new Vector3(0.0f,0.05f,0.0f)) * teleportRange);

        // Teleporta o jogador para frente
        go.transform.position += forwardDirection * teleportRange;
    }
}
