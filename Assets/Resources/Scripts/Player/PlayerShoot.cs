using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // 발사할 오브젝트
    public GameObject specialBulletPrefab; // 발사할 특수 오브젝트
    public float cooldownTime = 0.5f; // 발사 쿨타임
    public float damage = 1f; // 탄환 공격력
    public float specialDamage = 5f; // 스킬 탄환 공격력
    public float moveSpeed = 600f; // 탄환 이동속도
    public float specialMoveSpeed = 600f;
    private float nextShootTime = 0f; // 다음 발사 시간
    public float specialCooldownTime = 10f; // 특수 스킬 발사 쿨타임
    private float nextSpecialShootTime = 0f; // 다음 특수 스킬 시간
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
        if (Input.GetKey(KeyCode.LeftShift)) // 쉬프트 키 입력 감지
        {
            TrySpecialShoot(); // 특수 스킬 함수 호출
        }
    }
    private void TryShoot()
    {
        if (Time.time >= nextShootTime) // 다음 발사 시간 체크
        {
            Vector2 bulletPo = new Vector2(transform.position.x + 100, transform.position.y); // 발사 위치 초기화
            GameObject newObject = Instantiate(bulletPrefab, bulletPo, transform.rotation); // 탄환 소환
            nextShootTime = Time.time + cooldownTime; // 다음 발사 시간 수정
            PlayerBulletMove bulletMove = newObject.GetComponent<PlayerBulletMove>();
            bulletMove.damage = damage; // 공격력 설정
            bulletMove.moveSpeed = moveSpeed; // 이동속도 설정
        }
    }
    private void TrySpecialShoot()
    {
        if (Time.time >= nextSpecialShootTime) // 다음 발사 시간 체크
        {
            Vector2 bulletPo = new Vector2(transform.position.x + 100, transform.position.y); // 발사 위치 초기화
            GameObject newObject = Instantiate(specialBulletPrefab, bulletPo, transform.rotation); // 탄환 소환
            nextSpecialShootTime = Time.time + specialCooldownTime; // 다음 발사 시간 수정
            PlayerBulletMove bulletMove = newObject.GetComponent<PlayerBulletMove>();
            bulletMove.damage = specialDamage; // 공격력 설정
            bulletMove.moveSpeed = moveSpeed; // 이동속도 설정
        }
    }
}
