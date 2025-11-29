using Unity.Mathematics;
using UnityEngine;

public class Stage4BossShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // 발사할 오브젝트
    public float cooldownTime = 0.5f; // 발사 쿨타임
    public float moveSpeed = 900f;
    private float nextShootTime = 0f; // 다음 발사 시간
    private float[] bulletDirection1 = { 30, 0, -30 };
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
            for (int i = 0; i < 3; i++)
            {
                quaternion spawnRotaion = Quaternion.Euler(0f, 0f, bulletDirection1[i]);
                Vector2 bulletPo = new Vector2(transform.position.x - 140, transform.position.y); // 발사 위치 초기화
                GameObject newObject = Instantiate(bulletPrefab, bulletPo, spawnRotaion); // 탄환 소환
                Stage3_4BossBulletMove bulletMove = newObject.GetComponent<Stage3_4BossBulletMove>();
                bulletMove.moveSpeed = moveSpeed;
            }
            nextShootTime = Time.time + cooldownTime; // 다음 발사 시간 수정
        }
    }
}
