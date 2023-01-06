using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteFuel : PowerUp
{

    public static void infiniteFuelFunc(Player_Controller player) {
        player.freezeFuel();
    }

    public static void resetInfiniteFuelFunc(Player_Controller player) {
        player.unFreezeFuel();
    }

    public static bool startInfiniteFuelFunc(Player_Controller player) {
        return false;
    }

    public InfiniteFuel(): base(startInfiniteFuelFunc, infiniteFuelFunc, resetInfiniteFuelFunc) {

    }
    

    
}
