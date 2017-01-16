﻿using System;
using System.Collections.Generic;

namespace Infrastructure.Core.Ship
{
    public class ShipModel : Infrastructure.Base.Model.Model
    {
        public int id;

        public int currentHullAmount;
        public int currentShieldAmount;
        public float currentEnergyAmount;

        public Dictionary<ShipStats, float> shipStats;

        protected Dictionary<ShipParts, ShipPart> shipParts;

        public ShipModel()
        {
            shipParts = new Dictionary<ShipParts, ShipPart>();
            shipStats = new Dictionary<ShipStats, float>();
        }

        public void AddPart(ShipParts partName, ShipPart part)
        {
            shipParts.Add(partName, part);
            foreach(KeyValuePair<ShipStats, float> stat in part.stats)
            {
                shipStats.Add(stat.Key, stat.Value);
            }
        }
    }
}
