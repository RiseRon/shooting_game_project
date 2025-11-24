using UnityEngine;

public abstract class BossAI_Base : MonoBehaviour
{

    public abstract void CheckForPattern(float nowBossHP);
    public abstract void BossDie();
}
