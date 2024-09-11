using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    public int requiredPoints;
    public GameObject obstacle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //chamado quando o Player usar Input de interacao em uma zona com layer "ObstacleDestroyer
    public void DestroyObstacleRequest()
    {

        if(GameController.Instance.CollectedPoints >= requiredPoints) 
        {
            DestroyObstacle();
        
        }

        else
        {
            DeniedFeedback();

        }

    }

    //logica para quando o jogador tem pontos suficientes para destruir o obstaculo
    public void DestroyObstacle()
    {
        GameController.Instance.CollectedPoints -= requiredPoints;
        obstacle.SetActive(false);
        GameController.Instance.RefreshCollectedPointsUI();

    }

    //logica de feedback para quando o jogador nao tiver pontos suficiente para liberar o obstaculo
    private void DeniedFeedback()
    {
        Debug.Log("pontos insuficientes :c");

    }



}
