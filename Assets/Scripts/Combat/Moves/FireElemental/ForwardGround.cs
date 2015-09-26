﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireForwardGround : Move {
    private Hitbox hitbox1;

    public FireForwardGround(Combatent combatent)
    {
        owner = combatent;
        duration = 10;
        hitbox1 = new Hitbox();
        hitbox1.sourcePlayer = owner;
        hitbox1.sourceMove = this;
        hitbox1.pos = new Sphere();
        hitbox1.damage = 10;
        hitbox1.hitstun = 25;
        hitbox1.knockback = 10;
    }

    public override void Step(CombatManager mgr)
    {
        switch (currentFrame)
        {
            case 0:
                owner.blockingMove = true;
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                mgr.hitboxes.Add(hitbox1);
                hitbox1.pos.x = new FInt(owner.FacingRight ? 1 : -1);
                hitbox1.pos.y = new FInt(0.3);
                hitbox1.pos.r = new FInt(0.5);
                break;
            case 6:
                hitbox1.pos.x = new FInt(owner.FacingRight ? 1 : -1);
                hitbox1.pos.y = new FInt(0.3);
                hitbox1.pos.r = new FInt(0.5);
                break;
            case 7:
                hitbox1.pos.x = new FInt(owner.FacingRight ? 1 : -1);
                hitbox1.pos.y = new FInt(0.3);
                hitbox1.pos.r = new FInt(0.5);
                break;
            case 8:
                hitbox1.pos.x = new FInt(owner.FacingRight ? 1 : -1);
                hitbox1.pos.y = new FInt(0.3);
                hitbox1.pos.r = new FInt(0.5);
                break;
            case 9:
                hitbox1.pos.x = new FInt(owner.FacingRight ? 1 : -1);
                hitbox1.pos.y = new FInt(0.3);
                hitbox1.pos.r = new FInt(0.5);
                break;
            case 10:
                mgr.hitboxes.Remove(hitbox1);
                break;
            case 11:
                break;
            case 12:
                break;
            case 13:
                break;
            case 14:
                mgr.moves.Remove(this);
                owner.blockingMove = false;
                break;
        }
        currentFrame += 1;
    }

    public override void Trigger(CombatManager mgr)
    {
        if (!((Input.GetAxis("HorizontalAttack") == 1 && owner.FacingRight) ||
              (Input.GetAxis("HorizontalAttack") == -1 && !owner.FacingRight)) ||
            owner.blockingMove ||
            !owner.AllowInput ||
            !owner.Grounded)
        {
            return;
        }
        base.Trigger(mgr);
        //Debug.Log("Forward Ground");
    }
}