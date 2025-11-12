using UnityEngine;

public class PlayerBulletMove : MonoBehaviour
{
    private float damage = -10f; // 플레이어 공격력
    public float moveSpeed = 1000f; // 이동 속도
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.right; // 탄환 발사 방향
        transform.Translate(direction * moveSpeed * Time.deltaTime); // 탄환 움직임
        if(transform.position.x >= 740) // 화면을 넘어가면 제거
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss")) // 보스 충돌 감지 확인
        {
            BossHP bossHealth = other.GetComponent<BossHP>();
            if (bossHealth != null)
            {
                bossHealth.TakeDamage(damage);
            }
            Destroy(gameObject); // 탄환 제거
        }
    }
}
