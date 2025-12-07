using UnityEditor.SearchService;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource bgmAudioSource;
    private AudioSource sfxAudioSource;

    // 볼륨 단계를 저장할 변수 (0, 1, 2)
    private int currentVolumeLevel = 2;
    private const string GlobalVolumeKey = "GlobalVolumeLevel";

    private readonly float[] VolumeMap = { 0.0f, 0.5f, 1.0f };

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            bgmAudioSource = gameObject.AddComponent<AudioSource>();
            sfxAudioSource = gameObject.AddComponent<AudioSource>();

            // BGM 설정: 반복 재생 및 3D 사운드 효과 제거
            bgmAudioSource.loop = true;
            bgmAudioSource.spatialBlend = 0f;

            // SFX 설정: 반복 재생 안함
            sfxAudioSource.loop = false;
            sfxAudioSource.spatialBlend = 0f;

            currentVolumeLevel = PlayerPrefs.GetInt(GlobalVolumeKey, 2);

            ApplyVolume(currentVolumeLevel);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlayBGM(AudioClip clip)
    {
        if (clip == null) return;

        // 같은 Clip이 재생 중 이라면 즉시 함수 종료
        if (bgmAudioSource.isPlaying && bgmAudioSource.clip == clip)
        {
            return;
        }

        // 새로운 Clip이거나 재생 중이 아니라면, 현재 재생 멈춤
        if (bgmAudioSource.isPlaying)
        {
            bgmAudioSource.Stop();
        }

        // 새롭게 클립을 설정하고 재생
        bgmAudioSource.clip = clip;
        bgmAudioSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;

        // 현재 재생 중인 SFX에 영향을 주지 않고 추가 재생
        sfxAudioSource.PlayOneShot(clip);
    }

    // BGM 및 SFX의 볼륨을 레벨에 따라 일괄 적용
    private void ApplyVolume(int level)
    {
        if(level < 0 || level > 2) 
            level = 2;

        currentVolumeLevel = level;
        float volume = VolumeMap[level];

        if(bgmAudioSource != null) bgmAudioSource.volume = volume;
        if(sfxAudioSource != null) sfxAudioSource.volume = volume;

        PlayerPrefs.SetInt(GlobalVolumeKey, level);
        PlayerPrefs.Save();
    }

    // UI 버튼 클릭 시 호출, 볼륨 레벨 순환 변경
    public void ToggleGlobalVolume()
    {
        int nextLevel = currentVolumeLevel - 1;

        if (nextLevel < 0)
        {
            nextLevel = 2;
        }

        ApplyVolume(nextLevel);
    }

    // 외부에서 currentVolumeLevel 에 접근할 수 있는 함수
    public int GetCurrentVolumeLevel()
    {
        return currentVolumeLevel;
    }
}
