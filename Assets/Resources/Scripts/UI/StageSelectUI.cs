using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectUI : MonoBehaviour
{

    private UIManager uiManager;
    private SoundPlayer soundPlayer;

    public Button[] stageButtons;
    public Sprite lockedSprite; // 잠겨있을 때 보여줄 이미지

    public Sprite[] originalSprites; // 원본 이미지 저장용 배열
    public Sprite[] selectedBossSprites; // 선택 이미지 저장용 배열

    void Start()
    {
        uiManager = FindFirstObjectByType<UIManager>();
        soundPlayer = FindFirstObjectByType<SoundPlayer>();

        // 원본 이미지 저장
        if (stageButtons != null)
        {
            originalSprites = new Sprite[stageButtons.Length];
            for (int i = 0; i < stageButtons.Length; i++)
            {
                if (stageButtons[i] != null)
                    originalSprites[i] = stageButtons[i].image.sprite;
            }
        }

        // 현재 클리어 정보에 따라 잠금 상태 업데이트
        UpdateStageLockState();
    }

    private void UpdateStageLockState()
    {
        if (uiManager == null)
        {
            return;
        }

        int clearedStage = uiManager.clearedStage;
        int currentSelectedStage = uiManager.selectedStage;

        for (int i = 0; i < stageButtons.Length; i++)
        {
            int stageNumber = i + 1;

            if (stageNumber <= clearedStage + 1)
            {
                // 잠금 해제
                stageButtons[i].interactable = true;

                if (stageNumber == currentSelectedStage)
                {
                    if ( i < selectedBossSprites.Length && selectedBossSprites[i] != null)
                    {
                        stageButtons[i].image.sprite = selectedBossSprites[i];
                    }
                }
            }
            else
            {
                // 잠금
                stageButtons[i].interactable = false;
                if (lockedSprite != null)
                    stageButtons[i].image.sprite = lockedSprite;
            }
        }
    }

    public void OnClickStage(int selectIndex)
    {
        if (uiManager != null)
        {
            uiManager.SelectStage(selectIndex);

            UpdateStageLockState();
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
            uiManager.LoadGameStage();
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
            uiManager.LoadMainMenuScene();
        }
        if (soundPlayer != null)
        {
            soundPlayer.UIClickSFX();
        }
    }
}
