using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOther : MonoSingleton<AnimationOther>
{
    
    public void ActionAnimation(GameObject obj, string animName, bool state)
    {
        //obj.GetComponent<Animator>().SetBool(animName, state);
        Destroy(obj, 0.1f);
    }
	
	public void CancelAnimation(GameObject obj,string animName, bool state)
    {
        //obj.GetComponent<Animator>().SetBool(animName, state);
        
    }
    
}
