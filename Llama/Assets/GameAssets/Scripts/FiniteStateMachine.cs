using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FiniteStateMachine : MonoBehaviour
{
    #region JobFiniteState
    private Job hear;
    private Job see;
    private Job investigate;
    private Job takeCover;
    private Job followPlayer;
    private Job standGround;
	#endregion

    public bool IsChosen
    {
        get;
        private set;
    }
    public enum State
    { 
        Investigating = 1,
        FollowOrder,
        StayInCover,
        FollowPlayer,
        Stand
    }
    private State state = State.FollowPlayer;
    public State GetSetState
    {
        get
        {
            return state;
        }
        set 
        {
            ExitState(state);
            state = value;
            EnterState(state);
        }
    }
    private void EnterState(State stateEnter)
    {
        switch (stateEnter)
        { 
            case State.Stand:
                standGround = new Job(Stand());
                break;
            default:
                //Dont do anything yield break
                break;
        }
    }

    private void ExitState(State stateExit)
    {
        switch (stateExit)
        { 
            case State.Investigating:
                if (see != null) 
                    see.KillJob();
                if (hear != null)
                    hear.KillJob();
                break;
            default:
                break;
        }
    }

    
    public new void Start()
    {
        GetSetState = State.FollowPlayer;
    }
		

    private IEnumerator Stand()
    {
        //while (true)
        //{
            //Move again if we are far from the player
            //if(IsChosen && Vector3.Distance(target.position, transform.position) > 6.0f)
           // {
           //     GetSetState = State.FollowPlayer;
            //    yield break;
           // }
            yield return 0; //don't skip frames
        //}
    }
}
