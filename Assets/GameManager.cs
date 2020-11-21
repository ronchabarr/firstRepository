using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   public Text Kmh;
    public GameObject Track;
   public  GameObject[] Routs;
    public GameObject player;
    public int playerCourentRout;
    internal bool RightborderBlock=false;
    internal bool LeftborderBlock=false;
    internal int Streake;
    public string[] colors = new string[] {"Red", "Yellow", "Green" };
    internal string currentTarget;
    // Start is called before the first frame update
    void Start()
    {
        int ChildCount = Track.transform.childCount;
        Routs = new GameObject[ChildCount];
        for (int i = 0; i < ChildCount; i++)
        {
            Routs[i] = Track.transform.GetChild(i).gameObject;
        }
        playerCourentRout = ((ChildCount-1) + 1) / 2;
        StartCoroutine(ColorSwich());



     
       
    }

    // Update is called once per frame
    void Update()
    {
        
        player.transform.position = new Vector3(Routs[playerCourentRout].transform.position.x, player.transform.position.y, player.transform.position.z);
        if (playerCourentRout == Track.transform.childCount-1)
        {
            RightborderBlock = true;
        }else
            RightborderBlock = false;

        if (playerCourentRout == Track.transform.childCount - Track.transform.childCount)
        {
            LeftborderBlock = true;

        }
        else
            LeftborderBlock = false;
        if (Input.GetKeyDown(KeyCode.LeftArrow)&&!LeftborderBlock)
        {
            playerCourentRout--;
            
        } 
        if (Input.GetKeyDown(KeyCode.RightArrow)&&!RightborderBlock)
        {
            playerCourentRout++;
            
        }

    }

    IEnumerator ColorSwich()
    {
        currentTarget = colors[Random.Range(0,3)];
        
        yield return new WaitForSeconds(3);
        StartCoroutine(ColorSwich());
        
    }
}
