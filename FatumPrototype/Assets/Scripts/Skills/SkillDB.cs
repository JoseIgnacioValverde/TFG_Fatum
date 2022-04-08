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
        "The Empress"

    );
    public static Skill Devil = new Skill(
        "Devil",
        "None", 0, 0, 0,
        Skill.SkillType.Main, "null",
        "The Devil"

    );
    public static Skill Moon = new Skill(
        "Moon",
        "None", 0, 0, 0,
        Skill.SkillType.Main, "null",
        "The Moon"

    );
    public static Skill Sun = new Skill(
        "Sun",
        "None", 0, 0, 0,
        Skill.SkillType.Main, "null",
        "The Sun"

    );
    public static Skill Judgement = new Skill(
        "Judgement",
        "None", 0, 0, 0,
        Skill.SkillType.Main, "null",
        "Judgement"

    );
#endregion
#region Passive
    public static Skill Lovers = new Skill(
        "Lovers",
        "None", 0, 0, 0,
        Skill.SkillType.Pasive, "null",
        "The Lovers"

    );
    public static Skill Hierophant = new Skill(
        "Hierophant",
        "None", 0, 0, 0,
        Skill.SkillType.Pasive, "null",
        "The Hierophant"

    );
    public static Skill Strenght = new Skill(
        "Strenght",
        "None", 0, 0, 0,
        Skill.SkillType.Pasive, "null",
        "Strenght"

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
        "Temperance"

    );
    public static Skill Tower = new Skill(
        "Tower",
        "None", 0, 0, 0,
        Skill.SkillType.Pasive, "null",
        "The Tower"

    );
    public static Skill Hanged = new Skill(
        "Hanged",
        "None", 0, 0, 0,
        Skill.SkillType.Pasive, "null",
        "The Hanged Man"

    );
#endregion
#region Movement
public static Skill Magician = new Skill(
        "Magician",
        "None", 0, 0, 0,
        Skill.SkillType.Movement, "null",
        "The Magician"

    );
    public static Skill Chariot = new Skill(
        "Chariot",
        "None", 0, 0, 0,
        Skill.SkillType.Movement, "null",
        "The Chariot"

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
        "The High Priestess"

    );public static Skill Emperor = new Skill(
        "Emperor",
        "None", 0, 0, 0,
        Skill.SkillType.Mask, "null",
        "The Emperor"

    );public static Skill Justice = new Skill(
        "Justice",
        "None", 0, 0, 0,
        Skill.SkillType.Mask, "null",
        "Justice"

    );public static Skill Death = new Skill(
        "Death",
        "None", 0, 0, 0,
        Skill.SkillType.Mask, "null",
        "Death doesn't make distinctions between the wealthy and the poor"
    );
    public static Skill Star = new Skill(
        "Star",
        "None", 0, 0, 0,
        Skill.SkillType.Mask, "null",
        "The Star"
    );
    public static Skill World = new Skill(
        "World",
        "None", 0, 0, 0,
        Skill.SkillType.Mask, "null",
        "ZA WARUDO"
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
        case "Magician":
            get = Magician;
            break;
        case "Priestess":
            get = Priestess;
            break;
        case "Hierophant":
            get = Hierophant;
            break;
        case "Sun":
            get = Sun;
            break;
        case "Moon":
            get = Moon;
            break;
        case "Star":
            get = Star;
            break;
        case "World":
            get = World;
            break;
        case "Strenght":
            get = Strenght;
            break;
        case "Temperance":
            get = Temperance;
            break;
        case "Justice":
            get = Justice;
            break;
        case "Judgement":
            get = Judgement;
            break;
        case "Empress":
            get = Empress;
            break;
        case "Emperor":
            get = Emperor;
            break;
        case "Death":
            get = Death;
            break;
        case "Devil":
            get = Devil;
            break;
        case "Hanged":
            get = Hanged;
            break;
        case "Tower":
            get = Tower;
            break;
        case "Chariot":
            get = Chariot;
            break;
        case "Lovers":
            get = Lovers;
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
