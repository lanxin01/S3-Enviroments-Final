using Scripts.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Weapon
{
    public class BulletChufaqi : MonoBehaviour
    {

        protected void OnTriggerEnter(Collider other)
        {

            if (other.tag == "Prop")
            {
                AssualtRifle.Bulletxx = 30;
                Destroy(other.gameObject);

            }


        }
    }
}