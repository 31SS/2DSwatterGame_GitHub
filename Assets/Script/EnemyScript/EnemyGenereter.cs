using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenereter : MonoBehaviour
{
    public List<GameObject> enemyList;
    public GameObject dragon;
    public GameObject bossText;
    public float generateIntarvalTime;

    public static int limitEnemies; //敵の上限数
    public static int [] incidencesList; //{悪魔、弾を撃つ敵、虫}出現確率
    public static int bossScore;　//ボスの出現するスコア

    private int[] distribution = new int [100];//ランダム配列
    private bool isGenerate;
    private bool isGenerateDragon;

    private GameObject[] tabEnemyObject;//画面内の敵

    // Start is called before the first frame update
    void Start()
    {
        isGenerate = true;
        isGenerateDragon = true;
        RandomEnemy();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tabEnemyObject = GameObject.FindGameObjectsWithTag("Enemy");//EnemyTagの数(画面内の敵の上限)
        if (isGenerate == true && tabEnemyObject.Length < limitEnemies && GameManager.Instance.currentState == GameManager.GameState.Playing)
        {
            GenerateEnemy();
            StartCoroutine(GenerateIntarval());
        }
        if (isGenerateDragon && ScoreManeger.scoreValue > bossScore) //適当
        {
            bossText.SetActive(true);
            Instantiate(dragon, new Vector2(0, 16), Quaternion.identity);
            isGenerateDragon = false;
        }
    }

    //生成関数
    private void GenerateEnemy()
    {
        //位置ランダム指定(2,-2) 考え中
        int x = Random.Range(0, 2) * 4 - 2;
        int y = Random.Range(0, 2) * 4 - 2;
        Vector2 generatePos = Camera.main.ViewportToWorldPoint(new Vector2(x, y));
        Instantiate(enemyList[distribution[Random.Range(0, 100)]], generatePos, Quaternion.identity);
    }

    //確率関数(gomi)
    private void RandomEnemy()
    {
        var flag = 0;
        for(var i = 0; i < incidencesList.Length; i++){
            for(var j = flag; j < incidencesList[i] + flag; j++){
                distribution[j] = i;
            }
            flag += incidencesList[i];
        }
    }
    //インターバル
    private IEnumerator GenerateIntarval()
    {
        isGenerate = false;
        yield return new WaitForSeconds(generateIntarvalTime);
        isGenerate = true;
    }
}
