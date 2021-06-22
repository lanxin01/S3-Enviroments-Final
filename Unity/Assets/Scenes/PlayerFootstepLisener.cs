using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootstepLisener : MonoBehaviour
{
    public FootstepAudioData FootstepAudioData;//声明声音
    public AudioSource FootstepAudioSource;

    private CharacterController characterController;
    private Transform footstepTransform;
    private float velocity;

    private float nextPlayTime;
    public LayerMask LayerMask;
    //Q:发出声音条件
    //A：角色移动或动作发出声音

    //Q:如何检测移动
    //A:Physic API

    //Q:怎么实现对应物体碰撞播放声音
    //A：Physic API

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        footstepTransform = transform;
    }

    private void FixedUpdate()
    {
        if (characterController.isGrounded)// 是否处于地面上
        {

        if(characterController.velocity.normalized.magnitude >= 0.1f)//是否有在移动
            {
                nextPlayTime += Time.deltaTime;

                var height01 = characterController.height / 2;
                bool tmp_IsHit =Physics.Linecast(footstepTransform.position,
                    footstepTransform.position+Vector3.down * 2,
                    out RaycastHit tmp_HitInfo, LayerMask);//检测是否碰撞

#if UNITY
               
#endif
                if (tmp_IsHit)
                {
                    //播放声音
                    //检测类型
                    foreach (var tmp_AudioElement in FootstepAudioData.FootstepAudios)
                    {
                        if (tmp_HitInfo.collider.CompareTag(tmp_AudioElement.Tag))
                        {

                            var tmp_velocity = characterController.velocity;
                            tmp_velocity.y = 0;
                            velocity = tmp_velocity.magnitude;
                            if (nextPlayTime>= 0.6/ (velocity/4))
                            {

                            //播放移动声音
                                int tmp_AudioCount = tmp_AudioElement.AudioClips.Count;
                                int tmp_AudioIndex = UnityEngine.Random.Range(0, tmp_AudioCount);
                                AudioClip tmp_FootstepAudioClip = tmp_AudioElement.AudioClips[tmp_AudioIndex];
                                FootstepAudioSource.clip = tmp_FootstepAudioClip;
                                FootstepAudioSource.Play();
                                nextPlayTime = 0;
                                break;

                            }
                        }
                    }
                }      
            
            }
        }
    }
}
