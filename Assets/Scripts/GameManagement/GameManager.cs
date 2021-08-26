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
        private GameObject startUI;
        [SerializeField]
        private GameObject winLoseUI;
        [SerializeField]
        private GameObject textMesh;
        [SerializeField]
        private float timeDelayStartWave = 1f;
        private int currentWave = 0;
        private HashSet<GameObject> enemies;
        private bool isWaveSpawned = false;
        private bool isWaitForStart = true;

        public int score;

        private void Awake()
        {
            enemies = new HashSet<GameObject>();
            StartCoroutine(WaveStartDelay());
        }

        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (isWaitForStart && Input.GetKeyDown(KeyCode.X)) { BeginGame(); }
            if (isWaitForStart) { return; }
            if (Input.GetKeyDown(KeyCode.P)) { Time.timeScale = Time.timeScale == 0 ? 1 : 0; }//need better pause
            if(currentWave >= listOfWaves.Length) { EndGame(); }
            if(enemies.Count <= 0 && listOfWaves.Length > currentWave && isWaveSpawned)
            {
                NextWave();
                isWaveSpawned = false;
                StartCoroutine(WaveStartDelay());
            }
        }

        public void BeginGame()
        {
            isWaitForStart = false; Time.timeScale = 1; startUI.SetActive(false);
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
                //if (child.tag.Equals("Enemy"))
                //{
                    enemies.Add(child.gameObject);
                //}
            }
            Debug.Log(enemies.Count);
            isWaveSpawned = true;
        }

        public void RemoveEnemy(GameObject enemy)
        {
            enemies.Remove(enemy);
        }

        public void EndGame()
        {
            winLoseUI.SetActive(true); 
            Time.timeScale = 0;
        }
    }
}
