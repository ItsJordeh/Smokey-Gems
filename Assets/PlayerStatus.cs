using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int exhaustion = 30;
    public int maxHealth;
    public int maxStamina;

    public int currentHealth;
    public int currentStamina;

    public bool isExhausted = false;
    public bool isDead = false; //oof if true

    public void inflictDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth < 0)
        {
            //You died loser
        }
        

    }

    public void inflictHealing(int healing)
    {
        currentHealth += healing;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

    }

    public void regenerateStamina(int stamina)
    {
        currentStamina += stamina;

        //if the current stamina after regen is above exhaustion threshhold, player is no longer exhausted
        if(currentStamina > exhaustion)
        {
            isExhausted = false;
        }
        //if the current stamina after regen is above the maximum stamina, reset the stamina to max 
        if(currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }

    }
    public void diminishStamina(int stamina)
    {
        currentStamina -= stamina;
        if (currentStamina <= 0)
        {
            currentStamina = 0;
            isExhausted = true;
        }
    }





}
