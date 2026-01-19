using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBarGUI : MonoBehaviour
{
    public Image chargeBar;
    public PlayerBow playerBow;

    void Update()
    {
        chargeBar.fillAmount = playerBow.currentCharge / playerBow.chargeTime;
    }
}
