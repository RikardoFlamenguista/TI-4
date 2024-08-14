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



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

        // Update is called once per frame
        void Update()
    {
        Jump();
    }

    void Jump()
    {
        // Verifica se o personagem está no chão usando Raycast
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.2f, groundLayer);

        bool buffer = Physics.Raycast(transform.position, Vector3.down, bufferRange, groundLayer);

        // Se houver buffer e a barra de espaço for pressionada, coloca o pulo na fila
        if (buffer && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("buffer");
            jumpQueued = true;
        }

        if (isGrounded)
        {
            // Se estiver no chão ou o pulo estiver na fila, realiza o pulo
            if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
            {
                Debug.Log("pulo");
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumpQueued = false;
            }

            else if (jumpQueued && rb.velocity.y == 0)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumpQueued = false;
            }



        }


    }
}
