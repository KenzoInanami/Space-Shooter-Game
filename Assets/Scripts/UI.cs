using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    /* variaveis */
    public static int Score = 0; // valor da pontuação
    public static int Life = 3; // quantidade de vida do jogador
    static Text scoreText; // o texto na tela da pontuação
    static Text lifeText; // o texto na tela da quantidade de vida do jogador

    public Image rightPanel; // o painel direito da tela
    public GameObject gameOverPanel; // tela de game over

    // Start is called before the first frame update
    void Start()
    {   
        /* Quando iniciar, escreve o texto padrão no painel direito:
           "Score: 0
           : 3" (vida do jogador)  */
        WriteInitialTextUI();
    }

    void WriteInitialTextUI(){
        /*Pega o componente texto contindo nas crianças do painel direito, então
          coloca o texto padrão. */
        scoreText = rightPanel.transform.GetChild(0).GetComponent<Text>();
        lifeText = rightPanel.transform.GetChild(1).GetComponent<Text>();

        scoreText.text = "Score: 0";
        lifeText.text = ": 3";
    }

    public static void AddScore(){
        /* Soma um ponto na tela */
        Score++;
        scoreText.text = "Score: " + Score;
    }

    public static void LoseLife(){
        /* Diminui a vida na tela */
        Life--;
        lifeText.text = ": " + Life;
    }

    public void GameOver(){
        /* Tela de game over, desabilita o controle do jogador e a geração de asteróides,
           então ativa a o texto "GAME OVER" e o botão de recomeçar. Também destrói todos
           os asteróides contidos na cena */
        spawner.spawnOn = false;
        player.playing = false;
        gameOverPanel.SetActive(true);

        var asteroids = GameObject.FindGameObjectsWithTag("asteroid");
        foreach (var asteroid in asteroids)
        {
            Destroy(asteroid);
        }
    }

    public void RestartButton(){
        /* Função do botão de restart, reseta o contador de pontos e de vida, atualiza os textos,
           desabilita a tela de game over e liga novamente o controle do jogador e a geração de asteróides*/
        Score = 0;
        Life = 3;
        scoreText.text = "Score: 0";
        lifeText.text = ": 3";
        
        spawner.spawnOn = true;
        player.playing = true;
        gameOverPanel.SetActive(false);
    }
}
