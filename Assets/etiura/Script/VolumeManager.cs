using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : SingletonBase<VolumeManager>
{

    public enum VolumeType { MASTER, BGM, SE }
  

    public void OnValueChanged(VolumeType volumeType, float volume)
    {
        switch (volumeType)
        {
            case VolumeType.MASTER:
                AudioListener.volume = volume;
                break;
            case VolumeType.BGM:
               SoundManager.Instance.BGM.volume = volume;
                break;
            case VolumeType.SE:
                SoundManager.Instance.GameClear.volume = volume;
                SoundManager.Instance.GameOver.volume = volume;
                SoundManager.Instance.Click.volume = volume;
                SoundManager.Instance.coinGet.volume = volume;
                break;
        }
    }
}
