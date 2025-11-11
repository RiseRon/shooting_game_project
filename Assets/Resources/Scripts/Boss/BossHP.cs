using UnityEngine;
using UnityEngine.UI;
public class BossHP : MonoBehaviour
{
    float dmage = 1f; // 플레이어 공격력
    public Slider bossHPBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet")) // 보스 충돌 감지 확인
        {
            ChangeHealth(dmage); // 채력 변경 함수 호출
            Destroy(other.gameObject); // 탄환 제거
        }
    }
    private void ChangeHealth(float attack) // 채력 변경 함수
    {
        if(bossHPBar.value > 0)
        {
            bossHPBar.value -= attack; // 공격력에 따른 채력 감소
        }
    }
}
