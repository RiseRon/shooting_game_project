using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Stage1BossPatternBulletMove : MonoBehaviour
{
    private float moveSpeed = 500f;
    private float returnSpeed;
    private Vector2 targetPoint;
    private int moveOption = 1;
    private Transform bossTransform;
    private Vector2 direction;
    private float HealHP = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject PlayerObject = GameObject.FindWithTag("Boss"); // 플레이어 찾기

        if (PlayerObject != null)
        {
            bossTransform = PlayerObject.transform; // 플레이어의 포지션 값 받기
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        switch(moveOption)
        {
            case 1:
                if (Vector3.Distance(transform.position, targetPoint) > 0.01f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);
                }
                else if (Vector3.Distance(transform.position, targetPoint) <= 0.01f)
                {
                    transform.position = targetPoint;
                    moveOption = 2;
                }
                break;
            case 2:
                returnSpeed = Vector3.Distance(transform.position, bossTransform.position) / 25;
                transform.position = Vector2.MoveTowards(transform.position, bossTransform.position, returnSpeed * Time.deltaTime);
                break;

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss"))
        {
            Stage1BossAI bossAI = other.GetComponent<Stage1BossAI>();
            bossAI.EndPattern();
            BossHP bossHP = other.GetComponent<BossHP>();
            bossHP.TakeDamage(HealHP);
            Destroy(gameObject);
        }
    }
    public void vector2Point(Vector2 point)
    {
        targetPoint = point;
    }
}
