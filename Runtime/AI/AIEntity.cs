using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

public class AIEntity : MonoBehaviour
{
    [ProgressBar(-100, 100, r: 0, g: 1, b: 0, Height = 20)]
    public float Hunger = 100;
    [ProgressBar(-100, 100, r: 0, g: 1, b: 0, Height = 20)]
    public float Energy = 100;
    [ProgressBar(-100, 100, r: 0, g: 1, b: 0, Height = 20)]
    public float Bladder = 100;
    [ProgressBar(-100, 100, r: 0, g: 1, b: 0, Height = 20)]
    public float Social = 100;
    [ProgressBar(-100, 100, r: 0, g: 1, b: 0, Height = 20)]
    public float Hygiene = 100;
    [ProgressBar(-100, 100, r: 0, g: 1, b: 0, Height = 20)]
    public float Comfort = 100;
    [ProgressBar(-100, 100, r: 0, g: 1, b: 0, Height = 20)]
    public float Tidiness = 100;
    [ProgressBar(-100, 100, r: 0, g: 1, b: 0, Height = 20)]
    public float Fun = 100;

    private float HungerDeclineRate = 1;
    private float EnergyDeclineRate = 1;
    private float BladderDeclineRate = 1;
    private float SocialDeclineRate = 1;
    private float HygieneDeclineRate = 1;
    private float ComfortDeclineRate = 1;
    private float TidinessDeclineRate = 1;
    private float FunDeclineRate = 1;

    private float updateInterval = 0.1f; // Interval for updating motives (10 times per second)
    private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= updateInterval)
        {
            MotiveDegradation();
            timer = 0;
        }
    }

    private void MotiveDegradation()
    {
        float rateMultiplier = updateInterval; // Multiplier to adjust the decline rate per update

        Hunger -= HungerDeclineRate * rateMultiplier;
        Energy -= EnergyDeclineRate * rateMultiplier;
        Bladder -= BladderDeclineRate * rateMultiplier;
        Social -= SocialDeclineRate * rateMultiplier;
        Hygiene -= HygieneDeclineRate * rateMultiplier;
        Comfort -= ComfortDeclineRate * rateMultiplier;
        Tidiness -= TidinessDeclineRate * rateMultiplier;
        Fun -= FunDeclineRate * rateMultiplier;
    }
}
