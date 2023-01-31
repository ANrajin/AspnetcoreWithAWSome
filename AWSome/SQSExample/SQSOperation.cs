using System.Net;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace SQSExample
{
    public class SqsOperation
    {
        private readonly AmazonSQSClient _client;
        public SqsOperation()
        {
            _client = new AmazonSQSClient();
        }

        public async Task<string> CreateQueueAsync(string queueName)
        {
            var request = new CreateQueueRequest(queueName);
            var response = await _client.CreateQueueAsync(request);

            return response.HttpStatusCode == HttpStatusCode.OK ? response.QueueUrl : response.HttpStatusCode.ToString();
        }

        public async Task<string> DeleteQueueAsync(string url)
        {
            var request = new DeleteQueueRequest
            {
                QueueUrl = url
            };

            var response = await _client.DeleteQueueAsync(request);

            return response.HttpStatusCode.ToString();
        }


        public async Task<string> AddNewMessage(QueueMessage queueMessage)
        {
            var sendMessageRequest = new SendMessageRequest(queueMessage.url, queueMessage.body);
            var response = await _client.SendMessageAsync(sendMessageRequest);

            return response.HttpStatusCode == HttpStatusCode.OK ? 
                response.MessageId : response.HttpStatusCode.ToString();
        }


        public async Task<string> AddBatchMessages(List<SendMessageBatchRequestEntry> messages, string url)
        {
            var sendMessageBatchRequest = new SendMessageBatchRequest(url, messages);
            var response = await _client.SendMessageBatchAsync(sendMessageBatchRequest);

            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                foreach (var success in response.Successful)
                {
                    Console.WriteLine($"Success Message ID: {success.MessageId}");
                }

                foreach (var failed in response.Failed)
                {
                    Console.WriteLine($"Failed Message ID: {failed.Id}");
                    Console.WriteLine($"Fault: {failed.SenderFault}");
                }

                return response.HttpStatusCode.ToString();
            }

            return response.HttpStatusCode.ToString();
        }

        public async Task<List<Message>?> ReceiveMessages(string url)
        {
            var receiveMessageRequest = new ReceiveMessageRequest
            {
                QueueUrl = url,
                MaxNumberOfMessages = 10,
                WaitTimeSeconds = 5
            };

            var response = await _client.ReceiveMessageAsync(receiveMessageRequest);

            return response.HttpStatusCode == HttpStatusCode.OK ? response.Messages : null;
        }

        public async Task<string?> DeleteMessages(string url, string handle)
        {
            var response = await _client.DeleteMessageAsync(url, handle);

            return response.HttpStatusCode == HttpStatusCode.OK ? response.HttpStatusCode.ToString() : null;
        }
    }
}
