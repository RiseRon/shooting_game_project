using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager_StageSelect : MonoBehaviour
{

    public void LoadStage(int stageNumber)
    {
        string stageName = "Stage" + stageNumber;
        SceneManager.LoadScene(stageName);  
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
