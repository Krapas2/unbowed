using UnityEngine;

public class PauseDisableList : MonoBehaviour
{
    public MonoBehaviour[] behaviours;
    private PauseManager pauseManager;
    private bool[] originalStates;
    private bool wasPaused;

    void Start()
    {
        pauseManager = FindAnyObjectByType<PauseManager>();
        originalStates = new bool[behaviours.Length];
    }

    void Update()
    {
        bool isPaused = pauseManager.paused;

        if (isPaused && !wasPaused)
        {
            OnPause();
        }
        else if (!isPaused && wasPaused)
        {
            OnUnpause();
        }

        wasPaused = isPaused;
    }

    void OnPause()
    {
        SaveAndDisableBehaviours();
    }

    void OnUnpause()
    {
        RestoreBehaviours();
    }

    void SaveAndDisableBehaviours()
    {
        for (int i = 0; i < behaviours.Length; i++)
        {
            originalStates[i] = behaviours[i].enabled;
            behaviours[i].enabled = false;
        }
    }

    void RestoreBehaviours()
    {
        for (int i = 0; i < behaviours.Length; i++)
        {
            behaviours[i].enabled = originalStates[i];
        }
    }
}
