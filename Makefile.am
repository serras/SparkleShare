basedirs = build SparkleLib SparkleLib/Git data po

SUBDIRS = $(basedirs) $(GUISUBDIRS)
DIST_SUBDIRS = $(basedirs) SparkleShare

EXTRA_DIST = \
	gnome-doc-utils.make \
	LICENSE

DISTCLEANFILES = \
	intltool-extract        \
	intltool-merge          \
	intltool-update		\
	gnome-doc-utils.make

clean-local:
	rm -rf $(top_builddir)/bin
