using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInfo : MonoBehaviour
{
    [SerializeField]
    private string stageName;
    public string StageName { get { return stageName; } }

    [SerializeField]
    private GameObject background;

    [SerializeField]
    private GameObject door;

    private void Start()
    {
        //PlayerAgeManager pam = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAgeManager>();
        //if (pam.isAgeOver)
        //{
        //    door.SetActive(false);
        //}
    }

    public Vector2 GetStageSize()
    {
        Vector2 stageSize = Vector2.zero;
        for (int i = 0; i < background.transform.childCount; ++i)
        {
            SpriteRenderer sr = background.transform.GetChild(i).GetComponent<SpriteRenderer>();
            Vector2 spriteSize = sr.sprite.rect.size / sr.sprite.pixelsPerUnit;
            stageSize.x += spriteSize.x;
            stageSize.y = spriteSize.y;
        }
        return stageSize;
    }
}
