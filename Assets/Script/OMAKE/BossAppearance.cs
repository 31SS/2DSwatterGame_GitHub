using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossAppearance : MonoBehaviour
{

    public List<TextMeshProUGUI> dangerText;
    public TextMeshProUGUI warning;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        Sound.PlayBgm("BossWarning");
    }

    // Update is called once per frame
    void Update()
    {
        dangerText[0].color = GetAlphaColor(dangerText[0].color);
        dangerText[1].color = GetAlphaColor(dangerText[1].color);
        warning.color = GetAlphaColor(warning.color);
        dangerText[0].transform.position += new Vector3(-1, 0, 0);
        dangerText[1].transform.position += new Vector3(1, 0, 0);
        if (time > 12f && dangerText[0].color.a <= 1)
        {
            Sound.PlayBgm("Boss");
            this.gameObject.SetActive(false);
        }
    }

    //Alpha値を更新してColorを返す
    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * 0.5f;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;
        return color;
    }
}
