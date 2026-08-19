using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public GAME_STATUS Status
    { 
        get { return status; } 
        set { status = value; }
    }

    public GameObject panelReady;
    public GameObject panelGaming;
    public GameObject panelOver;
    public UFOOperation ufo;

    public TreesManager treesManager;
    // Start is called before the first frame update
    void Start()
    {
        this.panelReady.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 游戏开始按钮功能
    public void StartGame()
    {
        this.status = GAME_STATUS.Gaming;
        UpdateUI();
        treesManager.StartGame();
        ufo.Move();
        ufo.Jump();
        Debug.Log("GameStart");
    }
    // 游戏各状态检测
    public void UpdateUI()
    {
        this.panelReady.SetActive(this.status == GAME_STATUS.Ready);
        this.panelGaming.SetActive(this.status == GAME_STATUS.Gaming);
        this.panelOver.SetActive(this.status == GAME_STATUS.Over);
    }
}
