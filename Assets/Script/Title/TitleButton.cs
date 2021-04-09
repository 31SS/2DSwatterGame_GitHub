using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    public GameObject levelButton;
    public GameObject explainButton;
    private bool isExplainButton;

    private void Awake()
    {
        isExplainButton = false;
    }

    private void Update()
    {
        if(isExplainButton && explainButton.transform.position.y < 200)
        {
            explainButton.transform.position += new Vector3(0, 20, 0);
        }
        if(!isExplainButton && explainButton.transform.position.y > -200)
        {
            explainButton.transform.position -= new Vector3(0, 20, 0);
        }

    }

    public void StartGame()
    {
        levelButton.SetActive(true);
        Sound.PlaySe("TitleButton");
        isExplainButton = false;
        //GameManager.Instance.StartGame();
    }
    public void ExplainImage()
    {
        isExplainButton = true;
        Sound.PlaySe("TitleButton");
    }
    public void ExitGame()
    {
        Sound.PlaySe("TitleButton");
        Application.Quit();
        Debug.Log("終わり");
    }

    public void CloseExplainImage()
    {
        Sound.PlaySe("TitleButton");
        isExplainButton = false;
    }
}
