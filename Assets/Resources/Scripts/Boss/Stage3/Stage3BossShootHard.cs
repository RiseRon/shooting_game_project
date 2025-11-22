using System.Net.NetworkInformation;
using Unity.Mathematics;
using UnityEngine;

public class Stage3BossShootHard : MonoBehaviour
{
    public GameObject bulletPrefab; // 발사할 오브젝트
    public float cooldownTime = 1f; // 발사 쿨타임
    private float nextShootTime = 0f; // 다음 발사 시간
    private float[] bulletDirection1 = { 30, 0, -30 };
    private float[] bulletDirection2 = { 20, 0, -20 };
    private int bulletCount = 0;
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
            switch (bulletCount)
            {
                case 0:
                    for (int i = 0; i < 3; i++)
                    {
                        quaternion spawnRotaion = Quaternion.Euler(0f, 0f, bulletDirection1[i]);
                        Vector2 bulletPo = new Vector2(transform.position.x - 140, transform.position.y); // 발사 위치 초기화
                        GameObject newObject = Instantiate(bulletPrefab, bulletPo, spawnRotaion); // 탄환 소환
                    }
                    bulletCount++;
                    break;
                case 1:
                    for (int i = 0; i < 3; i++)
                    {
                        quaternion spawnRotaion = Quaternion.Euler(0f, 0f, bulletDirection2[i]);
                        Vector2 bulletPo = new Vector2(transform.position.x - 140, transform.position.y); // 발사 위치 초기화
                        GameObject newObject = Instantiate(bulletPrefab, bulletPo, spawnRotaion); // 탄환 소환
                    }
                    bulletCount--;
                    break;
            }
            nextShootTime = Time.time + cooldownTime; // 다음 발사 시간 수정
        }
    }
}
