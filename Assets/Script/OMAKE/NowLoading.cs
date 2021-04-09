using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NowLoading : MonoBehaviour
{
    public TextMeshProUGUI loadingText;
    public GameObject demon;
    private string nowLoadingText;
    public static string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        nowLoadingText = "Now Loading";
        StartCoroutine(WaitLoading());
    }

    private IEnumerator WaitLoading()
    {
        for(int i = 0; i < 4;i++)
        {
            loadingText.text = nowLoadingText;
            nowLoadingText = nowLoadingText + ".";
            yield return new WaitForSeconds(1);
        }
        StartCoroutine(EndLoad());
    }
    //徐々に消える
    private IEnumerator EndLoad()
    {
        var a_color = 0.1f;
        while(loadingText.color.a > 0)
        {
            loadingText.color -= new Color(0, 0, 0, a_color);
            demon.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, a_color);
            yield return new WaitForSeconds(0.1f);
        }
        SceneManager.LoadScene(sceneName);
        if(sceneName == "PlayerScene")
        {
            GameManager.Instance.dispatch(GameManager.GameState.Playing);
        }
        else if(sceneName == "TitleScene")
        {
            GameManager.Instance.dispatch(GameManager.GameState.Opening);
        }
    }
}
