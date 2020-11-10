using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text healthText;
    public Text staminaText;
    public GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        staminaText.text = player.GetComponent<PlayerStatus>().currentStamina + "/" + player.GetComponent<PlayerStatus>().maxStamina;
        healthText.text = player.GetComponent<PlayerStatus>().currentHealth + "/" + player.GetComponent<PlayerStatus>().maxHealth;
    }
}
