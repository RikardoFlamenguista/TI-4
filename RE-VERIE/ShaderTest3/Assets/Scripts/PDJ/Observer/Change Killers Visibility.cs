using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeKillersVisibility : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Subject.Instance.NotifyAllObservers();


        }
    }
}
