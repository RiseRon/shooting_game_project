using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{

    private UIManager_Result uiManager;
    private SoundPlayer soundPlayer;

    void Start()
    {
        uiManager = FindFirstObjectByType<UIManager_Result>();
        soundPlayer = FindFirstObjectByType<SoundPlayer>();

    }

    public void OnClickClose()
    {
        if (uiManager != null)
        {
            uiManager.CloseScene();
        }
        if (soundPlayer != null)
        {
            soundPlayer.UIClickSFX();
        }
    }

    public void OnClickRetry()
    {
        if (uiManager != null)
        {
            uiManager.RetryGame();
        }
        if (soundPlayer != null)
        {
            soundPlayer.UIClickSFX();
        }
    }
}
