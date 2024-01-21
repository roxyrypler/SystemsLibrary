using UnityEngine;

namespace SystemsLibrary.AI.Actions
{
    public class ConsumeWaterBottleAction: AIAction
    {
        public Motive _hydrationMotive;
        public float hydrationReward = 15; // Define reward for consuming the water bottle

        // Define AnimationCurve fields
        public AnimationCurve priorityCurve;
        public AnimationCurve distanceCurve; // For distance

        public override float EvaluateAction(AIEntity ai)
        {
            // Check hydration motive
            MotiveData hydrationMotive = ai.MotiveData.Find(m => m.Name == _hydrationMotive.Name);
            if (hydrationMotive == null)
                return 0; // Hydration motive not found

            // Calculate the expected hydration level after consuming the water bottle
            float expectedHydrationLevel = hydrationMotive.Status - hydrationReward; // Assuming reward increases hydration

            // Normalize the expected hydration level
            float normalizedHydration = Mathf.Clamp((expectedHydrationLevel + 100) / 200, 0, 1);

            // Evaluate hydration score based on expected level
            float hydrationScore = priorityCurve.Evaluate(normalizedHydration);

            // Calculate and normalize distance
            float distance = Vector3.Distance(transform.position, ai.transform.position);
            float maxDistance = 10; // Define a maximum distance
            float normalizedDistance = Mathf.Clamp(distance / maxDistance, 0, 1);

            // Use curve to evaluate distance score
            float distanceScore = distanceCurve.Evaluate(normalizedDistance);

            // Combine scores (example: average)
            float combinedScore = (hydrationScore + distanceScore) / 2;
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
                // Check hydration motive
                MotiveData hydrationMotive = ai.MotiveData.Find(m => m.Name == _hydrationMotive.Name);
                if (hydrationMotive == null)
                    return; // Hydration motive not found
                hydrationMotive.Status += hydrationReward;
                ai.ClearCurrentAction();
                Destroy(gameObject);
            }
            
        }
    }
}