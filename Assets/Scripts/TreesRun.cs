using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesRun : MonoBehaviour
{
    public float speed;
    public float yMax;
    public float yMin;

    float t = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.Init(); 

    }
    public void Init()
    {
        float y = Random.Range(yMin, yMax);
        this.transform.localPosition = new Vector3(0, y, 0);
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(-speed, 0) * Time.deltaTime;
        t += Time.deltaTime;
        if(t > 6.4)
        {
            t = 0;
            this.Init();
        }
    }
    
}