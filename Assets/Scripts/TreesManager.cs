using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesManager : MonoBehaviour
{
    // 创建一个模板
    public GameObject template;

    List<TreesRun> treesRuns = new List<TreesRun>();
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
        for (int i = 0;i < treesRuns.Count; i++)
            treesRuns[i].enabled = false;
    }
    
    void GenerateTree()
    {
        if(treesRuns.Count < 3)
        {
            // 将需要生成的物体实例化，然后将预制体生成在管理器内部
            GameObject obj = Instantiate(template, this.transform);
            TreesRun t = obj.GetComponent<TreesRun>();
            treesRuns.Add(t);
        }
    }
    // 生成多个实例化物体
    IEnumerator GenerateTrees()
    {
        for (int i = 0; i < 3; i++)
        {
            if (treesRuns.Count < 3)
                GenerateTree();
            else
            {
                treesRuns[i].enabled = true;
                treesRuns[i].Init();
            }
            yield return new WaitForSeconds(2f);
        }
    }
    // 
    public void Init()
    {
        for (int i = 0; i < treesRuns.Count; i++)
            Destroy(treesRuns[i].gameObject);
        treesRuns.Clear();
    }
}
