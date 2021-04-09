using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    public List<int> numberOfEnemies;
    public List<int> bossAppearanceScore;

    public void EasyLevel()
    {
        Sound.PlaySe("TitleButton");
        setLevel(0);
        EnemyGenereter.incidencesList = new int[] {30, 0, 70};//虫7悪魔3
        GameManager.Instance.StartGame();
    }

    public void NormalLevel()
    {
        Sound.PlaySe("TitleButton");
        setLevel(1);
        EnemyGenereter.incidencesList = new int[] {40, 40, 20};//虫と悪魔
        GameManager.Instance.StartGame();
    }

    public void HardLevel()
    {
        Sound.PlaySe("TitleButton");
        setLevel(2);
        EnemyGenereter.incidencesList = new int[] {70, 30, 0};//虫と悪魔ガンナー
        GameManager.Instance.StartGame();
    }

    public void setLevel(int i)
    {
        EnemyGenereter.limitEnemies = numberOfEnemies[i];
        EnemyGenereter.bossScore = bossAppearanceScore[i];

    }
}
