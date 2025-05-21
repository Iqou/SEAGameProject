using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    [Header("---------- Audio Souce ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip walking;
    public AudioClip attackhit;
    public AudioClip playergethit;
    public AudioClip pickitem;
    public AudioClip bowcharge;
    public AudioClip bowshoot;
    public AudioClip orcattack;
    public AudioClip orcgethit;
    public AudioClip talksound1;
    public AudioClip talksound2;
    public AudioClip talksound3;
    public AudioClip talksound4;
    public AudioClip talksound5;


    private void Start(){
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
