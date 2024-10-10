using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controla a deteccao de pontos e objetivo de vitoria
public class PlayerCollectPoints : MonoBehaviour
{
    public LayerMask pointLayer;
    public LayerMask victoryLayer;

    void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & pointLayer) != 0)
        {
            Collect(other.gameObject);
       
        }

        if (((1 << other.gameObject.layer) & victoryLayer) != 0)
        {
            Victory(other.gameObject);
            
        }
    }

    //chama o metodo que controla a coleta de pontos no GameController
    private void Collect(GameObject collectible)
    {
 collectible.SetActive(false);

        GameController.Instance.CollectPoint();
    }

    //chama o metodo que controla a vitoria de pontos no GameController
    private void Victory(GameObject victoryGO)
    {
        victoryGO.SetActive(false);


        GameController.Instance.Victory();

    }
}
