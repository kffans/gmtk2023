using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    private AudioSource audioSource;
    public Slider volumeSlider;
    
    void Awake()
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

    public static void PlaySound(string soundName)
    {
        AudioClip resourceSound = Resources.Load<AudioClip>($"Audio/Sounds/{soundName}");
        if (resourceSound != null)
        {
            AudioSource.PlayClipAtPoint(resourceSound, Vector3.zero);
        }
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