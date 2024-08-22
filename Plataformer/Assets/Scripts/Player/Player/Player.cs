using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

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
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAA");
        }
    }

    public CharacterController controller;
    private static bool isGrounded;
    public bool IsGrounded { get { return isGrounded; } set { isGrounded = value; } }


    public float gravity = -20f; // Forca da gravidade
    public float Gravity {  get { return gravity; } set {  gravity = value; } }

    public Vector3 velocity;

    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
     //   isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.2f, groundLayer);

        isGrounded = controller.isGrounded;
    }
}
