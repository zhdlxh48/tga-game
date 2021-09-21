using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YearObserver : MonoBehaviour
{
    public Text text;

    private PlayerAgeManager pam;

    private void Awake()
    {
        if (!text)
            text = GetComponent<Text>();

        pam = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAgeManager>();
    }

    private void Update()
    {
        if (text)
        {
            int age = pam.age + 1;
            text.text = age.ToString();
        }
    }
}
