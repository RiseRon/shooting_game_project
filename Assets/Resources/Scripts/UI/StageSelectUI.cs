using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectUI : MonoBehaviour
{

    private UIManager uiManager;
    private SoundPlayer soundPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiManager = FindFirstObjectByType<UIManager>();
        soundPlayer = FindFirstObjectByType<SoundPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStage(int selectIndex)
    {
        if (uiManager != null)
        {
            uiManager.SelectStage(selectIndex);
        }
        if (soundPlayer != null)
        {
            soundPlayer.UIClickSFX();
        }
    }

    public void OnClickStart()
    {
        if (uiManager != null)
        {
            uiManager.LoadGameStage();
        }
        if (soundPlayer != null)
        {
            soundPlayer.UIClickSFX();
        }
    }

    public void OnClickBack()
    {
        if (uiManager != null)
        {
            uiManager.LoadMainMenuScene();
        }
        if (soundPlayer != null)
        {
            soundPlayer.UIClickSFX();
        }
    }
}
