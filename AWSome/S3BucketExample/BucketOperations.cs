using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

namespace S3BucketExample
{
    public class BucketOperations
    {
        private readonly AmazonS3Client _client;

        public BucketOperations()
        {
            /**
             * Please install AWSSDK and setup credentials
             * 
             * AmazonSQSClient will automatically read credentials 
             * from AWS SDK
             */
            _client = new AmazonS3Client();
        }

        public string GetFilePath(string fileName)
        {
            DirectoryInfo info = new DirectoryInfo(Directory.GetCurrentDirectory());
            var parentPath = info.Parent.Parent.Parent;
            using FileStream fs = File.Create(Path.Combine(parentPath.FullName, fileName));

            return fs.Name;
        }

        public async Task UploadAsync(string fileName, string filePath)
        {
            Console.WriteLine("Uploading a file...");

            var request = new PutObjectRequest()
            {
                BucketName = "rajinbucket",
                Key = fileName,
                FilePath = filePath,
                ContentType = "text/plain"
            };

            request.Metadata.Add("x-amz-meta-title", "sample");
            PutObjectResponse response = await _client.PutObjectAsync(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
                Console.WriteLine("File successfully uploaded");
            else
                Console.WriteLine(response.HttpStatusCode.ToString());
        }

        public async Task DownloadAsync(string fileName)
        {
            try
            {
                using (TransferUtility fileTransferUtility = new TransferUtility(_client))
                {
                    TransferUtilityDownloadRequest request = new TransferUtilityDownloadRequest()
                    {
                        BucketName = "rajinbucket",
                        FilePath = "F:\\samplefile.txt",
                        Key = fileName,
                    };

                    await fileTransferUtility.DownloadAsync(request);
                }
                Console.WriteLine("ok");

            }
            catch (AmazonS3Exception s3Exception)
            {
                Console.WriteLine(s3Exception.Message, s3Exception.InnerException);
            }
        }

        public async Task DeleteAsync(string fileName)
        {
            Console.WriteLine("Removing an object");

            try
            {
                DeleteObjectRequest request = new DeleteObjectRequest()
                {
                    BucketName = "rajinbucket",
                    Key = fileName
                };

                var response = await _client.DeleteObjectAsync(request);

                Console.WriteLine("File successfully removed");
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when deleting an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when deleting an object", e.Message);
            }
        }
    }
}
