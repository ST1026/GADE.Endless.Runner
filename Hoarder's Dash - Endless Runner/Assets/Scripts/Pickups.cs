using TMPro;
using TMPro;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public enum PickupTypes { Gun, Shield, SpeedBoost }
    public PickupTypes types;
    public float rotateSpd = 100f;

    public TextMeshProUGUI coinsTxt;
    public int coinCount = 0;


    void Update()
    {
        //make pickups spin
        transform.Rotate(Vector3.up * rotateSpd * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PowerUps powerUps = other.GetComponent<PowerUps>();

            if(powerUps != null)
            {
                switch (types)
                {
                    case PickupTypes.Gun:
                        powerUps.UseGun(10f);
                        break;
                    case PickupTypes.Shield:
                        powerUps.UseShield(12f);
                        break;
                    case PickupTypes.SpeedBoost:
                        powerUps.TriggerBoost(8f, 3f);
                        break;
                }
            }
            Destroy(gameObject);

           
        }

        if (coinsTxt != null)
        {
            //keep track of coins collected
            coinsTxt.text = "Coins: " + coinCount.ToString();
        }

    }


}
