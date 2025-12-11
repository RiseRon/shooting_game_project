using UnityEngine;

public class Stage2BossAI : BossAI_Base
{
    private Stage2BossShoot bossAttack;
    private BossMove bossMove;
    private Stage2BossPattern bossPattern;
    private BossHP bossHP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        UIManager_Game.Instance.UIReset(150f);
    }
    void Start()
    {
        bossAttack = GetComponent<Stage2BossShoot>();
        bossMove = GetComponent<BossMove>();
        bossPattern = GetComponent<Stage2BossPattern>();
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
        bossHP.HP = 150f;
        bossMove.moveSpeed = 120f;
        bossMove.moveRange = 120f;
        UIManager_Game.Instance.ChangeBossHP(bossHP.HP);
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
