# TradeRepository
Technologies Used: 
   .net framework 4.6
   Asp.net Web API2
   SQLite
   Log4Net
   MSTest Unit Testing Framework

# Project Components:

  OWINSelfHostApp : Trade Saver OWIN self hosted Web API.
  TradeLoader.API : Trade(could be other entities as well)  View Loader based on filter criteria.
  TradeRepo.Data  : Data Access Layer for both the APIs
  TradeSaverAPI.Test : This is the Test projects contains UTs to simulate save and Load of trades as a front office application and 
  Back office application.
  
  # Configurations required:
  
     Log4Net log file path configuration in App.config of respective projects.
     SQLite database file path setup in SQLiteTradeServicePlugin class.
   
  
