using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIManager_Game : MonoBehaviour
{
    private SoundPlayer soundPlayer;
    private Slider bossHPBar;
    private Image playerHP;
    private Sprite[] playerHPImage;
    private Color playerColor;
    public static UIManager_Game Instance { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        // 씬에 GameManager가 이미 존재하는지 확인합니다.
        if (Instance != null && Instance != this)
        {
            // 이미 다른 인스턴스가 있다면, 현재 인스턴스를 파괴하여 중복 생성을 막습니다.
            Destroy(gameObject);
            return;
        }

        // 현재 인스턴스를 static 변수에 할당합니다.
        Instance = this;
        
        // 씬이 바뀌어도 이 오브젝트가 파괴되지 않도록 설정합니다.
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void UIReset(float bossMaxHP)
    {
        soundPlayer = FindFirstObjectByType<SoundPlayer>();
        GameObject bossHP = GameObject.FindWithTag("BossHP");
        if (bossHP != null)
        {
            bossHPBar = bossHP.GetComponent<Slider>();
        }
        GameObject player = GameObject.FindWithTag("PlayerHP");
        if (player != null)
        {
            playerHP = player.GetComponent<Image>();
        }
        playerHPImage = new Sprite[]
        {
            Resources.Load<Sprite>("Image/Player/HP/Heart_0"),
            Resources.Load<Sprite>("Image/Player/HP/Heart_1"),
            Resources.Load<Sprite>("Image/Player/HP/Heart_2"),
            Resources.Load<Sprite>("Image/Player/HP/Heart_3")
        };
        if (playerHP != null)
        {
            playerColor = playerHP.color;
        }
        playerHP.sprite = Resources.Load<Sprite>("Image/Player/HP/Heart_3");
        bossHPBar.maxValue = bossMaxHP;
        bossHPBar.value = bossMaxHP;
    }
    public void ChangeBossHP(float change) // 채력 변경 함수
    {
        bossHPBar.value = change; // 채력 변경
        if (soundPlayer != null)
            soundPlayer.BossHitSFX();

    }
    public void ChangePlayerHP(int change) // 채력 변경 함수
    {
        playerHP.sprite = playerHPImage[change]; // 채력 변경
        playerColor.g = 0.5f;
        playerColor.b = 0.5f;
        playerHP.color = playerColor;
        Invoke("PlayerDamaged", 0.3f);
        if (soundPlayer != null)
            soundPlayer.PlayerHitSFX();
        
    }
    private void PlayerDamaged()
    {
        playerColor.g = 1;
        playerColor.b = 1;
        if(playerHP != null)
        {
            playerHP.color = playerColor;
        }
    }
}
