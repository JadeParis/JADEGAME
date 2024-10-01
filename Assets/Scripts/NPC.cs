using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject dialogueTextObject;
    private TextMeshProUGUI dialogueText;

    public string[] chosenDialogue;

    public string[] dialogue;
    public string[] alternateDialogue;

    public string currentDialogue;
    private int index;

    public float wordspeed;
    public bool playerIsClose;
    bool isTyping;

    public bool hasGivenChips;
    Health health;

    public bool canGiveChips;

    private void Start()
    {
        dialogueText = dialogueTextObject.GetComponent<TextMeshProUGUI>();
        chosenDialogue = dialogue;
    }

    // Update is called once per framee
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

        chosenDialogue = alternateDialogue;

    }

    IEnumerator Typing()
    {
        isTyping = true;
        while (isTyping)
        {
            foreach (char letter in chosenDialogue[index].ToCharArray())
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
        if(index < chosenDialogue.Length -1)
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

            if (!hasGivenChips && canGiveChips)
            {
                Debug.Log("chips!");
                health.GainHealth();
                hasGivenChips = true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            health = other.GetComponent<Health>();
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
