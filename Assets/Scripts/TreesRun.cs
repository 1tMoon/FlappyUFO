using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesRun : MonoBehaviour
{
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(-speed, 0) * Time.deltaTime;
    }
}