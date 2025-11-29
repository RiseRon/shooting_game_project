using UnityEngine;

public class Stage2BossAI : BossAI_Base
{
    private Stage2BossShoot bossAttack;
    private BossMove bossMove;
    private Stage2BossPattern bossPattern;
    private BossHP bossHP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossAttack = GetComponent<Stage2BossShoot>();
        bossMove = GetComponent<BossMove>();
        bossPattern = GetComponent<Stage2BossPattern>();
        bossHP = GetComponent<BossHP>();
        bossAttack.enabled = true;
        bossPattern.enabled = false;
        bossMove.enabled = true;
        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void ResetGame()
    {
        bossHP.HP = 150f;
        bossMove.moveSpeed = 120f;
        bossMove.moveRange = 120f;
        UIManager_Game.Instance.UIReset(bossHP.HP);
    }
    public override void CheckForPattern(float nowBossHP)
    {
        if ( nowBossHP <= 100 )
        {
            bossPattern.PatternStart();
        }
    }

    public override void BossDie()
    {
        GameManager.Instance.currentState = GameManager.GameState.GameClear;
    }
}
