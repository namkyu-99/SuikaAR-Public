using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public TMP_InputField nickname;
    public Slider BGM_Slider;
    AudioSource BGM;
    public Slider SE_Slider;
    public AudioSource Pop;

    void Start()
    {
        nickname.text = PlayerPrefs.GetString("Nickname", "Unknown");
        BGM = GameObject.Find("BGM(Clone)").GetComponent<AudioSource>();
        BGM_Slider.value = BGM.volume;
        SE_Slider.value = PlayerPrefs.GetFloat("SE", 1f);
    }

    public void Nickname()
    {
        PlayerPrefs.SetString("Nickname", nickname.text);
    }

    public void BGMControl()
    {
        BGM.volume = BGM_Slider.value;
        PlayerPrefs.SetFloat("BGM", BGM_Slider.value);
    }

    public void SEControl()
    {
        Pop.volume = SE_Slider.value;
        PlayerPrefs.SetFloat("SE", SE_Slider.value);
    }
}
