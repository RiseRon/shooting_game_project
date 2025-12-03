using UnityEngine;

public class MainMenuUI : MonoBehaviour
{

    private UIManager_MainMenu uiManager;
    private SoundPlayer soundPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiManager = FindFirstObjectByType<UIManager_MainMenu>();
        soundPlayer = FindFirstObjectByType<SoundPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
