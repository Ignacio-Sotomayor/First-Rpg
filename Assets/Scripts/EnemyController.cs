using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyControler : MonoBehaviour
{

    public float EnemySpeed = 5;
    public float RotationSpeed = 10f;
    public float MinDist;
    public float MaxDist;

    private Transform enemy;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").transform;
    }


    void Update()
    {
        var distancia = Vector3.Distance(enemy.position, player.position);

        Debug.DrawLine(player.transform.position, transform.position, Color.green, Time.deltaTime, false);
        if (distancia >= MinDist && distancia <= MaxDist)
        {
            var targetPos = new Vector3(player.position.x, this.transform.position.y, player.position.z);
            transform.LookAt(targetPos);
            transform.Translate(Vector3.forward * EnemySpeed * Time.deltaTime);
            Debug.DrawLine(player.transform.position, transform.position, Color.red, Time.deltaTime, false);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Debug.Log("Game Over");
        }
    }
}
