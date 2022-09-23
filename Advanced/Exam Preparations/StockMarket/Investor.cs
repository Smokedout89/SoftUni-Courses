using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            this.portfolio = new List<Stock>();
        }

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public decimal MoneyToInvest { get; set; }

        public string BrokerName { get; set; }  

        public int Count => portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                portfolio.Add(stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock stock = portfolio.FirstOrDefault(n => n.CompanyName == companyName);

            if (stock == null)
            {
                return $"{companyName} does not exist.";
            }

            if (sellPrice < stock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            MoneyToInvest += sellPrice;
            portfolio.Remove(stock);
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            return portfolio.FirstOrDefault(n => n.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            return portfolio.OrderByDescending(v => v.MarketCapitalization).FirstOrDefault();
        }

        public string InvestorInformation()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");

            foreach (var stock in portfolio)
            {
                sb.AppendLine(stock.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
