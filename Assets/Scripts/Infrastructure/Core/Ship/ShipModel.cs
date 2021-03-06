﻿using System;
using System.Collections.Generic;
using Infrastructure.Core.Resource;
using System.Linq;

namespace Infrastructure.Core.Ship
{
    [Serializable]
    public class ShipModel : Infrastructure.Base.Model.Model
    {
        public int id;

        public int currentHullAmount;
        public int currentShieldAmount;
        public float currentEnergyAmount;

        public Dictionary<ShipStats, int> shipStats;

        protected Dictionary<ShipParts, ShipPart> shipParts;

        public Dictionary<string, int> shipCargo;

        public ShipModel()
        {
            shipParts = new Dictionary<ShipParts, ShipPart>();
            shipStats = new Dictionary<ShipStats, int>();
            shipCargo = new Dictionary<string, int>();
        }

        public void AddPart(ShipParts partName, ShipPart part)
        {
            shipParts.Add(partName, part);
            foreach(KeyValuePair<ShipStats, int> stat in part.stats)
            {
                shipStats.Add(stat.Key, stat.Value);
            }
        }

        public bool AddResource(string resourceName, int amount)
        {
            int cargoHold = shipCargo.Sum (x => x.Value);
            if (cargoHold < shipStats[ShipStats.CargoCapacity])
            {
                if (!shipCargo.ContainsKey(resourceName))
                {
                    shipCargo.Add(resourceName, amount);
                }
                else
                {
                    shipCargo[resourceName] += amount;
                }
                return true;
            }
            return false;
        }

        public bool RemoveResource(string resourceName, int amount)
        {
            if (shipCargo.ContainsKey(resourceName) && shipCargo[resourceName] >= amount )
            {
                shipCargo[resourceName]--;
                return true;
            }
            return false;
        }
    }
}

