using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public float fadeSpeed;

    [SerializeField]
    private bool playOnStart;
    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private AudioClip music;

    private float maxVolume;
    // Start is called before the first frame update
    void Start()
    {
        if (playOnStart)
            FadeMusicIn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeMusicIn()
    {
        maxVolume = musicSource.volume;
        musicSource.clip = music;
        StartCoroutine(FadingMusic(0, maxVolume));
    }

    public void FadeMusicOut()
    {
        StartCoroutine(FadingMusic(musicSource.volume, 0));
    }

    IEnumerator FadingMusic(float startVolume, float endVolume)
    {
        musicSource.volume = startVolume;
        musicSource.Play();
        while (!Mathf.Approximately(musicSource.volume, endVolume))
        {
            yield return new WaitForEndOfFrame();
            musicSource.volume = Mathf.MoveTowards(musicSource.volume, endVolume, fadeSpeed * Time.deltaTime);
        }
    }
}
