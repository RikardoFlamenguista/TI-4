using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controla a deteccao de void, ocorre quando jogador cai para fora do mapa
public class PlayerVoid : MonoBehaviour
{
    public LayerMask voidLayer;
    public Vector3 position;
    public Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        position = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & voidLayer) != 0)
        {
            Debug.Log("Colisão detectada com o void.");
            transform.position = startingPosition;
        }
    }
}
