using UnityEngine;

public class HyunMooShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float cooldownTime = 2f;
    private float nextShootTime = 0f;
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
        }
    }
}
