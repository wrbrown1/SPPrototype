using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SP.Move;
using SP.Core;

namespace SP.Combat
{
    public class PlayerCombat : MonoBehaviour, ActionInterface
    {

        Transform target;
        float timeSinceLastAttack = 0f;

        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] float attackRange = 2f;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            if(!target) return;
            if (!IsInAttackRange())
            {
                GetComponent<Movement>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Movement>().Cancel();
                HandleAttack();
            }
        }

        private void HandleAttack()
        {
            if(timeSinceLastAttack > timeBetweenAttacks)
            {
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLastAttack = 0f;
            }
        }

        private bool IsInAttackRange()
        {
            return Vector3.Distance(transform.position, target.position) < attackRange;
        }

        public void Attack(Enemy enemy)
        {
            GetComponent<ActionAgenda>().Act(this);
            target = enemy.transform;
        }

        public void Cancel()
        {
            target = null;
        }

        //Animation event that is called within the animator
        void Shoot()
        {
            print("hit");
        }
    }
}
