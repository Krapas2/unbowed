using UnityEngine;
using UnityEngine.UI;

public class HealthBarGUI : MonoBehaviour
{
    public Image healthBar;
    public Health playerHealth;
    
    void Update()
    {
        healthBar.fillAmount = playerHealth.curHealth / playerHealth.maxHealth;
    }
}
