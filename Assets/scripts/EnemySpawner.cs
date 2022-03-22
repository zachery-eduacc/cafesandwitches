using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemySpawner : MonoBehaviour
{
    private EnemyTemplates enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("esps").GetComponent<EnemyTemplates>();
        Instantiate(enemy.basicmac, transform.position, enemy.basicmac.transform.rotation);
    }

    // Update is called once per frame
    void Spawn()
    {
        
    }
}
