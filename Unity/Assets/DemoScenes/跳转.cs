using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class 跳转 : MonoBehaviour
{
public int 跳转页面;
    public void OnLoginButtonClick()
    {
        SceneManager.LoadScene(跳转页面);
    }
}
