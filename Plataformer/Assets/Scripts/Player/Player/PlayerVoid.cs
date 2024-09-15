using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controla a deteccao de void, ocorre quando jogador cai para fora do mapa
public class PlayerVoid : MonoBehaviour
{
    public LayerMask voidLayer;
    public Vector3 position;
    public Vector3 startingPosition;

    private CharacterController controller;

    void Start()
    {
        startingPosition = transform.position;
    controller = GetComponent<CharacterController>();   
    }

    private void Update()
    {
        position = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & voidLayer) != 0)
        {
            controller.enabled = false;

            transform.position = startingPosition;
         
            controller.enabled = true;
        }
    }
}
