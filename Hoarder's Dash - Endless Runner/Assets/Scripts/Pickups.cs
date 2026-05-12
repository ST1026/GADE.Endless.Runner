using UnityEngine;

public class Pickups : MonoBehaviour
{
    public enum PickupTypes { Coin, Gun, Shield, SpeedBoost }
    public PickupTypes types;
    public float rotateSpd = 100f;

    
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
                    case PickupTypes.Coin:
                        FindAnyObjectByType<ObstacleSpawner>().DeleteCoins();
                        break;
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
    }


}
