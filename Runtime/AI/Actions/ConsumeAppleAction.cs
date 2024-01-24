using UnityEngine;

namespace SystemsLibrary.AI.Actions
{
    public class ConsumeAppleAction : AIAction
    {
        public Motive _hungerMotive;
        public Motive _hydrationMotive;

        // Define rewards
        public float hungerReward = 20; // Reward for reducing hunger
        public float hydrationReward = 15; // Reward for increasing hydration

        // Define AnimationCurve fields
        public AnimationCurve HungerPriorityCurve;
        public AnimationCurve HydrationPriorityCurve;
        public AnimationCurve distanceCurve; // For distance

        public override float EvaluateAction(AIEntity ai)
        {
            // Check hunger and hydration motives
            MotiveData hungerMotive = ai.MotiveData.Find(m => m.Name == _hungerMotive.Name);
            MotiveData hydrationMotive = ai.MotiveData.Find(m => m.Name == _hydrationMotive.Name);
            if (hungerMotive == null || hydrationMotive == null)
                return 0; // Motive not found

            // Calculate the expected hunger and hydration levels after consuming the apple
            float expectedHungerLevel = hungerMotive.Status - hungerReward; // Assuming reward decreases hunger
            float expectedHydrationLevel = hydrationMotive.Status - hydrationReward; // Assuming reward increases hydration

            // Normalize the expected levels
            float normalizedHunger = Mathf.Clamp((expectedHungerLevel + 100) / 200, 0, 1);
            float normalizedHydration = Mathf.Clamp((expectedHydrationLevel + 100) / 200, 0, 1);

            // Evaluate scores based on expected levels
            float hungerScore = HungerPriorityCurve.Evaluate(normalizedHunger);
            float hydrationScore = HydrationPriorityCurve.Evaluate(normalizedHydration);

            // Calculate and normalize distance
            float distance = Vector3.Distance(transform.position, ai.transform.position);
            float maxDistance = 10; // Define a maximum distance
            float normalizedDistance = Mathf.Clamp(distance / maxDistance, 0, 1);

            // Use curve to evaluate distance score
            float distanceScore = distanceCurve.Evaluate(normalizedDistance);

            // Combine scores (example: average)
            float combinedScore = (hungerScore + hydrationScore + distanceScore) / 3;
            return combinedScore;
        }

        public override void ExecuteAction(AIEntity ai)
        {
            
            // Logic to find and consume food
            ai.agent.SetDestination(transform.position);
            var distance = Vector3.Distance(transform.position, ai.transform.position);
            print(distance);
            if (distance <= 1)
            {
                MotiveData hungerMotive = ai.MotiveData.Find(m => m.Name == _hungerMotive.Name);
                MotiveData hydrationMotive = ai.MotiveData.Find(m => m.Name == _hydrationMotive.Name);
                if (hungerMotive == null || hydrationMotive == null)
                    return; // Motive not found

                hungerMotive.Status += hungerReward;
                hydrationMotive.Status += hydrationReward;
                ai.ClearCurrentAction();
                Destroy(gameObject);
            }
            
        }
    }
}