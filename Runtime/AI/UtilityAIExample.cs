using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SystemsLibrary.AI
{
    public class UtilityAIExample: MonoBehaviour
    {
        [ProgressBar(-100, 100, r: 0, g: 1, b: 0, Height = 20)]
        public float health;
        [ProgressBar(-100, 100, r: 0, g: 1, b: 0, Height = 20)]
        public float distanceToEnemy;

        public List<string> actionStrings;

        private void Update()
        {
            DecideAction();    
        }
        
        public void DecideAction()
        {
            var actions = new Dictionary<Action, float>
            {
                { PerformAttack, CalculateAttackUtility() },
                { PerformFlee, CalculateFleeUtility() },
                { PerformSearchForHealth, CalculateSearchHealthUtility() }
            };
            
            var sortedActions = actions.OrderByDescending(a => a.Value);
            var bestAction = sortedActions.First().Key;
            bestAction.Invoke();

            actionStrings.Clear();
            foreach (var _action in sortedActions)
            {
                actionStrings.Add(_action.Key.Method.Name + " : " + _action.Value);
            }
        }

        float CalculateAttackUtility()
        {
            // Utility calculation for attack
            return (100 - distanceToEnemy) * health;
        }

        float CalculateFleeUtility()
        {
            // Utility calculation for flee
            return distanceToEnemy * (100 - health);
        }

        float CalculateSearchHealthUtility()
        {
            // Utility calculation for search for health
            return 100 - health;
        }

        void PerformAttack()
        {
            print("Attacking the enemy.");
        }

        void PerformFlee()
        {
            print("Fleeing from the enemy.");
        }

        void PerformSearchForHealth()
        {
            print("Searching for health.");
        }
    }
}