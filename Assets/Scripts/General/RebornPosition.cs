using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RebornPosition : MonoBehaviour
{
    public static RebornPosition Instance;

    public Vector3 rebornPosition;
    public string Place;
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
    }
    private void Start()
    {
        MusicPlay(Place);
    }

    public void ChangeRebornPosition(Vector3 vector3)
    {
        rebornPosition = vector3;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(rebornPosition, 2.0f);
    }
    private void MusicPlay(string name)
    {
         AudioManager.instance.PlayMusic(name);
    }
}
