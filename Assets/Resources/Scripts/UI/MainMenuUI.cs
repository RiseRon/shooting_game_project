using UnityEngine;

public class MainMenuUI : MonoBehaviour
{

    private UIManager_MainMenu uiManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiManager = FindObjectOfType<UIManager_MainMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStart()
    {
        if (uiManager != null)
        {
            uiManager.StartGame();
        }
    }

    public void OnClickExit()
    {
        if (uiManager != null)
        {
            uiManager.ExitGame();
        }
    }
}
