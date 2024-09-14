using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//classe estatica, controla variaveis e metodos do player que precisam de acesso global
public class Player : MonoBehaviour
{

    public static Player Instance { get; private set; }
    public CharacterController controller;

    //distancia de verificacao dos raycast de pulo
    public float groundCheckDistance = 1.0f;
    public float groundCheckDoubleJumpDistance = 1.5f;

    //variavel que controla se jogador esta no chao
    private static bool isGrounded;
    public bool IsGrounded { get { return isGrounded; } set { isGrounded = value; } }

    //variavel que controla esta perto demais do chao para realizar double jump (buffer eh ativado ao inves disso)
    private bool isGroundedDoubleJump;
    public bool IsGroundedDoubleJump { get { return isGroundedDoubleJump; }  }

    //layer do chao usada pelos raycasts
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
     
        //metodos que usam raycast para verificar se o jogador esta no chao
        isGrounded = CheckIsGrounded();
        isGroundedDoubleJump = CheckGroundDoubleJump();
    }

    private bool CheckIsGrounded()
    {
        bool hit;

        hit = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);

        return hit;

    }


    private bool CheckGroundDoubleJump()
    {
        bool hit;

        hit = Physics.Raycast(transform.position, Vector3.down, groundCheckDoubleJumpDistance, groundLayer);

        return hit;

    }

   




    }
