using UnityEngine;

public class Stage3BossBulletMove : MonoBehaviour
{
    public float moveSpeed; // 이동 속도
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
        if (transform.position.x <= -770 || transform.position.y >= 440 || transform.position.y <= -440) // 화면을 넘어가면 제거
        {
            Destroy(gameObject);
        }
    }
}
