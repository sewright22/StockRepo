﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StockDbWriter
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="StockDB")]
	public partial class StockDbDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertStock(Stock instance);
    partial void UpdateStock(Stock instance);
    partial void DeleteStock(Stock instance);
    partial void InsertStockSimulationRun(StockSimulationRun instance);
    partial void UpdateStockSimulationRun(StockSimulationRun instance);
    partial void DeleteStockSimulationRun(StockSimulationRun instance);
    partial void InsertCompletedTransaction(CompletedTransaction instance);
    partial void UpdateCompletedTransaction(CompletedTransaction instance);
    partial void DeleteCompletedTransaction(CompletedTransaction instance);
    partial void InsertStockPrice(StockPrice instance);
    partial void UpdateStockPrice(StockPrice instance);
    partial void DeleteStockPrice(StockPrice instance);
    #endregion
		
		public StockDbDataContext() : 
				base(global::StockDbWriter.Properties.Settings.Default.StockDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public StockDbDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StockDbDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StockDbDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StockDbDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ErrorLog> ErrorLogs
		{
			get
			{
				return this.GetTable<ErrorLog>();
			}
		}
		
		public System.Data.Linq.Table<Market> Markets
		{
			get
			{
				return this.GetTable<Market>();
			}
		}
		
		public System.Data.Linq.Table<Transaction> Transactions
		{
			get
			{
				return this.GetTable<Transaction>();
			}
		}
		
		public System.Data.Linq.Table<Stock> Stocks
		{
			get
			{
				return this.GetTable<Stock>();
			}
		}
		
		public System.Data.Linq.Table<StockSimulationRun> StockSimulationRuns
		{
			get
			{
				return this.GetTable<StockSimulationRun>();
			}
		}
		
		public System.Data.Linq.Table<CompletedTransaction> CompletedTransactions
		{
			get
			{
				return this.GetTable<CompletedTransaction>();
			}
		}
		
		public System.Data.Linq.Table<StockPrice> StockPrices
		{
			get
			{
				return this.GetTable<StockPrice>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.AddStockTransaction")]
		public int AddStockTransaction([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> stockID, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string action, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(18,0)")] System.Nullable<decimal> price, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")] System.Nullable<System.DateTime> date)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), stockID, action, price, date);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.BuyStock")]
		public int BuyStock([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> stockID, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(18,0)")] System.Nullable<decimal> price, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")] System.Nullable<System.DateTime> date)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), stockID, price, date);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SellStock")]
		public int SellStock([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> stockID, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(18,0)")] System.Nullable<decimal> price, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")] System.Nullable<System.DateTime> date)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), stockID, price, date);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.InsertStockPrice")]
		public int InsertStockPrice([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(100)")] string stockSymbol, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(12,2)")] System.Nullable<decimal> openPrice, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(12,2)")] System.Nullable<decimal> lowPrice, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(12,2)")] System.Nullable<decimal> highPrice, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(12,2)")] System.Nullable<decimal> closePrice, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> volume, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")] System.Nullable<System.DateTime> date)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), stockSymbol, openPrice, lowPrice, highPrice, closePrice, volume, date);
			return ((int)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ErrorLog")]
	public partial class ErrorLog
	{
		
		private int _ID;
		
		private string _Type;
		
		private string _Message;
		
		private System.DateTime _Time;
		
		public ErrorLog()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this._ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type", DbType="VarChar(MAX)")]
		public string Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this._Type = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Message", DbType="VarChar(MAX)")]
		public string Message
		{
			get
			{
				return this._Message;
			}
			set
			{
				if ((this._Message != value))
				{
					this._Message = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Time", DbType="DateTime NOT NULL")]
		public System.DateTime Time
		{
			get
			{
				return this._Time;
			}
			set
			{
				if ((this._Time != value))
				{
					this._Time = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Markets")]
	public partial class Market
	{
		
		private int _ID;
		
		private string _Name;
		
		public Market()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this._ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Transactions")]
	public partial class Transaction
	{
		
		private int _ID;
		
		private int _StockID;
		
		private string _Action;
		
		private System.DateTime _TransactionDate;
		
		private decimal _Price;
		
		public Transaction()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this._ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockID", DbType="Int NOT NULL")]
		public int StockID
		{
			get
			{
				return this._StockID;
			}
			set
			{
				if ((this._StockID != value))
				{
					this._StockID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Action", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Action
		{
			get
			{
				return this._Action;
			}
			set
			{
				if ((this._Action != value))
				{
					this._Action = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransactionDate", DbType="DateTime NOT NULL")]
		public System.DateTime TransactionDate
		{
			get
			{
				return this._TransactionDate;
			}
			set
			{
				if ((this._TransactionDate != value))
				{
					this._TransactionDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Decimal(18,0) NOT NULL")]
		public decimal Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this._Price = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Stocks")]
	public partial class Stock : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _MarketID;
		
		private string _Symbol;
		
		private string _Name;
		
		private string _Category;
		
		private string _TestIssue;
		
		private System.Nullable<int> _RoundLotSize;
		
		private string _ETF;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnMarketIDChanging(int value);
    partial void OnMarketIDChanged();
    partial void OnSymbolChanging(string value);
    partial void OnSymbolChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnCategoryChanging(string value);
    partial void OnCategoryChanged();
    partial void OnTestIssueChanging(string value);
    partial void OnTestIssueChanged();
    partial void OnRoundLotSizeChanging(System.Nullable<int> value);
    partial void OnRoundLotSizeChanged();
    partial void OnETFChanging(string value);
    partial void OnETFChanged();
    #endregion
		
		public Stock()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MarketID", DbType="Int NOT NULL")]
		public int MarketID
		{
			get
			{
				return this._MarketID;
			}
			set
			{
				if ((this._MarketID != value))
				{
					this.OnMarketIDChanging(value);
					this.SendPropertyChanging();
					this._MarketID = value;
					this.SendPropertyChanged("MarketID");
					this.OnMarketIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Symbol", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string Symbol
		{
			get
			{
				return this._Symbol;
			}
			set
			{
				if ((this._Symbol != value))
				{
					this.OnSymbolChanging(value);
					this.SendPropertyChanging();
					this._Symbol = value;
					this.SendPropertyChanged("Symbol");
					this.OnSymbolChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(MAX)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Category", DbType="VarChar(1)")]
		public string Category
		{
			get
			{
				return this._Category;
			}
			set
			{
				if ((this._Category != value))
				{
					this.OnCategoryChanging(value);
					this.SendPropertyChanging();
					this._Category = value;
					this.SendPropertyChanged("Category");
					this.OnCategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TestIssue", DbType="VarChar(1)")]
		public string TestIssue
		{
			get
			{
				return this._TestIssue;
			}
			set
			{
				if ((this._TestIssue != value))
				{
					this.OnTestIssueChanging(value);
					this.SendPropertyChanging();
					this._TestIssue = value;
					this.SendPropertyChanged("TestIssue");
					this.OnTestIssueChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoundLotSize", DbType="Int")]
		public System.Nullable<int> RoundLotSize
		{
			get
			{
				return this._RoundLotSize;
			}
			set
			{
				if ((this._RoundLotSize != value))
				{
					this.OnRoundLotSizeChanging(value);
					this.SendPropertyChanging();
					this._RoundLotSize = value;
					this.SendPropertyChanged("RoundLotSize");
					this.OnRoundLotSizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ETF", DbType="VarChar(1)")]
		public string ETF
		{
			get
			{
				return this._ETF;
			}
			set
			{
				if ((this._ETF != value))
				{
					this.OnETFChanging(value);
					this.SendPropertyChanging();
					this._ETF = value;
					this.SendPropertyChanged("ETF");
					this.OnETFChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.StockSimulationRun")]
	public partial class StockSimulationRun : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private System.DateTime _RunTime;
		
		private string _RunInfo;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnRunTimeChanging(System.DateTime value);
    partial void OnRunTimeChanged();
    partial void OnRunInfoChanging(string value);
    partial void OnRunInfoChanged();
    #endregion
		
		public StockSimulationRun()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RunTime", DbType="DateTime NOT NULL")]
		public System.DateTime RunTime
		{
			get
			{
				return this._RunTime;
			}
			set
			{
				if ((this._RunTime != value))
				{
					this.OnRunTimeChanging(value);
					this.SendPropertyChanging();
					this._RunTime = value;
					this.SendPropertyChanged("RunTime");
					this.OnRunTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RunInfo", DbType="VarChar(MAX)")]
		public string RunInfo
		{
			get
			{
				return this._RunInfo;
			}
			set
			{
				if ((this._RunInfo != value))
				{
					this.OnRunInfoChanging(value);
					this.SendPropertyChanging();
					this._RunInfo = value;
					this.SendPropertyChanged("RunInfo");
					this.OnRunInfoChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CompletedTransactions")]
	public partial class CompletedTransaction : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _RunID;
		
		private int _BuyStockPriceID;
		
		private int _SellStockPriceID;
		
		private int _HighStockPriceSinceBuyID;
		
		private int _LowStockPriceSinceBuyID;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnRunIDChanging(int value);
    partial void OnRunIDChanged();
    partial void OnBuyStockPriceIDChanging(int value);
    partial void OnBuyStockPriceIDChanged();
    partial void OnSellStockPriceIDChanging(int value);
    partial void OnSellStockPriceIDChanged();
    partial void OnHighStockPriceSinceBuyIDChanging(int value);
    partial void OnHighStockPriceSinceBuyIDChanged();
    partial void OnLowStockPriceSinceBuyIDChanging(int value);
    partial void OnLowStockPriceSinceBuyIDChanged();
    #endregion
		
		public CompletedTransaction()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RunID", DbType="Int NOT NULL")]
		public int RunID
		{
			get
			{
				return this._RunID;
			}
			set
			{
				if ((this._RunID != value))
				{
					this.OnRunIDChanging(value);
					this.SendPropertyChanging();
					this._RunID = value;
					this.SendPropertyChanged("RunID");
					this.OnRunIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BuyStockPriceID", DbType="Int NOT NULL")]
		public int BuyStockPriceID
		{
			get
			{
				return this._BuyStockPriceID;
			}
			set
			{
				if ((this._BuyStockPriceID != value))
				{
					this.OnBuyStockPriceIDChanging(value);
					this.SendPropertyChanging();
					this._BuyStockPriceID = value;
					this.SendPropertyChanged("BuyStockPriceID");
					this.OnBuyStockPriceIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SellStockPriceID", DbType="Int NOT NULL")]
		public int SellStockPriceID
		{
			get
			{
				return this._SellStockPriceID;
			}
			set
			{
				if ((this._SellStockPriceID != value))
				{
					this.OnSellStockPriceIDChanging(value);
					this.SendPropertyChanging();
					this._SellStockPriceID = value;
					this.SendPropertyChanged("SellStockPriceID");
					this.OnSellStockPriceIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HighStockPriceSinceBuyID", DbType="Int NOT NULL")]
		public int HighStockPriceSinceBuyID
		{
			get
			{
				return this._HighStockPriceSinceBuyID;
			}
			set
			{
				if ((this._HighStockPriceSinceBuyID != value))
				{
					this.OnHighStockPriceSinceBuyIDChanging(value);
					this.SendPropertyChanging();
					this._HighStockPriceSinceBuyID = value;
					this.SendPropertyChanged("HighStockPriceSinceBuyID");
					this.OnHighStockPriceSinceBuyIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LowStockPriceSinceBuyID", DbType="Int NOT NULL")]
		public int LowStockPriceSinceBuyID
		{
			get
			{
				return this._LowStockPriceSinceBuyID;
			}
			set
			{
				if ((this._LowStockPriceSinceBuyID != value))
				{
					this.OnLowStockPriceSinceBuyIDChanging(value);
					this.SendPropertyChanging();
					this._LowStockPriceSinceBuyID = value;
					this.SendPropertyChanged("LowStockPriceSinceBuyID");
					this.OnLowStockPriceSinceBuyIDChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.StockPrices")]
	public partial class StockPrice : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _StockID;
		
		private decimal _OpenPrice;
		
		private decimal _Low;
		
		private decimal _High;
		
		private decimal _ClosePrice;
		
		private int _Volume;
		
		private System.DateTime _Date;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnStockIDChanging(int value);
    partial void OnStockIDChanged();
    partial void OnOpenPriceChanging(decimal value);
    partial void OnOpenPriceChanged();
    partial void OnLowChanging(decimal value);
    partial void OnLowChanged();
    partial void OnHighChanging(decimal value);
    partial void OnHighChanged();
    partial void OnClosePriceChanging(decimal value);
    partial void OnClosePriceChanged();
    partial void OnVolumeChanging(int value);
    partial void OnVolumeChanged();
    partial void OnDateChanging(System.DateTime value);
    partial void OnDateChanged();
    #endregion
		
		public StockPrice()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockID", DbType="Int NOT NULL")]
		public int StockID
		{
			get
			{
				return this._StockID;
			}
			set
			{
				if ((this._StockID != value))
				{
					this.OnStockIDChanging(value);
					this.SendPropertyChanging();
					this._StockID = value;
					this.SendPropertyChanged("StockID");
					this.OnStockIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OpenPrice", DbType="Decimal(18,2) NOT NULL")]
		public decimal OpenPrice
		{
			get
			{
				return this._OpenPrice;
			}
			set
			{
				if ((this._OpenPrice != value))
				{
					this.OnOpenPriceChanging(value);
					this.SendPropertyChanging();
					this._OpenPrice = value;
					this.SendPropertyChanged("OpenPrice");
					this.OnOpenPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Low", DbType="Decimal(18,2) NOT NULL")]
		public decimal Low
		{
			get
			{
				return this._Low;
			}
			set
			{
				if ((this._Low != value))
				{
					this.OnLowChanging(value);
					this.SendPropertyChanging();
					this._Low = value;
					this.SendPropertyChanged("Low");
					this.OnLowChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_High", DbType="Decimal(18,2) NOT NULL")]
		public decimal High
		{
			get
			{
				return this._High;
			}
			set
			{
				if ((this._High != value))
				{
					this.OnHighChanging(value);
					this.SendPropertyChanging();
					this._High = value;
					this.SendPropertyChanged("High");
					this.OnHighChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ClosePrice", DbType="Decimal(18,2) NOT NULL")]
		public decimal ClosePrice
		{
			get
			{
				return this._ClosePrice;
			}
			set
			{
				if ((this._ClosePrice != value))
				{
					this.OnClosePriceChanging(value);
					this.SendPropertyChanging();
					this._ClosePrice = value;
					this.SendPropertyChanged("ClosePrice");
					this.OnClosePriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Volume", DbType="Int NOT NULL")]
		public int Volume
		{
			get
			{
				return this._Volume;
			}
			set
			{
				if ((this._Volume != value))
				{
					this.OnVolumeChanging(value);
					this.SendPropertyChanging();
					this._Volume = value;
					this.SendPropertyChanged("Volume");
					this.OnVolumeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="DateTime NOT NULL")]
		public System.DateTime Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
