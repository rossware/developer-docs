﻿Imports SaleKeyed.MWCredit

Module Module1

    Sub Main()
        'Create Soap Client
        Dim MWCredit As New CreditSoapClient

        'Create Credentials Object
        Dim Credentials As New MerchantCredentials With {
        .MerchantName = "TEST MERCHANT",
        .MerchantSiteId = "XXXXXXXX",
        .MerchantKey = "XXXXX-XXXXX-XXXXX-XXXXX-XXXXX"
        }

        'Create PaymentData Object
        Dim PaymentData As New PaymentData With {
        .Source = "KEYED",
        .CardNumber = "4012000033330026",
        .ExpirationDate = "1221",
        .CardHolder = "John Doe",
        .AvsStreetAddress = "1 Federal St",
        .AvsZipCode = "02110",
        .CardVerificationValue = "123"
        }

        'Create Request Object
        Dim SaleRequest As New SaleRequest With {
        .Amount = "1.01",
        .TaxAmount = "0.10",
        .InvoiceNumber = "INV1234",
        .CardAcceptorTerminalId = "01",
        .CustomerCode = "1234",
        .PurchaseOrderNumber = "PO1234",
        .EnablePartialAuthorization = "true",
        .ForceDuplicate = "true"
        }

        'Process Request
        Dim SaleResponse As TransactionResponse45
        SaleResponse = MWCredit.Sale(Credentials, PaymentData, SaleRequest)

        'Display Results
        Console.WriteLine(" Sale Response: {0} Token: {1} Amount: ${2} RFMIQ: {3}", SaleResponse.ApprovalStatus + vbNewLine, SaleResponse.Token + vbNewLine, SaleResponse.Amount + vbNewLine, SaleResponse.Rfmiq + vbNewLine)
        Console.WriteLine("Press Any Key to Close")
        Console.ReadKey()
    End Sub

End Module
