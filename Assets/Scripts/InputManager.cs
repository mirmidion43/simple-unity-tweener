using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject item;
    private Tweener tweener;
    private List<GameObject> itemList = new List<GameObject>();

    int count = 1;

    // Start is called before the first frame update
    void Start()
    {
        tweener = gameObject.GetComponent<Tweener>();
        itemList.Add(item);
    }

    // Update is called once per frame
    void Update()
    {
        //Transform currentTrans = item.transform;
        //Vector3 currentPos = item.transform.position;
        Vector3 basePos = new Vector3(0.0f, 0.5f, 0.0f);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //GameObject item = Instantiate(item, basePos, transform.rotation);
            itemList.Add(Instantiate(item, basePos, transform.rotation));
            Debug.Log(itemList.Count);
        }

            if(Input.GetKeyDown(KeyCode.A))
            {
                foreach(GameObject item in itemList)
                {
                    if(tweener.AddTween(item.transform, item.transform.position, new Vector3(-2.0f,0.5f,0.0f), 1.5f))
                    break;
                }
            }
                         
            if(Input.GetKeyDown(KeyCode.D))
            {
                foreach(GameObject item in itemList)
                {
                    if(tweener.AddTween(item.transform, item.transform.position, new Vector3(2.0f,0.5f,0.0f), 1.5f))
                    break;
                }              
            }
                
            if(Input.GetKeyDown(KeyCode.S))
            {
                foreach(GameObject item in itemList)
                {
                    if(tweener.AddTween(item.transform, item.transform.position, new Vector3(0.0f,0.5f,-2.0f), 0.5f))
                    break; 
                }               
            }
                         
            if(Input.GetKeyDown(KeyCode.W))
            {
                foreach(GameObject item in itemList)
                {
                    if(tweener.AddTween(item.transform, item.transform.position, new Vector3(0.0f,0.5f,2.0f), 0.5f))
                    break;
                } 
            }
               
        
    }
}
