using Amazon.SQS.Model;
using SQSExample;

Console.WriteLine("Amazon Simple Queue Service");

SQSOperation operation = new SQSOperation();

/*
 * ==============================================
 * Create a new queue
 * ==============================================
 */
//string url = await operation.CreateQueueAsync("rajinDemoQueue");
//Console.WriteLine(url);
var queueurl = "";


/*
 * ===============================================
 * Delete a queue
 * ===============================================
 */
//string response = await operation.DeleteQueueAsync(queueurl);
//Console.WriteLine(response);


/*
 * ===============================================
 * Add a message to queue
 * ===============================================
 */
//QueueMessage queueMessage = new QueueMessage()
//{
//    url = queueurl,
//    body = "This is a sample mesaage Two"
//};
//var response = await operation.AddNewMessage(queueMessage);
//Console.WriteLine(response);


/*
 * ===============================================
 * Send Batch Messages
 * ===============================================
 */
//var entries = new List<SendMessageBatchRequestEntry>();
//entries.Add(new SendMessageBatchRequestEntry("message3", "This is a sample mesaage Three"));
//entries.Add(new SendMessageBatchRequestEntry("message4", "This is a sample mesaage Four"));
//entries.Add(new SendMessageBatchRequestEntry("message5", "This is a sample mesaage Five"));
//entries.Add(new SendMessageBatchRequestEntry("message6", "This is a sample mesaage Six"));
//entries.Add(new SendMessageBatchRequestEntry("message7", "This is a sample mesaage Seven"));
//entries.Add(new SendMessageBatchRequestEntry("message8", "This is a sample mesaage Eignt"));
//entries.Add(new SendMessageBatchRequestEntry("message9", "This is a sample mesaage nine"));
//entries.Add(new SendMessageBatchRequestEntry("message10", "This is a sample mesaage Ten"));
//entries.Add(new SendMessageBatchRequestEntry("message11", "This is a sample mesaage Eleven"));
//entries.Add(new SendMessageBatchRequestEntry("message12", "This is a sample mesaage Twelve"));
//entries.Add(new SendMessageBatchRequestEntry("message13", "This is a sample mesaage Thirteen"));
//entries.Add(new SendMessageBatchRequestEntry("message14", "This is a sample mesaage Fourteen"));
//entries.Add(new SendMessageBatchRequestEntry("message15", "This is a sample mesaage Fifteen"));

//var response = await operation.AddBatchMessages(entries, queueurl);

//Console.WriteLine(response);


/*
 * ===================================================
 * Receive Messages
 * ===================================================
 */
//var response = await operation.ReceiveMessages(queueurl);
//var count = 1;

//foreach (var message in response)
//{
//    Console.WriteLine($"{count}. {message.MessageId}: {message.ReceiptHandle}");
//    count++;
//    Console.WriteLine();
//}


/*
 * ===================================================
 * Delete Messages 
 * ===================================================
 */
//string handle = "AQEB/g0CRoF29IyXqe1q+1fPsyOjJawgqnuPWrjS2kLDHREWQA6Uj0+Jb2ivz8LCMgXixta4seuLYgNh2Z36W6ryJNiq8ni/7iVWuya8APz0Lz3oAT6L3l1CML2k3J7XGpV2oH6MN2sQF3yM7rOQITI8E5ShBIL9ySbty0BYpz83irtJXA4NezcJ1AhN5/aDc2xaye8iiwCzJbA/Z3lpxJ19YtD3ADds7BOSB5Xha3nPAdAmlQUqQNmANGUa6GSuWQN3wVy5foS3wrG7RBzoGvnUPR2+2UP52hA18I359hNo6oaVKJxNgFtCRE13F3odYglz4GgPtHOEm1f5seq2vYT6bc1hgyJcmt8zCPIr5duPdjc4ZUBct82Z5lnjVijP8kPKNr2X1LkgHU1Xo+5zPYJO6Q==";

//var response = await operation.DeleteMessages(queueurl, handle);
//Console.WriteLine(response);

