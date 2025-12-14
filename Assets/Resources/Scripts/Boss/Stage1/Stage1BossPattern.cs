using UnityEngine;

public class Stage1BossPattern : MonoBehaviour
{
    public GameObject patternBullet;
    public float moveSpeed = 1000f;
    private float animationSpeed = 0.8f;
    private Vector2[] patternPoint;
    private int endCheck;
    private Animator animator;
    private Collider2D collider2;

    private SoundPlayer soundPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        collider2 = GetComponent<Collider2D>();
        soundPlayer = FindFirstObjectByType<SoundPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PatternStart()
    {

        collider2.offset = new Vector2(0, 0);
        animator.speed = animationSpeed;
        animator.SetTrigger("Pattern");
        patternPoint = new Vector2[]
        {
            new Vector2(150, 150),
            new Vector2(150, 0),
            new Vector2(150, -150)
        };
        Vector2 bulletPo = new Vector2(transform.position.x - 300, transform.position.y + 58);
        for (int i = 0; i < patternPoint.Length; i++)
        {

            GameObject newObject = Instantiate(patternBullet, bulletPo, transform.rotation);
            Stage1BossPatternBulletMove move = newObject.GetComponent<Stage1BossPatternBulletMove>();
            Stage1BossPatternBulletHP hp = newObject.GetComponent<Stage1BossPatternBulletHP>();
            if(hp != null)
            {
               hp.hp = 10f;
            }
            if (move != null)
            {
                move.moveSpeed = moveSpeed;
                move.targetPoint = patternPoint[i];
            }
        }
        endCheck = 3;
    }
    public void PatternEndCheck()
    {
        endCheck--;
        if (endCheck == 0)
        {
            if (soundPlayer != null)
            {
                soundPlayer.BossSkill_1SFX();
            }
            collider2.offset = new Vector2 (-50, 0);
            Stage1BossAI bossAI = GetComponent<Stage1BossAI>();
            animator.SetTrigger("Return");
            bossAI.EndPattern();
        }
    }
}
