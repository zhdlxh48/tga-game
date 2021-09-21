using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterManager : MonoBehaviour
{
    public static ParameterManager instance = null;

    List<Dictionary<string, object>> csvData;

    public Dictionary<string, int> endingData = new Dictionary<string, int>();

    public string currEnding;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        csvData = CSVReader.ReadResource("EndingData");
        foreach (Dictionary<string, object> data in csvData)
        {
            endingData[(string)data["name"]] = 0;
        }

        List<Dictionary<string, object>> saveData = CSVReader.Read(Application.dataPath + "/Resources/SaveData.csv");
        if (saveData.Count > 0)
        {
            foreach (Dictionary<string, object> data in saveData)
            {
                endingData[(string)data["name"]] = (int)data["use"];
            }
        }
        else
            SaveData();

        DontDestroyOnLoad(gameObject);
    }

    public void UpdateData(PlayerParameter pp)
    {
        Dictionary<int, List<string>> reserve = new Dictionary<int, List<string>>();
        for (int i = 0; i <= 3; ++i)
        {
            reserve.Add(i, new List<string>());
        }

        foreach (Dictionary<string, object> line in csvData)
        {
            bool success = true;
            foreach (KeyValuePair<string, object> data in line)
            {
                int val = 0;
                switch (data.Key)
                {
                    case "force": val = pp.GetParameter(Parameter.Strong); break;
                    case "int": val = pp.GetParameter(Parameter.Intellect); break;
                    case "art": val = pp.GetParameter(Parameter.Art); break;
                    case "moral": val = pp.GetParameter(Parameter.Moral); break;
                    case "charisma": val = pp.GetParameter(Parameter.Charisma); break;
                    case "personality": val = pp.GetParameter(Parameter.Grace); break;
                    case "charm": val = pp.GetParameter(Parameter.Beauty); break;
                    case "faith": val = pp.GetParameter(Parameter.Faith); break;
                    default: continue;
                }

                if (val < (int)data.Value)
                {
                    success = false;
                    break;
                }
            }

            if (success)
            {
                reserve[(int)line["priority"]].Add((string)line["name"]);
            }
        }

        for (int i = 3; i >= 0; --i)
        {
            if (reserve[i].Count > 0)
            {
                currEnding = reserve[i][0];
                endingData[currEnding] = 1;
                break;
            }
        }

        SaveData();
    }

    public void SaveData()
    {
        string filePath = Application.dataPath + "/Resources/SaveData.csv";
        CSVWriter writer = new CSVWriter(filePath);

        List<string> columns = new List<string>() { "name", "use" };
        writer.WriteRow(columns);
        columns.Clear();

        foreach (KeyValuePair<string, int> pair in endingData)
        {
            columns.Add(pair.Key);
            columns.Add(pair.Value.ToString());
            writer.WriteRow(columns);
            columns.Clear();
        }

        writer.Dispose();
        writer.Close();
    }

    public void ResetSaveData()
    {
        endingData.Clear();
        foreach (Dictionary<string, object> data in csvData)
        {
            endingData[(string)data["name"]] = 0;
        }

        SaveData();
    }
}
