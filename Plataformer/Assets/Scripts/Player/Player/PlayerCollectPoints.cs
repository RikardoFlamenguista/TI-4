using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectPoints : MonoBehaviour
{
    public LayerMask pointLayer;
    public LayerMask victoryLayer;

    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto est� na layer "CollectiblePoint" usando LayerMask
        if (((1 << other.gameObject.layer) & pointLayer) != 0)
        {

            // A��o a ser realizada quando a colis�o ocorre
            Collect(other.gameObject);
        }

        // Verifica se o objeto est� na layer "CollectiblePoint" usando LayerMask
        if (((1 << other.gameObject.layer) & victoryLayer) != 0)
        {

            // A��o a ser realizada quando a colis�o ocorre
            Victory(other.gameObject);
            
        }
    }

    private void Update()
    {
        



    }

    // M�todo gen�rico de coleta
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
