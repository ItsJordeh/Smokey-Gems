using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text healthText;
    public Text staminaText;

    public AdvancedBarManager stamina;
    public AdvancedBarManager health;

    public GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.Find("HealthBar").GetComponent<AdvancedBarManager>();
        stamina = GameObject.Find("StaminaBar").GetComponent<AdvancedBarManager>();
    }

    // Update is called once per frame
    void Update()
    {
        stamina.value = player.GetComponent<PlayerStatus>().maxStamina - player.GetComponent<PlayerStatus>().currentStamina;
        health.value = player.GetComponent<PlayerStatus>().maxHealth - player.GetComponent<PlayerStatus>().currentHealth;
    }
}
