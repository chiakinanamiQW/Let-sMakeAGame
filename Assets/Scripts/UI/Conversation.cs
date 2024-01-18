using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Conversation : MonoBehaviour
{
    [Header("UI")]
    public Image Face;
    public TMP_Text context;
    public TMP_Text name;
    [Header("ÄÚÈÝ")]
    public TextAsset textAsset;
    public int index;
    public float textspeed;
    private bool isFinshedSpeak=false;

    List<string> textlist = new List<string>();
    private void Awake()
    {
        GetText(textAsset);
        index = 0;
    }
    void OnEnable()
    {
        /*  context.text = textlist[index];
          index++;*/
        StartCoroutine(SetTextUI());
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F) && index == textlist.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        if (Input.GetKeyUp(KeyCode.F) && isFinshedSpeak == true)
        {
            /*context.text = textlist[index];
            index++;*/
            StartCoroutine(SetTextUI());
        }
    }
    void GetText(TextAsset file)
    {
        textlist.Clear();
        index = 0;
       var lineDate=file.text.Split('\n');
        foreach(var line in lineDate)
        {
            textlist.Add(line);
        }
    }
    IEnumerator SetTextUI()
    {
        context.text = "";
        isFinshedSpeak = false;
        for(int i = 0; i < textlist[index].Length; i++)
        {
            context.text += textlist[index][i];
            yield return new WaitForSeconds(textspeed);
        }
        isFinshedSpeak = true;
        index++;
    }

}
