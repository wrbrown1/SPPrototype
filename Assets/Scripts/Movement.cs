using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace SP.Move
{
    public class Movement : MonoBehaviour
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
        }
    }
}
