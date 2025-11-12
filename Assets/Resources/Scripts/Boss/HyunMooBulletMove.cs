using UnityEngine;

public class HyunMooBulletMove : MonoBehaviour
{
    private Transform PlayerTransform;
    public float moveSpeed = 200f; // 이동 속도
    private Vector2 direction; // 이동 방향
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject PlayerObject = GameObject.FindWithTag("Palayer"); // 플레이어 찾기

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
        if (transform.position.x <= -740) // 화면을 넘어가면 제거
        {
            Destroy(gameObject);
        }
    }
}
