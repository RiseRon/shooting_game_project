using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip sceneBGM;

    public AudioClip uiClickSFX;
    public AudioClip playerAttackSFX;

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
}
