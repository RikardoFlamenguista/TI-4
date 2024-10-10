using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpStrategy : IAirAction
{
    private Vector3 velocity;
    public float doubleJumpForce = 12.5f;
    public float gravity = -60f;

    public void HandleMove()
    {
        velocity.y = Mathf.Sqrt(doubleJumpForce * -2f * gravity);



        Player.Instance.controller.Move(velocity * Time.deltaTime);


    }
    }
