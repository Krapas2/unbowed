using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseUI;
    public bool startPaused;

    [HideInInspector]
    public bool paused;

    void Start()
    {
        SetPause(startPaused);
    }

    void Update()
    {
        bool pressedEsc = Input.GetKeyDown(KeyCode.Escape);

        if (pressedEsc)
        {
            SetPause(pressedEsc ^ paused);
        }
    }

    void SetPause(bool paused)
    {
        this.paused = paused;
        Cursor.lockState = paused ? CursorLockMode.None : CursorLockMode.Locked;
        pauseUI.SetActive(paused);
    }
}
