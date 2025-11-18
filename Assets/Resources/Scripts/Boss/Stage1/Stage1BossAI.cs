using UnityEngine;

public class Stage1BossAI : MonoBehaviour
{
    private Stage1BossShoot bossAttack;
    private BossMove bossMove;
    private Stage1BossPattern bossPattern;
    private BossHP bossHP;
    private int checkTime = 2; // 보스 패턴 사용 횟수
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossAttack = GetComponent<Stage1BossShoot>();
        bossMove = GetComponent<BossMove>();
        bossPattern = GetComponent<Stage1BossPattern>();
        bossHP = GetComponent<BossHP>();
        bossAttack.enabled = true;
        bossPattern.enabled = false;
        bossMove.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  void CheckForPettern(float nowBossHP)
    {
        if (nowBossHP <= 140 && checkTime == 2)
        {
            bossAttack.enabled = false;
            bossPattern.PatternStart();
            bossMove.enabled = false;
            bossHP.enabledCheck = false;
            checkTime--;
        }
        else if (nowBossHP <= 70 && checkTime == 1)
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
        bossPattern.enabled = false;
        bossMove.enabled = true;
        bossHP.enabledCheck = true;
    }
    public void BossDie()
    {
        bossAttack.enabled = false;
        bossPattern.enabled = false;
        bossMove.enabled = false;
        bossHP.enabledCheck = false;
    }
}
