using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    /* variáveis */
    public GameObject asteroid; // prefab do asteródide
    public GameObject player; // prefab do jogador

    private float spawnCooldown; // atraso do instanciamento de um asteróide
    public float timeCooldown; // tempo do atraso do instanciamento de um asteróide

    private Vector3 playerPosition; // posição do jogador
    private Vector3 spawnPosition; // posição em que o asteróide será instanciado

    public static bool spawnOn; // true -> gera asteróides com o passar do tempo | false -> deixa de gerar

    private bool positionOk; // true -> posição que o asteróide será gerado não é muito perto do jogador | false -> caso seja perto do jogador

    void Start(){
        /* Pega a posição do jogador e começa a gerar asteróides. */
        playerPosition = player.transform.position;
        spawnOn = true;
    }
    
    void Update()
    {
        /* Enquanto puder, gerará asteróides.*/
        if(spawnOn) Spawn();
    }

    void Spawn(){
        /* Enquanto não achar uma posição adequada (não muito perto do jogador), continuará
           a gerar uma nova posição. Quando achar, gera um asteróide caso um asteróide não 
           tiver sido gerado em um espaço muito curto de tempo. */
        while( !positionOk ){
            spawnPosition = new Vector3(Random.Range(-22,-2),Random.Range(-10,10),0);
            if((spawnPosition - playerPosition).magnitude > 5.0f) positionOk = true;
        }

        if(spawnCooldown <= 0)
        {
            Instantiate(asteroid, spawnPosition, Quaternion.identity);
            positionOk = false;
            spawnCooldown = timeCooldown;
        }
        else
        {
            spawnCooldown -= Time.deltaTime; 
        }
    }
}
