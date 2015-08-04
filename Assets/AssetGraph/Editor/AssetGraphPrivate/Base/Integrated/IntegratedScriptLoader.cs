using UnityEngine;

using System;
using System.Collections.Generic;

namespace AssetGraph {
	public class IntegratedScriptLoader : INodeBase {
		private readonly string loadFilePath;
			
		public IntegratedScriptLoader (string loadFilePath) {
			this.loadFilePath = loadFilePath;
		}

		public void Setup (string nodeId, string labelToNext, Dictionary<string, List<InternalAssetData>> inputSource, Action<string, string, Dictionary<string, List<InternalAssetData>>> Output) {
			var outputSource = new List<InternalAssetData>();
			try {
				var targetFilePaths = FileController.FilePathsInFolderWithoutMeta(loadFilePath);
				
				foreach (var targetFilePath in targetFilePaths) {
					outputSource.Add(
						InternalAssetData.InternalAssetDataByLoader(
							targetFilePath, 
							loadFilePath
						)
					);
				}

				var outputDict = new Dictionary<string, List<InternalAssetData>> {
					{"0", outputSource}
				};

				Output(nodeId, labelToNext, outputDict);
			} catch (Exception e) {
				Debug.LogError("Loader error:" + e);
			}
		}
		
		public void Run (string nodeId, string labelToNext, Dictionary<string, List<InternalAssetData>> inputSource, Action<string, string, Dictionary<string, List<InternalAssetData>>> Output) {
			var outputSource = new List<InternalAssetData>();
			try {
				var targetFilePaths = FileController.FilePathsInFolderWithoutMeta(loadFilePath);
				
				foreach (var targetFilePath in targetFilePaths) {
					outputSource.Add(
						InternalAssetData.InternalAssetDataByLoader(
							targetFilePath, 
							loadFilePath
						)
					);
				}

				var outputDict = new Dictionary<string, List<InternalAssetData>> {
					{"0", outputSource}
				};

				Output(nodeId, labelToNext, outputDict);
			} catch (Exception e) {
				Debug.LogError("Loader error:" + e);
			}
		}
	}
}