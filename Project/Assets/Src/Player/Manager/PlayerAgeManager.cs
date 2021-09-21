using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAgeManager : MonoBehaviour
{
    public int age
    {
        get;
        private set;
    }

    public int maxAge;

    public bool isAgeOver
    {
        get { return age > maxAge ? true : false; }
    }

    public int currIndex
    {
        get;
        private set;
    }

    public PlayerStateManager psm;
    public CapsuleCollider2D cc;

    public GameObject[] player;

    private void Awake()
    {
        age = 0;
        currIndex = -1;
    }

    public void UpdateAgeAndPlayer(bool upage = true)
    {
        if (upage)
            age++;
        //Debug.Log(age);

        int nextindex = age / 3;
        GameObject thisPlayer = player[nextindex];
        if (nextindex > player.Length)
            return;

        if (nextindex > currIndex)
        {
            Vector2 pos = transform.position;
            pos.y = thisPlayer.transform.position.y;
            GetComponent<Rigidbody2D>().MovePosition(pos);
        }

        foreach (GameObject p in player)
        {
            p.SetActive(false);
        }

        //thisPlayer.SetActive(true);
        cc.size = thisPlayer.GetComponent<CapsuleCollider2D>().size;

        Vector2 offset = thisPlayer.GetComponent<CapsuleCollider2D>().offset;
        //offset.y += cc.size.y / 2;
        cc.offset = offset;

        psm.anim.runtimeAnimatorController = thisPlayer.GetComponent<Animator>().runtimeAnimatorController;
        currIndex = nextindex;
    }
}