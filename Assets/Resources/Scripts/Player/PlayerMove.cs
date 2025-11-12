using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 300f; // 이동 속도
    private float minX, maxX, minY, maxY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minX = -660;
        maxX = 660;
        minY = -350;
        maxY = 350;
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
        Vector3 moveDirection = new Vector3(xInput, yInput).normalized; // 이동 방향 계산
        transform.position += moveDirection * moveSpeed * Time.deltaTime; // 이동
    }
    private void LimitPosition()
    {
        Vector2 position = transform.position;
        if (position.x <= minX)
        {
            position.x = minX;
        }
        else if (position.x >= maxX)
        {
            position.x = maxX;
        }
        if (position.y <= minY)
        {
            position.y = minY;
        }
        else if (position.y >= maxY)
        {
            position.y = maxY;
        }
        transform.position = position;
    }
}
