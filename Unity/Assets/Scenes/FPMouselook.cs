using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPMouselook : MonoBehaviour
{
    [SerializeField]private Transform characterTransform;
    private Transform cameraTransform;
    private Vector3 cameraRotation;//保持获取每一帧x轴值的输出
    public float MouseSensitiivity;//灵敏度
    public Vector2 MaxminAngle;//限制旋转，符合人的视野旋转
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        var tmp_MouseX = Input.GetAxis("Mouse X");//获取鼠标X，Y轴输入
        var tmp_MouseY = Input.GetAxis("Mouse Y");

        cameraRotation.y += tmp_MouseX * MouseSensitiivity;
        cameraRotation.x -= tmp_MouseY * MouseSensitiivity;

        cameraRotation.x = Mathf.Clamp(cameraRotation.x, MaxminAngle.x, MaxminAngle.y);

        cameraTransform.rotation = Quaternion.Euler(cameraRotation.x, cameraRotation.y, 0);
        characterTransform.rotation = Quaternion.Euler(0, cameraRotation.y, 0);
    }
}
