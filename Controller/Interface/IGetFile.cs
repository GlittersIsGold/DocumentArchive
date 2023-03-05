namespace DocumentArchive.Controller.Interface
{
	internal interface IGetFile
	{
		string GetFileName();
		string GetFileOwnerUsername();
		string GetFileContent();
		string GetFileVersion();
		string GetFileNumberOfWords();
		string GetFileSize();
		string GetFileFormat();
		string GetFileAttributes();
		string GetFileMetadata();
	}
}
