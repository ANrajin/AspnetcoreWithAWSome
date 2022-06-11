using System.Net;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace SQSExample
{
    public class SQSOperation
    {
        private readonly AmazonSQSClient _client;
        public SQSOperation()
        {
            /**
             * Please install AWSSDK and setup credentials
             * 
             * AmazonSQSClient will automatically read credentials 
             * from AWS SDK
             */
            _client = new AmazonSQSClient();
        }

        public async Task<string> CreateQueueAsync(string queueName)
        {
            CreateQueueRequest request = new CreateQueueRequest(queueName);
            CreateQueueResponse response = await _client.CreateQueueAsync(request);

            if (response.HttpStatusCode == HttpStatusCode.OK)
                return response.QueueUrl;
            else
                return response.HttpStatusCode.ToString();
        }

        public async Task<string> DeleteQueueAsync(string url)
        {
            DeleteQueueRequest request = new DeleteQueueRequest();

            request.QueueUrl = url;

            DeleteQueueResponse response = await _client.DeleteQueueAsync(request);

            if (response.HttpStatusCode == HttpStatusCode.OK)
                return response.HttpStatusCode.ToString();
            else
                return response.HttpStatusCode.ToString();
        }


        public async Task<string> AddNewMessage(QueueMessage queueMessage)
        {
            SendMessageRequest sendMessageRequest = new SendMessageRequest(queueMessage.url, queueMessage.body);
            SendMessageResponse response = await _client.SendMessageAsync(sendMessageRequest);

            if (response.HttpStatusCode == HttpStatusCode.OK)
                return response.MessageId;
            else
                return response.HttpStatusCode.ToString();
        }


        public async Task<string> AddBatchMessages(List<SendMessageBatchRequestEntry> messages, string url)
        {
            SendMessageBatchRequest sendMessageBatchRequest = new SendMessageBatchRequest(url, messages);
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
            else
                return response.HttpStatusCode.ToString();
        }

        public async Task<List<Message>> ReceiveMessages(string url)
        {
            ReceiveMessageRequest receiveMessageRequest = new ReceiveMessageRequest();
            receiveMessageRequest.QueueUrl = url;
            receiveMessageRequest.MaxNumberOfMessages = 10;
            receiveMessageRequest.WaitTimeSeconds = 5;

            var response = await _client.ReceiveMessageAsync(receiveMessageRequest);

            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                return response.Messages;
            }
            else
                return null;
        }

        public async Task<string> DeleteMessages(string url, string handle)
        {
            var response = await _client.DeleteMessageAsync(url, handle);

            if (response.HttpStatusCode == HttpStatusCode.OK)
                return response.HttpStatusCode.ToString();
            else
                return null;
        }
    }
}
