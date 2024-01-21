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
            Status = motive.StartingAmount;
            DecrimentalAmount = motive.DecrimentalAmount;
        }

        // Method to update status
        public void UpdateStatus(float rateMultiplier)
        {
            // Update the status
            Status -= DecrimentalAmount * rateMultiplier;

            // Clamp the status to ensure it stays within the range of -100 to 100
            Status = Mathf.Clamp(Status, -100, 100);
        }
    }
    
    [RequireComponent(typeof(GameObjectBoxTracker))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class AIEntity : MonoBehaviour
    {
        [Tooltip("Motive SOs")]
        public List<Motive> Motives;
        [ShowInInspector] public List<MotiveData> MotiveData = new ();
        [ShowInInspector] public Dictionary<AIAction, float> availableActions;
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

            SetupMotives();
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
                ChooseAction();
                actionTimer = 0;
            }
        }

        void SetupMotives()
        {
            MotiveData.Clear();
            foreach (var motive in Motives)
            {
                MotiveData.Add(new MotiveData(motive));
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
            if (availableActions == null)
            {
                availableActions = new Dictionary<AIAction, float>();
            }

            availableActions.Clear();

            if (goTracker == null)
            {
                Debug.LogError("GameObjectBoxTracker is not set.");
                return;
            }

            List<GameObject> gosInRange = goTracker.PerformCast();
            if (gosInRange == null)
            {
                Debug.LogError("gosInRange is null.");
                return;
            }

            foreach (var go in gosInRange)
            {
                AIAction action = go.GetComponent<AIAction>();
                if (action != null)
                {
                    availableActions.Add(action, 0);
                }
            }
        }
        
        void ChooseAction()
        {
            AIAction bestAction = null;
            float bestScore = float.MinValue;

            List<AIAction> keys = new List<AIAction>(availableActions.Keys);

            foreach (var action in keys)
            {
                float score = action.EvaluateAction(this);
                if (score > bestScore)
                {
                    availableActions[action] = score; // Update the value in the dictionary
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
        
        // Causes and effects

        void DecreaseEnergyWhenMoving()
        {
            // TODO
        }
        
        // Debug functions

        [Button]
        void TakeDamage()
        {
            // TODO
        }

        [Button]
        void MoveToRandomLocationInRange()
        {
            // TODO
        }
    }   
}
