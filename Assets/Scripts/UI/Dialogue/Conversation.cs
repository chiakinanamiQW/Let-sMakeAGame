using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Conversation : MonoBehaviour
{
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
    public List<Sprite> sprites = new List<Sprite>();
    Dictionary<string, Sprite> imageDic = new Dictionary<string, Sprite>();
    bool isSpeeking = false;

    List<string> textlist = new List<string>();
    private void Awake()
    {
        imageDic["少年"] = sprites[0];
        imageDic["自称是神使的很可爱的小狗"] =imageDic["不知道哪里来的很可爱的小狗"] = sprites[1];

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
            PlayerInputController.Instance.ControllEnable();

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
    public void UpdateSpite(string _name)
    {
        if (_name == "少年")
        {
            spriteLeft.sprite = imageDic[_name];
            spriteLeft.gameObject.SetActive(true);
        }
        else if(_name == "不知道哪里来的很可爱的小狗"||_name== "自称是神使的很可爱的小狗")
        {
            spriteRight.sprite = imageDic[_name];
            spriteRight.gameObject.SetActive(true);
        }
    }
    IEnumerator SetTextUI()
    {   isSpeeking=true;   
        Debug.Log(textlist[0]);
        context.text = "";
        isFinshedSpeak = false;
        UpdateSpite(textlist[index]);
        for(int i = 0; i < textlist[index].Length; i++)
        {
            context.text += textlist[index][i];
            yield return new WaitForSeconds(textspeed);
        }
        isFinshedSpeak = true;
        
        index++;
    }

}
