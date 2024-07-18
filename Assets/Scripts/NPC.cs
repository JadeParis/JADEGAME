using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    public string currentDialogue;
    private int index;

    public float wordspeed;
    public bool playerIsClose;
    bool isTyping;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if(dialoguePanel.activeInHierarchy)
            {
                //zeroText();
                NextLine();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
    }

    public void zeroText()
    {
        StopAllCoroutines();
        dialogueText.text = ""; 
        isTyping = false;
        currentDialogue = string.Empty;
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        isTyping = true;
        while (isTyping)
        {
            foreach (char letter in dialogue[index].ToCharArray())
            {
                currentDialogue += letter;
                dialogueText.text = currentDialogue;
                yield return new WaitForSeconds(wordspeed);
            }
            isTyping = false;
        }
        currentDialogue = string.Empty;
    }

    public void NextLine()
    {
        if(index < dialogue.Length -1)
        {
            StopAllCoroutines();
            currentDialogue = string.Empty;
            isTyping = false;
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
