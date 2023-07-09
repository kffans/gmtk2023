using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    private AudioSource audioSource;
    public Slider volumeSlider;
    public AudioClip[] musicsToPlay;
    public static string stateToPlay = "Menu";

    void Awake()
    {
        
        audioSource = GetComponent<AudioSource>();
        SetVolume(50);
        PlayMusic("Menu");
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
        PlayMusic(SceneManager.GetActiveScene().name);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("dupa");
        if (scene.name == "Menu")
        {
            PlayMusic("Menu");
        }
        else if (scene.name == "Cave")
        {
            PlayMusic("Cave");
        }
        else if (scene.name == "Fight")
        {
            PlayMusic("Fight");
        }
    }

    public void PlayMusic(string state)
    {
        if(state == "Menu")
        {
            audioSource.clip = musicsToPlay[0];
            audioSource.Play();
        }
        if(state == "Cave")
        {
            audioSource.clip = musicsToPlay[1];
            audioSource.Play();
        }
        if(state == "Fight")
        {
            audioSource.clip = musicsToPlay[2];
            audioSource.Play();
        }

        
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