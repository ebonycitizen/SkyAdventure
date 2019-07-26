using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Movement
{
    [TaskCategory("Movement")]
    [HelpURL("https://www.opsive.com/support/documentation/behavior-designer-movement-pack/")]
    [TaskIcon("Assets/Behavior Designer Movement/Editor/Icons/{SkinColor}RotateTowardsIcon.png")]
    public class Shooting : Action
    {
        [Tooltip("The GameObject that the agent is rotating towards")]
        public SharedGameObject target;

        public BirdShooter birdshooter;

        public override TaskStatus OnUpdate()
        {
            birdshooter.Shoot(target.Value);
            return TaskStatus.Success;

        }
        // Reset the public variables
        public override void OnReset()
        {
            target = null;
        }
    }
}