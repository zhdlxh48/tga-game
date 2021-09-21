using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public ItemPropertyDictionary itemProperty;

    private void Start()
    {
        int total = 0;
        foreach (KeyValuePair<GameObject, int> weight in itemProperty)
        {
            total += weight.Value;
        }

        int range = Random.Range(0, total);
        int index = 0;
        foreach (KeyValuePair<GameObject, int> weight in itemProperty)
        {
            index += weight.Value;
            if (index > range)
            {
                GameObject.Instantiate(weight.Key, transform.position, Quaternion.identity, transform.parent);
                break;
            }
        }

        GameObject.Destroy(gameObject);
    }
}