using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5f; // Força do pulo
    public LayerMask groundLayer; // Layer do chão para detecção
    private bool isGrounded;
    public bool jumpQueued;
    public float bufferRange = 1.4f; // Alcance do buffer de pulo

    private Rigidbody rb;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

        // Update is called once per frame
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
        Jump();
    }

    void Jump()
    {
        // Verifica se o personagem está no chão usando Raycast
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.2f, groundLayer);

        bool buffer = Physics.Raycast(transform.position, Vector3.down, bufferRange, groundLayer);

        if(isGrounded && jumpBufferCounter > 0f)
        {
            Vector3 velocity = rb.velocity;
            velocity.y = 0f;
            rb.velocity = velocity;

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpBufferCounter = 0f;
        }
        
      



        }


    }

