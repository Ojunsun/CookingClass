using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyMeleeMove : ArmyState
{
    public ArmyMeleeMove(Player army, ArmyStateMachine stateMachine, string animBoolName) : base(army, stateMachine, animBoolName)
    {
    }
}
