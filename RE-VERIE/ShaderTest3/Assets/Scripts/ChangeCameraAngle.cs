using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraAngle : MonoBehaviour
{
    public GameObject originalAngle;
    public GameObject newAngle;




    public void ChangeCameras()
    {
        originalAngle.SetActive(false);
        newAngle.SetActive(true);

    }
}
