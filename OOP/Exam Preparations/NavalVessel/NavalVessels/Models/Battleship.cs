namespace NavalVessels.Models
{
    using System;

    using Contracts;

    public class Battleship : Vessel, IBattleship
    {
        private const double BattleshipDefaultThickness = 300;

        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, BattleshipDefaultThickness)
        {
        }

        public bool SonarMode { get; private set; } = false;

        public void ToggleSonarMode()
        {
            if (!SonarMode)
            {
                SonarMode = true;
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else
            {
                SonarMode = false;
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < BattleshipDefaultThickness)
            {
                ArmorThickness = BattleshipDefaultThickness;
            }
        }

        public override string ToString()
        {
            string sonarOnOff = SonarMode 
                ? "ON" 
                : "OFF";

            return base.ToString() + Environment.NewLine 
                                   + $" *Sonar mode: {sonarOnOff}";
        }
    }
}