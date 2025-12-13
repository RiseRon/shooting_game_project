using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    private int HP = 3; // Ã¼·Â
    private Sprite[] playerSprite;
    private SpriteRenderer player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<SpriteRenderer>();
        playerSprite = new Sprite[]
        {
            Resources.Load<Sprite>("Image/Player/Player"),
            Resources.Load<Sprite>("Image/Player/PlayerDamaged")
        };
        HP = 3;
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
                player.sprite = playerSprite[1];
                Invoke("PlayerDamaged", 0.3f);
                Destroy(other.gameObject);
            }
            if (HP <= 0)
            {
                GameManager.Instance.currentState = GameManager.GameState.GameOver;
            }
        }
    }
    private void PlayerDamaged()
    {
        player.sprite = playerSprite[0];
    }
}
