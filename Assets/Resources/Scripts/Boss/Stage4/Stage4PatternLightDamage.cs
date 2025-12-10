using UnityEngine;

public class Stage4PatternLightDamage : MonoBehaviour
{
    private Stage4BossPattern bossPattern;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject boss = GameObject.FindWithTag("Boss");
        bossPattern = boss.GetComponent<Stage4BossPattern>();
        Invoke("DestroyObject", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Palayer"))
        {
            UIManager_Game.Instance.ChangePlayerHP(0);
            GameManager.Instance.currentState = GameManager.GameState.GameOver;
        }
    }
    private void DestroyObject()
    {
        bossPattern.CheckTime -= 1;
        Destroy(gameObject);
    }
}
