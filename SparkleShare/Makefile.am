SUBDIRS =	\
	Nautilus \
	Mac

ASSEMBLY = SparkleShare
TARGET = exe

LINK = $(REF_SPARKLESHARE) $(NOTIFY_SHARP_LIBS) $(WEBKIT_SHARP_LIBS) -r:$(DIR_BIN)/GithubSharp.Core.dll -r:$(DIR_BIN)/GithubSharp.Plugins.AuthProviders.UserPasswordAuthProvider.dll -r:$(DIR_BIN)/GithubSharp.Plugins.CacheProviders.ApplicationCacher.dll -r:$(DIR_BIN)/GithubSharp.Plugins.LogProviders.SimpleLogProvider.dll

if HAVE_APP_INDICATOR
BUILD_DEFINES="-define:HAVE_APP_INDICATOR"
endif

SOURCES =  \
	Program.cs \
	SparkleAbout.cs \
	SparkleAboutController.cs \
	SparkleBubbles.cs \
	SparkleBubblesController.cs \
	SparkleController.cs \
	SparkleControllerBase.cs \
	SparkleDiscovery.cs \
	SparkleDiscoveryGithub.cs \
	SparkleEntry.cs \
	SparkleEventLog.cs \
	SparkleEventLogController.cs \
	SparkleExtensions.cs \
	SparkleInvite.cs \
	SparkleOptions.cs \
	SparklePlugin.cs \
	SparkleSetup.cs \
	SparkleSetupController.cs \
	SparkleSetupWindow.cs \
	SparkleSpinner.cs \
	SparkleStatusIcon.cs \
	SparkleStatusIconController.cs \
	SparkleUI.cs \
	SparkleUIHelpers.cs

include $(top_srcdir)/build/build.mk

bin_SCRIPTS = sparkleshare

Applicationsdir = $(datadir)/applications
dist_Applications_DATA = sparkleshare.desktop
