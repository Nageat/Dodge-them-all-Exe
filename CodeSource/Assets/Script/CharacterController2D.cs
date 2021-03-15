using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class CharacterController2D : MonoBehaviour
{
    public string Nextlevel;
    public float speed = 20f;
    public int life = 3;
    public int TimebetweenHit=1;
    public int Score=0;
    public int ScoreGoal =500;
    public Text PlayerLife;
    public Text PlayerScore;

	public bool toucheLeSol = false;
    public bool IsCanHit = true;
    void Update () {
        Vector3 pos = transform.position;

		if(Input.GetButtonDown ("Jump") && toucheLeSol)
		   	{
				PlayerJump();
		   	}
        if (Input.GetKey ("d")) {
            pos.x += speed * Time.deltaTime;
            PlayerRight();
        }
        if (Input.GetKey ("q")) {
            pos.x -= speed * Time.deltaTime;
        } 
        transform.position = pos;
        PlayerLife.text = "Vie : " + life;

        if(Score == ScoreGoal){
            SceneManager.LoadScene(Nextlevel, LoadSceneMode.Single);
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        toucheLeSol = true;

        if (col.gameObject.tag == "Ennemis" && IsCanHit){
            life -= 1;
            IsCanHit = false;
            StartCoroutine(WaitForSpawn());
            GetComponent <SpriteRenderer> ().color += new Color (0, 0, 0, 255);
            if (life == 0)
            {
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);

            }
        }
        else if (col.gameObject.tag == "Coeur"){
            life += 1;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        Score++;
        PlayerScore.text = "Score : " + Score;
    }

    public void PlayerJump(){
	    if(toucheLeSol)
		    {
            GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, 1100));
            toucheLeSol = false;
            }
    }
    
    public void PlayerRight(){
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
    }

    IEnumerator WaitForSpawn()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(TimebetweenHit);
        IsCanHit = true;
    }
}
