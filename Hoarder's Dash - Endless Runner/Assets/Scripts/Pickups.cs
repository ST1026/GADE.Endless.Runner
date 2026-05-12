using TMPro;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public enum PickupTypes {Coin, Gun, Shield, SpeedBoost }
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
                if (types == PickupTypes.Gun) powerUps.UseGun(20f);
                if (types == PickupTypes.Shield) powerUps.UseShield(15f);
                if (types == PickupTypes.SpeedBoost) powerUps.TriggerBoost(10f, 10f);
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
