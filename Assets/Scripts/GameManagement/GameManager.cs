using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace IndieWizards.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        public GameObject[] listOfWaves;
        [SerializeField]
        private int currentWave = 0;
        [SerializeField]
        private HashSet<GameObject> enemies;

        public int score;

        private void Awake()
        {
            enemies = new HashSet<GameObject>();
            listOfWaves[currentWave].SetActive(true);
            for(int i = 0; i < listOfWaves[currentWave].transform.childCount; i++)
            {
                Transform child = listOfWaves[currentWave].transform.GetChild(i);
                if (child.tag.Equals("Enemy"))
                {
                    enemies.Add(child.gameObject);
                }
            }
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if(currentWave >= listOfWaves.Length) { SceneManager.LoadScene("End"); }
            if(enemies.Count <= 0 && listOfWaves.Length > 0)
            {
                NextWave();
            }
        }

        public void NextWave()
        {
            listOfWaves[currentWave].SetActive(false);
            currentWave++;
            listOfWaves[currentWave].SetActive(true);
            for (int i = 0; i < listOfWaves[currentWave].transform.childCount; i++)
            {
                Transform child = listOfWaves[currentWave].transform.GetChild(i);
                if (child.tag.Equals("Enemy"))
                {
                    enemies.Add(child.gameObject);
                }
            }
        }

        public void RemoveEnemy(GameObject enemy)
        {
            enemies.Remove(enemy);
        }
    }
}
