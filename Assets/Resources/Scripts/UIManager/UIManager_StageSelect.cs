using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager_StageSelect : MonoBehaviour
{
    private int selectStage = 0;

    public void SelectStage(int selectNumber)
    {
        selectStage = selectNumber;
        Debug.Log($"selectStage : {selectStage}");
    }

    public void StartGame()
    {
        string stageName = "Stage" + selectStage;
        if (selectStage == 0)
        {
            Debug.Log($"스테이지를 선택하세요");
        }
        else if (selectStage != 0)
        {
            SceneManager.LoadScene(stageName);
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
