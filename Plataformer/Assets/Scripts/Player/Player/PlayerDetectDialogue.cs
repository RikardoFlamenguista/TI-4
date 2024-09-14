using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controla a deteccao de areas e input para iniciar dialogo
public class PlayerDetectDialogue : MonoBehaviour
{
    public LayerMask dialogueLayer;

    public bool input = false;

    private Dialogue dialogue;

    void OnTriggerStay(Collider other)
    {
        if (((1 << other.gameObject.layer) & dialogueLayer) != 0)
        {

            if (input)
            {
                dialogue = other.gameObject.GetComponent<Dialogue>();
                dialogue.StartConversation();
                Debug.Log("dialogo encontrado");

                input = false;
            }
        }
    }

        void Start()
        {
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
            input = true;
            StartCoroutine(InputTime());
            }

        }

    //mantem o bool tivo por um segundo depois de input acontecer
    private IEnumerator InputTime()
    {
        yield return new WaitForSeconds(1);

        input = false;
    }
    
}
