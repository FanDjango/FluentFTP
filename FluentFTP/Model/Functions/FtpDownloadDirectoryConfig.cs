using System.Collections.Generic;

using FluentFTP.Rules;

namespace FluentFTP.Model.Functions {

	public class FtpDownloadDirectoryConfig {

		/// <summary>
		/// Downloads the specified directory onto the local file system.
		/// In Mirror mode, we will download missing files, and delete any extra files from disk that are not present on the server. This is very useful when creating an exact local backup of an FTP directory.
		/// In Update mode, we will only download missing files and preserve any extra files on disk. This is useful when you want to simply download missing files from an FTP directory.
		/// Only downloads the files and folders matching all the rules provided, if any.
		/// All exceptions during downloading are caught, and the exception is stored in the related FtpResult object.
		/// </summary>
		/// <remarks>
		/// If verification is enabled (All options other than <see cref="FtpVerify.None"/>) the file will be verified against the source using the verification methods specified by <see cref="FtpVerifyMethod"/> in the client config.

		/// <summary>
		/// Mirror or Update mode, as explained above
		/// </summary>
		public FtpFolderSyncMode Mode { get; set; } = FtpFolderSyncMode.Update;

		/// <summary>
		/// If the file exists on disk, should we skip it, resume the download or restart the download?
		/// </summary>
		public FtpLocalExists ExistsMode { get; set; } = FtpLocalExists.Skip;

		/// <summary>
		/// Sets verification type and what to do if verification fails (See Remarks)
		/// </summary>
		public FtpVerify VerifyOptions { get; set; } = FtpVerify.None;

		/// <summary>
		/// Optionally force the FtpListOptions of the internal GetListing() used
		/// FtpListOption.None is taken to mean "No special options"
		/// FtpListOption.Recursive and FtpListOption.Size are always on by default
		/// 
		/// </summary>
		public FtpListOption ListOptions { get; set; } = FtpListOption.None;

		/// <summary>
		/// Only files and folders that pass all these rules are downloaded, and the files that don't pass are skipped. In the Mirror mode, the files that fail the rules are also deleted from the local folder.
		/// </summary>
		public List<FtpRule> Rules { get; set; } = null;
	}
}