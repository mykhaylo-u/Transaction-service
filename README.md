# transaction-service
transaction-service

1. Transaction service supporting files:  
  1.1 *.csv  
     Example:  
            "Invoice0000001","1,000.00","USD","20/02/2019 12:33:16","Approved"  
            "Invoice0000002","300.00","USD","21/02/2019 02:04:59","Failed"  
  1.2 *.xml  
    Example:  
    ```<Transactions>
       <Transaction id="Inv00001">
       <TransactionDate>2019-01-23T13:45:10</TransactionDate>
       <PaymentDetails>
       <Amount>200.00</Amount>
       <CurrencyCode>USD</CurrencyCode>
       </PaymentDetails>
       <Status>Done</Status>
       </Transaction>
       <Transaction id="Inv00002">
       <TransactionDate>2019-01-24T16:09:15</TransactionDate>
       <PaymentDetails>
       <Amount>10000.00</Amount>
       <CurrencyCode>EUR</CurrencyCode>
       </PaymentDetails>
       <Status>Rejected</Status>
       </Transaction>
       </Transactions>```
               
2. Transaction service API  
  2.1 GET transaction filtered by currency       /api/transactions/currency?currency=USA  
  2.2 GET transaction filtered by status         /api/transactions/status?status=D  
  2.3 GET transaction filtered by date range     /api/transactions/dateRange?startDate=2019-01-23&endDate=2019-01-24  
