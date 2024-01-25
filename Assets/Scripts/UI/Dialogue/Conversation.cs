using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Conversation : MonoBehaviour
{
    public Canvas c;
    [Header("UI")]
    public TMP_Text context;
    [Header("内容")]
    public TextAsset textAsset;
    public int index;
    public float textspeed;
    private bool isFinshedSpeak=false;
    [Header("头像")]
    public Image spriteLeft;
    public Image spriteRight;
    public bool Speek=false;
    bool isSpeeking = false;
    bool cancelTyping = false;
    List<string> textlist = new List<string>();
    private void Awake()
    {
        spriteLeft.gameObject.SetActive(false);
        spriteRight.gameObject.SetActive(false);
        GetText(textAsset);
        index = 0;

    }
   
    private void Update()
    {
        if (Speek)
        {
          StartCoroutine(SetTextUI());
            Speek = false;
        }
        if (Input.GetKeyUp(KeyCode.J) && index == textlist.Count)
        {
            Debug.Log("last");
            gameObject.SetActive(false);
            index = 0;
            PlayerInputController.Instance.ControllEnable();
            spriteLeft.gameObject.SetActive(false);
            spriteRight.gameObject.SetActive(false);
            return;
        }//结束操作

        if (Input.GetKeyUp(KeyCode.J))
        {
            if (isFinshedSpeak && !cancelTyping)
            {
                Debug.Log(2);
                StartCoroutine(SetTextUI());
            }
            else if (!isFinshedSpeak)
            {
                cancelTyping = !cancelTyping;//为了能快速对话
            }
        }
        if (isSpeeking)
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
        c.gameObject.SetActive(true);
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
    public IEnumerator SetTextUI()
    {   
        isSpeeking=true;   
        context.text = "";
        isFinshedSpeak = false;
        UpdateSpite(textlist[index]);
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
