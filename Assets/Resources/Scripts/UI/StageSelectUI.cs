using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectUI : MonoBehaviour
{

    private UIManager_StageSelect uiManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiManager = FindFirstObjectByType<UIManager_StageSelect>();
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
    }

    public void OnClickStart()
    {
        if (uiManager != null)
        {
            uiManager.StartGame();
        }
    }

    public void OnClickBack()
    {
        if (uiManager != null)
        {
            uiManager.BackToMainMenu();
        }
    }
}
