using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public GameObject player;
    public GameObject choicePanel;
    public GameObject[] startStageList;

    private bool start = true;

    private void Awake()
    {
        //choicePanel.SetActive(true);
        //for (int i = 0; i < choicePanel.transform.childCount; ++i)
        //{
        //    choicePanel.transform.GetChild(i).GetComponentInChildren<Text>().text = startStageList[i].GetComponent<StageInfo>().StageName;
        //}
        //player.GetComponent<PlayerMovement>().isMove = false;

        player.GetComponent<PlayerAgeManager>().UpdateAgeAndPlayer(false);
    }

    public void UpdateStage(int index)
    {
        if (start)
            GetNextStageIndexToDoor(index);
        else
            StartChoice(index);
        start = true;
    }

    private void StartChoice(int index)
    {
        CreateNextStage(startStageList[index]);
        player.GetComponent<PlayerAgeManager>().UpdateAgeAndPlayer(false);
    }

    private void GetNextStageIndexToDoor(int index)
    {
        player.GetComponent<PlayerAgeManager>().UpdateAgeAndPlayer();
        GameObject nextStage = transform.GetChild(transform.childCount - 1).GetComponentInChildren<DoorManager>().nextStage[index];
        CreateNextStage(nextStage);
    }

    private void CreateNextStage(GameObject nextStage)
    {
        GameObject lastStage = transform.GetChild(transform.childCount - 1).gameObject;

        Vector2 pos = Vector2.zero;
        Debug.Log((nextStage.GetComponent<StageInfo>().GetStageSize().x / 2));
        pos.x = lastStage.transform.position.x + ((lastStage.GetComponent<StageInfo>().GetStageSize().x/2) + (nextStage.GetComponent<StageInfo>().GetStageSize().x / 2));
        pos.y = lastStage.transform.position.y;
        GameObject newStage = GameObject.Instantiate(nextStage, pos, Quaternion.identity, transform);
        newStage.GetComponentInChildren<DoorManager>().choiceCanvas = choicePanel;
        choicePanel.SetActive(false);
        player.GetComponent<PlayerMovement>().isMove = true;
    }
}
