using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Manager : MonoBehaviour
{
    [SerializeField]
    GameObject UI, GameOverScreen;
    [SerializeField]
    Button yes, no;
    [SerializeField]
    Text scoreCalcText, ghostsRemaining;
    SelectionData data;
    Text scoreText, batteryText;
    public int score;
    flashlighht light;
    Slider battery;
    public bool gameOver;
    public int ghostCount;
    [SerializeField]
    public float xMax, yMax, xMin, yMin, zMax, zMin;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        batteryText = GameObject.Find("Battery Label").GetComponent<Text>();
        light = GameObject.Find("flashray").GetComponent<flashlighht>();
        battery = GameObject.Find("Battery").GetComponent<Slider>();
        gameOver = false;
        yes.onClick.AddListener(YesButton);
        no.onClick.AddListener(NoButton);
        ghostCount = GameObject.Find("Ghosts").transform.childCount;
        data = GameObject.Find("SelectionData").GetComponent<SelectionData>();

        xMax = Camera.main.transform.parent.position.x + data.sizeX / 2;
        yMax = Camera.main.transform.parent.position.y + data.sizeY / 2;
        xMin = Camera.main.transform.parent.position.x - data.sizeX / 2;
        yMin = Camera.main.transform.parent.position.y - data.sizeY / 2;
        zMax = Camera.main.transform.parent.position.z + data.sizeZ / 2;
        zMin = Camera.main.transform.parent.position.z - data.sizeZ / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (UI.active)
        {
            scoreText.text = "Score: " + score.ToString();
            batteryText.text = "Battery: " + (light.on ? "ON" : "OFF") + "\n" + light.batteryPower.ToString("F0") + "%";
            battery.value = light.batteryPower;
            ghostsRemaining.text = "Ghosts Remaining: " + ghostCount.ToString();
            if (light.batteryPower <= 0 || ghostCount == 0)
            {
                if(light.batteryPower <= 0)light.batteryPower = 0;
                gameOver = true;
                UI.SetActive(false);
                GameOverScreen.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else if (GameOverScreen.active)
        {
            scoreCalcText.text = "Score: " + score.ToString() + "\nBattery Remaining: " + light.batteryPower.ToString("F0") + "\nBonus Points: " + (light.batteryPower + light.batteryPower * 100).ToString("F0") + "\nTotal Score: " + (score + light.batteryPower + light.batteryPower * 100).ToString("F0");
        }
    }

    void YesButton()
    {
        SceneManager.LoadScene("Get Ready", LoadSceneMode.Single);
    }

    void NoButton()
    {
        #if UNITY_EDITOR
                // Application.Quit() does not work in the editor so
                // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                 Application.Quit();
        #endif
    }
}
