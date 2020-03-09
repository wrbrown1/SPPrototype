using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SP.Move;
using SP.Combat;
using System;

namespace SP.Controller
{
    public class PlayerCharacterController : MonoBehaviour
    {
        private void Update()
        {
            if (HandleCombat()) return;
            if (HandleMovement()) return;
            print("Do nothing");
        }

        private bool HandleCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(ClickRay());
            foreach(RaycastHit hit in hits)
            {
                if (hit.transform.GetComponent<Enemy>() == null) continue;
                if(Input.GetMouseButtonDown(0)) {
                    GetComponent<PlayerCombat>().Attack(hit.transform.GetComponent<Enemy>());
                }
                return true;
            }
            return false;
        }

        private bool HandleMovement()
        {
            RaycastHit hit;
            if (Physics.Raycast(ClickRay(), out hit))
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Movement>().MoveAction(hit.point);
                }
                return true;
            }
            return false;
        }

        private static Ray ClickRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
