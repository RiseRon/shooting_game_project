using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 300f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal"); // 입력 값 받기
        float yInput = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(xInput, yInput, 0f).normalized; // 이동 방향 계산
        transform.position += moveDirection * moveSpeed * Time.deltaTime; // 이동
    }
}
