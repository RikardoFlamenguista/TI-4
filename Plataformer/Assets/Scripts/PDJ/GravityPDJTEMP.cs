using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPDJTEMP : MonoBehaviour
{
    private Vector3 velocity;
    public float gravity = -20f;

    // Update is called once per frame
    void Update()
    {
        ApplyGravity();
    }

    //aplica gravidade no jogador
    private void ApplyGravity()
    {
        if (Player.Instance.IsGrounded && velocity.y < 0)
        {
            velocity.y = 0.01f;
        }

        velocity.y += gravity * Time.deltaTime;

        Player.Instance.controller.Move(velocity * Time.deltaTime);
    }
}
