using UnityEngine;

public class PlayerBulletMove : MonoBehaviour
{
    public float moveSpeed = 1000;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.right; // 탄환 발사 방향
        transform.Translate(direction * moveSpeed * Time.deltaTime); // 탄환 움직임
        if(transform.position.x >= 740) // 화면을 넘어가면 제거
        {
            Destroy(gameObject);
        }
    }
}
