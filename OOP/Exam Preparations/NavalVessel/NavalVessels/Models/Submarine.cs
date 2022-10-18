namespace NavalVessels.Models
{
    using System;

    using Contracts;

    public class Submarine : Vessel, ISubmarine
    {
        private const double SubmarineDefaultThickness = 200;

        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, SubmarineDefaultThickness)
        {
        }
        public bool SubmergeMode { get; private set; } = false;

        public void ToggleSubmergeMode()
        {
            if (!SubmergeMode)
            {
                SubmergeMode = true;
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else
            {
                SubmergeMode = false;
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < SubmarineDefaultThickness)
            {
                ArmorThickness = SubmarineDefaultThickness;
            }
        }

        public override string ToString()
        {
            string submergeOnOff = SubmergeMode
                ? "ON"
                : "OFF";

            return base.ToString() + Environment.NewLine
                                   + $" *Submerge mode: {submergeOnOff}";
        }
    }
}