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
		AAudioSource = audioSource;
        SetVolume(50);
		MusicsToPlay = musicsToPlay;
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
        AudioClip resourceSound = Resources.Load<AudioClip>("Audio/Sounds/" + soundName) as AudioClip;
		Debug.Log("bb");
        if (resourceSound != null)
        {
			Debug.Log("aa");
            AudioSource.PlayClipAtPoint(resourceSound, Vector3.zero);
        }
    }

    public static void SetVolume(float volume)
    {
        AAudioSource.volume = volume;
    }

    void OnVolumeChanged(float volume)
    {
        SetVolume(volume);
    }

}