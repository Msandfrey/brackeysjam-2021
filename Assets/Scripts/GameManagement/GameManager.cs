using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace IndieWizards.GameManagement
{
    public class GameManager : MonoBehaviour
    {
        public GameObject[] listOfWaves;
        [SerializeField]
        private GameObject textMesh;
        [SerializeField]
        private float timeDelayStartWave = 1f;
        private int currentWave = 0;
        [SerializeField]
        private HashSet<GameObject> enemies;
        private bool isWaveSpawned = false;

        public int score;

        private void Awake()
        {
            enemies = new HashSet<GameObject>();
            StartCoroutine(WaveStartDelay());
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P)) { Time.timeScale = Time.timeScale == 0 ? 1 : 0; }//need better pause
            if(currentWave >= listOfWaves.Length) { SceneManager.LoadScene("End"); }
            if(enemies.Count <= 0 && listOfWaves.Length > currentWave && isWaveSpawned)
            {
                NextWave();
                isWaveSpawned = false;
                StartCoroutine(WaveStartDelay());
            }
        }

        public void AddToScore(int value)
        {
            score += value;
            textMesh.GetComponent<TextMeshProUGUI>().text = score.ToString();
        }

        IEnumerator WaveStartDelay()
        {
            yield return new WaitForSeconds(timeDelayStartWave);
            StartWave();
        }

        public void NextWave()
        {
            listOfWaves[currentWave].SetActive(false);
            currentWave++;
        }

        public void StartWave()
        {
            if (currentWave >= listOfWaves.Length){ return; }
            listOfWaves[currentWave].SetActive(true);
            for (int i = 0; i < listOfWaves[currentWave].transform.childCount; i++)
            {
                Transform child = listOfWaves[currentWave].transform.GetChild(i);
                if (child.tag.Equals("Enemy"))
                {
                    enemies.Add(child.gameObject);
                }
            }
            isWaveSpawned = true;
        }

        public void RemoveEnemy(GameObject enemy)
        {
            enemies.Remove(enemy);
        }
    }
}
