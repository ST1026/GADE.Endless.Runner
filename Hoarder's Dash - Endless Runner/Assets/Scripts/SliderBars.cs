using UnityEngine;
using UnityEngine.UI;

public class SliderBars : MonoBehaviour
{
    [SerializeField] private Slider bossHealthbar;
    [SerializeField] private Slider spdBoostbar;
    [SerializeField] private Slider shieldBar;
    [SerializeField] private Slider gunBar;

    public void UpdateHealth(float currHealth, float maxHealth)
    {
        bossHealthbar.value = currHealth/maxHealth;
    }

    public void UpdateSpeedBar(float currSpeed, float maxSpeed)
    {
        spdBoostbar.value = currSpeed/maxSpeed;
    }

    public void UpdateShieldBar(float currShield, float maxShield)
    {
        shieldBar.value = currShield/maxShield;
    }

    public void UpdateGunBar(float currGun, float maxGun)
    {
        gunBar.value = currGun/maxGun;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
