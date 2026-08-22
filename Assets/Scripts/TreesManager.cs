using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesManager : MonoBehaviour
{
    public GameObject template;     // 游戏对象

    List<TreesRun> treesRuns = new List<TreesRun>();    // 创建一个列表

    Coroutine coroutine = null; // 初始化协程，将协程设置为空
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // 游戏开始时控制启动
    public void StartGame()
    {
        coroutine = StartCoroutine(GenerateTrees());    // 启动协程方法
    }
    // 停止生成
    public void StopGame()
    {
        StopCoroutine(coroutine);   // 停止协程
        for (int i = 0;i < treesRuns.Count; i++)    // 列表内所有墙体脚本暂停
            treesRuns[i].enabled = false;   // 脚本停止运行
    }
    // 预制体生成
    void GenerateTree()
    {
        if(treesRuns.Count < 3) // 判断列表内的墙体数量是否小于 4
        { 
            GameObject obj = Instantiate(template, this.transform); // 将需要生成的预制体实例化，然后设置预制体的父物体作为管理器
            TreesRun t = obj.GetComponent<TreesRun>();  // 获取新生成墙体上的脚本
            treesRuns.Add(t);   // 将脚本存入列表内
        }
    }
    // 协程方法，生成多个实例化物体
    IEnumerator GenerateTrees()
    {
        for (int i = 0; i < 3; i++) // 最多生成 3 个墙体
        {
            if (treesRuns.Count < 3)    // 当墙体数量小于 4 时继续生成
                GenerateTree();
            else
            {
                treesRuns[i].enabled = true;    // 脚本正常运行
                treesRuns[i].Init();    // 重置墙体
            }
            yield return new WaitForSeconds(2f);    // 暂停协程，等待 2 秒
        }
    }
    // 重置多个实例化物体
    public void Init()
    {
        for (int i = 0; i < treesRuns.Count; i++)
            Destroy(treesRuns[i].gameObject);   // 销毁游戏内墙体对象
        treesRuns.Clear();  // 清空列表内墙体
    }
}
