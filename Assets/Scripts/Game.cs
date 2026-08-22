using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    // 枚举出游戏需要的几种状态
    public enum GAME_STATUS
    {
        Ready,  // 准备状态
        Gaming, // 游戏中状态
        Over    // 游戏结束状态
    }
    // 创建游戏状态属性
    private GAME_STATUS status;
    private GAME_STATUS Status
    { 
        get { return status; } 
        set { this.status = value;
            this.UpdateUI();    // 调用UI刷新界面
        }
    }

    public GameObject panelReady;   // 游戏准备场景
    public GameObject panelGaming;  // 游戏中场景
    public GameObject panelOver;    // 游戏结束场景

    public UFOOperation ufo;    // 调用脚本
    public TreesManager treesManager;   // 调用脚本

    private int score;   // 分数变量
    private int bestScore = 0;   // 分数变量
    public TextMeshProUGUI uiScore; // 文本组件（游戏内分数显示）
    public TextMeshProUGUI uiScore2;    // 文本组件（结算界面分数显示）
    public TextMeshProUGUI uiScore3;    // 文本组件（结算界面历史最高得分显示）
    public int Score
    {
        get { return score; }
        set
        {
            this.score = value;
            this.uiScore.text = this.score.ToString();  // 将分数转换为字符串存入文本组件内
            this.uiScore2.text = this.score.ToString();
            
        }
    }
    public int BestScore
    {
        get { return bestScore; }
        set
        {
            this.bestScore = value;
            this.uiScore3.text = this.bestScore.ToString();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        this.panelReady.SetActive(true);    // 激活游戏准备界面
        this.Status = GAME_STATUS.Ready;    // 界面更改为准备状态
        this.ufo.OnDeath += Ufo_OnDeath;    // 将本脚本内的 Ufo_OnDeath 函数绑定至 OnDeath 事件
        this.ufo.OnScore = Ufo_OnScore; // 将本脚本内的 Ufo_OnScore 函数绑定至 OnScore 事件
    }
    // Update is called once per frame
    void Update()
    {

    }

    // 游戏开始功能
    public void StartGame()
    {
        this.Status = GAME_STATUS.Gaming;   // 界面更改为游戏中状态
        treesManager.StartGame();   // 启动碰撞墙
        ufo.Jump(); // 改变 Player 动画
        Debug.Log("GameStart");
    }
    // 游戏重新开始功能
    public void Restart()
    {
        this.Status = GAME_STATUS.Ready;    // 界面更改为准备状态
        this.treesManager.Init();   // 重置碰撞墙
        this.ufo.Init();    // 初始化 Player 位置
        this.ufo.Idle();    // 改变 Player 动画
        this.Score = 0; // 重置分数
    }
    // 游戏界面刷新
    public void UpdateUI()
    {
        this.panelReady.SetActive(this.Status == GAME_STATUS.Ready);    // 当需要场景为准备界面时，激活该对象
        this.panelGaming.SetActive(this.Status == GAME_STATUS.Gaming);  // 当需要场景为游戏中界面时，激活该对象
        this.panelOver.SetActive(this.Status == GAME_STATUS.Over);  // 当需要场景为游戏结束界面时，激活该对象
    }
    // Player 死亡结算
    private void Ufo_OnDeath()
    {
        this.Status = GAME_STATUS.Over; // 界面更改为游戏结束状态
        this.treesManager.StopGame();   // 停止碰撞墙运行
        ufo.anim.SetBool("JumpAnim", false);   // Player 退出跳跃动画
        if (this.Score > this.BestScore)    // 判断当前得分是否大于历史最佳
            BestScore = this.Score;
    }
    // 游戏计分器
    private void Ufo_OnScore(int score)
    {
        this.Score += score;    // 当前分数累加（+1）
    }
}
