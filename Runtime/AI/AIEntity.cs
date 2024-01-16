using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

namespace SystemsLibrary.AI
{
    [Serializable]
    public class MotiveData
    {
        public string Name;
        [PropertyRange(-100, 100)] public float Status; // Dynamic status
        public float DecrimentalAmount;

        public MotiveData(Motive motive)
        {
            Name = motive.Name;
            Status = 0; // Initialize with default value
            DecrimentalAmount = motive.DecrimentalAmount;
        }

        // Method to update status
        public void UpdateStatus(float rateMultiplier)
        {
            if (Status > -100 && Status < 100)
                Status -= DecrimentalAmount * rateMultiplier;
        }
    }
    
    public class AIEntity : MonoBehaviour
    {
        public List<Motive> Motives;
        [ShowInInspector]
        public List<MotiveData> MotiveData { get; private set; } = new ();
    
        private float updateInterval = 0.1f;
        private float timer = 0;

        private void Start()
        {
            MotiveData.Clear();
            foreach (Motive m in Motives)
            {
                MotiveData.Add(new MotiveData(m));
            }
        }

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
            float rateMultiplier = updateInterval;
            foreach (MotiveData mData in MotiveData)
            {
                mData.UpdateStatus(rateMultiplier);
            }
        }
    }   
}
