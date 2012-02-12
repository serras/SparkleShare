EXTRA_LIBS = ServiceStack.Text.dll GithubSharp.Core.dll GithubSharp.Plugins.AuthProviders.UserPasswordAuthProvider.dll GithubSharp.Plugins.CacheProviders.ApplicationCacher.dll GithubSharp.Plugins.LogProviders.SimpleLogProvider.dll

all:
	mkdir -p $(top_srcdir)/bin
	cp $(EXTRA_LIBS) $(top_srcdir)/bin

install-data-hook:
	for ASM in $(EXTRA_LIBS); do \
		$(INSTALL) -m 0755 $$ASM $(DESTDIR)$(moduledir); \
	done;

uninstall-hook:
	for ASM in $(EXTRA_LIBS); do \
		rm -f $(DESTDIR)$(moduledir)/`basename $$ASM`; \
	done;
