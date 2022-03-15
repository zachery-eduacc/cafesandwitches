using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // 1 - need bottom door
    // 2 - need top door
    // 3 - need left door
    // 4 - need right door


    private RoomTemplates templates;
    private int rand;
    private bool Spawned = false;
    private float spawntimer = 0f;

    void Start()
    {



        
            




        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        
        Invoke("Spawn", 1f);
    }


    void Spawn()
    {
        if(openingDirection == 0)
        {
            Spawned = true;
        }

        if (Spawned == false)
        {
            if (openingDirection == 1)
            {
                // Need to spawn a room with BOTTOM door
                rand = Random.Range(0, templates.bRooms.Length);
                Instantiate(templates.bRooms[rand], transform.position, templates.bRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                // Spawn top door
                rand = Random.Range(0, templates.tRooms.Length);
                Instantiate(templates.tRooms[rand], transform.position, templates.tRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                // LEFT
                rand = Random.Range(0, templates.lRooms.Length);
                Instantiate(templates.lRooms[rand], transform.position, templates.lRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                // Right
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
        
        if(other.GetComponent<RoomSpawner>().openingDirection == 1 && other.GetComponent<RoomSpawner>().Spawned == false)
        {
            if(openingDirection == 3)
            {
                Instantiate(templates.rbRoom[0], transform.position, templates.rbRoom[0].transform.rotation);
                print("Top left corner placed 72");
            }
            if (openingDirection == 4)
            {
                Instantiate(templates.lbRoom[0], transform.position, templates.lbRoom[0].transform.rotation);
                print("Top right corner placed 77");
            }
        }
        if (other.GetComponent<RoomSpawner>().openingDirection == 2 && other.GetComponent<RoomSpawner>().Spawned == false)
        {
            if (openingDirection == 3)
            {
                Instantiate(templates.rtRoom[0], transform.position, templates.rtRoom[0].transform.rotation);
                print("Bottom left corner placed 85");
            }
            if (openingDirection == 4)
            {
                Instantiate(templates.ltRoom[0], transform.position, templates.ltRoom[0].transform.rotation);
                print("Bottom right corner placed 90");
            }
        }
        if (other.GetComponent<RoomSpawner>().openingDirection == 3 && other.GetComponent<RoomSpawner>().Spawned == false)
        {
            if (openingDirection == 1)
            {
                Instantiate(templates.rtRoom[0], transform.position, templates.rtRoom[0].transform.rotation);
                print("Bottom left corner placed 98");
            }
            if (openingDirection == 2)
            {
                Instantiate(templates.rbRoom[0], transform.position, templates.rbRoom[0].transform.rotation);
                print("Top left corner placed 103");
            }
        }
        if (other.GetComponent<RoomSpawner>().openingDirection == 4 && other.GetComponent<RoomSpawner>().Spawned == false)
        {
            if (openingDirection == 1)
            {
                Instantiate(templates.ltRoom[0], transform.position, templates.ltRoom[0].transform.rotation);
                print("Bottom right corner placed 111");
            }
            if (openingDirection == 2)
            {
                Instantiate(templates.lbRoom[0], transform.position, templates.lbRoom[0].transform.rotation);
                print("Top right corner placed 116");
            }
        }
    }
}
