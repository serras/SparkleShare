using System;

namespace SparkleShare {
	
	public class SparkleDiscoveryGithubServer : SparkleDiscoveryServer<SparkleDiscoveryGithub> {
		
		public string Domain {
			get {
				return "http://github.com";	
			}
		}
		
		public string Name {
			get {
				return "GitHub";	
			}
		}
		
		public bool SupportsCreation {
			get {
				return true;	
			}
		}
		
		public bool SupportsKeyUploading {
			get {
				return true;	
			}
		}
		
	}
	
	public class SparkleDiscoveryGithub : SparkleDiscovery {
		
	}
}

