using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip music;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.instance.PlayMusic(music, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
