using UnityEditor;
using UnityEngine;

public class PetternBulletHP : MonoBehaviour
{
    private float HP = 1f;
    private HyunMooPattern bossPattern;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject bossObject = GameObject.FindWithTag("Boss");
        bossPattern = bossObject.GetComponent<HyunMooPattern>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (HP > 0)
            {
                HP--;
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
