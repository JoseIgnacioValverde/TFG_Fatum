using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    SkillsLogic _skillsLogic;
    public void UseHermitSkill(){
        _skillsLogic.HermitSkill();
    }
    public void UsePrimarySkill(string skillName){
        switch (skillName){
            case "Hermit":
                UseHermitSkill();
                break;
            default:
            break;
        }
    }
    public void UseMoveSkill(string skillName){
        
    }
}
