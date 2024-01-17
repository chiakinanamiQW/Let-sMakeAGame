using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        GameEventSystem.instance.OnPlayerDead += test;
    }
    void Start()
    {
        GameEventSystem.instance.PlayerDead();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void test()
    {
        Debug.Log("EventTest");
    }
}
