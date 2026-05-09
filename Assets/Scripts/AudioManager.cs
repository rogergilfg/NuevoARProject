using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private GameObject prefabSFX;
    [SerializeField] private GameObject prefabMusic;

    private AudioSource music;
    private float volumeLevel;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        music = gameObject.AddComponent<AudioSource>();
    }


    public void PlayMusic(AudioClip _music, float _volumeLevel)
    {
        music.clip = _music;
        music.volume = _volumeLevel;
        music.Play();
        music.loop = true;
    }

    public void StopMusic()
    {
        music.Stop();
    }

    public void PlaySFX(AudioClip _sfx, float _volumeLevel, bool _loop, Vector3 _position)
    {
        GameObject sfxClone = Instantiate(prefabSFX, _position, Quaternion.identity);
        sfxClone.GetComponent<AudioSource>().clip = _sfx;
        sfxClone.GetComponent<AudioSource>().volume = _volumeLevel;
        sfxClone.GetComponent<AudioSource>().Play();
        sfxClone.GetComponent<AudioSource>().loop = _loop;
        
        if(_loop == false)
        {
            Destroy(sfxClone, _sfx.length);
        }
        else
        {
            Destroy(sfxClone, 5f);
        }    
    }
}
