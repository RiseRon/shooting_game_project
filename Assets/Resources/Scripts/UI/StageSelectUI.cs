using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectUI : MonoBehaviour
{

    private UIManager_StageSelect uiManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiManager = FindObjectOfType<UIManager_StageSelect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStage(int stageNumber)
    {
        if (uiManager != null)
        {
            SceneManager.LoadScene(stageNumber);
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
