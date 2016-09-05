using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioSource[] music_ambiant;
    
    public AudioSource effect_jump;
    public AudioSource effect_death;
    public AudioSource effect_hit;
    public AudioSource effect_arrow;
    public AudioSource effect_win;

    int currentMusicIndex = 0;

	void OnEnable()
    {
        EventManager.StartListening("jump", PlayJumpSound);
        EventManager.StartListening("change", ChangeAmbiantMusic);
        EventManager.StartListening("kill", PlayDeathSound);
        EventManager.StartListening("hit", PlayHitSound);
        EventManager.StartListening("arrow", PlayArrowSound);
        EventManager.StartListening("win", PlayWinSound);

        foreach (AudioSource audio in music_ambiant)
        {
            audio.mute = true;
            audio.Play();
        }
        music_ambiant[0].mute = false;
    }

    void ChangeAmbiantMusic()
    {
        music_ambiant[currentMusicIndex].mute = true;

        currentMusicIndex++;
        if (currentMusicIndex >= music_ambiant.Length)
            currentMusicIndex = 0;

        music_ambiant[currentMusicIndex].mute = false;
    }

    void PlayJumpSound()
    {
        effect_jump.Play();
    }

    void PlayDeathSound()
    {
        effect_death.Play();
    }
    void PlayHitSound()
    {
        //effect_hit.Play();
    }
    void PlayArrowSound()
    {
        effect_arrow.Play();
    }

    void PlayWinSound()
    {
        effect_win.Play();
    }
}
