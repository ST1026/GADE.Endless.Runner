using UnityEngine;

public class Pickups : MonoBehaviour
{

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
            FindAnyObjectByType<ObstacleSpawner>().Coins();
            Destroy(gameObject);
        }
    }


}
