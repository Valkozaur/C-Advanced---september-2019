﻿namespace P07.MilitaryElite.Models.Soldiers.Privates.SpecialisedSoldiers
{
    using Contracts.Soldier.Private.SpecialisedSoldier;
    using System;

    public class Mission : IMission
    {
        private string state;

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }
       
        public string CodeName { get; set; }

        public string State
        {
            get => this.state;
            private set
            {
                if (value != "inProgress" && value != "Finished")
                {
                    throw new ArgumentException("Invalid missions state!");
                }

                this.state = value;
            }
        }

        public void CompleteMission()
        {
            this.State = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}