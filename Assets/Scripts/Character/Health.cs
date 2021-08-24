using UnityEngine;

namespace IndieWizards.Character
{
    public class Health : MonoBehaviour
    {
        public delegate void DeathCallback();
        public DeathCallback onDeath;

        public delegate void DamageCallback();
        public DamageCallback onDamage;

        [Header("Hit point settings")]
        //[SerializeField]
        //private int initialHitPoints = 1;
        [SerializeField]
        private int maxHitPoints = 1;

        private int currentHitPoints;

        // Used to make sure we only trigger onDeath once
        private bool onDeathCallbackRaised;

        private void Awake()
        {
            currentHitPoints = maxHitPoints;
            onDeathCallbackRaised = false;
        }

        public void TakeDamage(int hitPoints)
        {
            currentHitPoints = Mathf.Max(currentHitPoints - hitPoints, 0);
            if (currentHitPoints > 0)
            {
                onDamage?.Invoke();
            }
            else if (currentHitPoints == 0 && !onDeathCallbackRaised)
            {
                onDeath?.Invoke();
                onDeathCallbackRaised = true;
            }
        }

        public void RestoreHealth(int hitPoints)
        {
            currentHitPoints = Mathf.Min(currentHitPoints + hitPoints, maxHitPoints);
        }
    }
}
