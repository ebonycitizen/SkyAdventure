using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Movement
{
    [TaskCategory("Movement")]
    [HelpURL("https://www.opsive.com/support/documentation/behavior-designer-movement-pack/")]
    [TaskIcon("Assets/Behavior Designer Movement/Editor/Icons/{SkinColor}RotateTowardsIcon.png")]
    public class OnLookAt : Action
    {
        [Tooltip("The GameObject that the agent is rotating towards")]
        public SharedGameObject target;
        
        public override TaskStatus OnUpdate()
        {
            Vector3 direction = (target.Value.transform.position - this.transform.position).normalized;
            this.transform.forward = direction;
            this.transform.LookAt(target.Value.transform.position);
            
            return TaskStatus.Running;

        }
        // Reset the public variables
        public override void OnReset()
        {
            target = null;
        }
    }
}