using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform  RespawnPoint; 
    public Transform  Player;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision){
        Player.position = RespawnPoint.position;
    }
}
