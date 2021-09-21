using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    public GameObject choiceCanvas;

    void Start()
    {
        choiceCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collider Start");
        if (col.gameObject.tag == "Choice")
        {
            Debug.Log("Collision Door");
            choiceCanvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("충돌 해제");
        choiceCanvas.gameObject.SetActive(false);
    }

    
}
