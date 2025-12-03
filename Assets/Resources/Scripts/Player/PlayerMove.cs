using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 500f; // 이동 속도
    private float minX, maxX, minY, maxY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minX = -666;
        maxX = 666;
        minY = -345;
        maxY = 345;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        LimitPosition();
        
    }
    private void Move() 
    {
        float xInput = Input.GetAxisRaw("Horizontal"); // 입력 값 받기
        float yInput = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(xInput, yInput).normalized; // 이동 방향 계산
        transform.Translate(direction * moveSpeed * Time.deltaTime); // 이동
    }
    private void LimitPosition()
    {
        Vector2 position = transform.position;
        if (position.x <= minX)
        {
            position.x = minX;
            transform.position = position;
        }
        else if (position.x >= maxX)
        {
            position.x = maxX;
            transform.position = position;
        }
        if (position.y <= minY)
        {
            position.y = minY;
            transform.position = position;
        }
        else if (position.y >= maxY)
        {
            position.y = maxY;
            transform.position = position;
        }
    }
}
