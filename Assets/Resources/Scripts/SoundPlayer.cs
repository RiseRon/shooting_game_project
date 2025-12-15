using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip sceneBGM;
    public AudioClip uiClickSFX;

    public AudioClip playerAttackSFX;
    public AudioClip playerHitSFX;
    public AudioClip playerSkillSFX;

    public AudioClip bossAttackSFX;
    public AudioClip bossHitSFX;
    public AudioClip bossSkill_1SFX;

    private void Start()
    {
        if (sceneBGM != null)
        {
            SoundManager.instance.PlayBGM(sceneBGM);
        }
    }

    public void UIClickSFX()
    {
        if(uiClickSFX != null)
        {
            SoundManager.instance.PlaySFX(uiClickSFX);
        }
    }

    public void PlayerAttackSFX()
    {
        if (playerAttackSFX != null)
        {
            SoundManager.instance.PlaySFX(playerAttackSFX);
        }
    }
    public void PlayerHitSFX()
    {
        if (playerHitSFX != null)
        {
            SoundManager.instance.PlaySFX(playerHitSFX);
        }
    }
    public void PlayerSkillSFX()
    {
        if (playerSkillSFX != null)
        {
            SoundManager.instance.PlaySFX(playerSkillSFX);
        }
    }

    public void BossAttackSFX()
    {
        if (bossAttackSFX != null)
        {
            SoundManager.instance.PlaySFX(bossAttackSFX);
        }
    }
    public void BossHitSFX()
    {
        if (bossHitSFX != null)
        {
            SoundManager.instance.PlaySFX(bossHitSFX);
        }
    }
    public void BossSkill_1SFX()
    {
        if (bossSkill_1SFX != null)
        {
            SoundManager.instance.PlaySFX(bossSkill_1SFX);
        }
    }
}
