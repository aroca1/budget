using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GimmeSolutionsBudget.Models
{
    public class TransactionCollection : IEnumerable<Transaction>
    {
        private List<Transaction> _transactions = new List<Transaction>();

        #region Properties

        public Transaction this[int index]
        {
            get
            {
                return this._transactions[index];
            }
            set
            {
                this._transactions[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return this._transactions.Count;
            }
        }

        #endregion

        #region Methods

        public IEnumerator<Transaction> GetEnumerator()
        {
            return this._transactions.GetEnumerator();
        }

        public void Add(Transaction transaction)
        {
            this._transactions.Add(transaction);
        }

        public void AddRange(IEnumerable<Transaction> transactions)
        {
            this._transactions.AddRange(transactions);
        }

        public void Remove(Transaction transaction)
        {
            this._transactions.Remove(transaction);
        }

        public void RemoveAll(Predicate<Transaction> matchPredicate)
        {
            this._transactions.RemoveAll(matchPredicate);
        }

        public IEnumerable<Transaction> GetAll(Predicate<Transaction> matchPredicate)
        {
            return this._transactions.FindAll(matchPredicate);
        }

        public IEnumerable<Transaction> PopAll(Predicate<Transaction> matchPredicate)
        {
            IEnumerable<Transaction> result = GetAll(matchPredicate);
            RemoveAll(matchPredicate);
            return result;
        }

        public void Clear()
        {
            this._transactions.Clear();
        }

        public bool Contains(Transaction transaction)
        {
            return this._transactions.Contains(transaction);
        }

        /// <summary>
        /// Returns enumerable of Transaction objects. Both limits exclusive.
        /// </summary>
        /// <param name="start">Beginning of range, exclusive.</param>
        /// <param name="end">End of range, exclusive.</param>
        /// <returns></returns>
        public IEnumerable<Transaction> GetEntriesInDateRange(DateTime start, DateTime end)
        {
            return this._transactions.Where(t => t.Timestamp > start && t.Timestamp < end);
        }

        public IEnumerable<Transaction> GetEntriesOnDate(DateTime targetDate)
        {
            return this._transactions.Where(t => t.Timestamp.Equals(targetDate));
        }

        public double GetTotalBalance()
        {
            return this._transactions.Sum<Transaction>(t => Convert.ToDouble(t.Amount));
        }

        public double GetBalanceFromRange(DateTime start, DateTime end)
        {
            IEnumerable<Transaction> transactions = GetEntriesInDateRange(start, end);
            return transactions.Sum<Transaction>(t => Convert.ToDouble(t.Amount));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._transactions.GetEnumerator();
        }
    }

    #endregion
}
