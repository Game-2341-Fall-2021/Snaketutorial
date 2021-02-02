using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControls : MonoBehaviour
{
    public GameObject pellet;
    // Start is called before the first frame update
    void Start()
    {
        spawnpellet();
    }
    public void spawnpellet()
    {
        float x = Random.Range(0, 20);
        float y = Random.Range(-10, 0);
        Vector3 spawnpos = new Vector3(x, y);
        Instantiate(pellet, spawnpos, pellet.transform.rotation);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
