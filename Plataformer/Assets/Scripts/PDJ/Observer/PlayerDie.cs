using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    private Vector3 startingPosition;
    public LayerMask killerLayer;

    private CharacterController controller;

    private void Start()
    {
        startingPosition = transform.position;
        controller = GetComponent<CharacterController>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & killerLayer) != 0)
        {

            controller.enabled = false;

            transform.position = startingPosition;
            transform.rotation = Quaternion.Euler(0, 0, 0);


            controller.enabled = true;

          
        }
    }
}
