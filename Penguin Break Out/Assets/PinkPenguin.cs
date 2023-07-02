using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkPenguin : PenguinBase
{
    bool foundMyMatch;
    public  GameObject PenguinPair;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        sight.target = PenguinPair;
       
    }

    // Update is called once per frame
    public override void  Update()
    {
        if (sight.canSee && Vector3.Distance(transform.position, PenguinPair.transform.position) > .2f)
        {
            agent.SetDestination(PenguinPair.transform.position);
            
        }
    }

    public void Lore(Transform loc)
    {
        //walk towards the lore 
        agent.SetDestination(loc.position);

        
    }

    public override IEnumerator gotHit()
    {
        //check around you. if theres another pink penguin hit. 
        if (foundMyMatch)
        {
            base.gotHit();
        }
        else
        {
            //particles to show that it didn't work
            yield return new WaitForSeconds(.1f);
        }
        
    }
}
