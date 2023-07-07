using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;
    public Slider volumeSlider;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SetVolume(50);
        PlayMusic();
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (volumeSlider == null)
        {
            volumeSlider = GameObject.Find("Volume").GetComponent<Slider>();
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        }
    }
    public void PlayMusic()
    {
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    void OnVolumeChanged(float volume)
    {
        SetVolume(volume);
    }

}