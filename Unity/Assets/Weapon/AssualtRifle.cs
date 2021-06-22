using Scripts.Weapon;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Weapon
{

    public class AssualtRifle : Firearms 
    {
        public Text BulletAmmo;
        private IEnumerator doAimCoroutine;
        public static int Bulletxx;
        public static bool SpiderDie;
        public int HP;

        protected override void Start()
        {
            base.Start();
            doAimCoroutine = DoAim();
        }
        protected override void Reload()
        {
            //GunAnimator.SetLayerWeight(2, 1);
            
            if (CurrentMaxAmmoCarried == 0)
            {
                GunAnimator.SetTrigger("Reload0");
            }
            else
            {
                GunAnimator.SetTrigger(CurrentAmmo > 0 ? "Reload1" : "Reload2");

                FirearmsReloadAudioSource.clip =
                    CurrentAmmo > 0
                    ? FirearmsAudioDate.ReloadLeft
                    : FirearmsAudioDate.ReloadOutOf;

                FirearmsReloadAudioSource.Play();
                StartCoroutine(CheckReloadAmmoAnimationEnd());

            }
            

        }


        public void BulletMax()
        {
            if (Bulletxx != 0) {
            CurrentMaxAmmoCarried += Bulletxx;
            Bulletxx = 0;
                FirearmsShootingAudioSource.clip = FirearmsAudioDate.Ding;
                FirearmsShootingAudioSource.Play();
            }
        }

        public void spiderDie()
        {
            if (SpiderDie)
            {
                FirearmsShootingAudioSource.clip = FirearmsAudioDate.SpiderDie;
                FirearmsShootingAudioSource.Play();
                SpiderDie = false;
            }
        }



        protected override void Shooting()
        {
            if (CurrentAmmo <= 0) return;
            if (!IsAllowShooting()) return;
            MuzzleParticle.Play();        
            CurrentAmmo -= 1;

            GunAnimator.Play("fire", IsAiming ? 1 : 0, 0);

            FirearmsShootingAudioSource.clip = FirearmsAudioDate.ShootingAudio;
            FirearmsShootingAudioSource.Play();

            CreteBullet();
            CasingParticle.Play();
            LastFireTime = Time.time;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0)) DoAttack();
            if (Input.GetKeyDown(KeyCode.R)) Reload();
            if (Input.GetMouseButtonDown(1))
            {
                IsAiming = true;
                Aim();//瞄准
            }
            if (Input.GetMouseButtonUp(1))
            {
                IsAiming = false;
                Aim();//退出瞄准
            }
            BulletAmmo.text = (CurrentAmmo + "/" + CurrentMaxAmmoCarried);
            BulletMax();
            HP = CurrentMaxAmmoCarried;
        }

   

        protected void CreteBullet()
        {
            GameObject tmp_Bullet = Instantiate(BulletPrefab, MuzzlePoint.position, MuzzlePoint.rotation);
            //var tmp_BulletRigidbody = tmp_Bullet.AddComponent<Rigidbody>();
            //tmp_BulletRigidbody.velocity = tmp_Bullet.transform.forward * 100f;
            
            var tmp_BulletScript = tmp_Bullet.AddComponent<Bullet>();
            tmp_BulletScript.ImpactPraefab = BulletPrefab;
            tmp_BulletScript.BulletSpeed = 100; 
        }

        private IEnumerator CheckReloadAmmoAnimationEnd()
        {
            while (true)
            {


                yield return null;
                    GunStateInfo = GunAnimator.GetCurrentAnimatorStateInfo(0);

                if (GunStateInfo.IsTag("Reload"))
                    {

                    if (GunStateInfo.normalizedTime > 0.9f)
                        {
                            int x = AmmoInMag - CurrentAmmo;
                            int y = CurrentMaxAmmoCarried - x;

                        if (y <= 0)
                            {
                                CurrentAmmo += CurrentMaxAmmoCarried;
                            }
                            else
                            {
                                CurrentAmmo = AmmoInMag;
                            }

                            CurrentMaxAmmoCarried = y <= 0 ? 0 : y;
                            yield break;
                        }
                    }

            }
        }

        protected override void Aim()
        {
            GunAnimator.SetBool("Aim", IsAiming);
            if (doAimCoroutine == null)
            {
                doAimCoroutine = DoAim();
                StartCoroutine(doAimCoroutine);
            }
            else
            {
                StopCoroutine(doAimCoroutine);
                doAimCoroutine = null;
                doAimCoroutine = DoAim();
                StartCoroutine(doAimCoroutine);
            }
        }

        private IEnumerator DoAim()
        {
            while (true)
            {
                yield return null;

                float tmp_CurrentFOV = 0;
                EyeCamera.fieldOfView = Mathf.SmoothDamp(EyeCamera.fieldOfView,IsAiming? 26:OriginFOV, ref tmp_CurrentFOV, Time.deltaTime * 2);
            }
        }


    }

}