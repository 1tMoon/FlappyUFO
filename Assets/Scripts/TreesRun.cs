using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesRun : MonoBehaviour
{
    public float speed; // 墙体的移动速度
    public float yMax;  // 墙体在y轴向上移动的最大距离
    public float yMin;  // 墙体在y轴下移动的最大距离

    float t = 0;    // 墙体刷新时间
    // Start is called before the first frame update
    void Start()
    {
        this.Init(); // 确定墙体的初始位置

    }
    // 碰撞墙刷新的随机位置
    public void Init()
    {
        float y = Random.Range(yMin, yMax); // 随机一个数给到 y 轴
        this.transform.localPosition = new Vector3(0, y, 0);    // 将坐标轴赋予预制体
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(-speed, 0) * Time.deltaTime; // 墙体向左进行移动，保证移动速度不受帧率影响
        t += Time.deltaTime;    // 计时
        if(t > 6.4) // 每过 t 秒确定墙体的随机位置
        {
            t = 0;  // 将 t 清零
            this.Init();    // 生成墙体
        }
    }
    
}