using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hextilemapgenerator3d : MonoBehaviour
{
    

    private GameObject hexTileprefab;

    static int mapwidth = 25;
    static int mapheight = 12;

    private float tilezoffset = 1.73f; //need to get right value
    private float tilexoffset = 1f;
    private float tileyoffset = 0.2f;

    // Start is called before the first frame update
    void Start()
    {

    }


    //creates base of the map
    private void createHextilemap()
    {
        for (int x = 0; x <= mapwidth; x++)
        {
            for (int z = 0; z <= mapheight; z++)
            {

                createtile(x, 0, z);

            }
        }
    }


    private void settileinfo(GameObject GO, int x, int z)
    {
        //GO.transform.parent = transform;
        //GO.name = x.ToString() + ", " + z.ToString();
    }

    //makes small hills
    private void flat()
    {
        int howmeny = 5; //% chance to spawn ?/100

        for (int x = 0; x <= mapwidth; x++)
        {
            for (int z = 0; z <= mapheight; z++)
            {
                if (Random.Range(0,100)<howmeny)
                {

                    createtile(x,1,z);
                }
            }
        }
    }

    //makes custom size hills (perfect hexagons)
    //perhaps add more uneque shapes in the future
    private void ahill(int size, int width, int startx, int startz)
    {

        
        for (int i = 1; i <= size; i++)
        {
            bool pom = false;
            Debug.Log(i);
            int r = width + size-i;
            int no = 0;
            int mo = r;


            for (int x = r * (-1); x <= r; x++)
            {

                    no = Mathf.Abs(x) / 2;

                   // Debug.Log("---------vrstica------------");
                for (int z = r*(-1); z <= r - mo; z++)
                {
                    
                    createtile(startx + x, i, startz + z+no);
                    //Debug.Log("here: x=" + x + "z=" + z);

                    //Debug.Log("stevec: "+z);

                }

                if (mo > 0 && pom == false)
                {
                    mo--;
                }
                else
                {
                    mo++;
                    pom = true;
                }
            }
            
        }
    }

    private void createtile(int x, int y, int z)
    {
        GameObject tempgo = Instantiate(hexTileprefab);
        if (x % 2 == 0)
        {
            tempgo.transform.position = new Vector3(x * tilexoffset / 0.75f, y*tileyoffset, z * tilezoffset);
        }
        else
        {
            tempgo.transform.position = new Vector3(x * tilexoffset / 0.75f, y*tileyoffset, z * tilezoffset + tilezoffset / 2);
        }
        settileinfo(tempgo, x, z);

    }

    public float zoffset
    {
            get{ return tilezoffset; }
    }
    public float yoffset
    {
        get { return tileyoffset; }
    }
    public float xoffset
    {
        get { return tilexoffset; }
    }


    //maps

    public void generateflat()
    {
        hexTileprefab = Resources.Load("grass") as GameObject;
        createHextilemap();
        flat();
        //ahill(3,4,10,10);
    }

    

}
