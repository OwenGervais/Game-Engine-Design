using UnityEngine;
using TMPro;

//Owen From 15 mins earlier: Poor method, works fine for now I guess. Switch to Scriptable Objects for phases going forward.

//Owen From 15 mins later: Yeah I'm gonna rewrite this whole thing
enum GameState
{
    PhaseOne,
    PhaseTwo
}

public class GameController : MonoBehaviour
{
    [SerializeField] private int phaseOneDuration = 60;
    [SerializeField] private int phaseTwoDuration = 60;

    [SerializeField] private GameObject phase1;
    [SerializeField] private GameObject phase2;
    [SerializeField] private GameObject winText;
    
    private int phaseTimer = 0;
    private int currentPhaseDuration = 60;

    private int currentPhase = 0;

    void Awake()
    {
        PhaseChange(GameState.PhaseOne);
    }

    void Update()
    {
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
        Debug.Log("You're fucked");

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
}
