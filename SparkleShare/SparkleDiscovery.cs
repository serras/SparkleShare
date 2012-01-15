namespace SparkleShare {
	
	public interface SparkleDiscoveryServer <T> where T : SparkleDiscovery {
		
		/// <summary>
		/// Gets the domain.
		/// </summary>
		/// <value>
		/// Should return null is the domain is to be provided by the user.
		/// </value>
		string Domain {
			get;	
		}
		
		string Name {
			get;	
		}
		
		bool SupportsCreation();
		bool SupportsKeyUploading();
		
		T Create(string address, string user, string password);
		
	}
	
	public abstract class SparkleDiscovery {
		
		SparkleDiscoveryServer server;
		string address;
		string user;
		string password;
		
		public abstract List<SparkleDiscoveryRepo> ListRepositories();
		
		public SparkleDiscoveryRepo Create(string name) {
			throw new NotImplementedException();	
		}
		
		public bool UploadKey(string path) {
			throw new NotImplementedException();
		}
		
	}
	
	public class SparkleDiscoveryRepo {
		
		string server, path, info;
		
		public SparkleDiscoveryRepo(string server, string path, string info) {
			this.server = server;
			this.path = path;
			this.info = info;
		}
		
		public string Server {
			get {
				return server;	
			}
		}
		
		public string Path {
			get {
				return path;	
			}
		}
		
		public string Information {
			get {
				return info;	
			}
		}
		
	}
	
}
