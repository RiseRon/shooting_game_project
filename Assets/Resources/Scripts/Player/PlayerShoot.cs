using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // 발사할 오브젝트
    public GameObject specialBulletPrefab; // 발사할 특수 오브젝트
    private SoundPlayer soundPlayer;

    public float damage = 1f; // 탄환 공격력
    public float specialDamage = 5f; // 스킬 탄환 공격력

    public float moveSpeed = 600f; // 탄환 이동속도
    public float specialMoveSpeed = 600f; // 스킬 탄환 이동속도

    private float cooldownTime = 0.5f; // 발사 쿨타임
    private float nextShootTime = 0f; // 다음 발사 시간
    private float specialCooldownTime = 10f; // 특수 스킬 발사 쿨타임
    private float nextSpecialShootTime = 0f; // 다음 특수 스킬 시간
    public GameObject attackEffect;
    public GameObject skillEffect;

    public Image cooldownMask;

    void Start()
    {
        soundPlayer = FindFirstObjectByType<SoundPlayer>();

        if (cooldownMask != null)
        {
            cooldownMask.fillAmount = 0.0f ;
        }
    }

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
            Vector2 bulletPo = new Vector2(transform.position.x + 70, transform.position.y); // 발사 위치 초기화
            GameObject newObject = Instantiate(bulletPrefab, bulletPo, transform.rotation); // 탄환 소환
            nextShootTime = Time.time + cooldownTime; // 다음 발사 시간 수정
            PlayerBulletMove bulletMove = newObject.GetComponent<PlayerBulletMove>();
            bulletMove.damage = damage; // 공격력 설정
            bulletMove.moveSpeed = moveSpeed; // 이동속도 설정
            bulletMove.effect = attackEffect; // 이펙트 설정
            if (soundPlayer != null)
                soundPlayer.PlayerAttackSFX();
        }
    }
    private void TrySpecialShoot()
    {
        if (Time.time >= nextSpecialShootTime) // 다음 발사 시간 체크
        {
            Vector2 bulletPo = new Vector2(transform.position.x + 100, transform.position.y); // 발사 위치 초기화
            GameObject newObject = Instantiate(specialBulletPrefab, bulletPo, transform.rotation); // 탄환 소환
            nextSpecialShootTime = Time.time + specialCooldownTime; // 다음 발사 시간 수정

            StartCoroutine(SpecialCooldown());

            PlayerBulletMove bulletMove = newObject.GetComponent<PlayerBulletMove>();
            bulletMove.damage = specialDamage; // 공격력 설정
            bulletMove.moveSpeed = moveSpeed; // 이동속도 설정
            bulletMove.effect = skillEffect; // 이펙트 설정
            if (soundPlayer != null)
                soundPlayer.PlayerSkillSFX();
            
        }
    }

    // 쿨다운 시각 효과를 처리할 코루틴
    private System.Collections.IEnumerator SpecialCooldown()
    {
        // 마스크가 연결되지 않았다면 코루틴 중지
        if (cooldownMask == null)
        {
            yield break;
        }

        cooldownMask.fillAmount = 1.0f;
        float startTime = Time.time;
        float endTime = startTime + specialCooldownTime;

        while (Time.time < endTime)
        {
            // 쿨다운 진행 시간 / 전체 쿨다운
            float elapsedTime = Time.time - startTime;

            // 남은 시간 비율 (1.0f에서 0.0f로 감소)
            float fillRatio = 1.0f - (elapsedTime / specialCooldownTime);

            cooldownMask.fillAmount = fillRatio;

            yield return null; // 다음 프레임 대기
        }

        // 쿨다운 완료
        cooldownMask.fillAmount = 0.0f;
    }
}
