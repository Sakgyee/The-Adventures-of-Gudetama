using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;
using UnityEngine.UI;
public class Sound : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider audioSlider;
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
    }
    public void BGMControl()
    {
        float sound = audioSlider.value;

        // -40에서 -80을 설정한 이유는 음소거 효과를 내기 위함이다.
        if (sound == -40f) masterMixer.SetFloat("BGM", -80);
        else masterMixer.SetFloat("BGM", sound);
    }
    public void EffectControl()
    {
        float sound1 = audioSlider.value;

        // -40에서 -80을 설정한 이유는 음소거 효과를 내기 위함이다.
        if (sound1 == -40f) masterMixer.SetFloat("SoundEffect", -80);
        else masterMixer.SetFloat("SoundEffect", sound1);
    }
  public void ToggleAudioVolume()
    {
        // Audio에 입력받는 쪽(AudioListener)이 볼륨이 줄이는것이다.
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}
