using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SP.Core;

namespace SP.Move
{
    public class Movement : MonoBehaviour, ActionInterface
    {
        private void Update()
        {
            UpdateAnimation();
        }

        private void UpdateAnimation()
        {
            Vector3 agentVelocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localAgentVelocity = transform.InverseTransformDirection(agentVelocity);//Gets the local velocity instead of the world velocity
            float speed = localAgentVelocity.z;
            GetComponent<Animator>().SetFloat("forwardRunSpeed", speed);
        }

        public void MoveTo(Vector3 destination)
        {
            GetComponent<NavMeshAgent>().destination = destination;
            GetComponent<NavMeshAgent>().isStopped = false;
        }

        public void MoveAction(Vector3 destination)
        {
            GetComponent<ActionAgenda>().Act(this);
            MoveTo(destination);
        }

        public void Cancel()
        {
            GetComponent<NavMeshAgent>().isStopped = true;
        }

    }
}
