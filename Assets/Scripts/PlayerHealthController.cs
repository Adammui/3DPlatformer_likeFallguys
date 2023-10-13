using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{

    [SerializeField]
    private int healthInitial = 3;
    public int healthCurrent;

    [SerializeField]
    //private GameObject _hp;
    private GameObject _defeatUI, _winUI;

    // Is called automatically before the first frame update
    void Start()
    {
        // create holder and pic
        /*
        GameObject imgObject = new GameObject("a");
        RectTransform trans = imgObject.AddComponent<RectTransform>();
        trans.transform.SetParent(_canvas.transform); // setting parent
        trans.anchoredPosition = new Vector2(0f, 0f); // setting position, will be on center
        trans.sizeDelta = new Vector2(25, 25); // custom size
        
        Image image = imgObject.AddComponent<Image>();
        Sprite img1 = Resources.Load<Sprite>("heart-icon-14");
        image.GetComponent<Image>().sprite = img1;

        imgObject.transform.SetParent(_canvas.transform);
        */
        //_defeatUI = GameObject.Find("Defeat UI");
        //_winUI = GameObject.Find("Win UI");
        ResetHealth();
    }

    // Sets player's current health back to its initial value
    public void ResetHealth()
    {
        Time.timeScale = 1;
        healthCurrent = healthInitial;
        DrawHeart("0");
        DrawHeart("1");
        DrawHeart("2");
    }

    private void EraseHeart(string healthAfter)
    {
        GameObject heart = GameObject.Find(healthAfter);
        heart.SetActive(false);
    }

    private void DrawHeart(string healthDefore)
    {
        GameObject heart = GameObject.Find(healthDefore);
        heart.SetActive(true);
    }

    // Handles all the stuff when player looses all hp
    public void HandleDeath()
    {
        
        _defeatUI.SetActive(true);
        Time.timeScale = 0;
        // animation

        // spawn system - reset game
        // game system counts time from start to finish and shows interface
        // - win and loose also counts number of deaths

    }

    // Reduces player's current health
    public void TakeDamage(int damageAmount)
    {
        healthCurrent -= damageAmount;
        EraseHeart(healthCurrent.ToString());

        if (healthCurrent <= 0)
        {
            HandleDeath();
        }
    }

    //Increases player's current health
    public void Heal(int healAmount)
    {
        DrawHeart(healthCurrent.ToString());
        healthCurrent += healAmount;
        if (healthCurrent > healthInitial)
        {
            ResetHealth();
        }
    }
}