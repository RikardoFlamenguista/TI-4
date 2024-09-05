using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectPoints : MonoBehaviour
{
    public LayerMask pointLayer;

    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto est� na layer "CollectiblePoint" usando LayerMask
        if (((1 << other.gameObject.layer) & pointLayer) != 0)
        {
            Debug.Log("Colet�vel detectado: " + other.gameObject.name);

            // A��o a ser realizada quando a colis�o ocorre
            Collect(other.gameObject);
        }
    }

    // M�todo gen�rico de coleta
    void Collect(GameObject collectible)
    {
 collectible.SetActive(false);


    }
}
