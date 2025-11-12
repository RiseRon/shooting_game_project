using UnityEngine;

public class BossHP : MonoBehaviour
{
    private float HP; // 채력
    public float maxHP = 200f;
    private HyunMooAI bossAI;
    public bool enabledCheck = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HP = maxHP;
        GameManager.Instance.ChangeBossHP(HP);
        bossAI = GetComponent<HyunMooAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float amount)
    {
        if (enabledCheck)
        {
            HP += amount; // 채력 값 변경

            bossAI.CheckForPettern(HP); // 패턴 확인

            GameManager.Instance.ChangeBossHP(HP); // 채력 ui 변경 호출

            if (HP <= 0) // 사망 확인
            {
                bossAI.BossDie();
            }
        }
    }
}
