using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectObstacleDestroyer : MonoBehaviour
{
    public LayerMask obstacleDestroyerLayer;

    public bool input = false;

    private ObstacleDestroyer obstacleDestroyer;

    void OnTriggerStay(Collider other)
    {
        // Verifica se o objeto está na layer "CollectiblePoint" usando LayerMask
        if (((1 << other.gameObject.layer) & obstacleDestroyerLayer) != 0)
        {

            // Ação a ser realizada quando a colisão ocorre
            if (input)
            {
                obstacleDestroyer = other.gameObject.GetComponent<ObstacleDestroyer>();
                obstacleDestroyer.DestroyObstacleRequest();
                Debug.Log("dialogo encontrado");

                input = false;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            input = true;
            StartCoroutine(InputTime());
        }

    }

    private IEnumerator InputTime()
    {
        yield return new WaitForSeconds(1);

        input = false;
    }
}
