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

        // -40���� -80�� ������ ������ ���Ұ� ȿ���� ���� �����̴�.
        if (sound == -40f) masterMixer.SetFloat("BGM", -80);
        else masterMixer.SetFloat("BGM", sound);
    }
    public void EffectControl()
    {
        float sound1 = audioSlider.value;

        // -40���� -80�� ������ ������ ���Ұ� ȿ���� ���� �����̴�.
        if (sound1 == -40f) masterMixer.SetFloat("SoundEffect", -80);
        else masterMixer.SetFloat("SoundEffect", sound1);
    }
  public void ToggleAudioVolume()
    {
        // Audio�� �Է¹޴� ��(AudioListener)�� ������ ���̴°��̴�.
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}
