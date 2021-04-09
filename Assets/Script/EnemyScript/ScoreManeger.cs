using UnityEngine;
using TMPro;
public class ScoreManeger : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int scoreValue;
 
    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "スコア:" + scoreValue.ToString() + "/100";
    }
}
