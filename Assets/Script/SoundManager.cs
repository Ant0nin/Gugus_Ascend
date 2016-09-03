using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioSource[] music_ambiant;
    
    public AudioSource effect_jump;

    int currentMusicIndex = 0;

	void OnEnable()
    {
        EventManager.StartListening("jump", PlayJumpSound);
        EventManager.StartListening("change", ChangeAmbiantMusic);
        music_ambiant[currentMusicIndex].Play();
    }

    void PlayJumpSound()
    {
        effect_jump.Play();
    }

    void ChangeAmbiantMusic()
    {
        music_ambiant[currentMusicIndex].Pause();

        currentMusicIndex++;
        if (currentMusicIndex >= music_ambiant.Length)
            currentMusicIndex = 0;

        music_ambiant[currentMusicIndex].Play();
    }
}
