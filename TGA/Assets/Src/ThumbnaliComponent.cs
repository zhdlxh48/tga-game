using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThumbnaliComponent : MonoBehaviour
{
    public bool isOpen = false;

    public Button bt;
    public Image img;

    public GameObject endingPanel;

    private void Awake()
    {
        if (bt)
            bt = GetComponent<Button>();

        if (img)
            img = GetComponent<Image>();
    }

    public void OnEndingPanel()
    {
        if (isOpen && !endingPanel.activeSelf)
        {
            endingPanel.GetComponent<Image>().sprite = img.sprite;
            endingPanel.SetActive(true);
        }
    }
}
