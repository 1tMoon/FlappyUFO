using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesManager : MonoBehaviour
{
    // 创建一个模板
    public GameObject template;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //
    Coroutine coroutine = null;
    // 游戏开始时控制启动
    public void StartGame()
    {
        coroutine = StartCoroutine(GenerateTrees());
    }
    // 停止
    public void StopGame()
    {
        StopCoroutine(coroutine);
    }
    // 生成多个实例化物体
    IEnumerator GenerateTrees()
    {
        while (true)
        {
            GenerateTree();
            yield return new WaitForSeconds(2f);
        }
    }
    void GenerateTree()
    {
        // 将需要生成的物体实例化，然后将预制体生成在管理器内部
        Instantiate(template, this.transform);
    }
}
