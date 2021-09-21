using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    public GameObject PopupPanel;
    public Slider BgmVolume;
    public Slider SfxVolume;
    public AudioSource backGroundMusic;
    public AudioSource[] sfxSounds;
    public Sprite SoundSprite;
    public Sprite muteSprite;
    public string SceneName; // 이동 할 SceneName 
    public FadeController fadeController;
    //public AlbumSceneManager albumSceneManager;

    private Image BgmButton;
    private Image SfxButton;

    private float bgmVol = 1.0f;
    private float sfxVol = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        BgmButton = GameObject.Find("BgmBtn").GetComponent<Image>();
        SfxButton = GameObject.Find("SfxBtn").GetComponent<Image>();

        PopupPanel.SetActive(false);

        BgmVolume.value = bgmVol;
        backGroundMusic.volume = BgmVolume.value;
        SfxVolume.value = sfxVol;
        for(int i = 0; i < sfxSounds.Length; i++)
        {
            sfxSounds[i].volume = SfxVolume.value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SoundSlider();
        //Debug.Log(backGroundMusic.volume);
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PopupPanel.SetActive(false);
        }

        if(BgmVolume.value == 0.0f)
            BgmButton.sprite = muteSprite;
        else
            BgmButton.sprite = SoundSprite;

        if (SfxVolume.value == 0.0f)
            SfxButton.sprite = muteSprite;
        else
            SfxButton.sprite = SoundSprite;
    }

    public void SoundSlider()
    {
        backGroundMusic.volume = BgmVolume.value;
        bgmVol = BgmVolume.value;

        for (int i = 0; i < sfxSounds.Length; i++)
        {
            sfxSounds[i].volume = SfxVolume.value;
        }
        sfxVol = SfxVolume.value;
    }

    public void OnClickedOptionButton()
    {
        PopupPanel.SetActive(true);
    }

    public void OnClickedAlbumButton()
    {
        //Invoke("AlbumSceneChange", fadeTime);
        AlbumSceneChange();
    }

    public void OnClickedOkButton()
    {
        PopupPanel.SetActive(false);
    }

    public void OnClickedExitButton()
    {
        PopupPanel.SetActive(false);
    }

    //public void OnClickedButton()
    //{
    //    albumSceneManager.clearEndingNum++;
    //    Debug.Log(albumSceneManager.clearEndingNum);
    //}


    public void OnClickedBgmButton()
    {
        if (BgmVolume.value == 0.0f)
            BgmVolume.value = 1.0f;
        else
            BgmVolume.value = 0.0f;
    }

    public void OnClickedSfxButton()
    {
        if (SfxVolume.value == 0.0f)
            SfxVolume.value = 1.0f;
        else
            SfxVolume.value = 0.0f;
    }

    public void OnClickedBackGround()
    {
        //Invoke("SceneChange", fadeTime);
        SceneChange();
    }

    void SceneChange()
    {
        SceneManager.LoadScene(SceneName);
    }

    void AlbumSceneChange()
    {
        SceneManager.LoadScene("AlbumScene");
    }
}
