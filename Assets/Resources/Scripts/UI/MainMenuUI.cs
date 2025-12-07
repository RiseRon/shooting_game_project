using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{

    private UIManager_MainMenu uiManager;
    private SoundPlayer soundPlayer;
    public Image soundButtonImage;
    private Sprite[] volumeSprite;

    void Start()
    {
        uiManager = FindFirstObjectByType<UIManager_MainMenu>();
        soundPlayer = FindFirstObjectByType<SoundPlayer>();

        volumeSprite = new Sprite[]
        {
            Resources.Load<Sprite>("Image/Button/Sound/Volume_0"),
            Resources.Load<Sprite>("Image/Button/Sound/Volume_1"),
            Resources.Load<Sprite>("Image/Button/Sound/Volume_2")
        };

        UpdateSoundButtonImage(SoundManager.instance.GetCurrentVolumeLevel());
    }

    public void OnClickStart()
    {
        if (soundPlayer != null)
        {
            soundPlayer.UIClickSFX();
        }
        if (uiManager != null)
        {
            uiManager.StartGame();
        }
    }

    public void OnClickExit()
    {
        if (soundPlayer != null)
        {
            soundPlayer.UIClickSFX();
        }
        if (uiManager != null)
        {
            uiManager.ExitGame();
        }
    }

    private void UpdateSoundButtonImage(int level)
    {
        if (soundButtonImage != null && level >= 0 && level < volumeSprite.Length)
        {
            soundButtonImage.sprite = volumeSprite[level];
        }
    }
    public void OnClickSound()
    {
        if (soundPlayer != null)
        {
            soundPlayer.UIClickSFX();
        }
        SoundManager.instance.ToggleGlobalVolume();

        int currentLevel = SoundManager.instance.GetCurrentVolumeLevel();

        UpdateSoundButtonImage(currentLevel);
    }
}
