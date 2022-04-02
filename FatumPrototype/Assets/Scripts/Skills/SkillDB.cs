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
        Skill.SkillType.None, "noItem",
        "Not unlocked yet"

    );
#region MainSkills
    public static Skill Hermit = new Skill(
        "Hermit",
        "UseHermitSkill", 0, 0, 0,
        Skill.SkillType.Main, "the hermit",
        "The Hermit walks through every plane, wandering, but never lost on it's way."

    );
    public static Skill Empress = new Skill(
        "Empress",
        "None", 0, 0, 0,
        Skill.SkillType.Main, "null",
        "Not unlocked yet"

    );
    public static Skill Devil = new Skill(
        "Devil",
        "None", 0, 0, 0,
        Skill.SkillType.Main, "null",
        "Not unlocked yet"

    );
    public static Skill Moon = new Skill(
        "Moon",
        "None", 0, 0, 0,
        Skill.SkillType.Main, "null",
        "Not unlocked yet"

    );
    public static Skill Sun = new Skill(
        "Sun",
        "None", 0, 0, 0,
        Skill.SkillType.Main, "null",
        "Not unlocked yet"

    );
    public static Skill Judgement = new Skill(
        "Judgement",
        "None", 0, 0, 0,
        Skill.SkillType.Main, "null",
        "Not unlocked yet"

    );
#endregion
#region Passive
    public static Skill Lovers = new Skill(
        "Lovers",
        "None", 0, 0, 0,
        Skill.SkillType.Pasive, "null",
        "Not unlocked yet"

    );
    public static Skill Hierophant = new Skill(
        "Hierophant",
        "None", 0, 0, 0,
        Skill.SkillType.Pasive, "null",
        "Not unlocked yet"

    );
    public static Skill Strenght = new Skill(
        "Strenght",
        "None", 0, 0, 0,
        Skill.SkillType.Pasive, "null",
        "Not unlocked yet"

    );
    public static Skill Wheel = new Skill(
        "Wheel",
        "None", 0, 0, 0,
        Skill.SkillType.Pasive, "null",
        "The wheel of fortune"

    );
    public static Skill Temperance = new Skill(
        "Temperance",
        "None", 0, 0, 0,
        Skill.SkillType.Pasive, "null",
        "Not unlocked yet"

    );
    public static Skill Tower = new Skill(
        "Tower",
        "None", 0, 0, 0,
        Skill.SkillType.Pasive, "null",
        "Not unlocked yet"

    );
    public static Skill Hanged = new Skill(
        "Hanged",
        "None", 0, 0, 0,
        Skill.SkillType.Pasive, "null",
        "Not unlocked yet"

    );
#endregion
#region Movement
public static Skill Magician = new Skill(
        "Magician",
        "None", 0, 0, 0,
        Skill.SkillType.Movement, "null",
        "Not unlocked yet"

    );
    public static Skill Chariot = new Skill(
        "Chariot",
        "None", 0, 0, 0,
        Skill.SkillType.Movement, "null",
        "Not unlocked yet"

    );
    
#endregion
#region Mask
public static Skill Fool = new Skill(
        "Fool",
        "None", 0, 0, 0,
        Skill.SkillType.Mask, "null",
        "Everything is conected somehow. Even a lost wanderer like you."

    );public static Skill Priestess = new Skill(
        "Priestess",
        "None", 0, 0, 0,
        Skill.SkillType.Mask, "null",
        "Not unlocked yet"

    );public static Skill Emperor = new Skill(
        "Emperor",
        "None", 0, 0, 0,
        Skill.SkillType.Mask, "null",
        "Not unlocked yet"

    );public static Skill Justice = new Skill(
        "Justice",
        "None", 0, 0, 0,
        Skill.SkillType.Mask, "null",
        "Not unlocked yet"

    );public static Skill Death = new Skill(
        "Death",
        "None", 0, 0, 0,
        Skill.SkillType.Mask, "null",
        "Not unlocked yet"
    );
    public static Skill Star = new Skill(
        "Star",
        "None", 0, 0, 0,
        Skill.SkillType.Mask, "null",
        "Not unlocked yet"
    );
    public static Skill World = new Skill(
        "World",
        "None", 0, 0, 0,
        Skill.SkillType.Mask, "null",
        "Not unlocked yet"
    );
#endregion
    
public static Skill GetSkillByName(string s){
    Skill get;
    switch(s){
        case "Hermit":
            get = Hermit;
            break;
        case "Fool":
            get = Fool;
            break;
        case "Wheel":
            get = Wheel;
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
