using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    //variaveis para controle de pontos restantes
    public GameObject points;
    public TextMeshProUGUI pointsText;
    private int pointsLeft;
    private int collectedPoints = 0;

    public GameObject pauseMenu;
    private bool isPaused = false;

    public GameObject victoryMenu;
    private int totalPoints;



    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            //eh pra destruir instance ou gameobject aqui? Nao lembro, conferir depois//
            Destroy(Instance);
            Debug.Log("Instancia ja existe, deletando");
        }
       

        //o menu de pause deve estar desativado no inicio do jogo
        pauseMenu.SetActive(false);

        SetStartPoints();
    

    }

    // Update is called once per frame
    void Update()
    {
        PauseGameHotkey();

    }

    //metodo chamado apenas no awake para ajustar a UI de pontos
    private void SetStartPoints()
    {
        pointsLeft = points.transform.childCount;
        totalPoints = pointsLeft;
        pointsText.text = collectedPoints.ToString() + "/" + totalPoints.ToString();
    }

    //chamado por PlayerCollectPoints sempre que o jogador coleta um ponto, ajusta a variavel de pontos restantes e atualiza o texto
    public void CollectPoint()
    {
        pointsLeft = pointsLeft - 1;

        collectedPoints = collectedPoints + 1;
        pointsText.text = collectedPoints.ToString() + "/" + totalPoints.ToString();



        //por enquanto essa variavel nao vai fazer nada, so vai ser util quando a mecanica de gastar pontos for implementada
    }

    //controla jogo pausado e despausado usando tecla de atalho do teclado
    private void PauseGameHotkey()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //pausa o jogo
            if (!isPaused)
            {
                PauseGame();

            }

            //despausa o jogo
            else if (isPaused)
            {
                ResumeGame();

            }

        }

    }

        //pausa o jogo
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0.0f;

    }

    //despausa o jogo
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1.0f;

    }

    public void QuitGame()
    {
        Time.timeScale = 1.0f;

        //encerra o jogo no editor ou na build, dependendo de onde esta sendo rodado
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }

    public void Victory()
    {
        victoryMenu.SetActive(true);
        Time.timeScale = 0.0f;

    }





}
