using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FPS/Footstep Audio Date")]
public class FootstepAudioData : ScriptableObject
{
    public List<FootstepAudio> FootstepAudios = new List<FootstepAudio>();
}

[System.Serializable]
public class FootstepAudio
{
    public string Tag;
    public List<AudioClip> AudioClips = new List<AudioClip>();//音频
    public float Delay;
}
