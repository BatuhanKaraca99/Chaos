using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    public TMP_Text healthBarText;

    Damageable playerDamageable;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if(player == null)
        {
            Debug.Log("No player found in the scene");
        }

        playerDamageable = player.GetComponent<Damageable>();
    }

    private void OnEnable()
    {
        playerDamageable.healthChanged.AddListener(OnPlayerHealthChanged);
    }

    private void OnDisable()
    {
        playerDamageable.healthChanged.RemoveListener(OnPlayerHealthChanged);
    }

    private void Start()
    {  
        healthBarText.text = "HP: " + playerDamageable.Health + " / " + playerDamageable.MaxHealth;
    }

    private void OnPlayerHealthChanged(int newHealth, int maxHealth)
    {
        healthBarText.text = "HP: " + newHealth + " / " + maxHealth;
    }
}
