using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillManager : MonoBehaviour
{
    public Image Skill1;
    public Image Skill2;
    public List<Sprite> sprites=new List<Sprite>();
    public Dictionary<string,Sprite> imageDic=new Dictionary<string,Sprite>();
    private void Awake()
    {
        imageDic["Cat"] = sprites[0];
        imageDic["Rabbit"] = sprites[1];
        imageDic["Squirrel"] = sprites[2];
        imageDic["Bird"] = sprites[3];
    }
    private void UpdateSprites(string _name)
    {
        
    }
}
