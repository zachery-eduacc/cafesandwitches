using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // 1 - top spawn
    // 2 - bottom spawn
    // 3 - right spawn
    // 4 - left spawn
    int top = 1;
    int bottom = 2;
    int right = 3;
    int left = 4;

    //number of spawnpoints spawned
    public int spawnnum;
    //number of this spawnpoint
    private int current;
    //current active spawnpoint
    public int nextspawn = 1;

    private RoomTemplates templates;
    private int rand;
    private bool Spawned = false;
    private float spawntimer = 2f;
    

    void Start()
    {
        if(spawnnum <= 4)
        {
            if(openingDirection)
        }


        
            




        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        
        Invoke("Spawn", spawntimer);
    }


    void Spawn()
    {
        if(openingDirection == 0)
        {
            Spawned = true;
        }

        if (Spawned == false)
        {
            if (openingDirection == top)
            {
                // Needs Down
                rand = Random.Range(0, templates.bRooms.Length);
                Instantiate(templates.bRooms[rand], transform.position, templates.bRooms[rand].transform.rotation);
            }
            else if (openingDirection == bottom)
            {
                // Needs Top
                rand = Random.Range(0, templates.tRooms.Length);
                Instantiate(templates.tRooms[rand], transform.position, templates.tRooms[rand].transform.rotation);
            }
            else if (openingDirection == right)
            {
                // Needs LEFT
                rand = Random.Range(0, templates.lRooms.Length);
                Instantiate(templates.lRooms[rand], transform.position, templates.lRooms[rand].transform.rotation);
            }
            else if (openingDirection == left)
            {
                // needs Right
                rand = Random.Range(0, templates.rRooms.Length);
                Instantiate(templates.rRooms[rand], transform.position, templates.rRooms[rand].transform.rotation);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SpawnPoint") || other.CompareTag("centerspawn")) {
            Spawned = true;
        }
        
        if(other.GetComponent<RoomSpawner>().openingDirection == top && other.GetComponent<RoomSpawner>().Spawned == false)
        {
            if(openingDirection == right)
            {
                Instantiate(templates.rbRoom[0], transform.position, templates.rbRoom[0].transform.rotation);
                print("Top left corner placed 72");
                
            }
            if (openingDirection == left)
            {
                Instantiate(templates.lbRoom[0], transform.position, templates.lbRoom[0].transform.rotation);
                print("Top right corner placed 77");
            }
            

        }
        if (other.GetComponent<RoomSpawner>().openingDirection == bottom && other.GetComponent<RoomSpawner>().Spawned == false)
        {
            if (openingDirection == right)
            {
                Instantiate(templates.rtRoom[0], transform.position, templates.rtRoom[0].transform.rotation);
                print("Bottom left corner placed 85");
            }
            if (openingDirection == left)
            {
                Instantiate(templates.ltRoom[0], transform.position, templates.ltRoom[0].transform.rotation);
                print("Bottom right corner placed 90");
            }
            

        }
        if (other.GetComponent<RoomSpawner>().openingDirection == right && other.GetComponent<RoomSpawner>().Spawned == false)
        {
            if (openingDirection == top)
            {
                Instantiate(templates.rbRoom[0], transform.position, templates.rbRoom[0].transform.rotation);
                print("Top right corner placed 98");
            }
            if (openingDirection == bottom)
            {
                Instantiate(templates.ltRoom[0], transform.position, templates.ltRoom[0].transform.rotation);
                print("Bottom right corner placed 103");
            }
            

        }
        if (other.GetComponent<RoomSpawner>().openingDirection == left && other.GetComponent<RoomSpawner>().Spawned == false)
        {
            if (openingDirection == top)
            {
                Instantiate(templates.rbRoom[0], transform.position, templates.rbRoom[0].transform.rotation);
                print("Top left corner placed 111");
            }
            if (openingDirection == bottom)
            {
                Instantiate(templates.rtRoom[0], transform.position, templates.rtRoom[0].transform.rotation);
                print("Bottom left corner placed 116");
            }
            

        }
        
        

    }
}
