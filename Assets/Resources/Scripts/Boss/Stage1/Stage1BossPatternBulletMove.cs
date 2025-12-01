using UnityEngine;

public class Stage1BossPatternBulletMove : MonoBehaviour
{
    public float moveSpeed;
    private float returnSpeed;
    public Vector2 targetPoint;
    private Transform bossTransform;
    private float HealHP = -20;
    private float direction;
    private bool OnOff = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        BossHP bossObject = FindAnyObjectByType<BossHP>();
        if (bossObject != null)
        {
            bossTransform = bossObject.transform; // 보스의 포지션 값 받기
        }
        direction = Vector3.Distance(transform.position, targetPoint);
        SetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (OnOff)
        {
            SetPosition();
        }
        else
        {
            Move();
        }
        
    }
    private void SetPosition()
    {
        if (direction > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);
            direction = Vector3.Distance(transform.position, targetPoint);
        }
        else if (direction <= 0.01f)
        { 
            transform.position = targetPoint;
            returnSpeed = Vector3.Distance(transform.position, bossTransform.position) / 25;
            OnOff = false;
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
}
