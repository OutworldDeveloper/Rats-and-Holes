﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{

    void ApplyDamage(int damage, DamageType damageType);

}