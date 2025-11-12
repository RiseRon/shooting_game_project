using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // 발사할 오브젝트
    public float cooldownTime = 0.5f; // 발사 쿨타임
    private float nextShootTime = 0f; // 다음 발사 시간
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) // 스페이스 바 키 입력 감지
        {
            TryShoot(); // 발사 함수 호출
        }
    }
    private void TryShoot()
    {
        if (Time.time >= nextShootTime) // 다음 발사 시간 체크
        {
            Vector2 bulletPo = new Vector2(transform.position.x + 100, transform.position.y); // 발사 위치 초기화
            GameObject newObject = Instantiate(bulletPrefab, bulletPo, transform.rotation); // 탄환 소환
            nextShootTime = Time.time + cooldownTime; // 다음 발사 시간 수정
        }
    }
}
