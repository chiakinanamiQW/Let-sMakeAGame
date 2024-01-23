using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebornPosition : MonoBehaviour
{
    public static RebornPosition Instance;

    public Vector3 rebornPosition;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    
    public void ChangeRebornPosition(Vector3 vector3)
    {
        rebornPosition = vector3;
    }

}
