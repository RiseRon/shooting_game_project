using UnityEngine;

public class Stage1BossAI : BossAI_Base
{
    private Stage1BossShoot bossAttack;
    private BossMove bossMove;
    private Stage1BossPattern bossPattern;
    private BossHP bossHP;
    private int checkTime; // 보스 패턴 사용 횟수
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossAttack = GetComponent<Stage1BossShoot>();
        bossMove = GetComponent<BossMove>();
        bossPattern = GetComponent<Stage1BossPattern>();
        bossHP = GetComponent<BossHP>();
        bossHP.enabled = true;
        bossAttack.enabled = true;
        bossMove.enabled = true;
        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void ResetGame()
    {
        checkTime = 2;
        bossHP.HP = 200f;
        bossMove.moveSpeed = 64f;
        bossMove.moveRange = 80f;
        UIManager_Game.Instance.UIReset(bossHP.HP);
    }
    public override void CheckForPattern(float nowBossHP)
    {
        if (nowBossHP <= 140 && checkTime == 2 || nowBossHP <= 70 && checkTime == 1)
        {
            bossAttack.enabled = false;
            bossPattern.PatternStart();
            bossMove.enabled = false;
            bossHP.enabledCheck = false;
            checkTime--;
        }
    }
    public void EndPattern()
    {
        bossAttack.enabled = true;
        bossMove.enabled = true;
        bossHP.enabledCheck = true;
        bossAttack.nextShootTime = Time.time + 1;
    }
    public override void BossDie()
    {
        GameManager.Instance.currentState = GameManager.GameState.GameClear;
    }
}
