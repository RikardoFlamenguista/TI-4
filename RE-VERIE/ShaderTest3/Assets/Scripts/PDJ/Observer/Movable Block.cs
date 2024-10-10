using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBlock : MonoBehaviour, IObserver
{

    public bool visibility;
public Material[] materials;


    // Distância máxima de deslocamento no eixo X
    public float moveDistance = 5f;

    // Velocidade do movimento
    public float moveSpeed = 2f;

    // Posição inicial
    private Vector3 startPosition;

    MeshRenderer mesh;

    void Start()
    {
        Subject.Instance.AddObserver(this);


        // Salva a posição inicial do objeto
        startPosition = transform.position;

        int luck = Random.Range(0, 2);


        mesh = GetComponent<MeshRenderer>();
        mesh.material = materials[luck];
        
        if (luck == 1)
        {
            visibility = true;
        
        }
        if (luck == 0)
        {
            visibility = false;
        ChangeVisibility();
        
        }
        

    }

    private void ChangeVisibility()
    {
        if(visibility == false) { 
        
        mesh.enabled = false;
        }

        else
        {
            mesh.enabled = true;

        }

    }

    void Update()
    {
        
        // Calcula a nova posição usando uma função senoidal para fazer o movimento de vai e vem
        float offset = Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        // Aplica o deslocamento no eixo X, mantendo as posições Y e Z constantes
        transform.position = new Vector3(startPosition.x + offset, startPosition.y, startPosition.z);
    


        
        


        

    }


    public void Notify()
    {
        visibility = !visibility;

        ChangeVisibility();


    }
}
