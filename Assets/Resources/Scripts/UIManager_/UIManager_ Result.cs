using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManager_Result : MonoBehaviour
{
    
    void Start()
    {
        
    }

    public void CloseScene()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void RetryGame()
    {
        //SceneManager.LoadScene();
    }

}
