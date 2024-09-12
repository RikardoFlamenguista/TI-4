using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public float maxTime = 60;
    public TextMeshProUGUI timeLeftText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        maxTime -= Time.deltaTime;

        RefreshTimeLeftUI();

        CheckGameOver();
    }

    //forma temporaria para mostrar tempo restante na tela, entao fiz algo nada eficiente, mas funcional
    public void RefreshTimeLeftUI()
    {

        int timeLeft = Mathf.CeilToInt(maxTime);
        timeLeftText.text = timeLeft.ToString();
    }

    //quando o tempo acabar, game over
    private void CheckGameOver()
    {
        if (maxTime <= -1) GameController.Instance.GameOver();

    }
}
