using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace ia_explorer
{
	public class CollectionMetadata
	{
		public CollectionMetadata()
		{

		}

		public void LoadFromJson(dynamic jsonDoc)
		{
			jsonDoc = jsonDoc.metadata;

			downloadServer = jsonDoc.server;
			downloadRootPath = jsonDoc.dir;

			description = jsonDoc.description ?? "";
			identifier = jsonDoc.identifier ?? "";
			mediatype = jsonDoc.mediatype ?? "";
			title = jsonDoc.title ?? "";
			uploader = jsonDoc.uploader ?? "";
			curation = jsonDoc.curation ?? "";
			collection = jsonDoc.collection ?? "";
			backup_location = jsonDoc.backup_location ?? "";
			publicDate = jsonDoc.publicdate ?? null;
			addedDate = jsonDoc.addeddate ?? null;
			hidden = jsonDoc.hidden ?? true;
		}

		public void LoadFromJsonString(string jsonString)
		{
			LoadFromJson(JsonConvert.DeserializeObject(jsonString));
		}

		public string identifier { get; set; }
		public string description { get; set; }
		public string mediatype { get; set; }
		public string title { get; set; }
		public string uploader { get; set; }
		public string curation { get; set; }
		public string collection { get; set; }
		public string backup_location { get; set; }
		public DateTime? publicDate { get; set; }
		public DateTime? addedDate { get; set; }
		public bool hidden { get; set; }

		public string downloadServer { get; set; }
		public string downloadRootPath { get; set; }
	}

	public class FileMetadata
	{
		public FileMetadata() { }
		public static HttpClient http = new HttpClient();

		public void LoadFromJson(dynamic jsonDoc, IaPath itemArchivePath, string itemRootURL, string itemServerURL)
		{
			name = jsonDoc["name"] ?? "";
			title = jsonDoc["title"] ?? "";
			source = jsonDoc["source"] ?? "";
			mtime = DateTime.UnixEpoch.AddSeconds((long)(jsonDoc["mtime"] ?? 0));
			size_bytes = jsonDoc["size"] ?? 0;
			md5 = jsonDoc["md5"] ?? "";
			crc32 = jsonDoc["crc32"] ?? "";
			sha1 = jsonDoc["sha1"] ?? "";
			format = jsonDoc["format"] ?? "";
			rotation = jsonDoc["rotation"] ?? 0;
			operatingsystem = jsonDoc["operatingsystem"] ?? "";

			//filePath = $@"{itemArchivePath.outputFilePath}\{name}";
			filePath = $@"{itemArchivePath.outputFilePath}\{name}";
			fileUrl = $@"https://{itemServerURL}{ itemRootURL}/{name}";

			fileDownloaded = File.Exists(filePath);
		}

		public void LoadFromJson(string jsonString, IaPath itemArchivePath, string itemRootURL, string itemServerURL)
		{
			LoadFromJson(JsonConvert.DeserializeObject(jsonString), itemArchivePath, itemRootURL, itemServerURL);
		}

		public async Task<bool> DownloadFile()
		{
			byte[] fileData = await http.GetByteArrayAsync(fileUrl);
			await File.WriteAllBytesAsync(filePath, fileData);

			fileDownloaded = true;

			return true;
		}

		public bool IsFileDownloaded() { return File.Exists(filePath); }
		public bool fileDownloaded { get; set; }

		public string name { get; set; }
		public string title { get; set; }
		public string source { get; set; }
		public DateTime? mtime { get; set; }
		public long size_bytes { get; set; }
		public string md5 { get; set; }
		public string crc32 { get; set; }
		public string sha1 { get; set; }
		public string format { get; set; }
		public int rotation { get; set; }
		public string operatingsystem { get; set; }

		public string filePath { get; set; }
		public string fileUrl { get; set; }

	}

	public class ItemMetadata
	{
		public List<FileMetadata> fileItems = new List<FileMetadata>();

		public ItemMetadata()
		{

		}

		private void LoadFiles(dynamic jsonDoc, IaPath itemArchivePath, string itemRootURL, string itemServerURL)
		{
			for (int i = 0; i < files_count; ++i)
			{
				FileMetadata fileMetadata = new FileMetadata();
				fileMetadata.LoadFromJson(jsonDoc[i], itemArchivePath, itemRootURL, itemServerURL);
				fileItems.Add(fileMetadata);
			}
		}

		public bool AnyFilesDownloaded()
		{
			foreach (FileMetadata fileMetadata in fileItems)
				if (!fileMetadata.name.Contains(".json") && fileMetadata.IsFileDownloaded())
					return true;

			return false;
		}

		public void LoadFromJson(string itemNameString, dynamic jsonDoc, IaPath itemArchivePath)
		{
			fileItems.Clear();

			itemName = itemNameString;
			files_count = jsonDoc["files_count"] ?? 0;
			item_size = jsonDoc["item_size"] ?? 0;
			identifier = jsonDoc["metadata"]["identifier"] ?? "";
			title = jsonDoc["metadata"]["title"] ?? "";
			rights = jsonDoc["metadata"]["rights"] ?? "";
			notes = jsonDoc["metadata"]["notes"] ?? "";
			description = jsonDoc["metadata"]["description"].ToString() ?? "";
			publisher = jsonDoc["metadata"]["publisher"] ?? "";
			adder = jsonDoc["metadata"]["adder"] ?? "";
			uploader = jsonDoc["metadata"]["uploader"] ?? "";
			mediatype = jsonDoc["metadata"]["mediatype"] ?? "";
			//updater = ((jsonDoc["metadata"]["updater"] != null) ? jsonDoc["metadata"]["updater"].ToString() ?? "" : "";
			curation = jsonDoc["metadata"]["curation"] ?? "";
			backup_location = jsonDoc["metadata"]["backup_location"] ?? "";
			uniq = jsonDoc["uniq"] ?? "";
			date = jsonDoc["metadata"]["date"] ?? null;
			createdDate = DateTime.UnixEpoch.AddSeconds((long)jsonDoc["created"]);
			addeddate = jsonDoc["metadata"]["addeddate"];
			publicdate = jsonDoc["publicdate"];
			date = jsonDoc["date"];
			item_last_updated = DateTime.UnixEpoch.AddSeconds((long)jsonDoc["item_last_updated"]);

			downloadRootPath = jsonDoc.dir;
			downloadServer = jsonDoc.server;

			LoadFiles(jsonDoc["files"], itemArchivePath, downloadRootPath, downloadServer);
		}

		public void LoadFromJson(string itemNameString, string jsonString, IaPath itemArchivePath)
		{
			LoadFromJson(itemNameString, JsonConvert.DeserializeObject(jsonString), itemArchivePath);
		}

		public string itemName { get; set; }
		public int files_count { get; set; }
		public long item_size { get; set; }
		public string identifier { get; set; }
		public string title { get; set; }
		public string rights { get; set; }
		public string notes { get; set; }
		public string description { get; set; }
		public string publisher { get; set; }
		public string adder { get; set; }
		public string uploader { get; set; }
		public string mediatype { get; set; }
		public string updater { get; set; }
		public string curation { get; set; }
		public string backup_location { get; set; }
		public string uniq { get; set; }
		public DateTime? createdDate { get; set; }
		public DateTime? addeddate { get; set; }
		public DateTime? publicdate { get; set; }
		public string date { get; set; }
		public DateTime? item_last_updated { get; set; }
		public string downloadServer { get; set; }
		public string downloadRootPath { get; set; }
	}


	public class IaPath
	{
		private HttpClient httpClient;

		private string identifier = "";
		private string outputPath = "";
		private bool isCollection = false;
		private string collectionName = "";

		public IaPath(string _outputPath, string _identifier, HttpClient _httpClient, bool _isCollection, string _collectionName)
		{
			httpClient = _httpClient;
			outputPath = _outputPath;
			identifier = _identifier;
			isCollection = _isCollection;
			collectionName = _collectionName;
		}

		public string collectionMetadataUrl { get => @$"https://archive.org/metadata/{identifier}"; }
		public string collectionItemsUrl { 
			get => 
				@"https://archive.org/advancedsearch.php"
				+ @$"?q=collection:{identifier}"
				+ @"&fl[]=identifier"
				+ @"&rows=20000"
				+ @"&page=1"
				+ @"&output=json";
		}

		public string outputFile { get => Path.Combine(outputFilePath, identifier + @".json"); }
		public string outputFilePath { 
			get {
				if (isCollection)
					return Path.Combine(outputPath, identifier);
				else
					return Path.Combine(Path.Combine(outputPath, collectionName), identifier);
			}
		}
		public string collectionItemsFile { get => Path.Combine(outputFilePath, "collectionItems.json"); }

		public void EnsurePathExists()
		{
			if (!Directory.Exists(outputFilePath))
				Directory.CreateDirectory(outputFilePath);
		}

		public bool MetadataFileExists() { return File.Exists(outputFile); }
		public bool CollectionItemsExist() { return File.Exists(collectionItemsFile); }

		public async Task<string[]> CheckAndDownloadMetadata(bool metadata = true, bool itemlist = false)
		{
			List<string> retVal = new List<string>();

			string mdjson = "";
			string icjson = "";

			EnsurePathExists();

			if (metadata && !MetadataFileExists())
			{
				mdjson = await DownloadMetadataFile();
				WriteMetadataFile(mdjson);
				retVal.Add(mdjson);
			}
			else if (metadata)
				retVal.Add(await File.ReadAllTextAsync(outputFile));

			if (itemlist && !CollectionItemsExist())
			{
				icjson = await DownloadCollectionItemsFile();
				WriteCollectionItemsMetadataFile(icjson);
				retVal.Add(icjson);
			}
			else if (itemlist)
				retVal.Add(await File.ReadAllTextAsync(collectionItemsFile));

			return retVal.ToArray();
		}

		public async void WriteMetadataFile(string jsonString)
		{
			await File.WriteAllTextAsync(outputFile, jsonString);
		}
		public async void WriteCollectionItemsMetadataFile(string jsonString)
		{
			await File.WriteAllTextAsync(collectionItemsFile, jsonString);
		}
		 
		public async Task<string> DownloadMetadataFile() {
			return await httpClient.GetStringAsync(collectionMetadataUrl) ?? "";
		}
		public async Task<string> DownloadCollectionItemsFile() {
			return await httpClient.GetStringAsync(collectionItemsUrl);
		}
	}

	 
	public class ArchiveCollection
	{
		public HttpClient httpClient = new HttpClient();

		public List<CollectionMetadata> collectionsMetadata = new List<CollectionMetadata>();
		public List<ItemMetadata> itemsMetadata = new List<ItemMetadata>();

		public int itemCount = 0;
		public int itemLoadProgress = 0;

		public string collectionMetadataJsonString { get; set; } = "";
		public string collectionItemsJsonString { get; set; } = "";

		public ArchiveCollection() { }

		public CollectionMetadata collectionMetadata = new CollectionMetadata();

		private void ResetArchive()
		{
			collectionsMetadata.Clear();
			itemsMetadata.Clear();
			itemCount = 0;
			itemLoadProgress = 0;
			collectionMetadata = new CollectionMetadata();
		}
		public async void DownloadAndLoadCollection(string outputPath, string collectionName, Action callback=null)
		{
			ResetArchive();

			// first we need the main collection metadata, this is how we know what files to get
			IaPath mainPath = new IaPath(outputPath, collectionName, httpClient, true, collectionName);

			string[] jsonResults = 
				mainPath.CheckAndDownloadMetadata(true, true).Result;

			collectionMetadataJsonString = jsonResults[0];
			if (jsonResults.Length > 1)
				collectionItemsJsonString = jsonResults[1];

			collectionMetadata.LoadFromJsonString(collectionMetadataJsonString);
			collectionsMetadata.Add(collectionMetadata);

			dynamic searchJson = JsonConvert.DeserializeObject(collectionItemsJsonString);
			dynamic docsJson = searchJson.response.docs;

			List<string> itemIdentifiers = new List<string>();

			for (int i=0; i < (int) searchJson.response.numFound; ++i)
			{
				itemIdentifiers.Add((string)docsJson[i].identifier);
			}

			//string[] itemIdentifiers = Directory.GetDirectories();

			itemCount = itemIdentifiers.Count;
			itemLoadProgress = 0;

			//foreach (string itemIdentifier in from i in itemIdentifiers select Path.GetFileName(i))
			foreach (string itemIdentifier in itemIdentifiers)
			{
				itemLoadProgress++;

				if (itemIdentifier.Contains(".."))
					continue;

				IaPath subPath = new IaPath(outputPath, itemIdentifier, httpClient, false, collectionName);
				string[] subJson = await subPath.CheckAndDownloadMetadata();

				ItemMetadata itemMetadata = new ItemMetadata();
				itemMetadata.LoadFromJson(itemIdentifier, subJson[0], subPath);

				itemsMetadata.Add(itemMetadata);
			}

			itemsMetadata = (from it in itemsMetadata where !it.itemName.Contains("..") orderby it.itemName select it).ToList();

			if (callback != null)
				callback();
		}
	}
}
