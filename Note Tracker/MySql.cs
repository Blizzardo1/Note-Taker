// <copyright file="MySql.cs" company="Blizzeta Software and Gaming">
// Copyright (c) 2013 All Rights Reserved
// <author>Adonis S. Deliannis (Blizzardo1)</author>
// </copyright>
      
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

using BreakerDev.Imports32;
using MySql.Data.MySqlClient;

namespace BreakerDev.DataBase
{
    /// <summary>
    /// COPIED CODE FROM AN OLD MINECRAFT DB PROJECT!
    /// </summary>
    public class BDevDataBase
    {
        string ConnectionString = string.Empty;
        public static Rijndael _Rijndael = Rijndael.Create();

        public static string SERVER
        {
            get;
            set;
        }

        public static string UID
        {
            get;
            set;
        }

        public static string PASSWORD
        {
            get;
            set;
        }

        public static string DATABASE
        {
            get;
            set;
        }

        public static byte[] Key
        {
            get
            {
                return _Rijndael.Key;
            }
        }

        public static byte[] IV
        {
            get
            {
                return _Rijndael.IV;
            }
        }

        MySqlConnection connection;

        public BDevDataBase()
        {
            UID = MySqlHelper.EscapeString(UID);
            PASSWORD = MySqlHelper.EscapeString(PASSWORD);
            ConnectionString = string.Format("SERVER={0};DATABASE={3};UID={1};PASSWORD={2};", SERVER, UID, PASSWORD, DATABASE);
            LoadDataBase();
        }

        public bool Integrity()
        {
            this.LogoutOfDB();
            if (this.LoginToDB())
            {
                this.LogoutOfDB();
                return true;
            }
            return false;
        }

        private bool LoginToDB()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException MSE)
            {
                switch (MSE.Number)
                {
                    case 0: Imports.User32.DisplayMessage(IntPtr.Zero, "Cannot connect to Server.\r\nPlease Contact your Administrator.", "Error Establishing Connection", Imports.User32.MessageBoxOptions.Ok | Imports.User32.MessageBoxOptions.IconError); break;
                    case 1045: Imports.User32.DisplayMessage(IntPtr.Zero, "Invalid Username/Password, Please try again.", "Error Establishing Connection", Imports.User32.MessageBoxOptions.Ok | Imports.User32.MessageBoxOptions.IconError); break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return true;
            }
            return false;
        }

