using RPG.Movement;
using UnityEngine;

namespace RPG.Combat {
    public class Fighter : MonoBehaviour {

        [SerializeField] float weaponRange = 2f;
        Transform target;

        private void Update () {

            if (target == null) return;

            var moverComponent = GetComponent<Mover> ();

            if (target != null && !GetIsInRage ()) {
                //move to traget
                moverComponent.MoveTo (target.position);
            } else {
                moverComponent.Stop ();
            }
        }

        public void Attack (CombatTarget combatTarget) {
            target = combatTarget.transform;
            print ("Take you short, squat peasant!");
        }

        // Cancel following the target to attack it. 
        public void Cancel () {
            target = null;
        }

        public bool GetIsInRage () {
            return Vector3.Distance (transform.position, target.position) < weaponRange;
        }
    }
}