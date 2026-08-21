using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UFOOperation : MonoBehaviour
{
    public Rigidbody2D rigidbodyUFO;    // Player刚体组件
    public Animator anim;   // Player动画组件

    private bool move = false;  // 移动状态
    private bool die = false;   // 死亡状态

    public float force = 200f;  // 飞行的力度

    public delegate void DeathNotify(); // 声明委托类型
    public event DeathNotify OnDeath;   // 创建事件

    private Vector3 initPos;    // 三维坐标变量

    public UnityAction<int> OnScore;    // 创建一个分数委托
    // Start is called before the first frame update
    void Start()
    {
        this.Idle();    // 游戏开始时设置 Plyaer 处于待机状态
        initPos = this.transform.position;  // 传递游戏初始坐标
    }

    // Update is called once per frame
    void Update()
    {
        if (this.die)   // 判断是否触发死亡状态
            return; // 直接跳出 Update() 函数，后续代码不再运行
        PlayerControl();    // Player 控制器
        if (move == true && Input.GetMouseButtonUp(0))  // 判断 Player 为可移动状态并且松开控制按键
        {
            this.anim.SetBool("JumpAnim", false);   // Player 退出跳跃动画
        }
    }
    // Player移动状态
    public void Move()  
    {
        this.move = true;   // 移动状态
    }
    // Player待机状态
    public void Idle()  
    {
        this.rigidbodyUFO.simulated = false; // 控制刚体是否需要进行物理模拟
        this.anim.SetTrigger("Idle"); // 动画状态触发
    }
    // Player游戏内状态
    public void Jump()  
    {
        this.rigidbodyUFO.simulated = true; // 控制刚体是否需要进行物理模拟
        this.anim.SetTrigger("Jump"); // 动画状态触发
    }
    // Player 控制器
    public void PlayerControl() 
    {
        if (move == true && Input.GetMouseButtonDown(0))    // 判断 Player 为可移动状态并且按下控制按键
        {
            this.anim.SetBool("JumpAnim", true);    // Player 进入跳跃动画
            rigidbodyUFO.velocity = Vector2.zero;   // 将刚体水平以及垂直方向的速度清零
            rigidbodyUFO.AddForce(new Vector2(0, force), ForceMode2D.Force);    // 给刚体施加一个垂直方向的力，力的模式为默认模式
        }
    }
    // Player死亡状态
    public void Man()   
    {
        this.die = true;    // 触发死亡状态
        if (this.OnDeath!=null) // 判断 OnDeath 事件是否存在脚本订阅
            this.OnDeath(); // 执行所有订阅该事件的函数
    }
    // 碰撞进入检测
    public void OnTriggerEnter2D(Collider2D collision)  
    {
        this.Man(); // 触发Player死亡状态
    }
    // 碰撞退出检测
    public void OnTriggerExit2D(Collider2D collision)   
    {
        if (collision.gameObject.name.Equals("ScoreRay"))   // 判断碰撞对象是否为 “ScoreRay”
        {
            if (this.OnScore != null)   // 判断 OnScore 事件是否存在脚本订阅
                this.OnScore(1);    // 执行事件，传入参数 1（+1）
        }
    }
    // Player位置初始化
    public void Init()  
    {
        this.transform.position = initPos;  // 将坐标位置传递给 Player
        this.Idle();    // 回到待机状态
        this.die = false;   // 关闭死亡状态
    }
}
