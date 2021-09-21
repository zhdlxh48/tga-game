using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBlink : MonoBehaviour
{
    public Text blinkText;
    public float blinkSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("BlinkText");
    }

    public IEnumerator BlinkText()
    {
        while(true)
        {
            blinkText.text = "";
            yield return new WaitForSeconds(blinkSpeed);
            blinkText.text = "아무 곳이나 클릭하면 게임이 시작됩니다.";
            yield return new WaitForSeconds(blinkSpeed);
        }
    }
}
