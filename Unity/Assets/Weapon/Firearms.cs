using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Weapon
{
    public abstract class Firearms : MonoBehaviour, IWeapon
    {
        public Camera EyeCamera;//倍镜
        
        public Transform MuzzlePoint;
        public Transform CasingPoint;

        public ParticleSystem MuzzleParticle;
        public ParticleSystem CasingParticle;

        public AudioSource FirearmsShootingAudioSource;//播放开枪声音
        public AudioSource FirearmsReloadAudioSource;//播放换子弹声音
        public FirearmsAudioDate FirearmsAudioDate;

        public float FireRate;

        public int AmmoInMag = 30;
        public int MaxAmmoCarried = 120;
        public GameObject BulletPrefab;

        protected int CurrentAmmo;
        protected int CurrentMaxAmmoCarried;
        protected float LastFireTime;
        protected Animator GunAnimator;
        protected AnimatorStateInfo GunStateInfo;
        protected float OriginFOV;//缓存倍镜大小
        protected bool IsAiming;//是否按下鼠标右键

        protected virtual void Start()
        {
            CurrentAmmo = AmmoInMag;
            CurrentMaxAmmoCarried = MaxAmmoCarried;
            GunAnimator = GetComponent<Animator>();
            OriginFOV = EyeCamera.fieldOfView;
        }


        public void DoAttack()
        {
            Shooting();

        }

        protected abstract void Shooting();
        protected abstract void Reload();
        protected abstract void Aim();

        protected bool IsAllowShooting()
        {
            
            return Time.time - LastFireTime > 1 / FireRate;
        }

        
    }
}

