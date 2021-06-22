using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Scripts.Weapon
{
    public class Bullet : MonoBehaviour
    {
        public float BulletSpeed;
        public GameObject ImpactPraefab;
        protected int SpiderDie;

        private Transform bulletTransform;
        private Vector3 prevPosition;


        private void Start()
        {
            bulletTransform = transform;
            prevPosition = bulletTransform.position;
        }

        protected void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Foe")
            {
                Destroy(other.gameObject);
                SpiderDie += 1;
                Bornpot.enemyDie = true;
                AssualtRifle.SpiderDie = true;
            }
        }

        private void Update()
        {
            bulletTransform.Translate(0, 0, BulletSpeed * Time.deltaTime);
            Destroy(transform.gameObject, 3);
            //if(Physics.Raycast(prevPosition,( bulletTransform.position-prevPosition).normalized,out RaycastHit tmp_hit, (bulletTransform.position - prevPosition).magnitude))
            // {
            //     var tmp_bulletEffect = Instantiate(ImpactPraefab, tmp_hit.point, Quaternion.LookRotation(tmp_hit.normal, Vector3.up));
            //     Destroy(tmp_bulletEffect, 3);
            // }
        }



    }
}