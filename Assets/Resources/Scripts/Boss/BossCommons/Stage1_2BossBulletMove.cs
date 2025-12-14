using UnityEngine;

public class Stage1_2BossBulletMove : MonoBehaviour
{
    private Transform PlayerTransform;
    public float moveSpeed; // 이동 속도
    private Vector2 direction; // 이동 방향
    public GameObject bossEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject PlayerObject = GameObject.FindWithTag("Player"); // 플레이어 찾기

        if (PlayerObject != null)
        {
            PlayerTransform = PlayerObject.transform; // 플레이어의 포지션 값 받기
            direction = (PlayerTransform.position - transform.position).normalized; // 방향 백터 구하기
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime); // 탄환 움직임
        if (transform.position.x <= -770 || transform.position.y >= 440 || transform.position.y <= -440) // 화면을 넘어가면 제거
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHP playerHP = other.GetComponent<PlayerHP>();
            if (playerHP != null)
            {
                playerHP.TakeDamage();
            }
            GameObject newObejct = Instantiate(bossEffect, transform.position, transform.rotation);
            EffectTime effectTime = newObejct.GetComponent<EffectTime>();
            effectTime.effectTime = 0.15f;
            Destroy(gameObject);
        }
    }
}
