using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    private int HP; // Ã¤·Â
    public int maxHP = 3;
    private Sprite[] playerHPImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HP = maxHP;
        playerHPImage = new Sprite[]
        {
            Resources.Load<Sprite>("Assets/Image/heart_0"),
            Resources.Load<Sprite>("Assets/Image/heart_1"),
            Resources.Load<Sprite>("Assets/Image/heart_2"),
            Resources.Load<Sprite>("Assets/Image/heart_3")
        };
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
                GameManager.Instance.ChangePlayerHP(playerHPImage[HP]);
                Destroy(other.gameObject);
            }
            if (HP <= 0)
            {
                GameManager.Instance.currentState = GameManager.GameState.GameOver;
            }
        }
    }
}
