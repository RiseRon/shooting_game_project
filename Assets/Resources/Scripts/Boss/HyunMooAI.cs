using UnityEngine;

public class HyunMooAI : MonoBehaviour
{
    private HyunMooShoot bossAttack;
    private BossMove bossMove;
    private HyunMooPattern bossPattern;
    private BossHP bossHP;
    private int checkTime = 2; // 보스 패턴 사용 횟수
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossAttack = GetComponent<HyunMooShoot>();
        bossMove = GetComponent<BossMove>();
        bossPattern = GetComponent<HyunMooPattern>();
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
