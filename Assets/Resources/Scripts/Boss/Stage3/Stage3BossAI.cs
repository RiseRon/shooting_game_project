using UnityEngine;

public class Stage3BossAI : BossAI_Base
{
    private Stage3BossShoot bossAttack;
    private BossMove bossMove;
    private BossHP bossHP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        UIManager_Game.Instance.UIReset(200f);
    }
    void Start()
    {
        bossAttack = GetComponent<Stage3BossShoot>();
        bossMove = GetComponent<BossMove>();
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
        bossHP.HP = 200f;
        bossMove.moveSpeed = 96f;
        bossMove.moveRange = 120f;
        UIManager_Game.Instance.ChangeBossHP(bossHP.HP);
    }
    public override void CheckForPattern(float nowBossHP)
    {

    }
    public override void BossDie()
    {
        GameManager.Instance.currentState = GameManager.GameState.GameClear;
    }
}
