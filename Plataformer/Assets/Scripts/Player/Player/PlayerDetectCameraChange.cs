using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerDetectCameraChange : MonoBehaviour
{
    public LayerMask cameraLayer;
    private ChangeCameraAngle changeCameraAngle;


    void OnTriggerStay(Collider other)
    {
        if (((1 << other.gameObject.layer) & cameraLayer) != 0)
        {


            changeCameraAngle = other.gameObject.GetComponent<ChangeCameraAngle>();
            changeCameraAngle.ChangeCameras();

      
            }
        }
    }


  

