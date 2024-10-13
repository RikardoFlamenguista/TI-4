using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotatePDJ : MonoBehaviour
{
   

    public GameObject mainCamera;

    private CharacterController controller;

    private bool speedBoost;
    public float speedBoostForce = 2;

    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    void Update()
    {
        //se nao tem nada que impede o movimento, o metodo eh chamado
        if (!Player.Instance.LockPlayer) Move();
        AlignRotationWithCamera();

      

    }

    // Alinha a rota��o do personagem com a c�mera
    void AlignRotationWithCamera()
    {
        // Obtem a rota�ao da c�mera em torno do eixo Y apenas
        Vector3 cameraForward = mainCamera.transform.forward;
        cameraForward.y = 0f;

        if (cameraForward.magnitude > 0)
        {
            // Define a rota�co do personagem para a dire��o da c�mera
            transform.rotation = Quaternion.LookRotation(cameraForward);
        }
    }



    // Move o jogador com base nos eixos locais
    void Move()
    {
        // Cria um vetor de movimento com base nas entradas
    

      
    }

   
}
