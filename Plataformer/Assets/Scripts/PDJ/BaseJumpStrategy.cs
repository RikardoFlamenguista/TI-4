using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseJumpStrategy : IAirAction
{


    public float jumpForce = 20f; // Forca do pulo
    public float gravity = -20f; // Forca da gravidade

    private Vector3 velocity;

 
    public void HandleMove(GameObject go)
    {
        // Inicia o pulo e o contador de tempo de pulo
        velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);


     


        // Move o personagem com a forca aplicada
        Player.Instance.controller.Move(velocity * Time.deltaTime);
    }

    
        

    


  
}
