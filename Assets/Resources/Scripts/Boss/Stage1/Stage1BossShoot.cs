using UnityEngine;
using static GameManager;

public class Stage1BossShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // 발사할 오브젝트
    public float cooldownTime = 2f; // 발사 쿨타임
    public float moveSpeed = 200f; // 탄환 속도
    private float nextShootTime = 0f; // 다음 발사 시간
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TryShoot();
    }
    private void TryShoot()
    {
        if (Time.time >= nextShootTime) // 다음 발사 시간 체크
        {
            Vector2 bulletPo = new Vector2(transform.position.x - 140, transform.position.y); // 발사 위치 초기화
            GameObject newObject = Instantiate(bulletPrefab, bulletPo, transform.rotation); // 탄환 소환
            nextShootTime = Time.time + cooldownTime; // 다음 발사 시간 수정
            Stage1_2BossBulletMove bulletMove = newObject.GetComponent<Stage1_2BossBulletMove>();
            bulletMove.moveSpeed = moveSpeed;
        }
    }
}
