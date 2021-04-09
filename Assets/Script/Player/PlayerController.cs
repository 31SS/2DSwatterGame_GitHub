using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private PlayerMover _playerMover;
    private PlayerGenerater _blockGenerater;
    private MobilityLimiter _mobilityLimiter;
    private PlayerDeader _playerDeader;
    private bool generateFlag;
    private bool damageAniFlag;
    private bool isDamaged;
    [SerializeField] private float elapsedTime;
    [SerializeField] private float interval = 1.0f;
    [SerializeField] private int hpValue = 5;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private Renderer spriteRenderer;//playerのsprite
    [SerializeField] private Animator playerAnimator;//playerのアニメーター
    //[SerializeField] private Animation ReleasedAni;
    [SerializeField] private PolygonCollider2D[] PolygonCollider;//playerのコライダー2種
    [SerializeField] private Slider intervalSlider;//playerがブロックを生成するまでの時間を視覚化
    [SerializeField] private Image intervalSliderColor;//上記のスライダーFillのImage
    private bool IsDead() => hpValue <= 0;

    private void Awake()
    {
        _playerMover = new PlayerMover();
        _blockGenerater = GetComponent<PlayerGenerater>();
        _mobilityLimiter = new MobilityLimiter();
        _playerDeader = new PlayerDeader();
        //_playerAnimator = new PlayerAnimator(GetComponent<Animator>(), this);
        generateFlag = true;
        damageAniFlag = false;
        IsDamaged = false;
        elapsedTime = 1.0f;
        PolygonCollider[0].enabled = true;
        PolygonCollider[1].enabled = false;        
    }
    void Update()
    {
        _playerMover.Move(this);
        if (Input.GetMouseButtonDown(0)&& generateFlag)
        {
            _blockGenerater.GenerateBlock();
            generateFlag = false;
            elapsedTime = 0.0f;
            RandomSE("PlayerAttack1", "PlayerAttack2", "PlayerAttack3");
            StartCoroutine(GenerateInterval());
            if (!isDamaged)
            {
                StartCoroutine(ReleasedAnimation());
            }
        }
        if (Input.GetMouseButtonDown(1))//ブロック切り替え
        {
            _blockGenerater.ChangeBlock();
            Sound.PlaySe("BlockChange");
        }
        hpText.text = "タイリョク:" + hpValue.ToString() + "/15";

        if (elapsedTime <= interval)
        {
            elapsedTime += Time.deltaTime;
            intervalSlider.value = elapsedTime / interval;
        }

        if (isDamaged)
        {
            StartCoroutine(DamageTimer());
        }

        if (IsDead())
        {
            DeadFunction();
        }

        if(GameManager.Instance.currentState == GameManager.GameState.Clear)
        {
            WonFunction();
        }
    }

    private void LateUpdate()
    {
        _mobilityLimiter.moveLimit(this);
    }

    private IEnumerator GenerateInterval()
    {
        intervalSliderColor.color = new Color(236 / 255.0f, 66 / 255.0f, 27 / 255.0f);//濃いオレンジ
        yield return new WaitForSeconds(interval);
        generateFlag = true;
        intervalSliderColor.color = new Color(60 / 255.0f, 84 / 255.0f, 236 / 255.0f);//長方形ブロックの濃い青色
    }

    private void DeadFunction()
    {
        Sound.PlaySe("PlayerDead", 0);
        Destroy(gameObject);
        GameManager.Instance.dispatch(GameManager.GameState.Over);
        intervalSliderColor.color = new Color(237, 85, 27);
    }

    private void WonFunction()
    {
        playerAnimator.SetTrigger("is_won");
        Sound.PlaySe("PlayerWin", 0);
        enabled = false;
    }

    private IEnumerator ReleasedAnimation()
    {
        playerAnimator.SetTrigger("is_Released");
        PolygonCollider[0].enabled = false;
        PolygonCollider[1].enabled = true;
        yield return new WaitForSeconds(0.3f);//要変更
        PolygonCollider[0].enabled = true;
        PolygonCollider[1].enabled = false;
    }

    private IEnumerator DamageTimer()
    {
        if (damageAniFlag)
        {
            yield break;
        }
        damageAniFlag = true;
        playerAnimator.SetTrigger("is_Attacked");
        spriteRenderer.material.color = new Color(1.0f, 0.6f, 0.6f);
        RandomSE("PlayerDamage1", "PlayerDamage2");
        for (int i = 0; i < 10; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.05f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.05f);
        }
        IsDamaged = false;
        damageAniFlag = false;
        spriteRenderer.material.color = new Color(1.0f, 1.0f, 1.0f);
    }

    private void RandomSE(params string[] strings)
    {
        var randomIndex = Random.Range(0, strings.Length);
        Sound.PlaySe(strings[randomIndex], 0);
    }

    public int HpValue
    {
        get { return hpValue; }
        internal set { hpValue = value; }
    }

    public bool IsDamaged {
        get { return isDamaged; }
        internal set { isDamaged = value; }
    }
}
