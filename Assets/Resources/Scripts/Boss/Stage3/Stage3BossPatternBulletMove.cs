using UnityEngine;

public class Stage3BossPatternBulletMove : MonoBehaviour
{
    public float moveSpeed = 600f; // 이동 속도
    private Vector2 direction; // 이동 방향
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = Vector2.left.normalized;
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
