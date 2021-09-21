using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParameterUIManager : MonoBehaviour
{
    [SerializeField]
    private List<Text> parameters;
    private PlayerParameter pp;

    private void Awake()
    {
        pp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerParameter>();
    }

    private void Update()
    {
        foreach (Text t in parameters)
        {
            switch (t.gameObject.name)
            {
                //case "Health": t.text = "Health : " + pp.GetParameter(Parameter.Health); break;
                case "Stress": t.text = "Stress : " + pp.GetParameter(Parameter.Stress); break;
                case "Strong": t.text = "Strong : " + pp.GetParameter(Parameter.Strong); break;
                case "Intellect": t.text = "Intellect : " + pp.GetParameter(Parameter.Intellect); break;
                case "Moral": t.text = "Moral : " + pp.GetParameter(Parameter.Moral); break;
                case "Charisma": t.text = "Charisma : " + pp.GetParameter(Parameter.Charisma); break;
                case "Grace": t.text = "Grace : " + pp.GetParameter(Parameter.Grace); break;
                case "Art": t.text = "Art : " + pp.GetParameter(Parameter.Art); break;
                case "Beauty": t.text = "Beauty : " + pp.GetParameter(Parameter.Beauty); break;
                case "Faith": t.text = "Faith : " + pp.GetParameter(Parameter.Faith); break;
                case "Gold": t.text = "Gold : " + pp.GetParameter(Parameter.Gold); break;
            }
        }
    }
}
