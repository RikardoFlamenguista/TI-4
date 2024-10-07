using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseJumpStrategy : IAirAction
{
    public float jumpForce = 20f; // Forca do pulo
    public float extraJumpForce = 0.6f; // Força adicional após minJumpTime
    public float gravity = -20f; // Forca da gravidade
    public float maxJumpTime = 0.2f; // Tempo máximo que o pulo pode ser sustentado
    public float minJumpTime = 0.15f; // Tempo mínimo para adicionar extraJumpForce


    private Vector3 velocity;
    private float jumpTimeCounter;
    private Coroutine jumpCoroutine;



    public void HandleMove()
    {
        Debug.Log("pulando");
      


        // Inicia o pulo e o contador de tempo de pulo
        velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);


        // Reseta o contador do buffer de pulo
        jumpTimeCounter = 0f;


        // Move o personagem com a forca aplicada
        Player.Instance.controller.Move(velocity * Time.deltaTime);
    }

    
        

    


  
}
