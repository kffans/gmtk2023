using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public GameObject DisplayTextObject;

    public void Start()
    {
        StartCoroutine(ShowTextAfterDelay());
    }

    public IEnumerator ShowTextAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        DisplayText.ChangeDisplayText("Tekst po 30 sekundach!");
    }
}