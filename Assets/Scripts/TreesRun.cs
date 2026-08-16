using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesRun : MonoBehaviour
{
    public float speed;
    public float yMax;
    public float yMin;
    // Start is called before the first frame update
    void Start()
    {
        float y = Random.Range(yMin, yMax);
        this.transform.localPosition = new Vector3(0, y, 0);

        Destroy(this.gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(-speed, 0) * Time.deltaTime;
    }
}