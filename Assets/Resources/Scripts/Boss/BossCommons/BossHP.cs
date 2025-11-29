using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHP : MonoBehaviour
{
    public float HP; // 채력
    private BossAI_Base bossAI;
    public bool enabledCheck = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIManager_Game.Instance.ChangeBossHP(HP);
        bossAI = GetComponent<BossAI_Base>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float amount)
    {
        if (enabledCheck)
        {
            HP -= amount; // 채력 값 변경

            bossAI.CheckForPattern(HP); // 패턴 확인

            UIManager_Game.Instance.ChangeBossHP(HP); // 채력 ui 변경 호출

            if (HP <= 0) // 사망 확인
            {
                bossAI.BossDie();
            }
        }
    }
}
