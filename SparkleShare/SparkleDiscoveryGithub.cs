using System;
using System.Collections.Generic;

using GithubSharp.Core;
using GithubSharp.Plugins.CacheProviders.ApplicationCacher;
using GithubSharp.Plugins.LogProviders.SimpleLogProvider;

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
		
		public SparkleDiscoveryGithub Create(string address, string user, string password) {
			return new SparkleDiscoveryGithub(user, password);	
		}
		
	}
	
	public class SparkleDiscoveryGithub : SparkleDiscovery {
		
		string user;
		string password;
		GithubSharp.Core.API.Repository repo_conn;
		GithubSharp.Core.API.User user_conn;
		
		public SparkleDiscoveryGithub(String user, String password) {
			this.user = user;
			this.password = password;
			// Set up connection
			try {
				// Create user info
				GithubSharp.Core.Models.GithubUser gh_user = 
					new GithubSharp.Core.Models.GithubUser();
				gh_user.Name = user;
				gh_user.APIToken = password;
				// Create cachers and loggers
				ApplicationCacher app_cacher = new ApplicationCacher();
				SimpleLogProvider log_prov = new SimpleLogProvider();
				// Set up connections and authenticate
				this.repo_conn = new GithubSharp.Core.API.Repository(app_cacher, log_prov);
				this.user_conn = new GithubSharp.Core.API.User(app_cacher, log_prov);
				this.repo_conn.Authenticate(gh_user);
				this.user_conn.Authenticate(gh_user);
			} catch (Exception e) {
				throw new SparkleDiscoveryException("Error authenticating", e);
			}
		}
		
		private SparkleDiscoveryRepo FromGithub(GithubSharp.Core.Models.Repository repo) {
			return new SparkleDiscoveryRepo("git://github.com", 
				                            String.Format("/{0}/{1}.git", repo.Owner, repo.Name),
				                            repo.Description);
		}
		
		public override IList<SparkleDiscoveryRepo> ListRepositories() {
			// Get repositories
			List<SparkleDiscoveryRepo> lst = new List<SparkleDiscoveryRepo>();
			foreach (GithubSharp.Core.Models.Repository repo in repo_conn.List (user)) {
				lst.Add(FromGithub(repo));
			}
			return lst;
		}
		
		public override SparkleDiscoveryRepo Create(string name, string info) {
			// Create repo
			try {
				GithubSharp.Core.Models.Repository repo = repo_conn.Create(name, info, null, false);
				return FromGithub(repo);
			} catch (Exception e) {
				throw new SparkleDiscoveryException("Error creating repository", e);
			}
		}
		
		public override bool UploadKey(string key) {
			try {
				GithubSharp.Core.Models.PublicKey pkey =
					new GithubSharp.Core.Models.PublicKey();
				pkey.Title = "SparkleShare";
				pkey.Key = key;
				user_conn.AddPublicKey(pkey);
				return true;
			} catch (Exception e) {
				return false;	
			}
		}
		
	}
}

