using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    private AudioSource audioSource;
    private static AudioSource AAudioSource;
    public Slider volumeSlider;
    public AudioClip[] musicsToPlay;
	public static AudioClip[] MusicsToPlay;
    public static string stateToPlay = "Menu";

    void Awake()
    {
        
        audioSource = GetComponent<AudioSource>();
        SetVolume(50);
		MusicsToPlay = musicsToPlay;
		AAudioSource = audioSource;
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (volumeSlider == null && Event.isPaused)
        {
            volumeSlider = GameObject.Find("Volume").GetComponent<Slider>();
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        }
    }

    public static void PlayMusic(int id)
    {
        AAudioSource.clip = MusicsToPlay[id];
        AAudioSource.Play();
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