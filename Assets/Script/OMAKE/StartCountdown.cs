using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCountdown : MonoBehaviour
{
    public Text CountText;
    public Image BlackImage;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startHaikei());
    }

    IEnumerator startHaikei()
    {
        var a_color = 0.1f;
        while(BlackImage.color.a > 0)
        {
            yield return new WaitForSeconds(0.1f);
            BlackImage.color -= new Color(0, 0, 0, a_color);
        }
        StartCoroutine(StartCountDown());
    }
    IEnumerator StartCountDown()
    {
        yield return new WaitForSeconds(0.5f);
        CountText.text = "     3";
        yield return new WaitForSeconds(1f);

        CountText.text = "     2";
        yield return new WaitForSeconds(1f);

        CountText.text = "     1";
        yield return new WaitForSeconds(1f);

        CountText.text = "START";
        yield return new WaitForSeconds(1f);
        Destroy(CountText);
    }
}
