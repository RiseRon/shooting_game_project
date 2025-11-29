using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Stage1BossPatternBulletMove : MonoBehaviour
{
    public float moveSpeed;
    private float returnSpeed;
    private Vector2 targetPoint;
    private Transform bossTransform;
    private float HealHP = -20;
    private float direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject PlayerObject = GameObject.FindWithTag("Boss"); // 보스 찾기

        if (PlayerObject != null)
        {
            bossTransform = PlayerObject.transform; // 보스의 포지션 값 받기
        }
        direction = Vector3.Distance(transform.position, targetPoint);
        SetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void SetPosition()
    {
        while (true)
        {
            if (direction > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);
            }
            else if (direction <= 0.01f)
            {
                transform.position = targetPoint;
                returnSpeed = Vector3.Distance(transform.position, bossTransform.position) / 25;
                break;
            }
        }
    }
    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, bossTransform.position, returnSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss"))
        {
            Stage1BossAI bossAI = other.GetComponent<Stage1BossAI>();
            if (bossAI != null)
            {
                bossAI.EndPattern();
                BossHP bossHP = other.GetComponent<BossHP>();
                bossHP.TakeDamage(HealHP);
                Destroy(gameObject);
            }
        }
    }
    public void vector2Point(Vector2 point)
    {
        targetPoint = point;
    }
}
