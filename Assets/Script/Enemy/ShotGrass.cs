using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Movement
{
    [TaskCategory("Movement")]
    [TaskIcon("Assets/Behavior Designer Movement/Editor/Icons/{SkinColor}PursueIcon.png")]
    public class ShotGrass : NavMeshMovement
    {
        public TurtleShooter TurtleShooter;

        public override void OnStart()
        {
            base.OnStart();
        }
        public override TaskStatus OnUpdate()
        {
            TurtleShooter.GetComponent<TurtleShooter>().Shoot();
            return TaskStatus.Success;
        }

        // Reset the public variables
        public override void OnReset()
        {
            base.OnReset();
        }
    }
}