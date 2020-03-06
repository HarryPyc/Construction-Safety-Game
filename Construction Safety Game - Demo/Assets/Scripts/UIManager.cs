using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Button BtnTutorial;
    //public Button BtnTool;
    public Button BtnSelectLevel;
    public Button BtnExitGame;

    public GameObject ScrollView;
    public GameObject LevelsView;
    public GameObject ItemList;
    public GameObject Introduction;

    public GameObject Hint1;
    public GameObject Hint2;
    public GameObject Hint3;

    public GameObject YouWin;
    public GameObject GameOver;

    public GameObject Player;

    private AudioSource[] m_AudioSource;

    private float gameOverCountDown;
    private float youWinCountDown;

    
    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = gameObject.GetComponents<AudioSource>();

        gameOverCountDown = -1.0f;
        youWinCountDown = -1.0f;

        if(ConfigurationUtils.ShowTutorial == 1)
        {
            Introduction.SetActive(true);
        }
        else
        {
            Introduction.SetActive(false);
        }

        //BtnTool.onClick.AddListener(delegate () {
        //    ShowUI(ItemList);
        //});
        BtnTutorial.onClick.AddListener(delegate ()
        {
            ShowUI(ScrollView);
        });
        BtnSelectLevel.onClick.AddListener(delegate ()
        {
            ShowUI(LevelsView);
            //ShowUI(BtnTool.gameObject);
            ItemList.SetActive(false);
        });

        BtnExitGame.onClick.AddListener(delegate ()
        {
            Application.Quit();
        });
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<PlayerController>().isFalling)
        {
            Player.GetComponent<PlayerController>().isFalling = false;
            gameOverCountDown = Time.time;
        }

        if (Player.GetComponent<PlayerController>().isWinning)
        {
            Player.GetComponent<PlayerController>().isWinning = false;
            youWinCountDown = Time.time;
        }

        if (gameOverCountDown >= 0)
        {
            if(Time.time - gameOverCountDown > 4)
            {
                gameOverCountDown = -1.0f;
                ShowGameOver();
            }
        }

        if (youWinCountDown >= 0)
        {
            if (Time.time - youWinCountDown > 1)
            {
                youWinCountDown = -1.0f;
                m_AudioSource[0].Play();
                ShowYouWin();
            }
        }

    }

    public void ShowUI(GameObject UI)
    {
        UI.SetActive(!UI.activeSelf);
    }

    public void ShowGameOver()
    {
        ShowUI(GameOver);
    }

    public void ShowYouWin()
    {
        ShowUI(YouWin);
    }

    public void ShowHint(int h)
    {

        if(h == 1)
        {
            Hint1.SetActive(true);
            Hint2.SetActive(false);
            Hint3.SetActive(false);
        }

        else if (h == 2)
        {
            Hint1.SetActive(false);
            Hint2.SetActive(true);
            Hint3.SetActive(false);
        }

        else if (h == 3)
        {
            Hint1.SetActive(false);
            Hint2.SetActive(false);
            Hint3.SetActive(true);
        }
    }
}
