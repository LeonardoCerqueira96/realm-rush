using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHits = 10;
    [SerializeField] private Text healthText;

    [SerializeField] private AudioClip baseHitClip;

    private int hits;

    void Start()
    {
        hits = maxHits;

        UpdateText();
    }

    public void HitBase()
    {
        hits--;
        UpdateText();
        PlayHitClip();

        if (hits < 1)
        {
            Debug.Log("Base dead");
        }
    }

    private void PlayHitClip()
    {
        AudioSource.PlayClipAtPoint(baseHitClip, Camera.main.transform.position, 1f);
    }

    private void UpdateText()
    {
        healthText.text = hits.ToString();
    }
}
