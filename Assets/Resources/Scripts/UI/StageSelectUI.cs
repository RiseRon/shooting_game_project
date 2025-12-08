using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectUI : MonoBehaviour
{

    private UIManager_StageSelect uiManager;
    private SoundPlayer soundPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiManager = FindFirstObjectByType<UIManager_StageSelect>();
        soundPlayer = FindFirstObjectByType<SoundPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStage(int selectNumber)
    {
        if (uiManager != null)
        {
            //SceneManager.LoadScene(stageNumber);
            uiManager.SelectStage(selectNumber);
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
            uiManager.StartGame();
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
            uiManager.BackToMainMenu();
        }
        if (soundPlayer != null)
        {
            soundPlayer.UIClickSFX();
        }
    }
}
