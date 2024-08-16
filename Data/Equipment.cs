using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCPSY200.Data
{
    public class Equipment
    {
        int equipmentID;
        string equipmentName;
        string description;
        float dailyRentalCost;
        int category;

        public int EquipmentID { get => equipmentID; set => equipmentID = value; }
        public string EquipmentName { get => equipmentName; set => equipmentName = value; }
        public string Description { get => description; set => description = value; }
        public float DailyRentalCost { get => dailyRentalCost; set => dailyRentalCost = value; }
        public int Category { get => category; set => category = value; }
        public Equipment()
        {
            
        }
        public Equipment(int equipmentID, string equipmentName, string description, float dailyRentalCost, int category)
        {
            this.equipmentID = equipmentID;
            this.equipmentName = equipmentName;
            this.description = description;
            this.dailyRentalCost=dailyRentalCost;
            this.category = category;
        }
    }
}
