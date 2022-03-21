using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    private bool assigned = false;
    // 1 - top spawn
    // 2 - bottom spawn
    // 3 - right spawn
    // 4 - left spawn
    int top = 1;
    int bottom = 2;
    int right = 3;
    int left = 4;

    public bool needtop;
    public bool needbottom;
    public bool needright;
    public bool needleft;
    private bool active = true;
    
    //number of this spawnpoint
    private int current;
    

    private RoomTemplates templates;
    private int rand;
    private bool Spawned = false;
    private float spawntimer = 3f;

    private GameObject CornerRoom;
    private bool needcorner = false;

    Vector3 Vup = new Vector3(0, 10, 0);
    Vector3 Vdown = new Vector3(0, -10, 0);
    Vector3 Vright = new Vector3(14 , 0, 0);
    Vector3 Vleft = new Vector3(-14 ,0,0);

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templates.spawnnum += 1;
        current = templates.spawnnum;

        print("current is " + current);

        print("spawnnum is " + templates.spawnnum);

        print("next spawn is " + templates.nextspawn);

        print("there are currently " + templates.roomnum + " rooms");

        /*while (current == templates.nextspawn && Spawned == false && active == true)
        {
            print("this is spawn point " + current + " and my spawn value is " + Spawned);
            Invoke("Spawn", 0f);
            active = false;
        }*/
    }
    void FixedUpdate()
    {
        
        if (current == templates.nextspawn && active == true && Spawned == false)
        {
            active = false;
            Invoke("Spawn",.1f);
            

        }
        else if(current == templates.nextspawn && active == true && Spawned == true)
        {
            active = false;
            templates.nextspawn += 1;
            Destroy(this.gameObject, 0f);
        }
        
    }
    
    void Spawn()
    {
        
        if (openingDirection == 0)
        {
            if (needtop == true)
            {
                //spawn up spawnpoint here

                Instantiate(templates.up, transform.position + Vup, transform.rotation);


            }
            if (needbottom == true)
            {
                //spawn bottom spawnpoint here

                Instantiate(templates.down, transform.position + Vdown, transform.rotation);

            }
            if (needleft == true)
            {
                //spawn left spawnpoint here

                Instantiate(templates.left, transform.position + Vleft, transform.rotation);

            }
            if (needright == true)
            {
                //Spawn right spawnpoint here

                Instantiate(templates.right, transform.position + Vright, transform.rotation);

            }

            Spawned = true;
            templates.roomnum += 1;
        }

        if (Spawned == false && needcorner == true)
        {
            Instantiate(CornerRoom, transform.position, CornerRoom.transform.rotation);
            Destroy(this.gameObject, 0f);
            
        }
        



        if (Spawned == false && needcorner == false)
        {
            if (openingDirection == top)
            {
                // Needs Down
                if (current < templates.roommax * 4)
                {
                    rand = Random.Range(0, templates.bRooms.Length);
                    Instantiate(templates.bRooms[rand], transform.position, templates.bRooms[rand].transform.rotation);
                    Destroy(this.gameObject, 0f);
                }
                else
                {
                    Instantiate(templates.topend, transform.position, templates.topend.transform.rotation);
                    Destroy(this.gameObject, 0f);
                }
            }
            else if (openingDirection == bottom)
            {
                // Needs Top
                if (current < templates.roommax * 4)
                {
                    rand = Random.Range(0, templates.tRooms.Length);
                    Instantiate(templates.tRooms[rand], transform.position, templates.tRooms[rand].transform.rotation);
                    Destroy(this.gameObject, 0f);
                }
                else
                {
                    Instantiate(templates.bottomend, transform.position, templates.bottomend.transform.rotation);
                    Destroy(this.gameObject, 0f);
                }
            }
            else if (openingDirection == right)
            {
                // Needs LEFT
                if (current < templates.roommax * 4)
                {
                    rand = Random.Range(0, templates.lRooms.Length);
                    Instantiate(templates.lRooms[rand], transform.position, templates.lRooms[rand].transform.rotation);
                    Destroy(this.gameObject, 0f);
                }
                else
                {
                    Instantiate(templates.rightend, transform.position, templates.rightend.transform.rotation);
                    Destroy(this.gameObject, 0f);
                }
            }
            else if (openingDirection == left)
            {
                // needs Right
                if (current < templates.roommax * 4)
                {
                    rand = Random.Range(0, templates.rRooms.Length);
                    Instantiate(templates.rRooms[rand], transform.position, templates.rRooms[rand].transform.rotation);
                    Destroy(this.gameObject, 0f);
                }
                else
                {
                    Instantiate(templates.leftend, transform.position, templates.leftend.transform.rotation);
                    Destroy(this.gameObject, 0f);
                }

            }
            
            
        }

        templates.nextspawn += 1;



    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (Spawned == false)
        {
            if (other.CompareTag("centerspawn"))
            {
                Spawned = true;
            }
            /*other.CompareTag("SpawnPoint") ||*/

        }

        if (other.GetComponent<RoomSpawner>().openingDirection == top/* && other.GetComponent<RoomSpawner>().Spawned == false*/)
        {
            if (openingDirection == right)
            {
                //Instantiate(templates.rbRoom[0], transform.position, templates.rbRoom[0].transform.rotation);
                //print("Top left corner placed 72");


                CornerRoom = templates.rbRoom[0];



            }
            if (openingDirection == left)
            {
                //Instantiate(templates.lbRoom[0], transform.position, templates.lbRoom[0].transform.rotation);
                //print("Top right corner placed 77");

                CornerRoom = templates.lbRoom[0];
            }

            needcorner = true;
        }
        if (other.GetComponent<RoomSpawner>().openingDirection == bottom/* && other.GetComponent<RoomSpawner>().Spawned == false*/)
        {
            if (openingDirection == right)
            {
                //Instantiate(templates.rtRoom[0], transform.position, templates.rtRoom[0].transform.rotation);
                //print("Bottom left corner placed 85");

                CornerRoom = templates.ltRoom[0];
            }
            if (openingDirection == left)
            {
                //Instantiate(templates.ltRoom[0], transform.position, templates.ltRoom[0].transform.rotation);
                //print("Bottom right corner placed 90");

                CornerRoom = templates.rtRoom[0];
            }

            needcorner = true;
        }
        if (other.GetComponent<RoomSpawner>().openingDirection == right/* && other.GetComponent<RoomSpawner>().Spawned == false*/)
        {
            if (openingDirection == top)
            {
                //Instantiate(templates.rbRoom[0], transform.position, templates.rbRoom[0].transform.rotation);
                //print("Top right corner placed 98");

                CornerRoom = templates.rbRoom[0];
            }
            if (openingDirection == bottom)
            {
                //Instantiate(templates.ltRoom[0], transform.position, templates.ltRoom[0].transform.rotation);
                //print("Bottom right corner placed 103");

                CornerRoom = templates.ltRoom[0];
            }

            needcorner = true;
        }
        if (other.GetComponent<RoomSpawner>().openingDirection == left/* && other.GetComponent<RoomSpawner>().Spawned == false*/)
        {
            if (openingDirection == top)
            {
                //Instantiate(templates.rbRoom[0], transform.position, templates.rbRoom[0].transform.rotation);
                //print("Top left corner placed 111");

                CornerRoom = templates.rbRoom[0];
            }
            if (openingDirection == bottom)
            {
                //Instantiate(templates.rtRoom[0], transform.position, templates.rtRoom[0].transform.rotation);
                //print("Bottom left corner placed 116");

                CornerRoom = templates.rtRoom[0];
            }

            needcorner = true;
        }




    }
}
