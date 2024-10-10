using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteFollowTarget : MonoBehaviour
{
    // Offset ajust�vel para o objeto em relacao a camera
    public Vector3 offset;

    private Transform cameraTransform;

    void Start()
    {
        // Obt�m a refer�ncia da Main Camera
        cameraTransform = Camera.main.transform;
    }

    void LateUpdate()
    {
        // Faz com que o objeto siga a camera com o offset ajust�vel
        transform.position = cameraTransform.position + offset;
    }




}
