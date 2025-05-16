using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Для доступа из других скриптов
    public AudioSource musicSource;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject); // Чтобы музыка не прерывалась при загрузке сцен
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }
}