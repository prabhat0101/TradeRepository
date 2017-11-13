using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeRepo.Data.Models;

namespace TradeRepo.Data.Plugins
{
    public class SQLLiteTradeServicePlugin : ITradeServicePlugin
    {
         
        public string connectionString { get; set; }
        public SQLLiteTradeServicePlugin()
        {
            var path = @"D:\TradeRepo\TradeRepo.Data\" + "Database.db";
            connectionString = @"Data Source= " + path + "; Version=3; FailIfMissing=True; Foreign Keys=True;";
        }

        public bool Delete(IEnumerable<string> Ids)
        {
            throw new NotImplementedException();
        }

        private string GetQuery(IList<string> ids, IList<string> fields)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select ");
            var count = fields.Count();
            for (int i=0; i< count -1; i++)
            {
                sb.Append(fields[i] + ",");
            }
            sb.Append(fields[count - 1]);
            sb.Append(" from Trade where ID in (");
            var idCount = ids.Count();
            for (int i = 0; i < idCount - 1; i++)
            {
                sb.Append(ids[i] + ",");
            }
            sb.Append(ids[idCount-1] + ")");
            return sb.ToString();
        }

        public IEnumerable<Trade> Load(List<string> ids, List<string> fields)
        {
            IList<Trade> trades = new List<Trade>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = GetQuery(ids,fields);
                    cmd.Prepare();                   
                    try
                    {
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var trade = new Trade();
                            trade.Id = reader["ID"].ToString();
                            //trade.Trader = reader["Trader"].ToString();
                            trade.Portfolio = reader["Portfolio"].ToString();
                            trade.CounterParty = reader["CounterParty"].ToString();
                            //trade.TradeDate = reader["TradeDate"].ToString();
                            //trade.ValueDate = reader["ValueDate"].ToString();
                            //trade.MaturityDate = reader["MaturityDate"].ToString();
                            trades.Add(trade);
                        }
                    }
                    catch (SQLiteException e)
                    {
                        throw;
                    }
                }
            }
            return trades;
        }

        public bool Save(Trade trade)
        {
            int result = -1;
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            { 
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "INSERT INTO Trade(ID,Portfolio,CounterParty,Trader,TradeDate,ValueDate,MaturityDate) VALUES " +
                        "(@ID,@Portfolio,@CounterParty,@Trader,@TradeDate,@ValueDate,@MaturityDate)";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@ID", trade.Id);
                    cmd.Parameters.AddWithValue("@Portfolio", trade.Portfolio);
                    cmd.Parameters.AddWithValue("@CounterParty", trade.CounterParty);
                    cmd.Parameters.AddWithValue("@Trader", trade.Trader);
                    cmd.Parameters.AddWithValue("@TradeDate", trade.TradeDate);
                    cmd.Parameters.AddWithValue("@ValueDate", trade.ValueDate);
                    cmd.Parameters.AddWithValue("@MaturityDate", trade.MaturityDate);
                    try
                    {
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException e)
                    {
                        throw;
                    }                    
                }
            }
            return true;
        }
    }
}
