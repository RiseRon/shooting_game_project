using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public int selectedStage = 0;
    private int lastSelectedStage = 0;
        
    public int clearedStage = 0;
    private void Awake()
    {
        // PlayerPrefs = 컴퓨터에 영구적으로 남아있는 데이터
        // 플레이어프레프스에 저장된 ClearedStage 삭제 (클리어된 스테이지 유지하고 싶으면 주석처리)
        PlayerPrefs.DeleteKey("ClearedStage");

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);

            clearedStage = PlayerPrefs.GetInt("ClearedStage", 0);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // --- 씬 이동 관련 ---

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
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

    // --- 스테이지 선택 및 게임 시작 ---
    public void SelectStage(int selectIndex)
    {
        if (selectIndex > clearedStage + 1)
        {
            Debug.Log($"잠긴 스테이지");
            return;
        }
        
        selectedStage = selectIndex;
        Debug.Log($"selectedStage : {selectedStage}");
    }

    public void LoadGameStage()
    {
        if (selectedStage == 0)
        {
            Debug.Log($"스테이지를 선택하세요");
            return;
        }

        if (selectedStage > clearedStage + 1)
        {
            return;
        }

        lastSelectedStage = selectedStage;

        string stageName = "Stage" + selectedStage;
        SceneManager.LoadScene(stageName);
    }

    // --- 결과 화면 및 데이터 저장 ---
    public void ClearStage() // Victory 씬에서 호출할 함수
    {
        if (lastSelectedStage > clearedStage)
        {
            clearedStage = lastSelectedStage;

            PlayerPrefs.SetInt("ClearedStage", clearedStage);
            PlayerPrefs.Save();
        }
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("Stage" + lastSelectedStage);
    }

}
