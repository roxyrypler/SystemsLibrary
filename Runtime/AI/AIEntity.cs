using System;
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
    
    [RequireComponent(typeof(GameObjectBoxTracker))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class AIEntity : MonoBehaviour
    {
        public List<Motive> Motives;
        [ShowInInspector] public List<MotiveData> MotiveData { get; private set; } = new ();
        [ShowInInspector] public List<AIAction> availableActions;
        [ShowInInspector] public AIAction currentAction;

        [HideInInspector] public GameObjectBoxTracker goTracker;
        [HideInInspector] public NavMeshAgent agent;
        private float motiveUpdateInterval = 0.1f;
        private float actionUpdateInterval = 1;
        private float motiveTimer = 0;
        private float actionTimer = 0;

        private void Start()
        {
            goTracker = GetComponent<GameObjectBoxTracker>();
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            motiveTimer += Time.deltaTime;
            actionTimer += Time.deltaTime;
            if (motiveTimer >= motiveUpdateInterval)
            {
                UpdateMotives();
                motiveTimer = 0;
            }
            
            if (actionTimer >= actionUpdateInterval)
            {
                FindActions();
                actionTimer = 0;
            }
        }

        private void UpdateMotives()
        {
            float rateMultiplier = motiveUpdateInterval;
            foreach (MotiveData mData in MotiveData)
            {
                mData.UpdateStatus(rateMultiplier);
            }
        }

        void FindActions()
        {
            availableActions.Clear();
            List<GameObject> gosInRange = goTracker.PerformCast();
            foreach (var go in gosInRange)
            {
                AIAction action = go.GetComponent<AIAction>();
                if (action)
                {
                    availableActions.Add(action);
                }
            }

            ChooseAction();
        }
        
        void ChooseAction()
        {
            
            //print("Action chooser timer");
            AIAction bestAction = null;
            float bestScore = float.MinValue;

            foreach (var action in availableActions)
            {
                float score = action.EvaluateAction(this);
                if (score > bestScore)
                {
                    bestScore = score;
                    bestAction = action;
                }
            }

            if (bestAction != currentAction)
            {
                currentAction = bestAction;
                // Optionally cancel the current action and start the new one
            }

            currentAction?.ExecuteAction(this);
        }

        public void ClearCurrentAction()
        {
            currentAction = null;
        }
    }   
}
