using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Character
{
    public class Bullets : MonoBehaviour
    {
        [SerializeField]
        protected GameObject owner;

        public void SetOwner(GameObject ownerObject)
        {
            owner = ownerObject;
        }
    }
}
