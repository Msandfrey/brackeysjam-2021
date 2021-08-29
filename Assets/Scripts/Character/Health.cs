using UnityEngine;
using UnityEngine.UI;

namespace IndieWizards.Character
{
    public class Health : MonoBehaviour
    {
        public delegate void DeathCallback();
        public DeathCallback onDeath;

        public delegate void DamageCallback();
        public DamageCallback onDamage;

        [SerializeField]
        private GameObject healthBar;

        [Header("Hit point settings")]
        //[SerializeField]
        //private int initialHitPoints = 1;
        [SerializeField]
        public int currentHitPoints;
        [SerializeField]
        public int maxHitPoints = 1;


        // Used to make sure we only trigger onDeath once
        private bool onDeathCallbackRaised;

        private void Awake()
        {
            currentHitPoints = maxHitPoints;
            onDeathCallbackRaised = false;
            if (healthBar) { healthBar.GetComponent<Slider>().maxValue = maxHitPoints; healthBar.GetComponent<Slider>().value = maxHitPoints; }
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
            if (healthBar) { AdjustHealthBar(); }
        }

        public void RestoreHealth(int hitPoints)
        {
            currentHitPoints = Mathf.Min(currentHitPoints + hitPoints, maxHitPoints);
            if (healthBar) { AdjustHealthBar(); }
        }

        public void AdjustHealthBar()
        {
            float hpPercentage = currentHitPoints / maxHitPoints;
            healthBar.GetComponent<Slider>().value = currentHitPoints;

        }
    }
}
