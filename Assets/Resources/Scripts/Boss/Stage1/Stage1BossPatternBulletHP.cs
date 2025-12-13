using UnityEngine;

public class Stage1BossPatternBulletHP : MonoBehaviour
{
    public float hp;
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
            if (hp > 0)
            {
                hp -= bulletMove.damage;
                GameObject newObject = Instantiate(bulletMove.effect, other.transform.position, other.transform.rotation);
                EffectTime effectTime = newObject.GetComponent<EffectTime>();
                effectTime.effectTime = 0.1f;
                Destroy(other.gameObject);
            }
            if (hp <= 0)
            {
                bossPattern.PatternEndCheck();
                Destroy(gameObject);
            }
        }
    }
}
