using UnityEngine.AI;

namespace SystemsLibrary.AI.Actions
{
    public class FindFoodAction : AIAction
    {
        public override float EvaluateAction(AIEntity ai)
        {
            MotiveData hungerMotive = ai.MotiveData.Find(m => m.Name == motive.Name);
            if (hungerMotive == null)
                return 0; // Hunger motive not found

            float hungerLevel = hungerMotive.Status;

            // Calculate score based on hunger level
            if (hungerLevel < -20)
            {
                // Example: linear increase in score as hunger decreases further from -20
                return 20 - hungerLevel; // The more negative the hunger, the higher the score
            }

            return 0; // No need for action if hunger is above -20
        }


        public override void ExecuteAction(AIEntity ai)
        {
            // Logic to find and consume food
            ai.agent.SetDestination(transform.position);
        }
    }
}