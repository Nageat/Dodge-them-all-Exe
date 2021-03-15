using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHaut : MonoBehaviour
{
    public Transform Triangle_Spawn;
    public Transform Coeur_Spawn;
    public int randomMax=10;//Nombre Max
    public int randomMin=0;//Nombre min
    public int randomRange=5;//Nombre a sortir
    public int randomRangeCoeur=6;
    public float TimebetweenSpawn=1;//Temps entre chaque tirage 

    private int random;//Nombre random
    private bool isCanSpawn = true;

    void Update()
    {
        random = Random.Range(randomMax, randomMin);
        if (random == randomRange && isCanSpawn){
            //Debug.Log(random);
            Transform clone;
            clone = Instantiate(Triangle_Spawn, transform.position, transform.rotation);
            StartCoroutine(WaitForSpawn());
            isCanSpawn = false;
        }
        if (random == randomRangeCoeur && isCanSpawn){
            //Debug.Log(random);
            Transform clone;
            clone = Instantiate(Coeur_Spawn, transform.position, transform.rotation);
            StartCoroutine(WaitForSpawn());
            isCanSpawn = false;
        }
    }
    IEnumerator WaitForSpawn()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(TimebetweenSpawn);
        isCanSpawn = true;
    }


}
