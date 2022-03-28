using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResources : MonoBehaviour
{
    public float health, maxHealth = 100f;
    public float mana, maxMana = 100f;
    private float lerpSpeed;
    public Image healthBar;
    public Image manaBar;
    public Transform lookAt;
    public Transform itemGroup;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        mana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        if(health > maxHealth) health = maxHealth;
        if(mana > maxMana) mana = maxMana;
        lerpSpeed = 3f* Time.deltaTime;
        BarFillers();
    }
    void FixedUpdate(){
        //FaceCamera();
    }
    void BarFillers(){
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount,health/maxHealth, lerpSpeed);
        manaBar.fillAmount = Mathf.Lerp(manaBar.fillAmount,mana/maxMana, lerpSpeed);
    }
    void ColorChanger(){
        Color healthColor = Color.Lerp(Color.red, Color.green,(health/maxHealth));
        Color manaColor = Color.Lerp(Color.cyan, Color.blue,(mana/maxMana));
        healthBar.color = healthColor;
        manaBar.color = manaColor;
    }
    public void TakeDamage(float quantity){
        if(health>0&& health < maxHealth){
            health -= quantity;
        }
    }
    public void ConsumeMana(float quantity){
        if(mana>0&& mana < maxMana){
            mana -= quantity;
        }
    }
    public void FaceCamera(){
        if(lookAt){
            itemGroup.LookAt(2* itemGroup.position -lookAt.position);
        }
    }
    
    
}
