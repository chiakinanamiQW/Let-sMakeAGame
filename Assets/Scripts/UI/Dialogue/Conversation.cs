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
    [Header("内容")]
    public TextAsset textAsset;
    public int index;
    public float textspeed;
    private bool isFinshedSpeak=false;
    [Header("头像")]
    public Sprite face01, face02;
    bool isSpeeking = false;

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

        if (Input.GetKeyUp(KeyCode.J) && index == textlist.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            Debug.Log(1);
           
            return;
        }
        if (Input.GetKeyUp(KeyCode.J) && isFinshedSpeak == true)
        {
            /*context.text = textlist[index];
            index++;*/
            StartCoroutine(SetTextUI());
        }
        if(isSpeeking)
        {
            PlayerInputController.Instance.ControllDisable();
        }
        else if(!isSpeeking)
        {
            Debug.Log(1);
            PlayerInputController.Instance.ControllEnable();
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
    {   isSpeeking=true;   
        Debug.Log(textlist[0]);
        context.text = "";
        isFinshedSpeak = false;
        switch (textlist[index])
        {
            case"少年":
                Face.sprite=face01;
                index++;
                break;
            case "":
                Face.sprite=face02;
                index++;
                break;
         
        }
        for(int i = 0; i < textlist[index].Length; i++)
        {
            context.text += textlist[index][i];
            yield return new WaitForSeconds(textspeed);
        }
        isFinshedSpeak = true;
        isSpeeking = false;
        index++;
    }

}
