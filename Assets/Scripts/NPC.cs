using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    private float resetWordspeed;
    public bool playerIsClose;
    bool isTyping;

    public bool hasGivenChips;
    Health health;

    public bool canGiveChips;


    public AudioSource interact;
    public AudioSource girltalk;

    public bool girlTalking;
    public bool interacting;
    public bool interacted;
    public bool talking;
    public bool finishedInteracting;

    //public List<AudioSource> HMMS;
    public List<AudioSource> HMMS = new List<AudioSource>();

    private void Start()
    {
        finishedInteracting = false;
        dialogueText = dialogueTextObject.GetComponent<TextMeshProUGUI>();
        chosenDialogue = dialogue;
        resetWordspeed = wordspeed;
    }

    // Update is called once per framee
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            talking = true;

           

            if (dialoguePanel.activeInHierarchy && !isTyping)
            {
                //zeroText();
                wordspeed = resetWordspeed;
                NextLine();
            }
            else if (dialoguePanel.activeInHierarchy && isTyping)
            {
                talking = false;
                wordspeed = 0.001f;
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }

            if (interacting)
            {
                if (!interacted)
                {
                  
                    interact.Play();
                    interacted = true;


                }    
                
            
            }

            if (interacted)
            {
              
                if (finishedInteracting)
                {
                    interacted = false;
                    finishedInteracting = false;
                }
                else
                {
                    return;
                }
            }


            if (girltalk)
            {
                if (talking)
                {
                    ActivateRandomHmms(Audio, Audio1, Audio2);

                }

                if (!talking)
                {
                    return;
                }
               
            }
        }

    }
    public AudioSource Audio;
    public AudioSource Audio1;
    public AudioSource Audio2;

    public void ActivateRandomHmms(AudioSource Audio, AudioSource Audio1, AudioSource Audio2)
    {
        if (HMMS.Count == 0) return;

        int randomIndex = Random.Range(0, HMMS.Count);

        HMMS[randomIndex].Play();

        HMMS.RemoveAt(randomIndex);
        
       
        if(HMMS.Count == 0)
        {
            HMMS.Add(Audio);
            HMMS.Add(Audio1);
            HMMS.Add(Audio2);
        }

    }

    public void zeroText()
    {
        finishedInteracting = true;
        StopAllCoroutines();
        dialogueText.text = ""; 
        isTyping = false;
        currentDialogue = string.Empty;
        index = 0;
        dialoguePanel.SetActive(false);
        interacted = false;
        talking = false;
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
        talking = true;
        
        if (index < chosenDialogue.Length -1)
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
