using UnityEngine;

public class PauseDisableList : MonoBehaviour
{
    public MonoBehaviour[] behaviours;
    private PauseManager pauseManager;

    void Start()
    {
        pauseManager = FindAnyObjectByType<PauseManager>();
    }

    void Update()
    {
        SetBehavioursEnabled(!pauseManager.paused);
    }

    void SetBehavioursEnabled(bool enable)
    {
        foreach(MonoBehaviour behaviour in behaviours)
        {
            behaviour.enabled = enable;
        }
    }
}
