using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderBars : MonoBehaviour
{
    [SerializeField] private Slider bossHealthbar;
    [SerializeField] private Slider spdBoostbar;
    [SerializeField] private Slider shieldBar;
    [SerializeField] private Slider gunBar;

    void Start()
    {
        if (spdBoostbar != null) spdBoostbar.gameObject.SetActive(false);
        if (shieldBar != null) shieldBar.gameObject.SetActive(false);
        if (gunBar != null) gunBar.gameObject.SetActive(false);
        
    }

    public void UpdateHealth(float currHealth, float maxHealth)
    {
        bossHealthbar.value = currHealth/maxHealth;
    }

    public void CountdownSpd (float duration)
    {
        StopCoroutine("SpeedCountdown"); //reset if already running coroutine
        StartCoroutine(SpeedCountdown(duration));
    }

    public void CountdownShield (float duration)
    {
        StopCoroutine("ShieldCountdown");
        StartCoroutine(ShieldCountdown(duration));
    }

    public void CountdownGun (float duration)
    {
        StopCoroutine("GunCountdown");
        StartCoroutine(GunCountdown(duration));

    }


    private  IEnumerator SpeedCountdown (float duration)
    {
        yield return StartCoroutine(DrainBar(spdBoostbar, duration));
    }

    private IEnumerator ShieldCountdown (float duration)
    {
        yield return StartCoroutine(DrainBar(shieldBar, duration));
    }

    private IEnumerator GunCountdown (float duration)
    {
        yield return StartCoroutine(DrainBar(gunBar, duration));
    }




    private IEnumerator DrainBar (Slider slider, float duration)
    {
        if (slider == null) yield break;

        slider.gameObject.SetActive (true);
        float timeLeft = duration;

        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            slider.value = timeLeft / duration; //scales value from 1 to 0
            yield return null;
        }

        slider.gameObject.SetActive(false); //ensure bar is hidden when finished
    }
    
}
