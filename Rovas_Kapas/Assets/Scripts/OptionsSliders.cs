using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsSliders : MonoBehaviour
{
   public AudioMixer mainMixer;
   public void SetVolume(float volume)
   {
      mainMixer.SetFloat("MainVolume", volume);
   }
}
