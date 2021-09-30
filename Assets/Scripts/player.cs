using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    /* variáveis */
    public GameObject shot; // prefab do tiro do jogador
    private float vel_shot = 6; // velocidade do tiro
    public Transform shotPoint; // posição de onde o tiro sai
    private float shootCooldown; // contador do atraso do tiro
    public float timeCooldown; // valor do tempo de atraso do tiro

    private Vector2 playerPosition; // posição do jogador
    public static bool playing; // true = jogo em andamento || false = jogo pausado/fim de jogo

    public UI UI; // objeto da classe UI (do script UI.cs)

    void Start(){
        playing = true; // o jogo começa assim que a cena carrega
    }

    void Update()
    {
        /* playing = true -> jogador pode mover a nave e atirar
           playing = true -> jogador não pode mover a nave nem atirar */
        if(playing){
            Move();
            Shoot();
        }
    }

    void Shoot()
    {
        /* Quando o shootCooldown é menor ou igual a 0, caso o jogardor clique com o botão
           esquerdor do mouse um GameObject do prefab shot é criado na posição em que
           se encontra o jogador. Caso shootCooldown for maior que 0, o atraso será decrescido
           ao longo do tempo. */
        if(shootCooldown <= 0)
        {
            if(Input.GetMouseButtonDown(0))
            {
                GameObject newshot = Instantiate(shot, playerPosition, Quaternion.identity);
                newshot.GetComponent<Rigidbody2D>().velocity = transform.right * vel_shot;
                shootCooldown = timeCooldown;
            }
        }
        else
        {
            shootCooldown -= Time.deltaTime; 
        }
    }

    void Move(){
        /* Captura a posição do atual do jogador e a posição da seta do mouse 
           para calcular o vetor direção que aponta para onde a nave precisa 
           estar virada. */
        playerPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - playerPosition;
        transform.right = direction; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        /* Quando o jogador colidir com algum asteroide, ele perderá vida e
           destruirá o asteroide que colidiu nele. Caso a variável vida, contida
           no script UI.cs for igual a 0, ativará a tela de Game Over.  */
        if( other.gameObject.tag == "asteroid" ){
            UI.LoseLife();
            Destroy(other.gameObject);
            if( UI.Life == 0) UI.GameOver();
        }
    }

}
