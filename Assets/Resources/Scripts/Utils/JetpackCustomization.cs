using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Jetpack {
    private const string acceleartionKey = "acceleartion";
    private const string damageKey = "damage";

    private const float maxDamage = 200f;
    private const float maxAcceleration = 20f;

    private float acceleartion = Player_Controller.getDefaultAccelaration();
    private float damage = Bullet.getDefaultDamage();

    public Jetpack () {
        acceleartion = getAcceleration();
        damage = getDamage();
    }

    public void reset() {
        PlayerPrefs.SetFloat(acceleartionKey, Player_Controller.getDefaultAccelaration());
        PlayerPrefs.SetFloat(damageKey, Bullet.getDefaultDamage());
    }

    public static float getAcceleration () {
        if(PlayerPrefs.HasKey(acceleartionKey)) {
            return PlayerPrefs.GetFloat(acceleartionKey);
        }
        return Player_Controller.getDefaultAccelaration();
    }

    public static float getDamage () {
        if(PlayerPrefs.HasKey(damageKey)) {
            return PlayerPrefs.GetFloat(damageKey);
        }
        return Bullet.getDefaultDamage();
    }

    public static float getMaxAcceleration () {
        return maxAcceleration;
    }

    public static float getMaxDamage () {
        return maxDamage;
    }

    public void updateAcceleration(float newAcceleartion) {
        if (newAcceleartion < 0) {
            newAcceleartion = 0;
        } else if (newAcceleartion > maxAcceleration) {
            newAcceleartion = maxAcceleration;
        }
        PlayerPrefs.SetFloat(acceleartionKey, newAcceleartion);
    }

    public void updateDamage(float newDamage) {
        if (newDamage < 0) {
            newDamage = 0;
        } else if (newDamage > maxDamage) {
            newDamage = maxDamage;
        }
        PlayerPrefs.SetFloat(damageKey, newDamage);
    }

    public static float getFuelConsumptionForAcceleration(float acceleartion) {
        return acceleartion/Player_Controller.defaultAccelarationPerFuel();
    }

    public static float getFuelConsumptionForDamage(float damage) {
        return damage/Player_Controller.defaultBulletPerFuel();
    }

    public float getCurrentFuelConsumptionForAcceleration() {
        return getFuelConsumptionForAcceleration(acceleartion);
    }

    public float getCurrentFuelConsumptionForDamage() {
        return getFuelConsumptionForDamage(damage);
    }
}