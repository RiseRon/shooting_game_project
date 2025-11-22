using UnityEngine;

public class Stage2BossAI : BossAI_Base
{
    // private Stage2BossShoot bossAttack;
    private BossMove bossMove;
    // private Stage2BossPattern bossPattern;
    private BossHP bossHP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // bossAttack = GetComponent<Stage2BossShoot>();
        bossMove = GetComponent<BossMove>();
        // bossPattern = GetComponent<Stage2BossPattern>();
        bossHP = GetComponent<BossHP>();
        // bossAttack.enabled = true;
        // bossPattern.enabled = false;
        bossMove.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void CheckForPattern(float nowBossHP)
    {

    }
    public override void EndPattern()
    {
        // bossAttack.enabled = true;
        // bossPattern.enabled = false;
        bossMove.enabled = true;
        bossHP.enabledCheck = true;
    }
    public override void BossDie()
    {
        GameManager.Instance.currentState = GameManager.GameState.GameClear;
    }
}
