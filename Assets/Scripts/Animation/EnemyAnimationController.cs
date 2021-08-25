using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Animation
{
    public class EnemyAnimationController : MonoBehaviour
    {
        [SerializeField]
        Animator animator;

        public void SetForm(int form)
        {
            animator.SetInteger("Form", form);
        }
    }
}
