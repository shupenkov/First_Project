using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/DoorSounds")]
public class ListSounds : ScriptableObject
{
    [SerializeField] private AudioField[] audioField;

    public AudioClip GetAudioClipByType(AudioType audioType)
    {
        return audioField.First(x => x.audioType == audioType).audioClip;
    }
}

public enum AudioType
{
    OpenDoor, CloseDoor, LockDoor, MainMenu, GameSound, StreetSound
}

[Serializable]
public class AudioField
{
    public AudioType audioType;
    public AudioClip audioClip;
}
