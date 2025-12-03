using UnityEditor.SearchService;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource bgmAudioSource;
    private AudioSource sfxAudioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            bgmAudioSource = gameObject.AddComponent<AudioSource>();
            sfxAudioSource = gameObject.AddComponent<AudioSource>();

            //BGM 설정: 반복 재생 및 3D 사운드 효과 제거
            bgmAudioSource.loop = true;
            bgmAudioSource.spatialBlend = 0f;

            //SFX 설정: 반복 재생 안함
            sfxAudioSource.loop = false;
            sfxAudioSource.spatialBlend = 0f;
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
        if(bgmAudioSource.isPlaying && bgmAudioSource.clip == clip)
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
}
