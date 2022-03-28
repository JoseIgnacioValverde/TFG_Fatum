using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    SkillsLogic _skillsLogic;
    public void UseHermitSkill(){
        _skillsLogic.HermitSkill();
    }
}
