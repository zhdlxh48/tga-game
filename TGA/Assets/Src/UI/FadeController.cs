using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public float fadeTime = 2.0f; // fade 재생 시간

    private Image FadeImg;

    private float start;
    private float end;
    private float time = 0.0f;
    private bool isPlaying = false;

    void Start()
    {
        FadeImg = GetComponent<Image>();
        //gameObject.SetActive(false);
        InStartFadeAnim();
    }

    public void InStartFadeAnim()
    {
        if (isPlaying == true)
            return;
        start = 1.0f;
        end = 0.0f;
        StartCoroutine("PlayFadeIn");
    }

    IEnumerator PlayFadeIn()
    {
        isPlaying = true;

        Color color = FadeImg.color;
        time = 0.0f;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a > 0.0f)
        {
            time += Time.deltaTime / fadeTime; // FadeTime의 설정된 시간동안 재생될 수 있게 나누기
            color.a = Mathf.Lerp(start, end, time);
            FadeImg.color = color;
            yield return null;
        }
        isPlaying = false;
        gameObject.SetActive(false);
    }

    public void OutStartFadeAnim()
    {
        if (isPlaying == true) // 중복실행방지
            return;
        start = 0.0f;
        end = 1.0f;
        gameObject.SetActive(true);
        StartCoroutine("PlayFadeOut");
    }

    IEnumerator PlayFadeOut()
    {
        isPlaying = true;

        Color color = FadeImg.color;
        time = 0.0f;
        color.a = Mathf.Lerp(start, end, time);
        
        while(color.a < 1.0f)
        {
            time += Time.deltaTime / fadeTime; // FadeTime의 설정된 시간동안 재생될 수 있게 나누기
            color.a = Mathf.Lerp(start, end, time);
            FadeImg.color = color;
            yield return null;
        }
        isPlaying = false;
    }
}
