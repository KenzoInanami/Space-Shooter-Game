using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    public GameObject player;
    private Transform player_transform;
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start(){
        rb = this.GetComponent<Rigidbody2D>();
        player_transform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update(){
        Vector3 direction = player_transform.position - transform.position;
        direction.Normalize();
        movement = direction;

        StartCoroutine( Rotate() );
    }

    private void FixedUpdate() {
        Move(movement);
    }

    void Move(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    

    private IEnumerator Rotate(){
        transform.Rotate(0,0,0.1f);
        yield return null;
    }
}
