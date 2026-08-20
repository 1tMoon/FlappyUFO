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
        Ready,
        Gaming,
        Over
    }

    private GAME_STATUS status;

    private GAME_STATUS Status
    { 
        get { return status; } 
        set { this.status = value;
            this.UpdateUI();
        }
    }

    public GameObject panelReady;
    public GameObject panelGaming;
    public GameObject panelOver;
    public UFOOperation ufo;

    public TreesManager treesManager;

    public int score;
    public TextMeshProUGUI uiScore;
    public TextMeshProUGUI uiScore2;
    public int Score
    {
        get { return score; }
        set
        {
            this.score = value;
            this.uiScore.text = this.score.ToString();
            this.uiScore2.text = this.score.ToString();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        this.panelReady.SetActive(true);
        this.Status = GAME_STATUS.Ready;
        this.ufo.OnDeath += Ufo_OnDeath;
        this.ufo.OnScore = Ufo_OnScore;
    }

    private void Ufo_OnDeath()
    {
        this.Status = GAME_STATUS.Over;
        this.treesManager.StopGame();
    }

    private void Ufo_OnScore(int score)
    {
        this.Score += score;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 游戏开始按钮功能
    public void StartGame()
    {
        this.Status = GAME_STATUS.Gaming;
        treesManager.StartGame();
        ufo.Move();
        ufo.Jump();
        Debug.Log("GameStart");
    }
    // 界面跳转
    public void Restart()
    {
        this.Status = GAME_STATUS.Ready;
        this.treesManager.Init();
        this.ufo.Init();
    }
    // 游戏各状态检测
    public void UpdateUI()
    {
        this.panelReady.SetActive(this.Status == GAME_STATUS.Ready);
        this.panelGaming.SetActive(this.Status == GAME_STATUS.Gaming);
        this.panelOver.SetActive(this.Status == GAME_STATUS.Over);
    }
}
