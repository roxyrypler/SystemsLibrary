using UnityEngine;

namespace SystemsLibrary.AI.Actions
{
    public class ConsumeCrackerAction: AIAction
    {
        public Motive _hungerMotive;
        public float hungerReward = 10; // Define reward for consuming the cracker

        // Define AnimationCurve fields
        public AnimationCurve priorityCurve;
        public AnimationCurve distanceCurve; // For distance

        public override float EvaluateAction(AIEntity ai)
        {
            // Check hunger motive
            MotiveData hungerMotive = ai.MotiveData.Find(m => m.Name == _hungerMotive.Name);
            if (hungerMotive == null)
                return 0; // Hunger motive not found

            // Calculate the expected hunger level after consuming the cracker
            float expectedHungerLevel = hungerMotive.Status - hungerReward; // Assuming reward decreases hunger

            // Normalize the expected hunger level
            float normalizedHunger = Mathf.Clamp((expectedHungerLevel + 100) / 200, 0, 1);

            // Evaluate hunger score based on expected level
            float hungerScore = priorityCurve.Evaluate(normalizedHunger);

            // Calculate and normalize distance
            float distance = Vector3.Distance(transform.position, ai.transform.position);
            float maxDistance = 10; // Define a maximum distance
            float normalizedDistance = Mathf.Clamp(distance / maxDistance, 0, 1);

            // Use curve to evaluate distance score
            float distanceScore = distanceCurve.Evaluate(normalizedDistance);

            // Combine scores (example: average)
            float combinedScore = (hungerScore + distanceScore) / 2;
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
                if (hungerMotive == null)
                    return; // Hunger motive not found
                hungerMotive.Status += hungerReward;
                ai.ClearCurrentAction();
                Destroy(gameObject);
            }
            
        }
    }
}