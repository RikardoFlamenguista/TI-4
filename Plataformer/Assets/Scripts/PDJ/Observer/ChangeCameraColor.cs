using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraColor : MonoBehaviour, IObserver
{
    public Color[] colors;
    Camera cam;

    private int currentColor = 1;

    private void Start()
    {
        Subject.Instance.AddObserver(this);

cam = GetComponent<Camera>();
        cam.backgroundColor = colors[currentColor];


    }


    public void Notify()
    {
        if(currentColor == 1) currentColor = 0;
        else if (currentColor == 0) currentColor = 1;

        cam.backgroundColor = colors[currentColor];

    }
}
