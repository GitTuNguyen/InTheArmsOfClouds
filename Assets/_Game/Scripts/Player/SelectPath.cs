using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SelectPath : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
       
    }

    public override void OnCollisionEnter(PlayerStateManager player, Collision collision)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.playerController.PlayerSelectPath();
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            player.SwitchState(PlayerState.FollowPath);
        }
    }
}
