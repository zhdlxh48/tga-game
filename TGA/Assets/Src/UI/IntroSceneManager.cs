using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneManager : MonoBehaviour
{
    public GameObject ScenePanel; // 팝업 창
    public string SceneName; // 이동 할 SceneName

    private FadeController fadeController;
    private float fadeTime;

    // Start is called before the first frame update
    void Start()
    {
        fadeController = GameObject.Find("FadeImage").GetComponent<FadeController>(); // fadeController를 받아옴
        fadeTime = fadeController.fadeTime; // fadeController에 fadeTime을 위에서 선언한 fadeTime에 입력
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ScenePanel.activeSelf == true)
            {
                ScenePanel.SetActive(false);
            }
            else
            {
                ScenePanel.SetActive(true);
            }
        }
    }

    public void OnClickedYesButton()
    {
        Invoke("SceneChange", fadeTime);
    }

    public void OnClickedNoButton()
    {
        ScenePanel.SetActive(false);
    }

    public void OnClickedBackground()
    {
        ScenePanel.SetActive(true);
    }

    void SceneChange()
    {
        gameObject.GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene(SceneName);
    }
}
