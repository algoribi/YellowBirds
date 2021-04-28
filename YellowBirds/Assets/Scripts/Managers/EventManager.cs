using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action EnemyDieEvent;
    public static event Action CoinEatEvent;
    public static event Action PlayerDieEvent;

    public static void RunPlayerDieEvent() {
        if (PlayerDieEvent != null) {
            PlayerDieEvent();
        }
    }

    public static void RunCoinEatEvent() {
        if (CoinEatEvent != null) {
            CoinEatEvent();
        }
    }

    public static void RunEnemyDieEvent() {
        if (EnemyDieEvent != null) {
            EnemyDieEvent();
        }
    }
}
