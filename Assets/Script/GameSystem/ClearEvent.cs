using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClearEvent : MonoBehaviour
{
    private bool curtainAniFlag = false;
    [SerializeField] private TextMeshProUGUI eventText;

    private void Awake()
    {
        eventText.enabled = false;
        Sound.StopBgm();
        Sound.PlaySe("GameClear");
    }
    void Update()
    {
        StartCoroutine(FinishedOverEventFlag());
        if (curtainAniFlag)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameManager.Instance.StartGame();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                GameManager.Instance.TitleGame();
            }
        }
    }

    private IEnumerator FinishedOverEventFlag()
    {
        yield return new WaitForSeconds(0.80f);
        curtainAniFlag = true;
        eventText.enabled = true;
    }
}
