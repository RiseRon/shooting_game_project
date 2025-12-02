using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 1. static 변수: 어디서든 접근할 수 있는 단일 인스턴스
    public static GameManager Instance { get; private set; }


    // 게임 상태 (예시)
    public enum GameState { Playing, GameOver, GameClear }
    public GameState currentState;

    // **[싱글톤 초기화 로직]**
    private void Awake()
    {
        // 씬에 GameManager가 이미 존재하는지 확인합니다.
        if (Instance != null && Instance != this)
        {
            // 이미 다른 인스턴스가 있다면, 현재 인스턴스를 파괴하여 중복 생성을 막습니다.
            Destroy(gameObject);
            return;
        }

        // 현재 인스턴스를 static 변수에 할당합니다.
        Instance = this;
        
        // 씬이 바뀌어도 이 오브젝트가 파괴되지 않도록 설정합니다.
        DontDestroyOnLoad(gameObject);

        // 초기 상태 설정
        currentState = GameState.Playing;
        Debug.Log("게임 매니저 초기화 완료.");
    }
    void Update()
    {
        switch (currentState)
        {
            case GameState.Playing:

                break;
            case GameState.GameOver:
                SceneManager.LoadScene("Defeat");
                break;
            case GameState.GameClear:
                SceneManager.LoadScene("Victory");
                break;

        }
    }
}
