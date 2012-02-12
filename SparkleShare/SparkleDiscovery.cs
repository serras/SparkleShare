using System;
using System.Collections.Generic;

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
		
		bool SupportsCreation {
			get;	
		}
			
		bool SupportsKeyUploading {
			get;	
		}
		
		T Create(string address, string user, string password);
		
	}
	
	public class SparkleDiscoveryException : Exception {
		
		public SparkleDiscoveryException() : base() { }
		public SparkleDiscoveryException(string msg) : base(msg) { }
		public SparkleDiscoveryException(string msg, Exception inner) : base(msg, inner) { }
		
	}
	
	public static class SparkleDiscoveryServers {
		
		public static SparkleDiscoveryServer<SparkleDiscovery>[] AvailableServers {
			get {
				return new SparkleDiscoveryServer<SparkleDiscovery>[0];
			}
		}
		
	}
	
	public abstract class SparkleDiscovery {
		
		SparkleDiscoveryServer <SparkleDiscovery> server;
		string address;
		string user;
		string password;
		
		public abstract IList<SparkleDiscoveryRepo> ListRepositories();
		
		public virtual SparkleDiscoveryRepo Create(string name, string info) {
			throw new NotImplementedException();	
		}
		
		public virtual bool UploadKey(string key) {
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
