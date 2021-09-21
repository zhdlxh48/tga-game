using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum NpcAttribute
{
    None,
    Success,
    Fail,
}

[Serializable]
public struct DataTrigger
{
    public int weight;
    public PlayerPropertyDictionary playerProperty;
    public GameObject icon;
}

public class NpcComponent : MonoBehaviour
{
    [SerializeField] public Animator anim;
    public NpcAttributeDictionary attribute;

    private bool useTrigger = false;

    private void Awake()
    {
        if (!anim) anim = GetComponent<Animator>();
    }

    public int GetTotalWeight()
    {
        int total = 0;
        foreach (KeyValuePair<NpcAttribute, DataTrigger> pair in attribute)
        {
            total += pair.Value.weight;
        }

        return total;
    }

    public NpcAttribute GetAttribute(int weight)
    {
        int curr = 0;
        foreach (KeyValuePair<NpcAttribute, DataTrigger> pair in attribute)
        {
            curr += pair.Value.weight;
            if (weight <= curr)
                return pair.Key;
        }
        return NpcAttribute.None;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!useTrigger)
            {
                if (Input.GetKey(KeyCode.Z))
                {
                    int range = UnityEngine.Random.Range(0, GetTotalWeight());
                    NpcAttribute na = GetAttribute(range);
                    switch (na)
                    {
                        case NpcAttribute.Fail: OnFail(); break;
                        case NpcAttribute.Success: OnSuccess(); break;
                    }
                    useTrigger = true;
                }
            }
        }
    }

    private void OnSuccess()
    {
        anim.SetTrigger("Success");
        attribute[NpcAttribute.Success].icon.SetActive(true);
    }

    private void OnFail()
    {
        anim.SetTrigger("Fail");
        attribute[NpcAttribute.Fail].icon.SetActive(true);
    }
}
