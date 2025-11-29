using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    private int HP = 3; // Ã¤·Â
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BossBullet"))
        {
            if (HP > 0)
            {
                HP--;
                UIManager_Game.Instance.ChangePlayerHP(HP);
                Destroy(other.gameObject);
            }
            if (HP <= 0)
            {
                GameManager.Instance.currentState = GameManager.GameState.GameOver;
            }
        }
    }
}
