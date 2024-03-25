namespace PrintingHouse.Infrastructure.Data.Common.Contracts
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
        Task AddFileAsync(Guid BucketName, string fileName, IFormFile content);

        /// <summary>
        /// Get object form database by bucket name and object name
        /// </summary>
        /// <param name="BucketName">Bucket name</param>
        /// <param name="fileName">Object name</param>
        /// <returns>Byte array</returns>
        Task<MemoryStream> GetFileAsync(Guid BucketName, string fileName);
    }
}
