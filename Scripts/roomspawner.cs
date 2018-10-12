using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class roomspawner : MonoBehaviour
{
    [SerializeField] private GameObject room;
    [SerializeField] private int AmoutOfRooms;
    [SerializeField] private int mapsize;    
    [SerializeField] private int roomsize;
    private GameObject[,] rooms;
    private Vector2 SpawnPosition = new Vector2(0, 0);
    public Action check;
    private int random;

    public int Mapsize()
    {
       return mapsize;
    }
    public int Roomsize()
    {
       return roomsize;
    }
    public GameObject Rooms(int x ,int y)
    {
        return rooms[x,y];
    }
    void Start ()
    {
        mapsize += 1;
        rooms = new GameObject[mapsize + mapsize + 1, mapsize + mapsize + 1];
        rooms[((int)SpawnPosition.x / roomsize) + mapsize, ((int)SpawnPosition.y / roomsize) + mapsize] = Instantiate(room, SpawnPosition, Quaternion.identity);

        for (int i = 0; i < AmoutOfRooms; i++)
        {
            random = UnityEngine.Random.Range(0, 4);
            if (random == 0)//right
            {
                SpawnPosition.x += roomsize;
            }
            else if (random == 1)//left
            {
                SpawnPosition.x -= roomsize;
            }
            else if (random == 2)//up
            {
                SpawnPosition.y += roomsize;
            }
            else if (random == 3)//down
            {
                SpawnPosition.y -= roomsize;
            }
            if (SpawnPosition.x / roomsize <= mapsize -1 && SpawnPosition.x / roomsize >= -mapsize +1 && SpawnPosition.y / roomsize <= mapsize -1 && SpawnPosition.y / roomsize >= -mapsize +1)
            {//spawn
                if (rooms[((int)SpawnPosition.x / roomsize) + mapsize, ((int)SpawnPosition.y / roomsize) + mapsize] == null)
                {//check for if thers already a room
                    rooms[((int)SpawnPosition.x / roomsize) + mapsize, ((int)SpawnPosition.y / roomsize) + mapsize] = Instantiate(room, SpawnPosition, Quaternion.identity); 
                }
                else
                {
                    AmoutOfRooms++;
                }
            }
            else
            {
                AmoutOfRooms++;
                SpawnPosition = new Vector2(0,0);
            }
        }
        if (check == null)
        {
            print("nul");
        }
        check();
    }
}
