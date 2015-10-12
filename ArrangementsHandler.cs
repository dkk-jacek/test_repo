﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArrangementsHandler : SynchronizeWrapper
{
	public override void AddToDownloadList (string s)
	{
		downloadPath = downloadParentPath + "/" + s;
		newDirectoryPath = catalogDigger.pathToArrangements + "/" + s;
		
		List<FileToDownload> fileList = new List<FileToDownload> ();
		fileList.Add (new FileToDownload (true, null, newDirectoryPath, null));
		fileList.Add (new FileToDownload (true, null, newDirectoryPath + "/photos", null));
		fileList.Add (new FileToDownload (false, downloadPath, newDirectoryPath, "mini.png"));
		fileList.Add (new FileToDownload (false, downloadPath, newDirectoryPath, "opis.txt"));
		fileList.Add (new FileToDownload (false, downloadPath, newDirectoryPath, "title.txt"));
		fileList.Add (new FileToDownload (false, downloadPath, newDirectoryPath, "products.txt"));

		downloadList.AddRange (fileList);	

		base.AddToDownloadList (s);
	}

	public override void CompareToLocal ()
	{
		for (int i=0; i<idsToDownload.Count; i++) {
			foreach (Arrangement a in catalogDigger._self.arrangements) {
				if (a.id.ToString () == idsToDownload [i]) {
					idsToDownload.RemoveAt (i);
				} 
			}
		}
	}


}