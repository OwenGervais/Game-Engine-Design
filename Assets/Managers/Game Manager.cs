using UnityEngine;
using UnityEngine.SceneManagement;

enum GameState
{
    PhaseOne,
    PhaseTwo,
    PhaseThree
}

namespace Patterns.Creational.Factory.Usage
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private int phaseOneDuration = 60;
        [SerializeField] private int phaseTwoDuration = 60;

        [SerializeField] private GameObject winText;

        private int phaseTimer = 0;
        private int currentPhaseDuration = 60;

        private int currentPhase = 0;
        private bool complete = false;

        [SerializeField] private EnemyFactory factory;

        private IEnemy enemy1;
        private IEnemy enemy2;

        void Awake()
        {
            enemy1 = factory.CreateEnemy(EnemyType.Enemy1, new Vector3(0, 8, 0));
            enemy2 = factory.CreateEnemy(EnemyType.Enemy2, new Vector3(0, 8, 0));

            PhaseChange(GameState.PhaseOne);

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.R)) Restart();

            if (Input.GetKeyDown(KeyCode.T)) SceneAndScoreReset();

            phaseTimer++;

            if (phaseTimer >= currentPhaseDuration * 60)
            {
                if (currentPhase == 0)
                {
                    PhaseChange(GameState.PhaseTwo);
                    
                }
                else
                {
                    if (!complete)
                    {
                        complete = true;
                        enemy2.Die();
                        winText.SetActive(true);
                    }
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

                    enemy1.Attack();
                    phaseTimer = 0;
                    currentPhaseDuration = phaseOneDuration;
                    break;
                case GameState.PhaseTwo:
                    enemy1.Die();
                    enemy2.Attack();
                    phaseTimer = 0;
                    currentPhaseDuration = phaseTwoDuration;
                    currentPhase = 1;
                    break;
            }
        }

        void Restart() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }

        void SceneAndScoreReset()
        {
            ScoreManager.Instance.ResetScore();
            Restart();
        }

        public void PhaseEnd()
        {
            //Wipe the play area of projectiles.
        }
    }
}