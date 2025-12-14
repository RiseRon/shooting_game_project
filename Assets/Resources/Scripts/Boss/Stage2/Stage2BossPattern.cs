using UnityEngine;

public class Stage2BossPattern : MonoBehaviour
{
    private Stage2BossShoot bossShoot;

    private SoundPlayer soundPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossShoot = GetComponent<Stage2BossShoot>();
        soundPlayer = FindFirstObjectByType<SoundPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PatternStart()
    {
        if (soundPlayer != null)
        {
            soundPlayer.BossSkill_1SFX();
        }
        bossShoot.cooldownTime = 0.5f;
        bossShoot.moveSpeed = 900f;
    }
}
