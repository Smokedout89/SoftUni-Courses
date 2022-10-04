using System;
using System.Collections.Generic;
using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using MilitaryElite.Models;

namespace MilitaryElite.Core
{
    public class Engine
    {
        private Dictionary<int, ISoldier> soldiers;

        public Engine()
        {
            soldiers = new Dictionary<int, ISoldier>();
        }

        public void Run()
        {
            ReadData();
            PrintData();
        }

        private void PrintData()
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.Value.ToString());
            }
        }

        private void ReadData()
        {
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();
                string type = cmdArgs[0];
                int id = int.Parse(cmdArgs[1]);
                string firstName = cmdArgs[2];
                string lastName = cmdArgs[3];

                if (type == "Private")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);

                    IPrivate @private = new Private(id, firstName, lastName, salary);
                    soldiers.Add(id, @private);
                }
                else if (type == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);

                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < cmdArgs.Length; i++)
                    {
                        int soldierId = int.Parse(cmdArgs[i]);

                        lieutenantGeneral.Privates.Add((IPrivate)soldiers[soldierId]);
                    }

                    soldiers.Add(id, lieutenantGeneral);
                }
                else if (type == "Engineer")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string inputCorps = cmdArgs[5];

                    bool isValidCorps = Enum.TryParse(inputCorps, out Corps currCorps);

                    if (!isValidCorps)
                    {
                        continue;
                    }

                    IEngineer enginner = new Engineer(id, firstName, lastName, salary, currCorps);

                    for (int i = 6; i < cmdArgs.Length; i += 2)
                    {
                        string repairPart = cmdArgs[i];
                        int repairHours = int.Parse(cmdArgs[i + 1]);

                        IRepair repair = new Repair(repairPart, repairHours);
                        enginner.Repairs.Add(repair);
                    }

                    soldiers.Add(id, enginner);
                }
                else if (type == "Commando")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string inputCorps = cmdArgs[5];

                    bool isValidCorps = Enum.TryParse(inputCorps, out Corps currCorps);

                    if (!isValidCorps)
                    {
                        continue;
                    }

                    ICommando commando = new Commando(id, firstName, lastName, salary, currCorps);

                    for (int i = 6; i < cmdArgs.Length; i += 2)
                    {
                        string missionName = cmdArgs[i];
                        string missionState = cmdArgs[i + 1];

                        bool missionValid = Enum.TryParse(missionState, out State currMission);

                        if (!missionValid)
                        {
                            continue;
                        }

                        IMission mission = new Mission(missionName, currMission);
                        commando.Missions.Add(mission);
                    }

                    soldiers.Add(id, commando);
                }
                else if (type == "Spy")
                {
                    int codeNumber = int.Parse(cmdArgs[4]);

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiers.Add(id, spy);
                }
            }
        }
    }
}