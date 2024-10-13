using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    //vari�veis para controle de pontos restantes
    public GameObject points;
    public TextMeshProUGUI pointsText;
    private int pointsLeft;
    private int totalPoints;
    private int collectedPoints = 0;
    public int CollectedPoints { get { return collectedPoints; } set { collectedPoints = value; } }

    //vari�veis de menus
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
            DontDestroyOnLoad(gameObject); // Mant�m o GameController entre cenas
        }
        else
        {
            Destroy(gameObject); // Destr�i o gameObject se uma inst�ncia j� existir
            Debug.Log("Inst�ncia j� existe, deletando a nova");
            return; // Evita que o c�digo abaixo seja executado na inst�ncia que ser� destru�da
        }

        // O menu de pause deve estar desativado no in�cio do jogo
        pauseMenu.SetActive(false);

        // No come�o do jogo ajusta a UI de pontos
        SetStartPoints();
    }

    // Update is called once per frame
    void Update()
    {
        PauseGameHotkey();
    }

    // Atualiza a UI de pontos restantes
    public void RefreshCollectedPointsUI()
    {
        pointsText.text = collectedPoints.ToString() + "/" + totalPoints.ToString();
    }

    // M�todo chamado apenas no awake para ajustar a UI de pontos
    private void SetStartPoints()
    {
        pointsLeft = points.transform.childCount;
        totalPoints = pointsLeft;
        RefreshCollectedPointsUI();
    }

    // Chamado por PlayerCollectPoints sempre que o jogador coleta um ponto, ajusta a vari�vel de pontos restantes e atualiza o texto
    public void CollectPoint()
    {
        pointsLeft = pointsLeft - 1;
        collectedPoints = collectedPoints + 1;
        RefreshCollectedPointsUI();
    }

    // Controla o jogo pausado e despausado usando tecla de atalho do teclado
    private void PauseGameHotkey()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    // Pausa o jogo
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0.0f;
    }

    // Despausa o jogo
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1.0f;
    }

    // Sai do jogo
    public void QuitGame()
    {
        Time.timeScale = 1.0f;
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // Reinicia o jogo (atualmente n�o tem checkpoint, ent�o reinicia desde o in�cio)
    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Ativa o menu de vit�ria
    public void Victory()
    {
        victoryMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }

    // Ativa o menu de game over
    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
