namespace BuyBike.Infrastructure.Data.Common
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Minio;
    using Minio.DataModel.Args;

    using BuyBike.Infrastructure.Contracts;
    using Minio.Exceptions;

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
        public async Task AddAsync(string BucketName, string fileName, IFormFile content)
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

           var response = await minioClient.PutObjectAsync(putObjectArgs);

            if (response != null)
            {
                Console.WriteLine(response);
            }
        }

        /// <summary>
        /// Get object from database by bucket name and object name
        /// </summary>
        /// <param name="BucketName">Bucket name</param>
        /// <param name="fileName">Object name</param>
        /// <returns>Byte array</returns>
        public async Task<MemoryStream?> FindAsync(string BucketName, string fileName)
        {
            var bucketExistArgs = new BucketExistsArgs().WithBucket(BucketName);
            if (await minioClient.BucketExistsAsync(bucketExistArgs) == false)
            {
                throw new ArgumentException("There is no such file in store or name is incorrect");
            }


            //var result = await minioClient.PresignedGetObjectAsync(new PresignedGetObjectArgs().WithBucket(BucketName).WithObject(fileName)).ConfigureAwait(false)

            using var file = new MemoryStream();

            var args = new GetObjectArgs()
                .WithBucket(BucketName)
                .WithObject(fileName)
                .WithCallbackStream(async stream =>
                {   
                    
                    await stream.CopyToAsync(file);
                });

            try
            {
                await minioClient.GetObjectAsync(args);

                return file;
            }
            catch (ObjectNotFoundException)
            {
                return null;
            }
            
        }
    }
}
