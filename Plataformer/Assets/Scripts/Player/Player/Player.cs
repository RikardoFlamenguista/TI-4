using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player Instance { get; private set; }
    public CharacterController controller;

    public float groundCheckDistance = 1.5f;

    private static bool isGrounded;
    public bool IsGrounded { get { return isGrounded; } set { isGrounded = value; } }

    private bool isGroundedDoubleJump;
    public bool IsGroundedDoubleJump { get { return isGroundedDoubleJump; }  }

    //public float gravity = -20f; // Forca da gravidade
    //  public float Gravity { get { return gravity; } set { gravity = value; } }

    public Vector3 velocity;

    public LayerMask groundLayer;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            //eh pra destruir instance ou gameobject aqui? Nao lembro, conferir depois//
            Destroy(Instance);
            Debug.Log("Instancia ja existe, deletando");
        }

        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        //   isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.2f, groundLayer);

        isGrounded = controller.isGrounded;

        isGroundedDoubleJump = CheckGroundDoubleJump();
    }

    private bool CheckGroundDoubleJump()
    {
        bool hit;

        hit = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);

        return hit;

    }

   




    }
