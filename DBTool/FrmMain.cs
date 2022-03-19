using MySqlHelper.Entity;
using SqlServerHelper.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBTool
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadConfig();
            LoadFreeSql();
            SetValueToControl();
        }
        private Dictionary<string, string> a_sqlconfig = new Dictionary<string, string>();
        private Dictionary<string, string> b_sqlconfig = new Dictionary<string, string>();
        private Dictionary<string, string> c_sqlconfig = new Dictionary<string, string>();
        private Dictionary<string, string> a_mysqlconfig = new Dictionary<string, string>();
        private Dictionary<string, string> b_mysqlconfig = new Dictionary<string, string>();
        private Dictionary<string, string> c_mysqlconfig = new Dictionary<string, string>();

        private string a_sqlConnectStr = ConfigurationManager.ConnectionStrings["A_sqlserver"].ConnectionString;
        private string b_sqlConnectStr = ConfigurationManager.ConnectionStrings["B_sqlserver"].ConnectionString;
        private string c_sqlConnectStr = ConfigurationManager.ConnectionStrings["C_sqlserver"].ConnectionString;
        private string a_mysqlConnectStr = ConfigurationManager.ConnectionStrings["A_mysql"].ConnectionString;
        private string b_mysqlConnectStr = ConfigurationManager.ConnectionStrings["B_mysql"].ConnectionString;
        private string c_mysqlConnectStr = ConfigurationManager.ConnectionStrings["C_mysql"].ConnectionString;

        private static IFreeSql fsq_SqlA = null;
        private static IFreeSql fsq_SqlB = null;
        private static IFreeSql fsq_SqlC = null;
        private static IFreeSql fsq_MySqlA = null;
        private static IFreeSql fsq_MySqlB = null;
        private static IFreeSql fsq_MySqlC = null;

        private void LoadConfig()
        {
            a_sqlconfig = GetConfig(a_sqlConnectStr);
            b_sqlconfig = GetConfig(b_sqlConnectStr);
            c_sqlconfig = GetConfig(c_sqlConnectStr);
            a_mysqlconfig = GetConfig(a_mysqlConnectStr);
            b_mysqlconfig = GetConfig(b_mysqlConnectStr);
            c_mysqlconfig = GetConfig(c_mysqlConnectStr);
        }

        private void LoadFreeSql()
        {
            fsq_MySqlA = new FreeSql.FreeSqlBuilder()
               .UseConnectionString(FreeSql.DataType.MySql, a_mysqlConnectStr)
               .UseAutoSyncStructure(true) //自动同步实体结构到数据库
               .Build(); //请务必定义成 Singleton 单例模式
            fsq_MySqlB = new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.MySql, b_mysqlConnectStr)
                .UseAutoSyncStructure(true) //自动同步实体结构到数据库
                .Build(); //请务必定义成 Singleton 单例模式
            fsq_MySqlC = new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.MySql, c_mysqlConnectStr)
                .UseAutoSyncStructure(true) //自动同步实体结构到数据库
                .Build(); //请务必定义成 Singleton 单例模式
            fsq_SqlA = new FreeSql.FreeSqlBuilder()
                 .UseConnectionString(FreeSql.DataType.SqlServer, a_sqlConnectStr)
                 .UseAutoSyncStructure(true) //自动同步实体结构到数据库
                 .Build(); //请务必定义成 Singleton 单例模式
            fsq_SqlB = new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.SqlServer, b_sqlConnectStr)
                .UseAutoSyncStructure(true) //自动同步实体结构到数据库
                .Build(); //请务必定义成 Singleton 单例模式
            fsq_SqlC = new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.SqlServer, c_sqlConnectStr)
                .UseAutoSyncStructure(true) //自动同步实体结构到数据库
                .Build(); //请务必定义成 Singleton 单例模式

        }

        public Dictionary<string, string> GetConfig(string connectStr)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            try
            {
                string[] arrstr = connectStr.Split(';');
                foreach (var item in arrstr)
                {
                    string[] keyVal = item.Split('=');
                    dic.Add(keyVal[0], keyVal[1]);
                }
            }
            catch (Exception)
            {

            }
            return dic;
        }

        public void SetValueToControl()
        {
            a_ip.Text = a_mysqlconfig["Data Source"];
            b_ip.Text = b_mysqlconfig["Data Source"];
            c_ip.Text = c_mysqlconfig["Data Source"];

            //mysql
            a_portMysql.Text = a_mysqlconfig["Port"];
            b_portMysql.Text = b_mysqlconfig["Port"];
            c_portMysql.Text = c_mysqlconfig["Port"];
            a_userMysql.Text = a_mysqlconfig["User ID"];
            b_userMysql.Text = b_mysqlconfig["User ID"];
            c_userMysql.Text = c_mysqlconfig["User ID"];
            a_pwdMysql.Text = a_mysqlconfig["Password"];
            b_pwdMysql.Text = b_mysqlconfig["Password"];
            c_pwdMysql.Text = c_mysqlconfig["Password"];
            a_dbMysql.Text = a_mysqlconfig["Initial Catalog"];
            b_dbMysql.Text = b_mysqlconfig["Initial Catalog"];
            c_dbMysql.Text = c_mysqlconfig["Initial Catalog"];

            //sqlserver
            a_userSql.Text = a_sqlconfig["User Id"];
            b_userSql.Text = b_sqlconfig["User Id"];
            c_userSql.Text = c_sqlconfig["User Id"];
            a_pwdSql.Text = a_sqlconfig["Password"];
            b_pwdSql.Text = b_sqlconfig["Password"];
            c_pwdSql.Text = c_sqlconfig["Password"];
            a_dbSql.Text = a_sqlconfig["Initial Catalog"];
            b_dbSql.Text = b_sqlconfig["Initial Catalog"];
            c_dbSql.Text = c_sqlconfig["Initial Catalog"];
        }

        private void SaveConfig()
        {
            string a_ipstr = a_ip.Text;
            string b_ipstr = b_ip.Text;
            string c_ipstr = c_ip.Text;

            string a_Mysqlport = a_portMysql.Text;
            string b_Mysqlport = b_portMysql.Text;
            string c_Mysqlport = c_portMysql.Text;
            string a_userNameMy = a_userMysql.Text;
            string b_userNameMy = b_userMysql.Text;
            string c_userNameMy = c_userMysql.Text;
            string a_pwdMy = a_pwdMysql.Text;
            string b_pwdMy = b_pwdMysql.Text;
            string c_pwdMy = c_pwdMysql.Text;
            string a_dbMy = a_dbMysql.Text;
            string b_dbMy = b_dbMysql.Text;
            string c_dbMy = c_dbMysql.Text;

            string a_sqlUser = a_userSql.Text;
            string b_sqlUser = b_userSql.Text;
            string c_sqlUser = c_userSql.Text;
            string a_sqlpwd = a_pwdSql.Text;
            string b_sqlpwd = b_pwdSql.Text;
            string c_sqlpwd = c_pwdSql.Text;
            string a_sqldb = a_dbSql.Text;
            string b_sqldb = b_dbSql.Text;
            string c_sqldb = c_dbSql.Text;


            string a_connectstrMy = string.Format("Data Source={0};Port={1};User ID={2};Password={3};Initial Catalog={4};Charset=utf8;SslMode=none;Max pool size=10", a_ipstr, a_Mysqlport, a_userNameMy, a_pwdMy, a_dbMy);
            string b_connectstrMy = string.Format("Data Source={0};Port={1};User ID={2};Password={3};Initial Catalog={4};Charset=utf8;SslMode=none;Max pool size=10", b_ipstr, b_Mysqlport, b_userNameMy, b_pwdMy, b_dbMy);
            string c_connectstrMy = string.Format("Data Source={0};Port={1};User ID={2};Password={3};Initial Catalog={4};Charset=utf8;SslMode=none;Max pool size=10", c_ipstr, c_Mysqlport, c_userNameMy, c_pwdMy, c_dbMy);

            string a_connectStrSql = string.Format("Data Source={0};User Id={1};Password={2};Initial Catalog={3};TrustServerCertificate=true;Pooling=true;Min Pool Size= 1", a_ipstr, a_sqlUser, a_sqlpwd, a_sqldb);
            string b_connectStrSql = string.Format("Data Source={0};User Id={1};Password={2};Initial Catalog={3};TrustServerCertificate=true;Pooling=true;Min Pool Size= 1", b_ipstr, b_sqlUser, b_sqlpwd, b_sqldb);
            string c_connectStrSql = string.Format("Data Source={0};User Id={1};Password={2};Initial Catalog={3};TrustServerCertificate=true;Pooling=true;Min Pool Size= 1", c_ipstr, c_sqlUser, c_sqlpwd, c_sqldb);


            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.ConnectionStrings.ConnectionStrings["A_mysql"].ConnectionString = a_connectstrMy;
            configuration.ConnectionStrings.ConnectionStrings["B_mysql"].ConnectionString = b_connectstrMy;
            configuration.ConnectionStrings.ConnectionStrings["C_mysql"].ConnectionString = c_connectstrMy;
            configuration.ConnectionStrings.ConnectionStrings["A_sqlserver"].ConnectionString = a_connectStrSql;
            configuration.ConnectionStrings.ConnectionStrings["B_sqlserver"].ConnectionString = b_connectStrSql;
            configuration.ConnectionStrings.ConnectionStrings["C_sqlserver"].ConnectionString = c_connectStrSql;
            configuration.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
            LoadConfig();
            LoadFreeSql();
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            SaveConfig();
            MessageBox.Show("保存成功!");
        }

        private void Hebing_btn_Click(object sender, EventArgs e)
        {
            this.progressBar.Value = 0;
            Log("");
            Task.Run(() =>
            {
                Log("正在合并mysql数据库......");
                HeBingMysql();
                Log("正在合并sqlserver数据库......");
                HebingOtherSqlserver();
                HeBingSqlServer2();
                Log("数据合并完成!");
            });
        }

        private void HeBingSqlServer()
        {
            var account1 = fsq_SqlA.Select<DboAccount>().ToList();
            var account2 = fsq_SqlB.Select<DboAccount>().ToList();
            var userDb1 = fsq_SqlA.Select<Userdb>().ToList();
            var userDb2 = fsq_SqlB.Select<Userdb>().ToList();

            List<DboAccount> newAccount = new List<DboAccount>();
            List<Userdb> newUserDB = new List<Userdb>();

            int progress = 0;
            int totalCount = account1.Count + 1;

            foreach (var item in account1)
            {
                var account = account2.FirstOrDefault(t => t.Account.Trim() == item.Account.Trim());//在2中找到同一个角色
                if (account != null)
                {
                    int juesecount1 = GetJueseCount(item);
                    int juesecount2 = GetJueseCount(account);
                    if ((juesecount1 + juesecount2) > 3)
                    {
                        item.Account = item.Account.Trim() + "_a";
                        newAccount.Add(item);
                        newAccount.Add(account);

                        if (item.Id1 != null)
                        {
                            Userdb juese = userDb1.FirstOrDefault(t => t.Id == item.Id1);
                            if (juese != null)
                            {
                                userDb1.Remove(juese);

                                juese.Account = item.Account;
                                newUserDB.Add(juese);
                            }

                        }
                        if (item.Id2 != null)
                        {
                            Userdb juese = userDb1.FirstOrDefault(t => t.Id == item.Id2);
                            if (juese != null)
                            {
                                userDb1.Remove(juese);

                                juese.Account = item.Account;
                                newUserDB.Add(juese);
                            }
                        }
                        if (item.Id3 != null)
                        {
                            Userdb juese = userDb1.FirstOrDefault(t => t.Id == item.Id3);
                            if (juese != null)
                            {
                                userDb1.Remove(juese);

                                juese.Account = item.Account;
                                newUserDB.Add(juese);
                            }
                        }

                        if (account.Id1 != null)
                        {
                            Userdb juese = userDb2.FirstOrDefault(t => t.Id == account.Id1);
                            if (juese != null)
                            {
                                newUserDB.Add(juese);
                                userDb2.Remove(juese);
                            }
                        }
                        if (account.Id2 != null)
                        {
                            Userdb juese = userDb2.FirstOrDefault(t => t.Id == account.Id2);
                            if (juese != null)
                            {
                                newUserDB.Add(juese);
                                userDb2.Remove(juese);
                            }
                        }
                        if (account.Id3 != null)
                        {
                            Userdb juese = userDb2.FirstOrDefault(t => t.Id == account.Id3);
                            if (juese != null)
                            {
                                newUserDB.Add(juese);
                                userDb2.Remove(juese);
                            }
                        }
                    }
                    else
                    {
                        if ((juesecount1 + juesecount2) != 0)//合并两个账户的角色ID
                        {
                            List<long?> ids = new List<long?>();
                            if (item.Id1 != null)
                                ids.Add(item.Id1);
                            if (item.Id2 != null)
                                ids.Add(item.Id3);
                            if (item.Id3 != null)
                                ids.Add(item.Id3);
                            if (account.Id1 != null)
                                ids.Add(account.Id1);
                            if (account.Id2 != null)
                                ids.Add(account.Id2);
                            if (account.Id3 != null)
                                ids.Add(account.Id3);
                            if (ids.Count == 1)
                                item.Id1 = ids[0];
                            if (ids.Count == 2)
                            {
                                item.Id1 = ids[0];
                                item.Id2 = ids[1];
                            }
                            if (ids.Count == 3)
                            {
                                item.Id1 = ids[0];
                                item.Id2 = ids[1];
                                item.Id3 = ids[2];
                            }

                            //合并角色表
                            if (item.Id1 != null)
                            {
                                Userdb juese = userDb1.FirstOrDefault(t => t.Id == item.Id1);
                                if (juese != null)
                                {
                                    newUserDB.Add(juese);
                                    userDb1.Remove(juese);
                                }
                            }
                            if (item.Id2 != null)
                            {
                                Userdb juese = userDb1.FirstOrDefault(t => t.Id == item.Id2);
                                if (juese != null)
                                {
                                    newUserDB.Add(juese);
                                    userDb1.Remove(juese);
                                }
                            }
                            if (item.Id3 != null)
                            {
                                Userdb juese = userDb1.FirstOrDefault(t => t.Id == item.Id3);
                                if (juese != null)
                                {
                                    newUserDB.Add(juese);
                                    userDb1.Remove(juese);
                                }
                            }

                            if (account.Id1 != null)
                            {
                                Userdb juese = userDb2.FirstOrDefault(t => t.Id == account.Id1);
                                if (juese != null)
                                {
                                    newUserDB.Add(juese);
                                    userDb2.Remove(juese);
                                }
                            }
                            if (account.Id2 != null)
                            {
                                Userdb juese = userDb2.FirstOrDefault(t => t.Id == account.Id2);
                                if (juese != null)
                                {
                                    newUserDB.Add(juese);
                                    userDb2.Remove(juese);
                                }
                            }
                            if (account.Id3 != null)
                            {
                                Userdb juese = userDb2.FirstOrDefault(t => t.Id == account.Id3);
                                if (juese != null)
                                {
                                    newUserDB.Add(juese);
                                    userDb2.Remove(juese);
                                }
                            }
                        }
                        //==0的情况 两个账户都没有角色也需要添加 这种情况就没有角色表合并
                        newAccount.Add(item);
                    }
                    account2.Remove(account);//把相同的去掉 最后融合
                }
                else
                {
                    newAccount.Add(item);
                }

                progress++;
                int press = (int)((progress * 1.0 / totalCount) * 100) + 10;
                Progress(press);
            }
            newAccount.AddRange(account2);
            newUserDB.AddRange(userDb1);
            newUserDB.AddRange(userDb2);

            //数据合并完后插入到融合的数据库
            fsq_SqlC.Insert(newAccount).ExecuteSqlBulkCopyAsync();
            fsq_SqlC.Insert(newUserDB).ExecuteSqlBulkCopyAsync();

            progress++;
            int p = (int)((progress * 1.0 / totalCount) * 100) + 10;
            Progress(p);
        }

        private void HeBingSqlServer2()
        {
            var account1 = fsq_SqlA.Select<DboAccount>().ToList();
            var account2 = fsq_SqlB.Select<DboAccount>().ToList();
            var userDb1 = fsq_SqlA.Select<Userdb>().ToList();
            var userDb2 = fsq_SqlB.Select<Userdb>().ToList();

            int count = account1.Count;
            int press = 0;
            List<DboAccount> newAccount = new List<DboAccount>();
            List<Userdb> newUserDB = new List<Userdb>();
            foreach (var item in account1)
            {
                var sameAccount = account2.FirstOrDefault(t => t.Account == item.Account);
                if (sameAccount != null)
                {
                    account2.Remove(sameAccount);
                    if (sameAccount.Id1 != null)
                    {
                        Userdb juese = userDb2.FirstOrDefault(t => t.Id == sameAccount.Id1);
                        if (juese != null)
                        {
                            juese.Account= sameAccount.Account + "_a";
                            newUserDB.Add(juese);
                            userDb2.Remove(juese);
                        }
                    }

                    if (sameAccount.Id2 != null)
                    {
                        Userdb juese = userDb2.FirstOrDefault(t => t.Id == sameAccount.Id2);
                        if (juese != null)
                        {
                            juese.Account = sameAccount.Account + "_a";
                            newUserDB.Add(juese);
                            userDb2.Remove(juese);
                        }
                    }

                    if (sameAccount.Id3 != null)
                    {
                        Userdb juese = userDb2.FirstOrDefault(t => t.Id == sameAccount.Id3);
                        if (juese != null)
                        {
                            juese.Account = sameAccount.Account + "_a";
                            newUserDB.Add(juese);
                            userDb2.Remove(juese);
                        }
                    }

                    sameAccount.Account = sameAccount.Account + "_a";
                    newAccount.Add(sameAccount);
                }
                press++;
                Progress((int)(press * 1.0 / count * 50 + 60));
            }
            newAccount.AddRange(account1);
            newAccount.AddRange(account2);
            fsq_SqlC.Insert(newAccount).ExecuteSqlBulkCopy();

            newUserDB.AddRange(userDb1);
            newUserDB.AddRange(userDb2);
            fsq_SqlC.Insert(newUserDB).ExecuteSqlBulkCopy();
        }
        private int GetJueseCount(DboAccount account)
        {
            int juesecount = 0;
            if (account.Id1 != null)
                juesecount++;
            if (account.Id2 != null)
                juesecount++;
            if (account.Id3 != null)
                juesecount++;
            return juesecount;
        }

        private void HebingOtherSqlserver()
        {
            var auction = fsq_SqlA.Select<Auction>().ToList();
            var auction1 = fsq_SqlB.Select<Auction>().ToList();
            var fact = fsq_SqlA.Select<Faction>().ToList();
            var fact1 = fsq_SqlB.Select<Faction>().ToList();
            var factionmember = fsq_SqlA.Select<Factionmember>().ToList();
            var factionmember1 = fsq_SqlB.Select<Factionmember>().ToList();
            var game = fsq_SqlA.Select<TGame>().ToList();
            var game1 = fsq_SqlB.Select<TGame>().ToList();
            var goods = fsq_SqlA.Select<Goods>().ToList();
            var goods1 = fsq_SqlB.Select<Goods>().ToList();
            var home = fsq_SqlA.Select<Home>().ToList();
            var home1 = fsq_SqlB.Select<Home>().ToList();

            foreach (var item in auction)
            {
                var list = auction1.Where(t => t.Id == item.Id).ToList();
                foreach (var l in list)
                {
                    auction1.Remove(l);
                }
            }
            fsq_SqlC.Insert(auction).ExecuteSqlBulkCopy();
            fsq_SqlC.Insert(auction1).ExecuteSqlBulkCopy();

            Progress(52);

            foreach (var item in fact)
            {
                var list = fact1.Where(t => t.Factionid == item.Factionid).ToList();
                foreach (var l in list)
                {
                    fact1.Remove(l);
                }
            }

            fsq_SqlC.Insert(fact).ExecuteSqlBulkCopy();
            fsq_SqlC.Insert(fact1).ExecuteSqlBulkCopy();
            fsq_SqlC.Insert(factionmember).ExecuteSqlBulkCopy();
            fsq_SqlC.Insert(factionmember1).ExecuteSqlBulkCopy();

            Progress(54);

            foreach (var item in game)
            {
                var list = game1.Where(t => t.Gameid == item.Gameid).ToList();
                foreach (var l in list)
                {
                    game1.Remove(l);
                }
            }
            fsq_SqlC.Insert(game).ExecuteSqlBulkCopy();
            fsq_SqlC.Insert(game1).ExecuteSqlBulkCopy();

            Progress(56);

            foreach (var item in goods)
            {
                var list = goods1.Where(t => t.Id == item.Id).ToList();
                foreach (var l in list)
                {
                    goods1.Remove(l);
                }
            }

            fsq_SqlC.Insert(goods).ExecuteSqlBulkCopy();
            fsq_SqlC.Insert(goods1).ExecuteSqlBulkCopy();
            Progress(58);

            foreach (var item in home)
            {
                var list = home1.Where(t => t.Homeid == item.Homeid).ToList();
                foreach (var l in list)
                {
                    home1.Remove(l);
                }
            }
            fsq_SqlC.Insert(home).ExecuteSqlBulkCopy();
            fsq_SqlC.Insert(home1).ExecuteSqlBulkCopy();
            Progress(60);
        }

        private void HeBingMysql()
        {
            var cardp = fsq_MySqlA.Select<t_cardprize>().ToList();
            var consume = fsq_MySqlA.Select<t_consume>().ToList();
            var fcm = fsq_MySqlA.Select<t_fcm>().ToList();
            var cardp1 = fsq_MySqlB.Select<t_cardprize>().ToList();
            var consume1 = fsq_MySqlB.Select<t_consume>().ToList();
            var fcm1 = fsq_MySqlB.Select<t_fcm>().ToList();

            fsq_MySqlC.Insert(cardp).ExecuteAffrows();
            fsq_MySqlC.Insert(cardp1).ExecuteAffrows();
            fsq_MySqlC.Insert(consume).ExecuteAffrows();
            fsq_MySqlC.Insert(consume1).ExecuteAffrows();
            fsq_MySqlC.Insert(fcm).ExecuteAffrows();
            fsq_MySqlC.Insert(fcm1).ExecuteAffrows();

            var xntg = fsq_MySqlB.Select<t_xntg>().ToList();
            var xntg1 = fsq_MySqlB.Select<t_xntg>().ToList();
            List<t_xntg> newxntg = new List<t_xntg>();

            int count = xntg.Count;
            int press = 0;
            foreach (var item in xntg)
            {
                var samexntg = xntg1.FirstOrDefault(t => t.passport_id.Trim() == item.passport_id.Trim());
                if (samexntg != null)
                {
                    xntg1.Remove(samexntg);

                    samexntg.passport_id = samexntg.passport_id.Trim() + "_a";
                    newxntg.Add(samexntg);
                }
                press++;
                Progress((int)(press * 1.0 / count * 50));
            }
            newxntg.AddRange(xntg);
            newxntg.AddRange(xntg1);
            fsq_MySqlC.Insert(newxntg).ExecuteAffrows();
        }

        private void Log(string msg)
        {
            if (this.msg_lab.InvokeRequired)
            {
                this.Invoke(new Action<string>(Log), msg);
            }
            else
            {
                this.msg_lab.Text = msg;
            }
        }

        private void Progress(int progress)
        {
            if (this.progressBar.InvokeRequired)
            {
                this.Invoke(new Action<int>(Progress), progress);
            }
            else
            {
                this.progressBar.Value = progress;
            }
        }
    }
}
