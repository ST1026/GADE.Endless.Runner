using UnityEngine;
using UnityEngine.UI;

public class SliderBars : MonoBehaviour
{
    [SerializeField] private Slider bossHealthbar;

    public void UpdateHealth(float currHealth, float maxHealth)
    {
        bossHealthbar.value = currHealth/maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
