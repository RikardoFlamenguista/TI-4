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

    // Alinha a rotação do personagem com a câmera
    void AlignRotationWithCamera()
    {
        // Obtem a rotaçao da câmera em torno do eixo Y apenas
        Vector3 cameraForward = mainCamera.transform.forward;
        cameraForward.y = 0f;

        if (cameraForward.magnitude > 0)
        {
            // Define a rotaçco do personagem para a direção da câmera
            transform.rotation = Quaternion.LookRotation(cameraForward);
        }
    }



    // Move o jogador com base nos eixos locais
    void Move()
    {
        // Cria um vetor de movimento com base nas entradas
    

      
    }

   
}
