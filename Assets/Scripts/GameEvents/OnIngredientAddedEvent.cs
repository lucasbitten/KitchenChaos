using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameEvents/OnIngredientAddedEvent")]
public class OnIngredientAddedEvent : GameEvent_WithArgs<OnIngredientAddedEvent.EventArgs>
{
    public class EventArgs : GameEvent_Args
    {
        public EventArgs(PlateKitchenObject plate, KitchenObjectSO ingredient)
        {
            Plate = plate;
            Ingredient = ingredient;
        }

        public PlateKitchenObject Plate { get; private set; }
        public KitchenObjectSO Ingredient { get; private set; }
    }
}
