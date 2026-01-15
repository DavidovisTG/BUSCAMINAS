using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject endMenu;
    [SerializeField] GameObject inputErrorScreen;
    [SerializeField] GameObject winMenu;

    public static GameManager instance;

    public bool gameOver;

    private void Awake()
    {
        if (instance == null) { 
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad (gameObject);
        mainMenu.SetActive(true);
        endMenu.SetActive(false);
        inputErrorScreen.SetActive(false);
        winMenu.SetActive(false);
    }

    public void GameStart()
    {
        Generator.instance.setWidth(int.Parse(MainMenu.instance.width_Input.GetComponentInChildren<TMP_InputField>().text.ToString()));
        Generator.instance.setHeight(int.Parse(MainMenu.instance.height_Input.GetComponentInChildren<TMP_InputField>().text.ToString()));
        Generator.instance.setBombsCount(int.Parse(MainMenu.instance.bombsCount_Input.GetComponentInChildren<TMP_InputField>().text.ToString()));

        if (Generator.instance.Validate() == 0)
            Generator.instance.Generate();
        else inputErrorScreen.SetActive(true);

        mainMenu.SetActive(false);
    }

    public void GameOverWin()
    {
        Generator.instance.DestroyCellMatrix();
        winMenu.SetActive(true);
    }

    public void GameOverLose()
    {
        Generator.instance.DestroyCellMatrix();
        endMenu.SetActive(true);
    }

    public void Restart()
    {
        Start();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
