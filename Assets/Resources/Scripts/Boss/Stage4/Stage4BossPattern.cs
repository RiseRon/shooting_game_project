using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class Stage4BossPattern : MonoBehaviour
{
    public GameObject lightHorizontalWarning;
    public GameObject lightVerticalWarning;
    private Vector2 position;
    public int CheckTime;
    private bool OnOff;
    private Stage4BossAI bossAI;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossAI = GetComponent<Stage4BossAI>();
        animator = GetComponent<Animator>();
        animator.speed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (OnOff)
        {
            if (CheckTime <= 3)
            {
                PatternNext();
                OnOff = false;
            }
        }
        else
        {
            if (CheckTime <= 0)
            {
                bossAI.EndPattern();
            }
        }
    }
    public void PatternStart()
    {
        animator.SetTrigger("Pattern");
        OnOff = true;
        CheckTime = 5;
        position = new Vector2(0, 140);
        for ( int i = 0;  i < 2; i++ )
        {
            GameObject HorWarning = Instantiate(lightHorizontalWarning, position, transform.rotation);
            position.y *= -1;
        }
        animator.SetTrigger("Return");
    }
    public void PatternNext()
    {
        animator.SetTrigger("Pattern");
        position = new Vector2(-500, 0);
        for (int i = 0; i < 3; i++)
        {
            GameObject VerWarning = Instantiate(lightVerticalWarning, position, transform.rotation);
            position.x += 350;
        }
        animator.SetTrigger("Return");
    }
}
