using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingSceneManager : MonoBehaviour
{
    public RectTransform PanelContentRect; // 스크롤 되는 오브젝트의 크기
    public GameObject ScenePanel; // 팝업 창
    public Image EndingImage; // 엔딩 이미지가 들어갈 오브젝트
    public Sprite EndingSprite; // 엔딩 이미지 파일
    public string SceneName; // 이동 할 SceneName 

    private FadeController fadeController;
    private float fadeTime;

    private void Awake()
    {
        EndingSprite = Resources.Load<Sprite>("일러스트/엔딩/" + ParameterManager.instance.currEnding);
    }

    // Start is called before the first frame update
    void Start()
    {
        fadeController = GameObject.Find("FadeImage").GetComponent<FadeController>(); // fadeController를 받아옴
        fadeTime = fadeController.fadeTime; // fadeController에 fadeTime을 위에서 선언한 fadeTime에 입력
        EndingImage.sprite = EndingSprite; // 엔딩에 나올 sprite 설정
        ScenePanel.SetActive(false); // 시작할 때 팝업 창 숨김
        SetEndingImageSize(); // 엔딩 ImageSize를 RectSize와 맞게 설정하는 부분
        SetPanelContectSize(); // 스크롤 되는 오브젝트의 size를 ImageSize와 맞게 설정
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(ScenePanel.activeSelf == true)
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

    void SceneChange()
    {
        gameObject.GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene(SceneName);
    }

    void SetEndingImageSize()
    {
        RectTransform rt = EndingImage.rectTransform;
        rt.sizeDelta = new Vector2(EndingSprite.rect.width, EndingSprite.rect.height);
    }

    void SetPanelContectSize()
    {
        PanelContentRect.sizeDelta = new Vector2(EndingSprite.rect.width, EndingSprite.rect.height);
    }
}
