using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    /* variaveis */
    private Rigidbody2D rb; // componente rigidbody do tiro
    private bool hasHit; // true -> atingiu alguma coisa || false -> ainda não atingiu nada

    public GameObject player; // game object do prefab do jogador
    private Vector3 playerPosition; // posição do jogador


    void Start()
    {
        /* Assim que iniciar, captura a posição do jogador e o componente
           rigid body 2D do tiro */
        playerPosition = player.transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /* Enquanto o tiro estiver em campo ele se movimenta e é destruído
           quando se afasta demais do jogador  */
        Move();
        DestroyShot();
    }

    void Move(){
        /* Se move enquanto não atingir alguma coisa */
        if(hasHit == false)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void DestroyShot(){
        /* Caso se afaste demais do jogador o tiro é destruido */
        if((this.transform.position - playerPosition).magnitude > 6.0f) Destroy(this.gameObject);   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        /* Caso tenha acertado um asteroide, adiciona um ponto, destrói o tiro e o asteróide */
        hasHit = true;
        if( other.gameObject.tag == "asteroid" ){
            UI.AddScore();
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
    

}
