using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] hpList;

    private PlayerParameter pp;

    private void Awake()
    {
        pp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerParameter>();
    }

    private void Update()
    {
        foreach (GameObject obj in hpList)
        {
            obj.SetActive(false);
        }

        for (int i = 0; i < pp.currHp; ++i)
        {
            hpList[i].SetActive(true);
        }
    }
}
