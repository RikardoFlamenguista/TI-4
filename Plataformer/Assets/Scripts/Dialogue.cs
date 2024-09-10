using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string[] lines;
    public GameObject dialogueManagerGO;

    private DialogueManager dialogueM;

    // Start is called before the first frame update
    void Start()
    {
        dialogueM= dialogueManagerGO.GetComponent<DialogueManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //chama o dialogue manager quando deseja comecar uma conversa, dessa forma se pode ter varios GameObject com dialogue pela cena, mas so 1 Dialogue Manager para controlar a caixa de texto
    public void StartConversation()
    {
        Debug.Log("dialogo");
        dialogueM.StartDialogue(lines);

    }
}
