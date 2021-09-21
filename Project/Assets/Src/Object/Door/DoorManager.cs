using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{
    public GameObject choiceCanvas;

    public GameObject[] nextStage;

    public bool checkInDoor { get; set; }

    public string endingSceneName;

    private void Awake()
    {
        checkInDoor = false;
        //choiceCanvas = GameObject.FindGameObjectWithTag("ChoicePanel");
        //choiceCanvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (checkInDoor)
            return;

        if (collision.gameObject.tag == "Player")
        {
            PlayerAgeManager pam = collision.gameObject.GetComponent<PlayerAgeManager>();
            if (pam.isAgeOver)
            {
                SceneManager.LoadScene(endingSceneName);
            }
            else
            {
                choiceCanvas.gameObject.SetActive(true);

                for (int i = 0; i < choiceCanvas.transform.childCount; ++i)
                {
                    choiceCanvas.transform.GetChild(i).GetComponentInChildren<Text>().text = nextStage[i].GetComponent<StageInfo>().StageName;
                }

                PlayerMovement pm = collision.gameObject.GetComponent<PlayerMovement>();
                pm.isMove = false;
                checkInDoor = true;
            }
        }
    }
}
