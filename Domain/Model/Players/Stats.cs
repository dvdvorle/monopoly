using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restless.Monopoly.Domain.Model.Players
{
    public class Stats
    {
        public virtual Guid Id { get; protected set; }
        public virtual int Money { get; protected set; }

        public Stats()
        {
            Money = 0;
        }

        public virtual void AddMoney(int moneyToAdd)
        {
            Money += moneyToAdd;
        }

        public virtual int GetAndRemoveMoney(int moneyToRemove)
        {
            // TODO: handle not enough money
            Money -= moneyToRemove;

            return moneyToRemove;
        }
    }
}
