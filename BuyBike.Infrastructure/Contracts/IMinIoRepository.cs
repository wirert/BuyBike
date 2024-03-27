namespace BuyBike.Infrastructure.Contracts
{
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Abstraction of repository access methods
    /// </summary>
    public interface IMinIoRepository
    {
        /// <summary>
        /// Adds object to the MinIO database
        /// </summary>
        /// <param name="BucketName">MinIO bucket name</param>
        /// <param name="fileName">The name of the object</param>
        /// <param name="content">Content to add (Byte array)</param>
        Task AddAsync(string BucketName, string fileName, IFormFile content);

        /// <summary>
        /// Get image by name
        /// </summary>
        /// <param name="BucketName">Bucket name</param>
        /// <param name="fileName">Object name</param>
        /// <returns>Byte array or null</returns>
        Task<MemoryStream?> FindAsync(string BucketName, string fileName);
    }
}
