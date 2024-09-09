using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectPoints : MonoBehaviour
{
    public LayerMask pointLayer;
    public LayerMask victoryLayer;

    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto está na layer "CollectiblePoint" usando LayerMask
        if (((1 << other.gameObject.layer) & pointLayer) != 0)
        {

            // Ação a ser realizada quando a colisão ocorre
            Collect(other.gameObject);
        }

        // Verifica se o objeto está na layer "CollectiblePoint" usando LayerMask
        if (((1 << other.gameObject.layer) & victoryLayer) != 0)
        {

            // Ação a ser realizada quando a colisão ocorre
            Victory(other.gameObject);
            
        }
    }

    private void Update()
    {
        



    }

    // Método genérico de coleta
    private void Collect(GameObject collectible)
    {
 collectible.SetActive(false);

        GameController.Instance.CollectPoint();
    }

    private void Victory(GameObject victoryGO)
    {
        victoryGO.SetActive(false);


        GameController.Instance.Victory();

    }
}
