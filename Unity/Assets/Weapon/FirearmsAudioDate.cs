using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Weapon
{
    [CreateAssetMenu(menuName ="FPS/Firearms Audio Date")]
    public class FirearmsAudioDate :ScriptableObject
    {
        public AudioClip ShootingAudio;
        public AudioClip ReloadLeft;
        public AudioClip ReloadOutOf;
        public AudioClip Ding;
        public AudioClip SpiderDie;
    }
}
