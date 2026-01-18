using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class StatsSliders : MonoBehaviour
{
    public float maxPoints;
    private float remainingPoints;

    public Slider damageSlider;
    public Slider healthSlider;
    public Slider chargeSlider;
    public Slider speedSlider;

    private float previousDamageValue;
    private float previousHealthValue;
    private float previousChargeValue;
    private float previousSpeedValue;

    public static StatsSliders Instance { get; private set; }
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple StatsSliders found!");
        }
    }

    void Start()
    {
        previousDamageValue = damageSlider.value;
        previousHealthValue = healthSlider.value;
        previousChargeValue = chargeSlider.value;
        previousSpeedValue = speedSlider.value;
        remainingPoints = maxPoints;

        damageSlider.onValueChanged.AddListener(delegate { OnSliderChanged(damageSlider, ref previousDamageValue); });
        healthSlider.onValueChanged.AddListener(delegate { OnSliderChanged(healthSlider, ref previousHealthValue); });
        chargeSlider.onValueChanged.AddListener(delegate { OnSliderChanged(chargeSlider, ref previousChargeValue); });
        speedSlider.onValueChanged.AddListener(delegate { OnSliderChanged(speedSlider, ref previousSpeedValue); });
    }

    void OnSliderChanged(Slider slider, ref float previousValue)
    {
        float delta = slider.value - previousValue;
        
        if (delta > remainingPoints)
        {
            slider.value = previousValue + remainingPoints;
            delta = remainingPoints;
        }
        
        remainingPoints -= delta;
        previousValue = slider.value;
    }
    
    public float GetRemainingPoints()
    {
        return remainingPoints;
    }
}
