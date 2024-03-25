namespace BuyBike.Infrastructure.Data.Common
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Minio;
    using Minio.DataModel.Args;

    using PrintingHouse.Infrastructure.Data.Common.Contracts;

    /// <summary>
    /// Implementation of repository access methods
    /// for MinIO object store database
    /// </summary>   
    public class MinIoRepository : IMinIoRepository
    {
        public readonly IMinioClient minioClient;

        public MinIoRepository(IMinioClient _minioClient)
        {
            minioClient = _minioClient;
        }

        /// <summary>
        /// Adds object to the MinIO database
        /// </summary>
        /// <param name="BucketName">MinIO bucket name</param>
        /// <param name="fileName">The name of the object</param>
        /// <param name="content">Content to add (Byte array)</param>
        /// <returns></returns>
        public async Task AddFileAsync(Guid BucketName, string fileName, IFormFile content)
        {
            var bucketExistArgs = new BucketExistsArgs().WithBucket(BucketName.ToString());

            if (await minioClient.BucketExistsAsync(bucketExistArgs) == false)
            {
                var makeBucketArgs = new MakeBucketArgs()
                    .WithBucket(BucketName.ToString());

                await minioClient.MakeBucketAsync(makeBucketArgs);
            }

            var putObjectArgs = new PutObjectArgs()
                .WithBucket(BucketName.ToString())
                .WithObject(fileName)
                .WithObjectSize(content.Length)
                .WithContentType("application/octet-stream")
                .WithStreamData(content.OpenReadStream());

            await minioClient.PutObjectAsync(putObjectArgs);
        }

        /// <summary>
        /// Get object from database by bucket name and object name
        /// </summary>
        /// <param name="BucketName">Bucket name</param>
        /// <param name="fileName">Object name</param>
        /// <returns>Byte array</returns>
        public async Task<MemoryStream> GetFileAsync(Guid BucketName, string fileName)
        {
            var bucketExistArgs = new BucketExistsArgs().WithBucket(BucketName.ToString());
            if (await minioClient.BucketExistsAsync(bucketExistArgs) == false)
            {
                throw new ArgumentException("There is no such file in store or id is incorrect");
            }

            using var result = new MemoryStream();

            var args = new GetObjectArgs()
                .WithBucket(BucketName.ToString())
                .WithObject(fileName)
                .WithCallbackStream(async stream =>
                {
                    await stream.CopyToAsync(result);
                });

            await minioClient.GetObjectAsync(args);

            return result;
        }
    }
}
