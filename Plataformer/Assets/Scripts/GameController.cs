using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


//classe estatica, game controller assuntos gerais, pause, game over, tempo restante, contagem de pontos, etc
public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    //variaveis para controle de pontos restantes
    public GameObject points;
    public TextMeshProUGUI pointsText;
    private int pointsLeft;
    private int totalPoints;
    private int collectedPoints = 0;
    public int CollectedPoints { get { return collectedPoints; } set { collectedPoints = value; } }



    //variaveis de menus
    public GameObject pauseMenu;
    private bool isPaused = false;

    public GameObject victoryMenu;
    public GameObject gameOverMenu;




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

        //no comeco do jogo ajusta a UI de pontos
        SetStartPoints();
    

    }

    // Update is called once per frame
    void Update()
    {
        PauseGameHotkey();

    }

    //atualiza a UI de pontos restantes
    public void RefreshCollectedPointsUI()
    {

        pointsText.text = collectedPoints.ToString() + "/" + totalPoints.ToString();
    }

    //metodo chamado apenas no awake para ajustar a UI de pontos
    private void SetStartPoints()
    {
        pointsLeft = points.transform.childCount;
        totalPoints = pointsLeft + 1;
        RefreshCollectedPointsUI();
    }

    //chamado por PlayerCollectPoints sempre que o jogador coleta um ponto, ajusta a variavel de pontos restantes e atualiza o texto
    public void CollectPoint()
    {
        pointsLeft = pointsLeft - 1;

        collectedPoints = collectedPoints + 1;
        RefreshCollectedPointsUI();

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

    //sai do jogo
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

    //reinicia o jogo (atualmente nao tem checkpoint, entao reinicia desde o inicio)
    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    //ativa o menu de vitoria
    public void Victory()
    {
        victoryMenu.SetActive(true);
        Time.timeScale = 0.0f;

    }

    //ativa o menu de game over
    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0.0f;

    }





}
