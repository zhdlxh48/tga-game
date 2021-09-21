using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParameterObserver : MonoBehaviour
{
    public Text text;
    public Parameter parameter;

    private PlayerParameter pp;

    private void Awake()
    {
        if (!text)
            text = GetComponent<Text>();

        pp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerParameter>();
    }

    private void Update()
    {
        if (text)
        {
            text.text = pp.GetParameter(parameter).ToString();
        }
    }
}
