using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
 public static Subject Instance;



List<IObserver> observers = new List<IObserver>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);

    }

    public void NotifyAllObservers()
    {
        foreach (IObserver observer in observers)
        {
            observer.Notify();

        }

    }

}
