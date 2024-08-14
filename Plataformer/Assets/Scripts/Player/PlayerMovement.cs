using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float startingSpeed = 5f;
    public float maximumSpeed = 10f;
    public float acceleration = 1f;
    public float breakSpeed = 1f;

    private float currentSpeed; // Velocidade atual do personagem
    private Rigidbody rb;

    


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = startingSpeed; // Define a velocidade inicial como startingSpeed
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D ou Setas Esquerda/Direita
        float moveVertical = Input.GetAxis("Vertical");     // W/S ou Setas Cima/Baixo

        // Cria um vetor de movimento com base nas entradas
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement.magnitude > 0)
        {
            // Aumenta a velocidade atual até o limite de maximumSpeed
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Min(currentSpeed, maximumSpeed); // Garante que a velocidade não exceda o máximo

            // Move o personagem aplicando a velocidade atual
            rb.velocity = new Vector3(movement.x * currentSpeed, rb.velocity.y, movement.z * currentSpeed);
        }
        else
        {
            // Diminui a velocidade assim que o Input se encerra
            currentSpeed = breakSpeed + (currentSpeed / 10);
        }
    }

 
}