        private bool LogoutOfDB()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException MSE)
            {
                Imports.User32.DisplayMessage(IntPtr.Zero, MSE.Message, "Error", Imports.User32.MessageBoxOptions.Ok | Imports.User32.MessageBoxOptions.IconError);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return true;
            }
            return false;
        }

        public void LoadDataBase()
        {
            connection = new MySqlConnection(ConnectionString);
        }

        public void Insert()
        {
            /*
            FirstName
            LastName
            Address
            Email
            PrimaryPhone
            AlternatePhone
            Issues
            ComputerResponse
            NetworkResponse
            SpeedResponse
            ProtectionResponse
            BackupReponse
            DiscussReponse
            
            Brand
            Model
            Serial
            OperatingSystem
            Processor
            RAM
            MaxRAM
             */
             
            string query = string.Format("INSERT INTO {0}.OpenTickets (FirstName, LastName, Address, Email, PrimaryPhone, AlternatePhone, Issues) VALUES (@FirstName,@LastName,@Address,@Email, @PrimaryPhone, @AlternatePhone,@Issue);", DATABASE);
            if (this.LoginToDB())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.LogoutOfDB();
            }
        }

        public bool UpdateUser(string FirstName, string LastName, string Address, string Email, string PrimaryPhone, string AlternatePhone, string Issues)
        {
            string query = string.Format("UPDATE `{0}`.`OpenTickets` FirstName = `{1}`, LastName = `{2}`, Address = `{2}`, Email, PrimaryPhone, AlternatePhone, Issues` WHERE `members`.`MemberName`='{0}' LIMIT 1;", DATABASE, FirstName, LastName, Address, Email, PrimaryPhone, AlternatePhone, Issues);
            try
            {
                if (this.LoginToDB())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    this.LogoutOfDB();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Imports.User32.DisplayMessage(IntPtr.Zero, ex.Message, "Error", Imports.User32.MessageBoxOptions.Ok);
                return false;
            }
            return false;
        }

        public void AddUser(string MemberName, string MemberID, string DateJoined, string MemberStatus, string HomeAddress, string UserPassword)
        {
            string query = string.Format("INSERT INTO {6}.members (MemberName, MemberID, DateJoined, MemberStatus, HomeAddress, UserPassword) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", MemberName, MemberID.Split(':')[1], DateJoined, MemberStatus, HomeAddress, UserPassword, DATABASE);
            if (this.LoginToDB())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                this.LogoutOfDB();
            }
        }

        public void Delete(string MemberName)
        {
            string query = string.Format("DELETE FROM {1}.members WHERE MemberName='{0}'", MemberName, DATABASE);
            if (this.LoginToDB())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.LogoutOfDB();
            }
        }

        public List<string> SelectUserByName(string MemberName)
        {
            string query = string.Format("SELECT * FROM `{1}`.`members` WHERE `MemberName`='{0}'", MemberName, DATABASE);
            List<string> lst = new List<string>();
            if (this.LoginToDB())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lst.Add(reader["MemberName"].ToString());
                    lst.Add(reader["MemberID"].ToString());
                    lst.Add(reader["DateJoined"].ToString());
                    lst.Add(reader["MemberStatus"].ToString());
                    lst.Add(reader["HomeAddress"].ToString());
                    lst.Add(reader["UserPassword"].ToString());
                }

                reader.Close();
                this.LogoutOfDB();

                return lst;
            }
            else
                return lst;
        }

        public List<string> SelectUserByID(string MemberID)
        {
            string query = string.Format("SELECT * FROM {1}.members WHERE `MemberID`='{0}'", MemberID, DATABASE);
            List<string> lst = new List<string>();
            if (this.LoginToDB())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lst.Add(reader["MemberName"].ToString());
                    lst.Add(reader["MemberID"].ToString());
                    lst.Add(reader["DateJoined"].ToString());
                    lst.Add(reader["MemberStatus"].ToString());
                    lst.Add(reader["HomeAddress"].ToString());
                    lst.Add(reader["UserPassword"].ToString());
                }

                reader.Close();
                this.LogoutOfDB();

                return lst;
            }
            else
                return lst;
        }

        private int CountAdmin()
        {
            string query = string.Format("SELECT Count(*) FROM {0}.admincmd", DATABASE);
            int count = -1;

            if (this.LoginToDB())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                count = int.Parse(cmd.ExecuteScalar().ToString());
                this.LogoutOfDB();

                return count;
            }
            else
                return count;
        }

        public bool AddAdmin(string UserName, string Password, string Permission, bool IsOnline, string ActiveUser)
        {
            string query = string.Format("INSERT INTO {5}.admincmd (UserName, Password, Permission, IsOnline, ActiveUser) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", UserName, Password, Permission, IsOnline, ActiveUser, DATABASE);

            try
            {
                if (this.LoginToDB())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    this.LogoutOfDB();
                }
                return true;
            }
            catch (Exception ex)
            {
                Imports.User32.DisplayMessage(IntPtr.Zero, ex.Message, "Error", Imports.User32.MessageBoxOptions.IconStop | Imports.User32.MessageBoxOptions.Ok);
                return false;
            }
        }

        public bool UpdateAdmin(string UserName, string Password, string Permission, bool IsOnline, string ActiveUser)
        {
            UserName = MySqlHelper.EscapeString(UserName);
            Password = MySqlHelper.EscapeString(Password);
            string query = string.Format("UPDATE `{5}`.`admincmd` SET `Password`='{1}',`Permission`='{2}', `IsOnline`='{3}', `ActiveUser`='{4}' WHERE `admincmd`.`UserName`='{0}' LIMIT 1;", UserName, Password, Permission, IsOnline.ToString().ToUpper(), ActiveUser, DATABASE);

            try
            {
                if (this.LoginToDB())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    this.LogoutOfDB();
                }
                return true;
            }
            catch (Exception ex)
            {
                Imports.User32.DisplayMessage(IntPtr.Zero, ex.Message, "Error", Imports.User32.MessageBoxOptions.IconStop | Imports.User32.MessageBoxOptions.Ok);
                return false;
            }
        }

        public bool RemoveAdmin(string Username)
        {
            string query = string.Format("DELETE FROM {1}.admincmd WHERE UserName='{0}'", Username, DATABASE);
            if (this.LoginToDB())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.LogoutOfDB();
                return true;
            }
            return false;
        }

        public bool Override(string Username, string Password)
        {
            Crypto.SymCryptography CryptoSec = new Crypto.SymCryptography(Crypto.SymCryptography.ServiceProviderEnum.Rijndael);

            string query = string.Format("SELECT `UserName`, `Password` FROM `{1}`.`admincmd` WHERE UserName='{0}'", Username, DATABASE);
            if (this.LoginToDB())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    List<string>[] lst = new List<string>[2];

                    for (int i = 0; i < lst.Length; i++)
                        lst[i] = new List<string>();

                    string un = string.Empty, pw = string.Empty;

                    while (reader.Read())
                    {
                        lst[0].Add(string.Format("{0}", reader["UserName"].ToString()));
                        lst[1].Add(string.Format("{0}", reader["Password"].ToString()));
                    }

                    for (int i = 0; i < lst[0].Count; i++)
                    {
                        if (Username == lst[0].ToArray()[i])
                        {
                            string Pass = lst[1].ToArray()[i];
                            if ((new Crypto.Hash(Crypto.Hash.ServiceProviderEnum.SHA512).Encrypt(Password)) == Pass)
                            {
                                //Imports.DisplayMessage(IntPtr.Zero, "Proceed.", "Authenticated", Imports.MessageBoxOptions.IconInformation | Imports.MessageBoxOptions.Ok);
                                this.LogoutOfDB();
                                return true;
                            }
                            else
                            {
                                //Imports.DisplayMessage(IntPtr.Zero, "Invalid Password.", "Error", Imports.MessageBoxOptions.IconError | Imports.MessageBoxOptions.Ok);
                                this.LogoutOfDB();
                                return false;
                            }
                        }
                    }
                    //Imports.DisplayMessage(IntPtr.Zero, "Invalid Username.", "Error", Imports.MessageBoxOptions.IconError | Imports.MessageBoxOptions.Ok);
                }
                catch (Exception ex)
                {
                    Imports.User32.DisplayMessage(IntPtr.Zero, ex.Message, "Error", Imports.User32.MessageBoxOptions.IconError | Imports.User32.MessageBoxOptions.Ok);
                    this.LogoutOfDB();
                    return true;
                }
            }
            return false;
        }

        public List<string> SelectAdminByName(string UserName)
        {
            string query = string.Format("SELECT `UserName`, `Password`, `Permission`, `IsOnline`, `ActiveUser` FROM `{1}`.`admincmd` WHERE UserName='{0}'", UserName, DATABASE);
            List<string> lst = new List<string>();

            if (this.LoginToDB())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lst.Add(reader["UserName"].ToString());
                    lst.Add(reader["Password"].ToString());
                    lst.Add(reader["Permission"].ToString());
                    lst.Add(reader["IsOnline"].ToString());
                    lst.Add(reader["ActiveUser"].ToString());
                }

                reader.Close();
                this.LogoutOfDB();

                return lst;
            }
            else
                return lst;
        }

        public List<string>[] SelectAdmin()
        {
            string query = string.Format("SELECT * FROM `{0}`.`admincmd` ORDER BY `{0}`.`admincmd`.`UserName` ASC", DATABASE);
            List<string>[] lst = new List<string>[5];

            for (int i = 0; i < lst.Length; i++)
                lst[i] = new List<string>();

            if (this.LoginToDB())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lst[0].Add(reader["UserName"].ToString());
                    lst[1].Add(reader["Password"].ToString());
                    lst[2].Add(reader["Permission"].ToString());
                    lst[3].Add(reader["IsOnline"].ToString());
                    lst[4].Add(reader["ActiveUser"].ToString());
                }

                reader.Close();
                this.LogoutOfDB();

                return lst;
            }
            else
                return lst;
        }

        public List<string>[] Select()
        {
            string query = string.Format("SELECT * FROM `{0}`.`members` ORDER BY `{0}`.`members`.`MemberName` ASC", DATABASE);
            List<string>[] lst = new List<string>[6];

            for (int i = 0; i < lst.Length; i++)
                lst[i] = new List<string>();

            if (this.LoginToDB())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lst[0].Add(reader["MemberName"].ToString());
                    lst[1].Add(reader["MemberID"].ToString());
                    lst[2].Add(reader["DateJoined"].ToString());
                    lst[3].Add(reader["MemberStatus"].ToString());
                    lst[4].Add(reader["HomeAddress"].ToString());
                    lst[5].Add(reader["UserPAssword"].ToString());
                }

                reader.Close();
                this.LogoutOfDB();

                return lst;
            }
            else
                return lst;
        }

        public int Count()
        {
            string query = string.Format("SELECT Count(*) FROM {0}.members", DATABASE);
            int count = -1;

            if (this.LoginToDB())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                count = int.Parse(cmd.ExecuteScalar().ToString());
                this.LogoutOfDB();

                return count;
            }
            else
                return count;
        }
    }
}
