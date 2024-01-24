using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;

public class Conversation : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text context;
    [Header("内容")]
    public TextAsset[] textAsset;
    public int index;
    public float textspeed;
    private bool isFinshedSpeak=false;
    [Header("头像")]
    public Image spriteLeft;
    public Image spriteRight;
    bool isSpeeking = false;
    bool cancelTyping = false;
    int i = 0;

    List<string> textlist = new List<string>();
    private void Awake()
    {
        spriteLeft.gameObject.SetActive(false);
        spriteRight.gameObject.SetActive(false);
        GetText(textAsset[i]);
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
            PlayerInputController.Instance.ControllEnable();
            spriteLeft.gameObject.SetActive(false);
            spriteRight.gameObject.SetActive(false);
            return;
        }
        /*  if (Input.GetKeyUp(KeyCode.J) && isFinshedSpeak == true)
          {
              *//*context.text = textlist[index];
              index++;*//*
              StartCoroutine(SetTextUI());
          }*/
        if (Input.GetKeyUp(KeyCode.J))
        {
            if (isFinshedSpeak && !cancelTyping)
            {
                StartCoroutine (SetTextUI());
            }
            else if (!isFinshedSpeak)
            {
                cancelTyping = !cancelTyping;
            }
        }
        if(isSpeeking)
        {
            PlayerInputController.Instance.ControllDisable();
        }
       
    }
    void GetText(TextAsset file)
    {
        textlist.Clear();
        index = 0;
        var lineDate=file.text.Split('\n');
        foreach (var line in lineDate)
        {
            textlist.Add(line);
        }
    }
    public void UpdateSpite(string _name)
    {
        if (_name == "少年\r")
        {
            spriteLeft.gameObject.SetActive(true);
            index++;
        }
        else if(_name == "不知道哪里来的很可爱的小狗\r"||_name== "自称是神使的很可爱的小狗\r")
        {
            spriteRight.gameObject.SetActive(true);
            index++;
        }
    }
    IEnumerator SetTextUI()
    {   isSpeeking=true;   
        context.text = "";
        isFinshedSpeak = false;
        UpdateSpite(textlist[index]);
        /*   for(int i = 0; i < textlist[index].Length; i++)
           {
               context.text += textlist[index][i];
               yield return new WaitForSeconds(textspeed);
           }*/
        int letter = 0;
        while (!cancelTyping && letter < textlist[index].Length - 1)
        {
            context.text += textlist[index][letter];
            letter++;
            yield return new WaitForSeconds(textspeed);
        }
        context.text = textlist[index];
        cancelTyping = false;
        isFinshedSpeak = true;
        
        index++;
    }

}
