using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float textTime;
    public GameObject dialogueBox;

    private int index;

    private string[] lines;

    private bool dialogueGoing = false;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        dialogueBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueGoing){


        
        {
            
        }
            if (Input.GetMouseButtonDown(0))
            {
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        }
    }

    //chamado por Dialogue quando deseja comecar uma conversa, recebe do outro script quais palavras serao escritas
   public void StartDialogue(string[] lines)
    {
        this.lines = lines;
        dialogueBox.SetActive(true);
        index = 0;
        dialogueGoing = true;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textTime);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            index = 0;
            lines = null;
            dialogueGoing = false;
            textComponent.text = string.Empty;
            dialogueBox.SetActive(false);
        }
    }
}
