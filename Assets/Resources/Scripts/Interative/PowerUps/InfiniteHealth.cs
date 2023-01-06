using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteHealth : PowerUp
{
    public static void infiniteHealthFunc (Player_Controller player) {
        player.setHealth();
    }

    public static bool startInfiniteHealthFunc(Player_Controller player) {
        player.setHealth();
        return true;
    }

    public InfiniteHealth(): base(startInfiniteHealthFunc, infiniteHealthFunc) {

    }
}
