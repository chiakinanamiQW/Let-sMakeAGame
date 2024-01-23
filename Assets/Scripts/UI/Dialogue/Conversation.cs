using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Conversation : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text context;
    [Header("����")]
    public TextAsset textAsset;
    public int index;
    public float textspeed;
    private bool isFinshedSpeak=false;
    [Header("ͷ��")]
    public Image spriteLeft;
    public Image spriteRight;
    public List<Sprite> sprites = new List<Sprite>();
    Dictionary<string, Sprite> imageDic = new Dictionary<string, Sprite>();
    bool isSpeeking = false;

    List<string> textlist = new List<string>();
    private void Awake()
    {
        imageDic["����"] = sprites[0];
        imageDic["�Գ�����ʹ�ĺܿɰ���С��"] =imageDic["��֪���������ĺܿɰ���С��"] = sprites[1];

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
        if (_name == "����")
        {
            spriteLeft.sprite = imageDic[_name];
            spriteLeft.gameObject.SetActive(true);
        }
        else if(_name == "��֪���������ĺܿɰ���С��"||_name== "�Գ�����ʹ�ĺܿɰ���С��")
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
