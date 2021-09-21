using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinsManager : MonoBehaviour
{
    private PlayerAgeManager pam;

    [SerializeField]
    private int maxWeight;

    [SerializeField]
    private int useWeight;

    [SerializeField] private GameObject[] prinsList;

    private void Awake()
    {
        if (!pam)
            pam = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAgeManager>();

        int range = UnityEngine.Random.Range(0, maxWeight);
        if (useWeight >= range)
        {
            int index = pam.age / 3;
            prinsList[index].SetActive(true);
        }
    }

    //private void Update()
    //{
    //    int index = pam.age / 3;

    //}
}
