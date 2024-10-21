using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CutsceneFinish : MonoBehaviour
{
    public UnityEvent finishedEvent;

    public void Finished()
    {
        gameObject.SetActive(false);
        finishedEvent.Invoke();
    }
}
