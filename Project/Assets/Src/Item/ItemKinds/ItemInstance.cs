using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstance : MonoBehaviour
{
    public PlayerPropertyDictionary playerProperty;
    public bool isNegative = false;
    public bool isHealthUp = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            PlayerParameter pp = col.gameObject.GetComponent<PlayerParameter>();
            foreach (KeyValuePair<Parameter, int> instance in playerProperty)
            {
                int parameter = pp.GetParameter(instance.Key);
                parameter += instance.Value;
                pp.SetParameter(instance.Key, parameter);
            }

            if (isNegative)
            {
                pp.SubHp();
            }

            if (isHealthUp)
            {
                pp.UpHp();
            }

            Destroy(gameObject);
        }
    }
}
