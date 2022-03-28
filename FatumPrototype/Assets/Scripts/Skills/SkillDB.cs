using System.Dynamic;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class SkillDB
{
    public static Sprite[] s_skillSprites = new Sprite[23];

    public static Skill NoSkill = new Skill(
        "NoSkill",
        "None", 0, 0, 0,
        Skill.SkillType.None, "null",
        "Not unlocked yet"

    );
#region MainSkills
    public static Skill Hermit = new Skill(
        "Hermit",
        "UseHermitSkill", 0, 0, 0,
        Skill.SkillType.None, "null",
        "Not unlocked yet"

    );
#endregion
public static Skill GetSkillByName(string s){
    Skill get;
    switch(s){
        case "Hermit":
            get = Hermit;
            break;
        default:
            get = NoSkill;
            break;
    }

    Sprite skillSprite =(Sprite)Resources.Load(get.SpritePath, typeof(Sprite));
    get.SetSprite(skillSprite);
    s_skillSprites[get.ID] = skillSprite;

    return get;
}
}
