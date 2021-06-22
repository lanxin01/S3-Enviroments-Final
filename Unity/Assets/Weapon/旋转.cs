using Scripts.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 旋转 : MonoBehaviour
{


    void Update()
    {
        transform.Rotate(-Vector3.up * 40 * Time.deltaTime);
    }
}
