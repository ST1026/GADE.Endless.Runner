using TMPro;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public enum PickupTypes {Coin, Gun, Shield, SpeedBoost }
    public PickupTypes types;

    public TextMeshProUGUI coinsTxt;
    public int coinCount = 0;


    void Update()
    {
        //display pickups in level
        transform.Rotate(Vector3.up * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PowerUps powerUps = other.GetComponent<PowerUps>();

            if(powerUps != null)
            {
                if (types == PickupTypes.Gun)
                {
                    SFXManager.Instance.PlaySound2D("Pickup2");
                    powerUps.UseGun(20f);
                }
                if (types == PickupTypes.Shield)
                {
                    SFXManager.Instance.PlaySound2D("Pickup3");
                    powerUps.UseShield(15f);
                }

                if (types == PickupTypes.SpeedBoost)
                {
                    SFXManager.Instance.PlaySound2D("Pickup1");
                    powerUps.TriggerBoost(10f, 2f);
                }

            }

            SliderBars sliderBars = FindAnyObjectByType<SliderBars>();
            if(sliderBars != null)
            {
                sliderBars.CountdownGun(20f);
                sliderBars.CountdownShield(15f);
                sliderBars.CountdownSpd(10f);
            }
            Destroy(gameObject);

        }

    }


}
