using UnityEngine;

public class Stage3BossPattern : MonoBehaviour
{
    public GameObject bulletPrefab; // 발사할 오브젝트
    public float cooldownTime = 13.5f; // 발사 쿨타임
    public float moveSpeed = 600;
    private float nextShootTime = 2f; // 다음 발사 시간
    private Animator animator;
    private bool OnOff = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = 1;
        OnOff = true;
    }

    // Update is called once per frame
    void Update()
    {
        TryShoot();
    }
    private void TryShoot()
    {
        if (Time.time >= nextShootTime && OnOff) // 다음 발사 시간 체크
        {
            animator.SetTrigger("Pattern");
            OnOff = false;
        }
        if (Time.time >= nextShootTime + 0.2f)
        {
            Vector2 bulletPo = new Vector2(transform.position.x - 380, transform.position.y - 100); // 발사 위치 초기화
            GameObject newObject = Instantiate(bulletPrefab, bulletPo, transform.rotation); // 탄환 소환
            nextShootTime = Time.time + cooldownTime; // 다음 발사 시간 수정
            Stage3_4BossBulletMove bulletMove = newObject.GetComponent<Stage3_4BossBulletMove>();
            bulletMove.moveSpeed = moveSpeed;
            animator.SetTrigger("Return");
            OnOff = true;
        }
    }
}
