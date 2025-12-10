using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private int selectedStage = 0;
    private int lastSelectedStage = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void LoadStageSelectScene()
    {
        SceneManager.LoadScene("StageSelect");
        selectedStage = 0;
    }

    public void ExitGame()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }

    // 보스선택 씬 기능
    public void SelectStage(int selectIndex)
    {
        selectedStage = selectIndex;
        Debug.Log($"selectStage : {selectedStage}");
    }

    public void LoadGameStage()
    {
        if (selectedStage == 0)
        {
            Debug.Log($"스테이지를 선택하세요");
            return;
        }

        lastSelectedStage = selectedStage;

        string stageName = "Stage" + selectedStage;

        SceneManager.LoadScene(stageName);
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // 결과 씬 기능
    public void RetryGame()
    {
        SceneManager.LoadScene("Stage" + lastSelectedStage);
    }
}
