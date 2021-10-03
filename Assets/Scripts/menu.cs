using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    /* Script do botão do menu principal, quando o botão é clicado
       troca para a cena InGame onde o jogo acontece */
    public void StartGameButton(){
        SceneManager.LoadScene("InGame");
    }

    public void QuitGameButton(){
        Application.Quit();
    }
}
