using UnityEngine;

public class Stage3BossAI : BossAI_Base
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void CheckForPattern(float nowBossHP)
    {

    }
    public override void BossDie()
    {
        GameManager.Instance.currentState = GameManager.GameState.GameClear;
    }
}
