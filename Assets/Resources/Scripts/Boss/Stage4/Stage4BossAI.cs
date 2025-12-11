using UnityEngine;

public class Stage4BossAI : BossAI_Base
{
    private Stage4BossShoot bossAttack;
    private BossMove bossMove;
    private Stage4BossPattern bossPattern;
    private BossHP bossHP;
    private int checkTime; // 보스 패턴 사용 횟수
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        UIManager_Game.Instance.UIReset(250f);
    }
    void Start()
    {
        bossAttack = GetComponent<Stage4BossShoot>();
        bossMove = GetComponent<BossMove>();
        bossPattern = GetComponent<Stage4BossPattern>();
        bossHP = GetComponent<BossHP>();
        bossHP.enabled = true;
        bossAttack.enabled = true;
        bossMove.enabled = true;
        bossPattern.enabled = false;
        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void ResetGame()
    {
        checkTime = 2;
        bossHP.HP = 250f;
        bossMove.moveSpeed = 120f;
        bossMove.moveRange = 120f;
        UIManager_Game.Instance.ChangeBossHP(bossHP.HP);
    }
    public override void CheckForPattern(float nowBossHP)
    {
        if (nowBossHP <= 125 && checkTime == 2 || nowBossHP <= 50 && checkTime == 1)
        {
            bossAttack.enabled = false;
            bossPattern.PatternStart();
            bossPattern.enabled = true;
            checkTime--;
        }
    }
    public void EndPattern()
    {
        bossAttack.enabled = true;
        bossMove.enabled = true;
        bossHP.enabled = true;
        bossPattern.enabled = false;
    }
    public override void BossDie()
    {
        GameManager.Instance.currentState = GameManager.GameState.GameClear;
    }
}
