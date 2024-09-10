using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDialogue : MonoBehaviour
{
    public LayerMask dialogueLayer;

    public bool dialogueInput = false;

    private Dialogue dialogue;

    void OnTriggerStay(Collider other)
    {
        // Verifica se o objeto está na layer "CollectiblePoint" usando LayerMask
        if (((1 << other.gameObject.layer) & dialogueLayer) != 0)
        {

            // Ação a ser realizada quando a colisão ocorre
            if (dialogueInput)
            {
                dialogue = other.gameObject.GetComponent<Dialogue>();
                dialogue.StartConversation();
                Debug.Log("dialogo encontrado");

                dialogueInput = false;
            }
        }
    }
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogueInput = true;
            StartCoroutine(InputTime());
            }

        }

    private IEnumerator InputTime()
    {
        yield return new WaitForSeconds(1);

        dialogueInput = false;
    }
    
}
