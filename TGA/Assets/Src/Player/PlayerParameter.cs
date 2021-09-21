using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Parameter
{
    //Health = 0,
    Stress,
    Strong,
    Intellect,
    Moral,
    Charisma,
    Grace,
    Art,
    Beauty,
    Faith,
    Gold,
    EndParameter, // 파라메터의 끝을 명시하기 위한 선언, 실제 파라메터는 아니다
}

public class PlayerParameter : MonoBehaviour
{
    private Dictionary<Parameter, int> parameter = new Dictionary<Parameter, int>();

    [SerializeField]
    private int maxHp;

    [HideInInspector]
    public int currHp;

    [SerializeField]
    private int allDesc;

    private void Awake()
    {
        for (int i = 0; i < (int)Parameter.EndParameter; ++i)
        {
            parameter[(Parameter)i] = 0;
        }

        currHp = maxHp;

        //parameter[Parameter.Health] = maxHp;
    }

    public int GetParameter(Parameter p)
    {
        return parameter[p];
    }

    public void SetParameter(Parameter p, int val)
    {
        parameter[p] = val;
    }

    public void AllDecrease()
    {
        for (int i = 0; i < (int)Parameter.EndParameter; ++i)
        {
            parameter[(Parameter)i] -= allDesc;
            if (parameter[(Parameter)i] <= 0)
                parameter[(Parameter)i] = 0;
        }
    }

    public void SubHp()
    {
        currHp -= 1;
        if (currHp <= 0)
        {
            AllDecrease();
            currHp = maxHp;
        }
    }

    public void UpHp()
    {
        currHp += 1;
        if (currHp > maxHp)
            currHp = maxHp;
    }

    private void OnDestroy()
    {
        ParameterManager manager = ParameterManager.instance;
        if(manager)
            manager.UpdateData(this);
        //GameObject.FindGameObjectWithTag("ParameterManager").GetComponent<ParameterManager>().UpdateData(this);
    }

    //private void Update()
    //{
    //    //if (parameter[Parameter.Health] <= 0)
    //    //{

    //    //}
    //}

    //public int health { get; set; }
    //public int stress { get; set; }
    //public int strong { get; set; }
    //public int intellect { get; set; }
    //public int moral { get; set; }
    //public int charisma { get; set; }
    //public int grace { get; set; }
    //public int art { get; set; }
    //public int beauty { get; set; }
    //public int faith { get; set; }
    //public int gold { get; set; }

    //private void Awake()
    //{
    //    health = 0;
    //    stress = 0;
    //    strong = 0;
    //    intellect = 0;
    //    moral = 0;
    //    charisma = 0;
    //    grace = 0;
    //    art = 0;
    //    beauty = 0;
    //    faith = 0;
    //    gold = 0;
    //}
}
