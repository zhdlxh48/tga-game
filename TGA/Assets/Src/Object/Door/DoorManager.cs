using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{
    public GameObject choiceCanvas;

    public Image fadeImg;
    public float maxDist;

    public GameObject[] nextStage;

    public bool checkInDoor { get; set; }

    public string endingSceneName;

    private void Awake()
    {
        checkInDoor = false;
        //choiceCanvas = GameObject.FindGameObjectWithTag("ChoicePanel");
        //choiceCanvas.SetActive(false);
    }

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 playerPos = player.transform.position;
        Vector2 pos = transform.position;

        float currDist = Mathf.Abs(playerPos.x - pos.x);
        //Debug.Log(currDist);
        if (currDist <= maxDist)
        {
            float per = currDist / maxDist;
            //Debug.Log(per);
            Color color = fadeImg.color;
            color.a = 1.0f - per;
            fadeImg.color = color;
            //Debug.Log(fadeImg.color);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (checkInDoor)
            return;

        if (collision.gameObject.tag == "Player")
        {
            PlayerAgeManager pam = collision.gameObject.GetComponent<PlayerAgeManager>();
            if (pam.IsAgeOver())
            {
                SoundManager.instance.PlayBgm("EndingBgm");
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

                Vector2 playerPos = pm.transform.position;
                playerPos.x = transform.position.x;
                pm.rig.MovePosition(playerPos);
                checkInDoor = true;
            }
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        PlayerMovement pm = collision.gameObject.GetComponent<PlayerMovement>();
    //        if (transform.position.x == collision.gameObject.transform.position.x)
    //        {
    //            pm.isMove = false;
    //        }
    //    }
    //}
}
