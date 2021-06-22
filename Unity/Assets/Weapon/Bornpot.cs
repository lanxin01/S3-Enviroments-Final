using Scripts.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bornpot : MonoBehaviour
{
    //该出生点生成的怪物
    public GameObject targetEnemy;
    public GameObject Por;
    //生成怪物的总数量
    public int enemyTotalNum = 10;
    //生成怪物的时间间隔
    public float intervalTime = 0;
    //生成怪物的计数器
    private int enemyCounter;
    public int enemyDieCounter;
    public Text enemyDieCounterText;
    public static bool enemyDie;
    //玩家
    private AssualtRifle targetPlayer;

    // Use this for initialization
    void Start()
    {
        //初始时，怪物计数为0；
        enemyCounter = 0;
        enemyDieCounter = enemyTotalNum;
        //重复生成怪物
        InvokeRepeating("CreatEnemy", 1F, intervalTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyDie)
        {
            enemyDieCounter--;
            enemyDie = false;
        }
        enemyDieCounterText.text = ("蜘蛛  X "+ enemyDieCounter);

        if(enemyDieCounter==0) SceneManager.LoadScene(2);


    }
    //方法，生成怪物
    private void CreatEnemy()
    {

              Instantiate(Por, targetEnemy.transform.position, Quaternion.identity);
          //  Instantiate(Por, new Vector3(-3.5f, 0.5f, Random.Range(-4.0f, 4.0f)), Por.transform.rotation);
            enemyCounter++;
            //如果计数达到最大值
            if (enemyCounter == enemyTotalNum)
            {
                //停止刷新
                CancelInvoke();
            }
    }

}
