using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using Technossus.Reincarnation.Core.Interfaces;
using Technossus.Reincarnation.Data;
using File = Technossus.Reincarnation.Models.File;

namespace Technossus.Reincarnation.Core.Managers
{
    public class UploadManager : BaseManager, IUploadManager
    {
        private readonly ReincarnationContext _context;
        public UploadManager(ReincarnationContext context) : base(context) => _context = context;
        public bool UploadFileToBlob(File file)
        {
            #region Save File in Blob
            var container = GetContainerByContainerName("deepak");
            CloudBlockBlob blob = container.GetBlockBlobReference(file.FileName);
            using (var ms = new MemoryStream(file.DocBytes, false))
            {
                blob.UploadFromStream(ms);
            }
            #endregion
            file.DocBytes = null;
            Context.Files.Add(file);
            Context.SaveChanges();
            return true;
        }
    }
}
