using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndieWizards.Player
{
    public class Spin : MonoBehaviour
    {
        private int spinCount = 0;
        private bool isSpinning = false;
        private float startRotation = 0;
        private float endRotation = 360;
        [SerializeField]
        private float currRotation;
        [SerializeField]
        private float rotationStep;
        [SerializeField]
        private GameObject Player;
        private AudioManager audioManager;
        // Start is called before the first frame update
        private void Start() 
        {
            audioManager = FindObjectOfType<AudioManager>();
        }
        // Update is called once per frame
        void Update()
        {
            if (isSpinning && spinCount > 0)
            {
                //spin
                if(currRotation >= endRotation)
                {
                    spinCount--;
                    isSpinning = spinCount > 0;
                }
                else
                {
                    transform.Rotate(new Vector3(0, rotationStep * Time.deltaTime, 0));
                    currRotation += rotationStep * Time.deltaTime;
                    currRotation = Mathf.Clamp(currRotation, 0, 360);
                }
            }
            if (Input.GetKeyDown(KeyCode.Q)) { BeASpin(); }
        }

        public void BeASpin()
        {
            if (isSpinning) { return; }
            audioManager.PlayHitInCircleSound();
            currRotation = startRotation;
            spinCount++;
            isSpinning = true;
        }
    }
}
