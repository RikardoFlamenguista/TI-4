using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

//responsavel pelos metodos de destruir obstaculo, caso o jogador tenha pontos suficientes, e pelo feedback de falha, caso nao tenha
public class ObstacleDestroyer : MonoBehaviour
{
    public int requiredPoints;
    public GameObject obstacle;


    //chamado quando o Player usar Input de interacao em uma zona com layer "ObstacleDestroyer"
    public void DestroyObstacleRequest()
    {
        //caso o jogador tenha mais pontos do que o necessario, o obstaculo eh destruido, se nao, feedback de falha
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
