#define DEBUG_KEY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    TextMeshProUGUI scoreText = default;

    static int ScoreMax => 99999;

    static int score;
    static float time;
    static float StartTime => 10;
    static bool clear;
    static bool gameover;

    private void Awake()
    {
        Instance = this;
        ClearScore();
        time=StartTime;
        clear = false;
        gameover = false;
    }


    void Start()
    {
        TinyAudio.PlaySE(TinyAudio.SE.Start);
    }

    void Update()
    {
#if DEBUG_KEY
        if (Input.GetKeyDown(KeyCode.O))
        {
            ToGameover();
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            ToClear();
        }
        else if(Input.GetKeyDown(KeyCode.P))
        {
            AddPoint(12345);
           
        }
#endif
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $"{score:00000}";
        }
    }

    public static void AddPoint(int add)
    {
        //score += add;
        //����`�F�b�N����1 �葱���^�̓T�^
        //if (score > ScoreMax)
        //{
        //   score = ScoreMax;
        //}

        //����`�F�b�N����2�@�葱���^�̏ȗ��`
        //score = score > ScoreMax ? ScoreMax : score;

        //����`�F�b�N����3�@�֐��^�ŋߑ�I
        score = Mathf.Min(score+add, ScoreMax);


        if (Instance!=null)
        {
            Instance.UpdateScoreText();
        }
            
    }

    public static void ClearScore()
    {
        score = 0;
        if(Instance!=null)
        {
            Instance.UpdateScoreText();
        }
    }

    public static void ToClear()
    {
        if (clear || gameover) return;

        clear = true;
        SceneManager.LoadScene("Clear", LoadSceneMode.Additive);
        Time.timeScale = 0;
    }

    public static void ToGameover()
    {
        if (clear || gameover) return;

        gameover = true;
        SceneManager.LoadScene("Gameover", LoadSceneMode.Additive);
        Time.timeScale = 0f;


    }
}
