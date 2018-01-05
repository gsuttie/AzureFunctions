# AzureFunctions
Azure Functions for demo purposes.

This will be used for a demo where yo use postman to send in 
some JSON which looks like the following:-

{ "orderId" : "179", "productId" : "179", "email" : "gsuttie2001@gmail.com", "price" : 179}

This will create a licence file and then email it to the email address within the JSON, 
representing a demo of someone requesting a licence for a piece of software, a licence file being generated
for the order and then stored in Azure storage and then put on an Azure queue and then emailed out to them.
