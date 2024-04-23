using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthBarScript : MonoBehaviour
{



    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public int startHealth;
    public float DisplayHealth;

    public Canvas GameOverCanvas;
    private void Start()
    {
        GameOverCanvas.enabled = false;
        startHealth = 100;
        SetHealth(startHealth);
    }

    void Update()
    {
        if (slider.value <= 1) 
        {
            // game over canvas
            GameOver();  
        }

       
    }

    public void SetMaxHealth(int health)
    {
        if (health <= 0)
            health = 0;
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        if (health <= 0)
            health = 0;
        DisplayHealth = health;
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public float GetHealth()
    {
        return slider.value;
    }

    public void IncreaseHealth(int amount)
    {
        float newHealth = GetHealth() + amount;

        newHealth = Mathf.Clamp(newHealth, 0f, slider.maxValue);

        SetHealth(newHealth);

    }

    public void TakeDamageForPlayer(int damage) {

        float currentHealth = GetHealth();
        float newHealth = currentHealth - damage;

        newHealth = Mathf.Max(newHealth, 0f);

        SetHealth(newHealth);
    }

    private void GameOver()
    {
        GameOverCanvas.gameObject.SetActive(true);
        GameOverCanvas.enabled = true;
        Time.timeScale = 0f;
    }
}
