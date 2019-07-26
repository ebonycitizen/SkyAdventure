using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Movement
{
    [TaskDescription("Rotates towards the specified rotation. The rotation can either be specified by a transform or rotation. If the transform " +
                     "is used then the rotation will not be used.")]
    [TaskCategory("Movement")]
    [HelpURL("https://www.opsive.com/support/documentation/behavior-designer-movement-pack/")]
    [TaskIcon("Assets/Behavior Designer Movement/Editor/Icons/{SkinColor}RotateTowardsIcon.png")]
    public class RotateTowards : Action
    {
        [Tooltip("Should the 2D version be used?")]
        public bool usePhysics2D;
        [Tooltip("The agent is done rotating when the angle is less than this value")]
        public SharedFloat rotationEpsilonMin = 0.5f;
        [Tooltip("The agent is done rotating when the angle is less than this value")]
        public SharedFloat rotationEpsilonMax = 0.5f;
        [Tooltip("The maximum number of angles the agent can rotate in a single tick")]
        public SharedFloat maxLookAtRotationDelta = 1;
        [Tooltip("Should the rotation only affect the Y axis?")]
        public SharedBool onlyY;
        [Tooltip("The GameObject that the agent is rotating towards")]
        public SharedGameObject target;
        [Tooltip("If target is null then use the target rotation")]
        public SharedVector3 targetRotation;

        public SharedBool IsRotating;

        public override TaskStatus OnUpdate()
        {
            var rotation = Target();
            
            var rotationAngleInXZ = Quaternion.Angle(transform.rotation, rotation);

            // Return a task status of success once we are done rotating
            if (rotationAngleInXZ < rotationEpsilonMin.Value)
            {
                IsRotating.Value = false;
                return TaskStatus.Success;
            }
            // Return a task status of success once we are done rotating
            if (rotationAngleInXZ < rotationEpsilonMax.Value)
            {
                IsRotating.Value = false;
                return TaskStatus.Success;
            }

            // We haven't reached the target yet so keep rotating towards it
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, maxLookAtRotationDelta.Value);
            IsRotating.Value = true;
            return TaskStatus.Running;
        }

        // Return targetPosition if targetTransform is null
        private Quaternion Target()
        {
            if (target == null || target.Value == null)
            {
                return Quaternion.Euler(targetRotation.Value);
            }
            var position = target.Value.transform.position - transform.position;
            if (onlyY.Value)
            {
                position.y = 0;
            }
            if (usePhysics2D)
            {
                var angle = Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg;
                return Quaternion.AngleAxis(angle, Vector3.forward);
            }
            return Quaternion.LookRotation(position);
        }

        // Reset the public variables
        public override void OnReset()
        {
            usePhysics2D = false;
            rotationEpsilonMin = 0.5f;
            maxLookAtRotationDelta = 1f;
            onlyY = false;
            target = null;
            targetRotation = Vector3.zero;
        }
    }
}