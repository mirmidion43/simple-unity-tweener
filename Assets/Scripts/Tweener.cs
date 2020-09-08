using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    //private Tween activeTween;
    private List<Tween> activeTweens = new List<Tween>();
   
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public bool AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if(TweenExists(targetObject))
            return false;
        else
            activeTweens.Add(new Tween(targetObject, startPos, endPos, Time.time, duration));
        return true;
    }

    public bool TweenExists(Transform target)
    {
        foreach(Tween Tween in activeTweens)
        if(Tween.Target == target)
        {
            return true;
        }
      
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if(activeTweens != null)
        
        //foreach(Tween Tween in activeTweens)
        for(int i = activeTweens.Count - 1; i >= 0; i--)
        {
                float distance = Vector3.Distance(activeTweens[i].Target.position, activeTweens[i].EndPos);

                if(distance > 0.1f)
                {
                    float t = (Time.time - activeTweens[i].StartTime) / activeTweens[i].Duration;
                    float cubeT = t*t*t;
                    activeTweens[i].Target.position = Vector3.Lerp(activeTweens[i].StartPos, activeTweens[i].EndPos, cubeT);
                }
        
                if(distance <= 0.1f)
                {
                    activeTweens[i].Target.position = activeTweens[i].EndPos;
                    activeTweens.Remove(activeTweens[i]);
                } 
        }
        

    }
}
