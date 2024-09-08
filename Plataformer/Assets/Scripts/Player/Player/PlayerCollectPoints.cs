using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectPoints : MonoBehaviour
{
    public LayerMask pointLayer;

    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto está na layer "CollectiblePoint" usando LayerMask
        if (((1 << other.gameObject.layer) & pointLayer) != 0)
        {

            // Ação a ser realizada quando a colisão ocorre
            Collect(other.gameObject);
        }
    }

    // Método genérico de coleta
    void Collect(GameObject collectible)
    {
 collectible.SetActive(false);


    }
}
