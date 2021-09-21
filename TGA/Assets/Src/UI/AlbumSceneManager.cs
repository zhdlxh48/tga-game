using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AlbumSceneManager : MonoBehaviour
{
    //
    public GameObject EndingPanel;
    public Transform content;
    public GameObject thumbnaliPrefeb;

    private List<GameObject> thumbnaliList = new List<GameObject>();
    //

    public string SceneName; // 이동 할 SceneName 


    void Start()
    {
        EndingPanel.SetActive(false);

        Dictionary<string, int> list = ParameterManager.instance.endingData;
        foreach (KeyValuePair<string, int> pair in list)
        {
            GameObject copy = GameObject.Instantiate(thumbnaliPrefeb, transform.position, Quaternion.identity, content);

            string imgPath = "일러스트/";
            if (pair.Value == 0)
            {
                copy.GetComponent<ThumbnaliComponent>().isOpen = false;
                imgPath += "실루엣/" + pair.Key + "_silhouette";
            }
            else if (pair.Value == 1)
            {
                copy.GetComponent<ThumbnaliComponent>().isOpen = true;
                imgPath += pair.Key;
            }
            copy.GetComponent<ThumbnaliComponent>().endingPanel = EndingPanel;

            copy.GetComponent<Image>().sprite = Resources.Load<Sprite>(imgPath);

            thumbnaliList.Add(copy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(EndingPanel.activeSelf == true)
            {
                EndingPanel.SetActive(false);
            }
        }
    }


    public void OnClickedBackButton()
    {
        if(EndingPanel.activeSelf == true)
        {
            EndingPanel.SetActive(false);
        }
        else
        {
            //Invoke("SceneChange", fadeTime);
            SceneChange();
        }
    }

    public void OnClickedResetButton()
    {
        if (EndingPanel.activeSelf)
            return;

        ParameterManager.instance.ResetSaveData();

        int i = 0;
        Dictionary<string, int> list = ParameterManager.instance.endingData;
        foreach (KeyValuePair<string, int> pair in list)
        {
            string imgPath = "일러스트/";
            if (pair.Value == 0)
            {
                thumbnaliList[i].GetComponent<ThumbnaliComponent>().isOpen = false;
                imgPath += "실루엣/" + pair.Key + "_silhouette";
            }
            else if (pair.Value == 1)
            {
                thumbnaliList[i].GetComponent<ThumbnaliComponent>().isOpen = true;
                imgPath += pair.Key;
            }
            thumbnaliList[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(imgPath);
           
            i++;
        }
    }

    void SceneChange()
    {
        gameObject.GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene(SceneName);
    }
}
