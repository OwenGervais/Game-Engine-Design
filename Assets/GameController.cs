using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

enum GameState
{
    PhaseOne,
    PhaseTwo
}

namespace Patterns.Creational.Factory.Usage
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }

        public int CurrentScore { get; set; }

        [SerializeField] private int phaseOneDuration = 60;
        [SerializeField] private int phaseTwoDuration = 60;

        [SerializeField] private GameObject phase1;
        [SerializeField] private GameObject phase2;
        [SerializeField] private GameObject winText;
        [SerializeField] private TMP_Text scoreText;

        private int phaseTimer = 0;
        private int currentPhaseDuration = 60;

        private int currentPhase = 0;

        [SerializeField] private EnemyFactory factory;

        void Start()
        {
            IEnemy enemy1 = factory.CreateEnemy(EnemyType.Enemy1, new Vector3(0, 0, 0));
            IEnemy enemy2 = factory.CreateEnemy(EnemyType.Enemy2, new Vector3(0, 0, 0));
        }

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            PhaseChange(GameState.PhaseOne);
        }

        void Update()
        {
            scoreText.text = CurrentScore.ToString();

            if (Input.GetKeyDown(KeyCode.R)) Restart();


            phaseTimer++;

            if (phaseTimer >= currentPhaseDuration * 60)
            {
                if (currentPhase == 0)
                {
                    PhaseChange(GameState.PhaseTwo);
                }
                else
                {
                    phase2.SetActive(false);
                    winText.SetActive(true);
                }
            }

            Debug.Log("FPS: " + 1.0f / Time.deltaTime);
        }

        void PhaseChange(GameState gameState)
        {
            //When changing phases switch active spawners and destroy all projectiles
            switch (gameState)
            {
                case GameState.PhaseOne:

                    phase1.SetActive(true);
                    phase2.SetActive(false);
                    phaseTimer = 0;
                    currentPhaseDuration = phaseOneDuration;
                    break;
                case GameState.PhaseTwo:
                    phase1.SetActive(false);
                    phase2.SetActive(true);
                    phaseTimer = 0;
                    currentPhaseDuration = phaseTwoDuration;
                    currentPhase = 1;
                    break;
            }
        }

        void Restart() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }

        public void PhaseEnd()
        {
            //Wipe the play area of projectiles.
        }
    }
}