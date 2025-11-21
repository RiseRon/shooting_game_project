using UnityEditor;
using UnityEngine;

public class Stage1BossPatternBulletHP : MonoBehaviour
{
    private float HP = 10f;
    private Stage1BossPattern bossPattern;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject bossObject = GameObject.FindWithTag("Boss");
        bossPattern = bossObject.GetComponent<Stage1BossPattern>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            PlayerBulletMove bulletMove = other.GetComponent<PlayerBulletMove>();
            if (HP > 0)
            {
                HP -= bulletMove.damage;
                Destroy(other.gameObject);
            }
            if (HP <= 0)
            {
                bossPattern.PatternEndCheck();
                Destroy(gameObject);
            }
        }
    }
}
