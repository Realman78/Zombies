using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot {
        public AmmoType ammoType;
        public int amount;
    }
    
    public int getAmount(AmmoType ammoType) {
        return getAmmoSlot(ammoType).amount;
    }

    public void reduceAmmo(AmmoType ammoType) {
        getAmmoSlot(ammoType).amount--;
    }
    public void increaseAmmo(AmmoType ammoType, int amount) {
        getAmmoSlot(ammoType).amount += amount;
    }
private AmmoSlot getAmmoSlot(AmmoType ammoType) {
        foreach(AmmoSlot slot in ammoSlots) {
            if (slot.ammoType == ammoType) {
                return slot;
            }
        }
        return null;
    }
}
