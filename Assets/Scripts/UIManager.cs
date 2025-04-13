using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] TMP_Text heroModeText;
    [SerializeField] TMP_Text eggCountText;
    [SerializeField] TMP_Text eggKillsText;
    [SerializeField] TMP_Text touchKillsText;
    [SerializeField] TMP_Text pausedText;

    public int eggsOnScreen;
    public int eggKills;
    public int touchKills;

    public bool paused = false;

    void Awake()
    {
        Instance = this;   
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(paused)
            {
                //Unpause
                pausedText.enabled = false;
                Time.timeScale = 1f;
                paused = false;
            }
            else
            {
                //Pause
                pausedText.enabled = true;
                Time.timeScale = 0f;
                paused = true;
            }
        }
    }

    public void SetEggs()
    {
        eggCountText.text = "EGGS ON SCREEN: " + eggsOnScreen;
    }

    public void SetKills()
    {
        eggKillsText.text = "DESTROYED (EGG): " + eggKills;
        touchKillsText.text = "DESTROYED (TOUCH): " + touchKills;
    }

    public void SetHeroMode(bool usingMouse)
    {
        if(usingMouse) heroModeText.text = "HERO MODE: MOUSE";
        else heroModeText.text = "HERO MODE: KEYBOARD";
    }
}
