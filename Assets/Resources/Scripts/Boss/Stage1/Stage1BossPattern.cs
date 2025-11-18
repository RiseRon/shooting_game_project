using UnityEngine;

public class Stage1BossPattern : MonoBehaviour
{
    public GameObject patternBullet;
    private Vector2[] patternPoint;
    private int endCheck = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PatternStart()
    {
        patternPoint = new Vector2[]
        {
            new Vector2(150, 150),
            new Vector2(150, 0),
            new Vector2(150, -150)
        };
        Vector2 bulletPo = new Vector2(transform.position.x - 160, transform.position.y);
        for (int i = 0; i < patternPoint.Length; i++)
        {

            GameObject newObject = Instantiate(patternBullet, bulletPo, transform.rotation);
            newObject.name = "PetternBullet_" + i;
            Stage1BossPatternBulletMove pettern = newObject.GetComponent<Stage1BossPatternBulletMove>();
            if (pettern != null)
            {
                pettern.vector2Point(patternPoint[i]);
            }

        }
        endCheck = 3;
    }
    public void PatternEndCheck()
    {
        endCheck--;
        if (endCheck == 0)
        {
            Stage1BossAI bossAI = GetComponent<Stage1BossAI>();
            bossAI.EndPattern();
        }
    }
}
