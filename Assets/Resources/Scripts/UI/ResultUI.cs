using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{

    private UIManager uiManager;
    private SoundPlayer soundPlayer;

    void Start()
    {
        uiManager = FindFirstObjectByType<UIManager>();
        soundPlayer = FindFirstObjectByType<SoundPlayer>();

    }

    public void OnClickClose()
    {
        if (uiManager != null)
        {
            uiManager.LoadStageSelectScene();
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
