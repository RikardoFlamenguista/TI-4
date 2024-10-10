using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controla a deteccao de areas e input para destuir obstaculos
public class PlayerDetectObstacleDestroyer : MonoBehaviour
{
    public LayerMask obstacleDestroyerLayer;

    public bool input = false;

    private ObstacleDestroyer obstacleDestroyer;

    void OnTriggerStay(Collider other)
    {
        if (((1 << other.gameObject.layer) & obstacleDestroyerLayer) != 0)
        {

            if (input)
            {
                obstacleDestroyer = other.gameObject.GetComponent<ObstacleDestroyer>();
                obstacleDestroyer.DestroyObstacleRequest();

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

    //mantem o bool tivo por um segundo depois de input acontecer
    private IEnumerator InputTime()
    {
        yield return new WaitForSeconds(1);

        input = false;
    }
}
