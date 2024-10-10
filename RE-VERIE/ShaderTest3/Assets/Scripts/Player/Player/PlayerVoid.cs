using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controla a deteccao de void, ocorre quando jogador cai para fora do mapa
public class PlayerVoid : MonoBehaviour
{
    public LayerMask voidLayer;
    private Vector3 position;
    private Vector3 startingPosition;

    private CharacterController controller;


    public GameObject mainCamera;
    private Quaternion cameraRotation;
    private Vector3 cameraPosition;

    public GameObject originalAngle;
    public GameObject[] otherAngles;

    void Start()
    {
        startingPosition = transform.position;
    controller = GetComponent<CharacterController>();
        SaveCameraRotation();
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

            ResetCamera();
        }
    }

    //salva a posicao inicial da camera
    void SaveCameraRotation()
    {
        cameraPosition = mainCamera.transform.position;
         cameraRotation = mainCamera.transform.rotation;

    }

    //reseta camera para a posicao original e ativa reseta o cinemachine para o padrão
    //ta com erro, mudar posicao e rotacao direto da camera com cinemachine nao funciona, tenho q pesquisar como fazer -.- //
    private void ResetCamera()
    {
        mainCamera.transform.position = cameraPosition;
        mainCamera.transform.rotation = cameraRotation;

        originalAngle.SetActive(true);

        foreach (GameObject go in otherAngles) {
            go.SetActive(false);    
        
        }

    }

}
